using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem;

internal  class BooksController {

    internal  void ViewBooks() {
        AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

        foreach (var book in MockDatabase.Books) {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
        }
        
        AnsiConsole.MarkupLine("Press Any Key to Continue");
        Console.ReadKey();
    }


    internal  void AddBook() {

        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add: ");
        var pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book:");

        if (MockDatabase.Books.Exists(b => b.Name.Equals(title, StringComparison.OrdinalIgnoreCase))) {
            AnsiConsole.MarkupLine("[red]This book already exists[/]");
        } else {
            var newBook = new Book(title, pages);
            MockDatabase.Books.Add(newBook);
            AnsiConsole.MarkupLine("[green]Book added successfully![/]");
        }
        // var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");

        //     if (MockDatabase.Books.Contains(title)) {
        //         AnsiConsole.MarkupLine("[red]This book already exists.[/]");
        //     } else {
        //         MockDatabase.Books.Add(title);
        //         AnsiConsole.MarkupLine("[green]Book added successfully![/]");
        //     }

            AnsiConsole.MarkupLine("Press any key to continue");
            Console.ReadKey();
    }

    internal  void DeleteBook() {
         if (MockDatabase.Books.Count == 0) {
                AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
                Console.ReadKey();
                return;
            }

            var bookToDelete = AnsiConsole.Prompt(new SelectionPrompt<Book>().Title("Select a [red]book[/] to delete:").UseConverter(b => $"{b.Name}").AddChoices(MockDatabase.Books));

            if (MockDatabase.Books.Remove(bookToDelete)) {
                AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
            } else {
                AnsiConsole.MarkupLine("[red]Book not found.[/]");
            }   

            AnsiConsole.MarkupLine("Press any key to continue.");
            Console.ReadKey();
    }

}
