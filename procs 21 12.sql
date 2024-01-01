create proc ClientsCountByCity
as
begin
select count(*) as Count,ci.Name from Client c join Cities ci on c.CityId = ci.Id group by ci.Name
end

create proc ClientsCountByCountry
as
begin
select count(*) as Count,co.Name from Client c join Cities ci on c.CityId = ci.Id join Countries co on ci.CountryId=co.Id group by co.Name
end

create proc CitiesCountByCountry
as
begin
select count(*) as Count,co.Name from Cities ci join Countries co on ci.CountryId=co.Id group by co.Name
end

create proc AvgCitiesInAllCountries
as
begin
select avg(Count) as Average from (select count(*) as Count,co.Name from Cities ci join Countries co on ci.CountryId=co.Id group by co.Name) as tmp
end

create proc SectionsOfClientsByCountry
@parameter nvarchar(max)
as
begin
select s.Name 
from Client c join ClientInterest ci on ci.ClientId = c.Id join Sections s on ci.SectionId=s.Id join Cities cit on cit.Id=c.CityId join Countries co on co.Id = cit.CountryId 
where co.Name = @parameter
end

create proc PromoBySectionAndDate
@parameter nvarchar(max),
@date1 date,
@date2 date
as
begin
	select p.Name
	from Promotions p join Sections s on p.SectionId=s.Id 
	where s.Name=@parameter and (p.StartDate between @date1 and @date2 or p.EndDate between @date1 and @date2 or @date1 between p.StartDate and p.EndDate)
end

create proc PromoByClient
@parameter nvarchar(max)
as
begin
	select p.Id,p.Name,c.Name as Country,s.Name as Section,p.StartDate,p.EndDate from Promotions p join Countries c on p.CountryId = c.Id join Sections s on s.Id = p.SectionId
	where CountryId = (select ci.CountryId from Client c join Cities ci on ci.Id=c.CityId where c.Name = @parameter)
end

create proc top3CountryByClients
as
begin
 select top(3)c.Name 
 from Countries c join (select co.Id, count(*) as count from Countries co join Cities ci on co.Id = ci.CountryId join Client c on c.CityId = ci.Id group by co.Id) as tmp
 on c.Id = tmp.Id
 order by tmp.count desc
end

create proc top1CountryByClients
as
begin
 select top(1)c.Name 
 from Countries c join (select co.Id, count(*) as count from Countries co join Cities ci on co.Id = ci.CountryId join Client c on c.CityId = ci.Id group by co.Id) as tmp
 on c.Id = tmp.Id
 order by tmp.count desc
end

create proc top3CityByClients
as
begin
 select top(3)c.Name 
 from Cities c join (select ci.Id, count(*) as count from Cities ci join Client c on c.CityId = ci.Id group by ci.Id) as tmp
 on c.Id = tmp.Id
 order by tmp.count desc
end

create proc top1CityByClients
as
begin
 select top(1)c.Name 
 from Cities c join (select ci.Id, count(*) as count from Cities ci join Client c on c.CityId = ci.Id group by ci.Id) as tmp
 on c.Id = tmp.Id
 order by tmp.count desc
end




create proc top3PromoSection
as
begin
	select top(3)s.Name
	from Sections s join (select s.Id, count(*) count from Promotions p join Sections s on p.SectionId=s.Id group by s.Id) tmp
	on s.Id = tmp.Id
	order by tmp.count desc
end

create proc top1PromoSection
as
begin
	select top(1)s.Name
	from Sections s join (select s.Id, count(*) count from Promotions p join Sections s on p.SectionId=s.Id group by s.Id) tmp
	on s.Id = tmp.Id
	order by tmp.count desc
end

create proc topMinus3PromoSection
as
begin
	select top(3)s.Name
	from Sections s join (select s.Id, count(*) count from Promotions p join Sections s on p.SectionId=s.Id group by s.Id) tmp
	on s.Id = tmp.Id
	order by tmp.count
end

create proc topMinus1PromoSection
as
begin
	select top(1)s.Name
	from Sections s join (select s.Id, count(*) count from Promotions p join Sections s on p.SectionId=s.Id group by s.Id) tmp
	on s.Id = tmp.Id
	order by tmp.count
end

