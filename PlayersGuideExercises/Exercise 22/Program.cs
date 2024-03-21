 using Exercise_22;
 
 Console.WriteLine("What kind of arrowhead would you like?");
 Console.WriteLine("1) Steel");
 Console.WriteLine("2) Wood");
 Console.WriteLine("3) Obsidian");
 string arrowheadInput = Console.ReadLine();
 Console.Clear();
 Console.WriteLine("What kind of fletching would you like?");
 Console.WriteLine("1) Plastic");
 Console.WriteLine("2) Goose feather");
 Console.WriteLine("3) Turkey feather");
 string fletchingInput = Console.ReadLine();
 Console.Clear();
 Console.WriteLine("How long would you like the arrow shaft, in centimeters?"); 
 int shaftInput = Convert.ToInt32(Console.ReadLine());
 
 Arrow arrow = Arrow.BuildArrow(arrowheadInput, fletchingInput, shaftInput);
 float arrowPrice = arrow.ArrowPrice(arrow);
 Console.WriteLine("Your arrow costs " + arrowPrice +" gold.");
 