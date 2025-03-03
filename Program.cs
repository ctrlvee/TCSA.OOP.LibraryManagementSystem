using Spectre.Console;

var menuChoices = new string[3] {"View Books", "Add Book", "Delete Book"};



var books = new List<string>(){
    "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in The Rye"
};

while(true) {
    Console.Clear();

    var choice = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOption>()
            .Title("What do you want to do next?")
            .AddChoices(Enum.GetValues<MenuOption>()));

    switch (choice) {
        case MenuOption.ViewBooks:
            AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

            foreach (var book in books) {
                AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
            }
            
            AnsiConsole.MarkupLine("Press Any Key to Continue");
            Console.ReadKey();
            break;
        case MenuOption.AddBook:
            var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");

            if (books.Contains(title)) {
                AnsiConsole.MarkupLine("[red]This book already exists.[/]");
            } else {
                books.Add(title);
                AnsiConsole.MarkupLine("[green]Book added successfully![/]");
            }

            AnsiConsole.MarkupLine("Press any key to continue");
            Console.ReadKey();
            break;
        case MenuOption.DeleteBook:

            if (books.Count == 0) {
                AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
                Console.ReadKey();
                return;
            }

            var bookToDelete = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Select a [red]book[/] to delete:").AddChoices(books));

            if (books.Remove(bookToDelete)) {
                AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
            } else {
                AnsiConsole.MarkupLine("[red]Book not found.[/]");
            }   

            AnsiConsole.MarkupLine("Press any key to continue.");
            Console.ReadKey();
            break;
    }
}

enum MenuOption {
    ViewBooks,
    AddBook,
    DeleteBook
}