using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace net_ef_videogame
{
    internal class VideogameManager
    {
        public static void InsertVideogame()
        {
            using VideogameContext db = new VideogameContext();
            
            string name;
            string overview;
            DateTime release_date;
            long software_house_id;
            string input;


            do
            {
                Console.Write("Inserisci il nome: ");
                name = Console.ReadLine();

            } while (string.IsNullOrEmpty(name));

            do
            {
                Console.Write("Inserisci la descrizione: ");
                overview = Console.ReadLine();

            } while (string.IsNullOrEmpty(overview));

            do
            {
                Console.Write("Inserisci la data di uscita (formato yyyy-MM-dd): ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out release_date));

            var SoftwareHouse = db.SoftwareHouse.ToList();

            foreach (var aviable in SoftwareHouse)
            {
                Console.WriteLine($"{aviable.Id} - {aviable.Name}");
            }


            do
            {
                Console.Write("Inserisci l'ID della software house: ");
                input = Console.ReadLine();
            } while (!long.TryParse(input, out software_house_id));

            // Create a new VideoGame object and set its properties
            var videogame = new VideoGame
            {
                Name = name,
                Overview = overview,
                ReleaseDate = release_date,
                SoftwareHouseId = software_house_id
            };

            // Add the new VideoGame object to the database
            db.VideoGames.Add(videogame);
            db.SaveChanges();

        }

        public static void GetVideogameById()
        {
            using (var context = new VideogameContext())
            {
                try
                {
                    int id;

                    do
                    {
                        Console.Write("Inserisci l'ID del videogioco: ");
                    } while (!int.TryParse(Console.ReadLine(), out id));

                    var videogame = context.Videogames.Find(id);

                    if (videogame != null)
                    {
                        Console.WriteLine($"Nome: {videogame.Name}");
                        Console.WriteLine($"Panoramica: {videogame.Overview}");
                        Console.WriteLine($"Data di rilascio: {videogame.Release_date}");
                        Console.WriteLine($"ID software house: {videogame.Software_house_id}");
                    }
                    else
                    {
                        Console.WriteLine("Videogame non trovato.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void GetVideogamesName()
        {
            using (var context = new VideogameContext())
            {
                try
                {
                    string input;

                    do
                    {
                        Console.Write("Inserisci il nome (o parte del nome) del videogioco: ");
                        input = Console.ReadLine();
                    } while (string.IsNullOrEmpty(input));

                    var videogames = context.Videogames
                        .Where(v => v.Name.Contains(input))
                        .ToList();

                    foreach (var videogame in videogames)
                    {
                        Console.WriteLine(videogame.Name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void DeleteGame()
        {
            using (var context = new VideogameContext())
            {
                try
                {
                    long id;

                    do
                    {
                        Console.Write("Inserisci l'ID del videogioco da eliminare: ");
                    } while (!long.TryParse(Console.ReadLine(), out id));

                    var videogameToDelete = context.Videogames.Find(id);

                    if (videogameToDelete != null)
                    {
                        context.Videogames.Remove(videogameToDelete);
                        context.SaveChanges();
                        Console.WriteLine("Dato Eliminato!");
                    }
                    else
                    {
                        Console.WriteLine("Dato non eliminato!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void CreateSoftwareHouse()
        {
            using (VideogameContext db = new VideogameContext())
            {
                string name;
                string taxId;
                string city;
                string country;
                string input;

                do
                {
                    Console.Write("Inserisci il nome della software house: ");
                    name = Console.ReadLine();
                } while (string.IsNullOrEmpty(name));

                do
                {
                    Console.Write("Inserisci il tax ID della software house: ");
                    taxId = Console.ReadLine();
                } while (string.IsNullOrEmpty(taxId));

                do
                {
                    Console.Write("Inserisci la città della software house: ");
                    city = Console.ReadLine();
                } while (string.IsNullOrEmpty(city));

                do
                {
                    Console.Write("Inserisci il paese della software house: ");
                    country = Console.ReadLine();
                } while (string.IsNullOrEmpty(country));

                SoftwareHouse softwareHouse = new SoftwareHouse
                {
                    Name = name,
                    Tax_id = taxId,
                    City = city,
                    Country = country
                };

                db.SoftwareHouse.Add(softwareHouse);
                db.SaveChanges();

                Console.WriteLine("Software house creata con successo!");
            }
        }


    }

    internal class VideoGame
    {
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long SoftwareHouseId { get; set; }
    }
}

