using System;
using System.Collections.Generic;

namespace IndexCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pfad zur JSON-Datei (im Projektverzeichnis)
            string filePath = Path.Combine(AppContext.BaseDirectory, "../../../card_bank.json");
            Console.WriteLine($"JSON-Datei wird gesucht/gespeichert unter: {filePath}");

            // CardBankManagement-Instanz erstellen
            var cardManager = new CardBankManagement(filePath);

            // Karten laden
            var cards = cardManager.LoadCards();

            // IDs aktualisieren
            cardManager.ReindexCards(cards);

            // Karten speichern
            cardManager.SaveCards(cards);

            // Karten anzeigen
            foreach (var card in cards)
            {
                Console.WriteLine($"ID: {card.Id}, Vorderseite: {card.Front}, Rückseite: {card.Back}, Kategorie: {card.Category}");
            }
        }
    }
}