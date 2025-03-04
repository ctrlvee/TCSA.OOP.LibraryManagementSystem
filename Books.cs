namespace TCSA.OOP.LibraryManagementSystem;

internal class Book {
    public string Name {get; set;} = "Unknown";
    public int Pages {get; set;} = 0;

    internal Book(string name, int pages) {
        Name = name;
        Pages = pages;
        Console.WriteLine($"Name: {Name}, Num Pages: {Pages}");
    }
}