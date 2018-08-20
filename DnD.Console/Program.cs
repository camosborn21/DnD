using DnD.Application;
using DnD.Application.EntityStats;

namespace DnD.Console
{
	class Program
	{
		const string HorizontalRule = "****************************************************";
		static void Main(string[] args)
		{
			bool inMenu = true;
			char keyPressed;
			DiceBag dice = new DiceBag();
			Character c = new Character();
			while (inMenu)
			{
				System.Console.WriteLine();
				System.Console.WriteLine(HorizontalRule);
				System.Console.WriteLine("What would you like to do now?");
				System.Console.WriteLine("1. Roll d20");
				System.Console.WriteLine("2. Roll with advantage");
				System.Console.WriteLine("3. Roll from dice bag");
				System.Console.WriteLine("4. Character Creation");
				System.Console.WriteLine("Q. Quit");

				keyPressed = System.Console.ReadKey().KeyChar;
				System.Console.WriteLine();
				switch (keyPressed)
				{
					case '1':
						dice.Roll_d20(false);
						break;

					case '2':
						dice.Roll_d20(true);
						break;

					case '3':
						RollFromDiceBag();
						break;

					case '4':
						//c.RollCharacterCreation();
						
						break;
					case '5':
						c.Strength.Score = 14;
						
						break;
					case 'Q':
					case 'q':
						inMenu = false;
						break;
				}
			}

		}

		static void RollFromDiceBag()
		{
			DiceBag dice = new DiceBag();
			System.Console.WriteLine("What type of dice would you like to roll?");
			System.Console.WriteLine("1. d2");
			System.Console.WriteLine("2. d3");
			System.Console.WriteLine("3. d4");
			System.Console.WriteLine("4. d6");
			System.Console.WriteLine("5. d8");
			System.Console.WriteLine("6. d10");
			System.Console.WriteLine("7. d12");
			System.Console.WriteLine("8. d20");
			System.Console.WriteLine("9. Percentage Dice");
			char typeKey = System.Console.ReadKey().KeyChar;
			System.Console.WriteLine();
			string quantityAttempt;
			if (typeKey != '9')
			{
				System.Console.WriteLine("How many would you like to roll?");
				quantityAttempt = System.Console.ReadLine();
				System.Console.WriteLine();
			}
			else
			{
				quantityAttempt = "1";
			}
			if (quantityAttempt != null)
			{
				int quantity = int.Parse(quantityAttempt);
				switch (typeKey)
				{
					case '1':
						dice.Roll(quantity, 2);
						break;
					case '2':
						dice.Roll(quantity, 3);
						break;
					case '3':
						dice.Roll(quantity, 4);
						break;
					case '4':
						dice.Roll(quantity, 6);
						break;
					case '5':
						dice.Roll(quantity, 8);
						break;
					case '6':
						dice.Roll(quantity, 10);
						break;
					case '7':
						dice.Roll(quantity, 12);
						break;
					case '8':
						dice.Roll(quantity, 20);
						break;
					case '9':
						dice.Roll_Percent();
						break;
				}
			}
		}
	}
}
