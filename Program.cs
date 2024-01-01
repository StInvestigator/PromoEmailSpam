using Microsoft.Data.SqlClient;
using PromoEmailSpam;
using System.Diagnostics.Metrics;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            PromoDB db = new PromoDB(@"Data Source=DESKTOP-OF66R01\SQLEXPRESS;Initial Catalog=PromotionalGoods;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            Console.WriteLine("DataBase was connected!\n");

            // first part (20.12)

            //db.GetClients(Constants.GetAllClients);
            //db.GetString(Constants.GetAllEmails);
            //db.GetString(Constants.GetAllSections);
            //db.GetPromo(Constants.GetAllPromo);
            //db.GetString(Constants.GetAllCities);
            //db.GetString(Constants.GetAllCountries);
            //db.GetClients(Constants.GetClientsFromCountry, "Ukraine");
            //db.GetClients(Constants.GetClientsFromCity, "Rivno");
            //db.GetPromo(Constants.GetPromoByCountry, "Ukraine");

            //db.insertString(Constants.InsertCountry, "Japan");
            //db.GetString(Constants.GetAllCountries);
            //db.updateString(Constants.UpdateCountry, 4, "China");
            //db.GetString(Constants.GetAllCountries);
            //db.deleteString(Constants.DeleteCountry, 4);
            //db.GetString(Constants.GetAllCountries);

            //db.GetString(Constants.GetCitiesInCountry, "Ukraine");
            //db.GetString(Constants.GetSectionsByUser, "Motvei Viktorenko");
            //db.GetPromo(Constants.GetPromoBySection, "PC and accessories");

            // second part (21.12)

            //db.GetIntStringFromSP("ClientsCountByCity");
            //db.GetIntStringFromSP("ClientsCountByCountry");
            //db.GetIntStringFromSP("CitiesCountByCountry");
            //db.GetIntFromSP("AvgCitiesInAllCountries");

            //db.GetStringFromSP("SectionsOfClientsByCountry", "Ukraine");
            //db.GetStringFromSP("PromoBySectionAndDate", "PC and accessories", new DateTime(2023, 9, 10), new DateTime(2023, 12, 1));
            //db.GetPromoFromSP("PromoByClient", "Motvei Viktorenko");

            //db.GetStringFromSP("top3CountryByClients");
            //db.GetStringFromSP("top1CountryByClients");
            //db.GetStringFromSP("top3CityByClients");
            //db.GetStringFromSP("top1CityByClients");

            //db.GetStringFromSP("top3PromoSection");
            //db.GetStringFromSP("top1PromoSection");
            //db.GetStringFromSP("topMinus3PromoSection");
            //db.GetStringFromSP("topMinus1PromoSection");
            //db.GetStringFromSP("top3PopularSection");
            //db.GetStringFromSP("top1PopularSection");
            //db.GetStringFromSP("top3UnPopularSection");
            //db.GetStringFromSP("top3UnPopularSection");

            //db.GetPromoFromSP("Promo3daysBeforeEnd");
            //db.GetPromoFromSP("PromoThatEnded");

            //db.GetIntStringFromSP("AvgAgeBySection");
            //db.GetIntStringFromSP("AvgAgeByCity");
            //db.GetIntStringFromSP("AvgAgeByCountry");

            //db.GetStringStringFromSP("Top3SectionBySex");
            //db.GetIntStringFromSP("ClientsBySex");
            db.GetStringStringIntFromSP("ClientsBySexAndCountry");
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}