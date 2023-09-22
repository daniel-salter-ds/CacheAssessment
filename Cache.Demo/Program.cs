using CacheAssessment;

Console.WriteLine("----- Welcome to the Cache demo -----");
Console.WriteLine();


Console.WriteLine("Initialising new integer Cache with string type keys, int type values, and default capacity");
Console.WriteLine();
Cache<string, int> integerCache = new Cache<string, int>();

Console.WriteLine($"Capacity = {integerCache.Capacity}");
Console.WriteLine();

Console.WriteLine("Caching:");
Console.WriteLine("(One, 1)");
Console.WriteLine("(Two, 2)");
Console.WriteLine();
integerCache["One"] = 1;
integerCache["Two"] = 2;

Console.WriteLine("Integer Cache contents:");
Console.WriteLine(integerCache);
Console.WriteLine("\n");



Console.WriteLine("Initialising new animal Cache with int type keys, string type values, and capacity = 5");
Console.WriteLine();
Cache<int, string> animalCache = new Cache<int, string>(5);

Console.WriteLine($"Capacity = {animalCache.Capacity}");
Console.WriteLine();

Console.WriteLine("Caching:");
Console.WriteLine("(0, Dog)");
Console.WriteLine("(1, Cat)");
Console.WriteLine("(2, Frog)");
Console.WriteLine("(3, Horse)");
Console.WriteLine("(4, Cow)");
Console.WriteLine();
animalCache[0] = "Dog";
animalCache[1] = "Cat";
animalCache[2] = "Frog";
animalCache[3] = "Horse";
animalCache[4] = "Cow";

Console.WriteLine("Animal Cache contents:");
Console.WriteLine(animalCache);
Console.WriteLine();

Console.WriteLine("Get 3, then rewrite Cache contents to check it is bumped to top of Cache:");
Console.WriteLine($"Cache[2] = {animalCache[2]}");
Console.WriteLine(); 
Console.WriteLine(animalCache);
Console.WriteLine();

Console.WriteLine("Set 0 = 'Lemur', then rewrite Cache contents to check it is bumped to top of Cache:");
animalCache[0] = "Lemur";
Console.WriteLine();
Console.WriteLine(animalCache);
Console.WriteLine();

Console.WriteLine("Add new pair (10, 'Fish'), then rewrite Cache contents to check least recently touched pair is removed from Cache:");
animalCache[10] = "Fish";
Console.WriteLine();
Console.WriteLine(animalCache);
Console.WriteLine();
