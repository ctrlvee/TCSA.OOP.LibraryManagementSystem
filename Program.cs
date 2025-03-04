using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem;



// UserInterface userInterface = new();
// userInterface.MainMenu();

var book1 = new Book("Hamlet", 200);

Animal myDog = new Dog("Buddy", 3);
Animal myCat = new Cat("Whiskers", 2);

myDog.MakeSound();
myCat.MakeSound();

internal abstract class Animal {
    public string Name {get; set;}
    public int Age {get; set;}

    protected Animal(string name, int age) {
        Name = name;
        Age = age;
    }

    public abstract void MakeSound();
}

internal class Dog : Animal {
    public Dog(string name, int age) 
        : base (name, age)
        {}
    

    public override void MakeSound() {
        Console.WriteLine($"{Name} says: Woof!");
    }
}

internal class Cat : Animal {
    public Cat (string name, int age) 
        : base(name, age)
        {}

    public override void MakeSound() {
        Console.WriteLine($"{Name} says: Meow!");
    }
}