using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEmailSpam
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Client() { }
        public Client(int id, string name, string sex, string email, string country, string city)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Email = email;
            Country = country;
            City = city;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}, Sex: {Sex}\nEmail: {Email}\nCountry: {Country}, City: {City}\n";
        }
    }
}
