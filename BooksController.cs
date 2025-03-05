using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem;

internal  class BooksController {

    internal  void ViewBooks() {

        var table = new Table();
        table.Border(TableBorder.Rounded);

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Author[/]");
        table.AddColumn("[yellow]Category[/]");
        table.AddColumn("[yellow]Location[/]");
        table.AddColumn("[yellow]Pages[/]");

        // Filtering only items of the book type
        var books = MockDatabase.LibraryItems.OfType<Book>();

        foreach (var book in books)
        {
            table.AddRow(
                book.Id.ToString(),
                $"[cyan]{book.Name}[/]",
                $"[cyan]{book.Author}[/]",
                $"[green]{book.Category}[/]",
                $"[blue]{book.Location}[/]",
                book.Pages.ToString()
                );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }


    internal  void AddBook() {

        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        var author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book:");
        var category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book:");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book:");

        if (MockDatabase.LibraryItems.OfType<Book>().Any(b => b.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine("[red]This book already exists.[/]");
        }
        else
        {
            var newBook = new Book(MockDatabase.LibraryItems.Count + 1, title, author, category, location, pages);
            MockDatabase.LibraryItems.Add(newBook);
            AnsiConsole.MarkupLine("[green]Book added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    internal  void DeleteBook() {

        // var title = AnsiConsole.Ask<string>("Enter the [red]title[/] of the book to remove.");

        // if (MockDatabase.LibraryItems.OfType<Book>().Any(b => b.Name.Equals(title, StringComparison.OrdinalIgnoreCase))) {
        //     MockDatabase.LibraryItems
        // }
        // AnsiConsole.MarkupLine("Press Any Key to Continue");
        // Console.ReadKey();
        // //  if (MockDatabase.Books.Count == 0) {
        //         AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
        //         Console.ReadKey();
        //         return;
        //     }

        //     var bookToDelete = AnsiConsole.Prompt(new SelectionPrompt<Book>().Title("Select a [red]book[/] to delete:").UseConverter(b => $"{b.Name}").AddChoices(MockDatabase.Books));

        //     if (MockDatabase.Books.Remove(bookToDelete)) {
        //         AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
        //     } else {
        //         AnsiConsole.MarkupLine("[red]Book not found.[/]");
        //     }   

        //     AnsiConsole.MarkupLine("Press any key to continue.");
        //     Console.ReadKey();
    }

}
