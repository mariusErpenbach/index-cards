using System;
public class Indexcard{
    public int Id {get;set;}
    public string Front {get;set;}
    public string Back {get;set;}
    public DateTime CreatedAt {get; set;}
    public DateTime LastModified {get;set;}
    public string Category {get;set;}

    // Constructor function to create a new instance of Indexcard with question and answer
    public Indexcard(int id, string keyword, string answer, string category = "Uncategorized"){
        Id = id;
        Front = keyword;
        Back = answer;
        CreatedAt = DateTime.Now;
        LastModified = DateTime.Now;
        Category = category;
    }
    public void DisplayCard(){
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Keyword: {Front}");
        Console.WriteLine($"Antwort: {Back}");
        Console.WriteLine($"Kategorie: {Category}");
        Console.WriteLine($"Erstellt am: {CreatedAt}");
        Console.WriteLine($"Letzte Änderung: {LastModified}");
    }
    public void UpdateMetaData(string newCategory){
        Category = newCategory;
        LastModified = DateTime.Now;
    }
    
}