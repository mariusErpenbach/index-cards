// CardService.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace IndexCards
{
    public class CardService
    {
        private string filePath;

        public CardService(string path)
        {
            filePath = path;
        }

        // Lädt die Karten aus der JSON-Datei
        public List<IndexCard> LoadIndexCards()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Die Datei existiert nicht. Bitte erstelle eine JSON-Datei mit den Karten.");
                    return new List<IndexCard>();
                }

                // Lade die JSON-Datei
                var jsonData = File.ReadAllText(filePath);
                Console.WriteLine("JSON-Datei erfolgreich geladen.");

                // Deserialisiere die JSON-Daten
                var indexCards = JsonSerializer.Deserialize<List<IndexCard>>(jsonData);
                if (indexCards == null)
                {
                    Console.WriteLine("Fehler: Die JSON-Datei konnte nicht deserialisiert werden.");
                    return new List<IndexCard>();
                }

                Console.WriteLine($"Anzahl der geladenen Karten: {indexCards.Count}");
                return indexCards;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Laden der Karteikarten: {ex.Message}");
                return new List<IndexCard>();
            }
        }

        // Speichert die Karten in der JSON-Datei
        public void SaveCards(List<IndexCard> cards)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(cards, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonData);
                Console.WriteLine($"Karten wurden erfolgreich in {filePath} gespeichert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern der Karteikarten: {ex.Message}");
            }
        }

        // Fügt eine neue Karte hinzu
        public void AddNewCard(List<IndexCard> cards)
        {
            Console.Write("Gib die Vorderseite der Karte ein: ");
            string front = Console.ReadLine() ?? string.Empty;

            Console.Write("Gib die Rückseite der Karte ein: ");
            string back = Console.ReadLine() ?? string.Empty;

            Console.Write("Gib die Kategorie der Karte ein: ");
            string category = Console.ReadLine() ?? string.Empty;

            int newId = cards.Count > 0 ? cards.Max(card => card.Id) + 1 : 1;

            var newCard = new IndexCard
            {
                Id = newId,
                Front = front,
                Back = back,
                Category = category
            };

            cards.Add(newCard);
            SaveCards(cards); // Speichern nach dem Hinzufügen
            Console.WriteLine("Karte erfolgreich hinzugefügt!");
        }

        // Bearbeitet eine vorhandene Karte
        public void EditCard(List<IndexCard> cards)
        {
            Console.Write("Gib die ID der Karte ein, die du bearbeiten möchtest: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var cardToEdit = cards.FirstOrDefault(card => card.Id == id);
                if (cardToEdit != null)
                {
                    Console.Write("Neue Vorderseite (aktuell: " + cardToEdit.Front + "): ");
                    string front = Console.ReadLine() ?? cardToEdit.Front;

                    Console.Write("Neue Rückseite (aktuell: " + cardToEdit.Back + "): ");
                    string back = Console.ReadLine() ?? cardToEdit.Back;

                    Console.Write("Neue Kategorie (aktuell: " + cardToEdit.Category + "): ");
                    string category = Console.ReadLine() ?? cardToEdit.Category;

                    cardToEdit.Front = front;
                    cardToEdit.Back = back;
                    cardToEdit.Category = category;

                    SaveCards(cards); // Speichern nach dem Bearbeiten
                    Console.WriteLine("Karte erfolgreich bearbeitet!");
                }
                else
                {
                    Console.WriteLine("Karte mit der angegebenen ID wurde nicht gefunden.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe.");
            }
        }

        // Löscht eine vorhandene Karte
        public void DeleteCard(List<IndexCard> cards)
        {
            Console.Write("Gib die ID der Karte ein, die du löschen möchtest: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var cardToDelete = cards.FirstOrDefault(card => card.Id == id);
                if (cardToDelete != null)
                {
                    cards.Remove(cardToDelete);
                    SaveCards(cards); // Speichern nach dem Löschen
                    Console.WriteLine("Karte erfolgreich gelöscht!");
                }
                else
                {
                    Console.WriteLine("Karte mit der angegebenen ID wurde nicht gefunden.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe.");
            }
        }

        // Zeigt alle Karten an
        public void DisplayCards(List<IndexCard> cards)
        {
            if (cards.Count == 0)
            {
                Console.WriteLine("Keine Karten vorhanden.");
                return;
            }

            foreach (var card in cards)
            {
                Console.WriteLine($"ID: {card.Id}, Vorderseite: {card.Front}, Rückseite: {card.Back}, Kategorie: {card.Category}");
            }
        }
    }
}