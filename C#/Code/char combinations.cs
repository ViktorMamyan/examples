var alphabet = "abcdefghijklmnopqrstuvwxyz";
var q = alphabet.Select(x => x.ToString());
int size = 2;
for (int i = 0; i < size - 1; i++)
	q = q.SelectMany(x => alphabet, (x, y) => x + y);

foreach (var item in q)
	Console.WriteLine(item);

Console.WriteLine("OK");
Console.ReadKey();