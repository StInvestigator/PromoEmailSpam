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
            //db.updateString(Constants.UpdateCountry,2, "China");
            //db.GetString(Constants.GetAllCountries);
            //db.deleteString(Constants.DeleteCountry,2);
            //db.GetString(Constants.GetAllCountries);

            db.GetString(Constants.GetCitiesInCountry, "Ukraine");
            db.GetString(Constants.GetSectionsByUser, "Motvei Viktorenko");
            db.GetPromo(Constants.GetPromoBySection, "PC and accessories");

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