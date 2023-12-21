using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEmailSpam
{
    public static class Constants
    {
        public const string GetAllClients = @"select cl.Id,cl.Name,cl.Sex,cl.Email,co.Name as Country,c.Name as City from Client cl join Cities c on cl.CityId = c.Id join Countries co on co.Id = c.CountryId";
        public const string GetAllEmails = @"select Email from Client";
        public const string GetAllSections = @"select Name from Sections";
        public const string GetAllPromo = @"select p.Id,p.Name,c.Name as Country,s.Name as Section,p.StartDate,p.EndDate from Promotions p join Countries c on p.CountryId = c.Id join Sections s on s.Id = p.SectionId";
        public const string GetAllCities = @"select Name from Cities";
        public const string GetAllCountries = @"select Name from Countries";
        public const string GetClientsFromCountry = @"select cl.Id,cl.Name,cl.Sex,cl.Email,co.Name as Country,c.Name as City from Client cl join Cities c on cl.CityId = c.Id join Countries co on co.Id = c.CountryId where co.Name = @parameter";
        public const string GetClientsFromCity = @"select cl.Id,cl.Name,cl.Sex,cl.Email,co.Name as Country,c.Name as City from Client cl join Cities c on cl.CityId = c.Id join Countries co on co.Id = c.CountryId where c.Name = @parameter";
        public const string GetPromoByCountry = @"select p.Id,p.Name,c.Name as Country,s.Name as Section,p.StartDate,p.EndDate from Promotions p join Countries c on p.CountryId = c.Id join Sections s on s.Id = p.SectionId where c.Name = @parameter";
        
        public const string InsertClient = @"insert into Client (Name,Sex,Email,CityId) values(@Name,@Sex,@Email,@CityId)";
        public const string InsertCountry = @"insert into Countries (Name) values(@Name)";
        public const string InsertCity = @"insert into Cities (Name,CountryId) values(@Name,@CountryId)";
        public const string InsertSection = @"insert into Sections (Name) values(@Name)";
        public const string InsertPromo = @"insert into Promotions (Name,CountryId,SectionId,StartDate,EndDate) values(@Name,@CountryId,@SectionId,@StartDate,@EndDate)";

        public const string UpdateClient = @"update Client set Name = @Name,Sex = @Sex,Email = @Email,CityId = @CityId where Id = @Id";
        public const string UpdateCountry = @"update Countries set Name = @Name where Id = @Id";
        public const string UpdateCity = @"update Cities set Name = @Name,CountryId = @CountryId where Id = @Id";
        public const string UpdateSection = @"update Sections set Name = @Name where Id = @Id";
        public const string UpdatePromo = @"update Promotions set Name = @Name,CountryId = @CountryId,SectionId = @SectionId,StartDate = @StartDate,EndDate = @EndDate where Id = @Id";

        public const string DeleteClient = @"delete from Client where Id = @Id";
        public const string DeleteCountry = @"delete from Countries where Id = @Id";
        public const string DeleteCity = @"delete from Cities where Id = @Id";
        public const string DeleteSection = @"delete from Sections where Id = @Id";
        public const string DeletePromo = @"delete from Promotions where Id = @Id";

        public const string GetCitiesInCountry = @"select c.Name from Cities c join Countries co on c.CountryId = co.Id where co.Name = @parameter";
        public const string GetSectionsByUser = @"select s.Name from Sections s join ClientInterest ci on ci.SectionId=s.Id join Client c on ci.ClientId = c.Id where c.Name = @parameter";
        public const string GetPromoBySection = @"select p.Id,p.Name,c.Name as Country,s.Name as Section,p.StartDate,p.EndDate from Promotions p join Countries c on p.CountryId = c.Id join Sections s on s.Id = p.SectionId where s.Name = @parameter";

    }
}
