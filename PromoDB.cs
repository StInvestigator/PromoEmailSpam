using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PromoEmailSpam
{
    public class PromoDB
    {
        public string connectionString {  get; set; }
        public PromoDB(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void GetClients(string SqlQuery, string param = null)
        {
            using(var connection = new SqlConnection(connectionString))
            {
                List<Client>? clients;
                if (param == null)
                {
                    clients = connection.Query<Client>(SqlQuery).ToList();
                }
                else
                {
                    clients = connection.Query<Client>(SqlQuery,new {parameter = param }).ToList();
                }
                foreach (var client in clients)
                {
                    Console.WriteLine(client);
                }
            }
        }
        public void GetString(string SqlQuery, string param = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                System.Data.IDataReader reader;
                if (param == null)
                {
                    reader = connection.ExecuteReader(SqlQuery);
                }
                else
                {
                    reader = connection.ExecuteReader(SqlQuery,new {parameter = param});
                }
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0)+"\n");
                }
            }
        }
        public void GetPromo(string SqlQuery, string param = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                List<Promo>? promoes;
                if (param == null)
                {
                    promoes = connection.Query<Promo>(SqlQuery).ToList();
                }
                else
                {
                    promoes = connection.Query<Promo>(SqlQuery, new { parameter = param }).ToList();
                }
                foreach (var promo in promoes)
                {
                    Console.WriteLine(promo);
                }
            }
        }
        
        public void insertClient(string SqlQuery,string name, string sex, string email, int cityId)
        {
            object[] parameters = { new { Name = name,Sex = sex, Email = email, CityId = cityId }};
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
        public void insertPromo(string SqlQuery, string name, int countryId, int sectionId, DateTime startDate, DateTime endDate)
        {
            object[] parameters = { new { Name = name, CountryId = countryId, SectionId = sectionId, StartDate = startDate, EndDate = endDate} };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
        public void insertString(string SqlQuery, string name)
        {
            object[] parameters = { new { Name = name} };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
        public void insertCity(string SqlQuery, string name, int countryId)
        {
            object[] parameters = { new { Name = name, CountryId = countryId } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
        public void updateClient(string SqlQuery, int id, string name, string sex, string email, int cityId)
        {
            object[] parameters = { new { Name = name, Sex = sex, Email = email, CityId = cityId, Id = id } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
        public void updatePromo(string SqlQuery, int id, string name, int countryId, int sectionId, DateTime startDate, DateTime endDate)
        {
            object[] parameters = { new { Name = name, CountryId = countryId, SectionId = sectionId, StartDate = startDate, EndDate = endDate, Id = id } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
        public void updateString(string SqlQuery, int id, string name)
        {
            object[] parameters = { new { Name = name, Id = id } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
        public void updateCity(string SqlQuery, int id, string name, int countryId)
        {
            object[] parameters = { new { Name = name, CountryId = countryId, Id = id } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
        public void deleteClient(string SqlQuery, int id)
        {
            object[] parameters = { new { Id = id } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
        public void deletePromo(string SqlQuery, int id)
        {
            object[] parameters = { new { Id = id } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
        public void deleteString(string SqlQuery, int id)
        {
            object[] parameters = { new { Id = id } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
        public void deleteCity(string SqlQuery,int id)
        {
            object[] parameters = { new { Id = id } };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(SqlQuery, parameters);
            }
        }
    }
}
