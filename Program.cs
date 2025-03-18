using System;
using System.Text.Json;
using System.Collections.Generic;  // Notwendig für List<T>
using System.IO;  // Notwendig für File.ReadAllText und File.WriteAllText

class IndexcardApp{
    static string filePath = "card_bank.json";
    // create new IndexCard
    static void Main(string[]args){
     var newCard = new IndexCard{
        Id=1,
        Front="HTML",
        Back="Hyper Text Module Language",
        Category="web-dev"
     };
        // read Indexcards from json file
    List<IndexCard> cards = LoadIndexCards();
        // check highest id for the next submitted card
        newCard.Id = cards.Count>0 ? cards.Max(card=>card.Id)+1 : 1;
        // add new card to the list
    cards.Add(newCard);
        // safe cards in the json file
    SaveIndexCards(cards);
        // show all cards
    DisplayCards(cards);
    }
    static List<IndexCard> LoadIndexCards(){
        // check if files exists
        if(!File.Exists(filePath)){
            return new List<IndexCard>();
        }
        //transform json data into a List
        var jsonData = File.ReadAllText(filePath);
        var indexCards = JsonSerializer.Deserialize<List<IndexCard>>(jsonData);
        return indexCards ?? [];
    }
    static void SaveIndexCards(List<IndexCard>cards){
        // transform list of cards into JSON format
        var jsonData = JsonSerializer.Serialize(cards, new JsonSerializerOptions{WriteIndented=true});
        //safe JsonData into the Json file
        File.WriteAllText(filePath,jsonData);
    }
    static void DisplayCards(List<IndexCard>cards){
        // display all cards
        foreach(var card in cards){
            Console.WriteLine($"ID:{card.Id},Front:{card.Front},Back:{card.Back},Category:{card.Category}");
        }
    }

}
 