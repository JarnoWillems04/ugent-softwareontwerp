using Labo1;

Console.WriteLine("Geef uw naam aub");
string? name = Console.ReadLine();

if (name != null)
{
    Person student = new Student(name, 123);

    Console.WriteLine(student.WelcomeMessage());
}
