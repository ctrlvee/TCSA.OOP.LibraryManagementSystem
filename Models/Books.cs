namespace TCSA.OOP.LibraryManagementSystem;

internal class Book : LibraryItem {

    internal string Author {get; set;}
    internal string Category {get; set;}
    internal int Pages {get; set;}

    internal Book(int id, string name, string author, string cateogyr, string location, int pages) : base(id, name, location) {
        Author = author;
        Category = category;
        Pages = pages;
    }

    public override void DisplayDetails() {
        
    }
}