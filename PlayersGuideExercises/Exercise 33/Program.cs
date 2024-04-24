using Exercise_33;

Sword sword = new Sword();
Bow bow = new Bow();
Axe axe = new Axe();


ColoredItem BlueSword = new(sword, ConsoleColor.Blue);
ColoredItem RedBow = new ColoredItem(bow, ConsoleColor.Red);
ColoredItem GreenAxe = new ColoredItem(axe, ConsoleColor.Green);

BlueSword.Display();
RedBow.Display();
GreenAxe.Display();