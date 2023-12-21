using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEmailSpam
{
    public class Promo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Section { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Promo() { }
        public Promo(int id, string name, string country, string section, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            Country = country;
            Section = section;
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nSection: {Section}, Country: {Country}\nStart date: {startDate}, End date: {endDate}";
        }
    }
}
