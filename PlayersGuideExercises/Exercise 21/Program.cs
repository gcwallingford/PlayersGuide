using Exercise_21;
using Type = System.Type;

(SoupType type, Ingredient ingredient, Flavor flavor) soupExample = new();

Console.WriteLine("What kind of soup would you like?");
Console.WriteLine("Soup");
Console.WriteLine("Stew");
Console.WriteLine("Gumbo");
string exampleType = Console.ReadLine();
Console.WriteLine("What main ingredient would you like in the soup?");
Console.WriteLine("Mushrooms");
Console.WriteLine("Chicken");
Console.WriteLine("Carrots");
Console.WriteLine("Potatoes");
string exampleIngredient = Console.ReadLine();
Console.WriteLine("What primary flavor would you like in the soup");
Console.WriteLine("Spicy");
Console.WriteLine("Sweet");
Console.WriteLine("Salty");
string exampleFlavor = Console.ReadLine();

if (exampleType == "Soup")
{
    soupExample.type = SoupType.Soup;
}
else if (exampleType == "Stew")
{
    soupExample.type = SoupType.Stew;
}
else if (exampleType == "Gumbo")
{
    soupExample.type = SoupType.Gumbo;
}

if (exampleIngredient == "Mushroom")
{
    soupExample.ingredient = Ingredient.Mushroom;
}
else if (exampleIngredient == "Chicken")
{
    soupExample.ingredient = Ingredient.Chicken;
}
else if (exampleIngredient == "Carrots")
{
    soupExample.ingredient = Ingredient.Carrot;
}
else if (exampleIngredient == "Potatoes")
{
    soupExample.ingredient = Ingredient.Potato;
}

if (exampleFlavor == "Spicy")
{
    soupExample.flavor = Flavor.Spicy;
}
else if (exampleFlavor == "Sweet")
{
    soupExample.flavor = Flavor.Sweet;
}
else if (exampleFlavor == "Salty")
{
    soupExample.flavor = Flavor.Salty;
}

Console.WriteLine("You've made a " + soupExample.flavor + " " + soupExample.ingredient + " " + soupExample.type);