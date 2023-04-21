using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("Videogames")]
    internal class Videogame
    {

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }

        [Column("overview")]
        public string Overview { get; set; }

        [Column("release_date")]
        public DateTime Release_date { get; set; }

        [ForeignKey("software_house")]
        [Column("software_house_id")]
        public long Software_house_id { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }

        public Videogame(long id, string name, string overview, DateTime release_date, long software_house_id, SoftwareHouse softwareHouse)
        {
            Id = id;
            Name = name;
            Overview = overview;
            Release_date = release_date;
            Software_house_id = software_house_id;
            SoftwareHouse = softwareHouse;
        }
    }
}
