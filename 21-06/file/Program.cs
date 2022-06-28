var curPath = Directory.GetCurrentDirectory();

var file = Path.Combine(curPath, "Program.cs");

Console.WriteLine($"Exists: {File.Exists(file)}");
Console.WriteLine($"Full path: {Path.GetFullPath(file)}");
Console.WriteLine($"Extension: {Path.GetExtension(file)}");
Console.WriteLine($"Filename w/ extension: {Path.GetFileNameWithoutExtension(file)}");
Console.WriteLine($"Directory name: {Path.GetDirectoryName(file)}");
Console.WriteLine($"Random filename: {Path.GetRandomFileName()}");

using var sw = File.AppendText(file);
await sw.WriteLineAsync("// this comment added dynamically");

sw.Dispose();

using var sr = File.OpenText(file);
string line = "";
while((line = sr.ReadLine()) != null)
{
    Console.WriteLine(line); 
}
