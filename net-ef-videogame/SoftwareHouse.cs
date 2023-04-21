using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("Software_house")]
    internal class SoftwareHouse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Tax_id { get; set; }
        public string City { get; set; }
        public string Country { get; set; } 
        public string? Created_at { get; set; }  
        public string? Update_at { get; set; }

        public List<Videogame> Videogames { get; set; }

        public SoftwareHouse(long id, string name, string tax_id, string city, string country, string created_at, string update_at)
        {
            Id = id;
            Name = name;
            Tax_id = tax_id;
            City = city;
            Country = country;
            Created_at = created_at;
            Update_at = update_at;
        }
    }
}