create proc top3PopularSection
as
begin
	select top(3)s.Name
	from Sections s join (select s.Id, count(*) count from ClientInterest p join Sections s on p.SectionId=s.Id group by s.Id) tmp
	on s.Id = tmp.Id
	order by tmp.count desc
end

create proc top1PopularSection
as
begin
	select top(1)s.Name
	from Sections s join (select s.Id, count(*) count from ClientInterest p join Sections s on p.SectionId=s.Id group by s.Id) tmp
	on s.Id = tmp.Id
	order by tmp.count desc
end

create proc top3UnPopularSection
as
begin
	select top(3)s.Name
	from Sections s join (select s.Id, count(*) count from ClientInterest p join Sections s on p.SectionId=s.Id group by s.Id) tmp
	on s.Id = tmp.Id
	order by tmp.count
end

create proc top1UnPopularSection
as
begin
	select top(1)s.Name
	from Sections s join (select s.Id, count(*) count from ClientInterest p join Sections s on p.SectionId=s.Id group by s.Id) tmp
	on s.Id = tmp.Id
	order by tmp.count
end

create proc Promo3daysBeforeEnd
as
begin
	select p.Id,p.Name,c.Name Country,s.Name Section,p.StartDate,p.EndDate
	from Promotions p join Sections s on p.SectionId = s.Id join Countries c on c.Id = p.CountryId
	where DATEDIFF(day,getdate(),p.EndDate) = 3
end

create proc PromoThatEnded
as
begin
	select *
	from PromotionsArchive
end

create trigger PromoToArchive
on Promotions 
after insert
as
begin
	insert into PromotionsArchive
	select p.Name,c.Name Country,s.Name Section,p.StartDate,p.EndDate
	from Promotions p join Sections s on p.SectionId = s.Id join Countries c on c.Id = p.CountryId
	where DATEDIFF(day,p.EndDate,GETDATE()) > 0
	delete from Promotions where DATEDIFF(day,EndDate,GETDATE()) > 0
end

alter table Client add Age int not null default(18)

create proc AvgAgeBySection
as
begin
	select avg(c.Age) AvgAge, s.Name
	from Client c join ClientInterest ci on c.Id = ci.ClientId join Sections s on ci.SectionId = s.Id
	group by s.Name
end

create proc AvgAgeByCity
as
begin
	select avg(c.Age) AvgAge, ci.Name
	from Client c join Cities ci on ci.Id = c.CityId
	group by ci.Name
end

create proc AvgAgeByCountry
as
begin
	select avg(c.Age) AvgAge, co.Name
	from Client c join Cities ci on ci.Id = c.CityId join Countries co on co.Id = ci.CountryId
	group by co.Name
end

create proc BestSectionBySex
as
begin
	select tmp.Name, tmp.gender
	from					(select top(1)Name,cnt,'Male' as gender from 
								(select s.Name,count(*) cnt from Sections s join ClientInterest ci on s.Id=ci.SectionId join Client c on c.Id = ci.ClientId where c.Sex='Male' group by s.Name) 
							as tmp order by cnt desc
							union
						  select top(1)Name,cnt,'Female' as gender from 
								(select s.Name,count(*) cnt from Sections s join ClientInterest ci on s.Id=ci.SectionId join Client c on c.Id = ci.ClientId where c.Sex='Female' group by s.Name) 
							as tmp order by cnt desc) tmp
end

create proc Top3SectionBySex
as
begin
	select tmp.Name, tmp.gender
	from					(select top(3)Name,cnt,'Male' as gender from 
								(select s.Name,count(*) cnt from Sections s join ClientInterest ci on s.Id=ci.SectionId join Client c on c.Id = ci.ClientId where c.Sex='Male' group by s.Name) 
							as tmp order by cnt desc
							union
						  select top(3)Name,cnt,'Female' as gender from 
								(select s.Name,count(*) cnt from Sections s join ClientInterest ci on s.Id=ci.SectionId join Client c on c.Id = ci.ClientId where c.Sex='Female' group by s.Name) 
							as tmp order by cnt desc) tmp
end

create proc ClientsBySex
as
begin
	select count(*) as count, Sex
	from Client
	group by Sex
end

create proc ClientsBySexAndCountry
as
begin
	select co.Name,c.Sex,count(*) count
	from Client c join Cities ci on c.CityId=ci.Id join Countries co on co.Id = ci.CountryId 
	group by co.Name,c.Sex
end