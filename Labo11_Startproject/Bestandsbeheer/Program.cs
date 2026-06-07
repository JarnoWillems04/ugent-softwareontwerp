using Bestanden;

//Read files
Console.Out.Write("Enter file name or STOP to exit: ");
string? filename = Console.ReadLine();
while (filename != null && filename.ToUpper() != "STOP")
{
    RealFile file = new RealFile(filename);
    Console.WriteLine("=== 1 === " + filename + " ======");
    Console.WriteLine(file.Content);

    Console.WriteLine("=== 2 === " + filename + " ======");
    Console.WriteLine(file.Content);  //twee keer de content ophalen

    Console.WriteLine("============================");
    Console.Out.Write("\nEnter file name or STOP to exit: ");
    filename = Console.ReadLine();
}