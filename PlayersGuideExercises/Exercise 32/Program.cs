using Exercise_32;

Sword basicSword = new Sword(Material.Iron, Stone.None, 20, 8);
Sword rubySword = basicSword with { stone = Stone.Ruby }; 
Sword bronzeSword = basicSword with{material = Material.Bronze};

Console.WriteLine(basicSword);
Console.WriteLine(rubySword);
Console.WriteLine(bronzeSword);