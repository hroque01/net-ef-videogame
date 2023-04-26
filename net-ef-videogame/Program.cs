namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                int opzione;

                Console.WriteLine("Scegli una opzione: ");
                Console.WriteLine("1. Inserisci nuovo gioco");
                Console.WriteLine("2. Cerca un gioco tramite Id");
                Console.WriteLine("3. Cerca un gioco tramite nome");
                Console.WriteLine("4. Cancella un gioco");
                Console.WriteLine("5. Crea SotfwareHouse");
                Console.WriteLine("6. Chiudi il programma");
                Console.WriteLine("\n ------------------ \n");

                Console.Write("Inserisci opzione: ");
                if (!int.TryParse(Console.ReadLine(), out opzione))
                {
                    Console.WriteLine("Opzione non valida.");
                    continue;
                }

                switch (opzione)
                {
                    case 1:
                        VideogameManager.InsertVideogame();
                        break;
                    case 2:
                        VideogameManager.GetVideogameById();
                        break;
                    case 3:
                        VideogameManager.GetVideogamesName();
                        break;
                    case 4:
                        VideogameManager.DeleteGame();
                        break;
                    case 5:
                        VideogameManager.CreateSoftwareHouse();
                        break;
                    case 6:
                        Console.WriteLine("Arrivederci!");
                    return;
                }
            }


           
         

        }
    }
}