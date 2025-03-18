// Program.cs
using System;
using System.IO;

namespace IndexCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pfad zur JSON-Datei (im Projektverzeichnis)
            string filePath = Path.Combine(AppContext.BaseDirectory, "../../../card_bank.json");
            Console.WriteLine($"JSON-Datei wird gesucht/gespeichert unter: {filePath}");

            var cardService = new CardService(filePath);
            List<IndexCard> cards = cardService.LoadIndexCards();

            while (true)
            {
                Console.WriteLine("1. Karten anzeigen");
                Console.WriteLine("2. Neue Karte hinzufügen");
                Console.WriteLine("3. Karte bearbeiten");
                Console.WriteLine("4. Karte löschen");
                Console.WriteLine("5. Karten speichern");
                Console.WriteLine("6. Programm beenden");
                Console.Write("Wähle eine Option: ");
                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        cardService.DisplayCards(cards);
                        break;
                    case "2":
                        cardService.AddNewCard(cards);
                        break;
                    case "3":
                        cardService.EditCard(cards);
                        break;
                    case "4":
                        cardService.DeleteCard(cards);
                        break;
                    case "5":
                        cardService.SaveCards(cards);
                        Console.WriteLine("Karten erfolgreich gespeichert!");
                        break;
                    case "6":
                        cardService.SaveCards(cards); // Speichern vor dem Beenden
                        Console.WriteLine("Programm wird beendet...");
                        return;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte versuche es erneut.");
                        break;
                }
            }
        }
    }
}