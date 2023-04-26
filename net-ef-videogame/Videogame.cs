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
        public Videogame(string name, string overview, DateTime release_date, int software_house_id)
        {
            Name = name;
            Overview = overview;
            Release_date = release_date;
            Software_house_id = software_house_id;
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }

        [Column("overview")]
        public string Overview { get; set; }

        [Column("release_date")]
        public DateTime Release_date { get; set; }

        [ForeignKey("SoftwareHouse")]
        [Column("software_house_id")]
        public int Software_house_id { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }


        public void Print()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Overview: {Overview}");
            Console.WriteLine($"Release Date: {Release_date:dd/MM/yyyy}");
            Console.WriteLine($"Software House: {Software_house_id}");
        }

    }
}
