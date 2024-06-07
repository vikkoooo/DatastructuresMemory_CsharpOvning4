using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

/*
 Frågor:
 1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
	Stacken fungerar precis som datastrukturen stack, det brukar ofta visualiseras med en trave tallrikar. När man lägger
	något på stacken så hamnar det högst upp. När något plockas bort från stacken så plockas den översta "tallriken" bort.
	Det är bra för att då vet vi var vi var, det blir som en ordning i vilken vi ska exekvera uppgifter. Se det som långtidsminne.
	Om vi gör ett metodanrop så lägger vi det på stacken, när vi kört klart metoden tas det bort. 

	Heapen fungerar lite mer som t.ex. datastrukturen tree, där allting kopplas genom noder och grenar, helt huller om buller. 
	Det är mer av ett korttidsminne och när vi genomför någon uppgift i stacken kanske vi behöver extra minnesplats som då skapas
	i heapen. Vi reserverar minnesplatser för detta t.ex. att lagra en string. Säg att vi ska lagra en string av 12 characters
	då kan vi reservera upp 12 platser för 12 char, och då vet vi att strängen är dessa 12 platser i sekvens. Om vi plockar bort pekaren
	som pekar till denna sträng ligger fortfarandet den binära datan för våra 12 chars kvar på de aktuella minnesplatserna, men garbage
	collection säger tillslut åt oss att vi kan skriva över dessa minnespostioner de är fria för användning. 

	Det är liknande teknik som används för att återskapa borttagna filer på en trasig hårddisk, filer tas egentligen inte bort
	utan vi säger bara att dessa platser går att skriva över. Men värdet från tidigare ligger där fortfarande tills vi faktiskt
	skriver över platsen. 

 2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
	Value Types innehåller det värde som variabeln fick när vi skapa den direkt på den minnesplats vi tilldelades när vi skapa värdet.
	Alltså om vi skapar en int så är ju värdet ett binärt värde egentligen, och det sätts till en minnesplats, och på den
	minnesplatsen sparas det binära värdet. Int, double, bool är exempel på value types men det finns fler.

	Reference types är oftast objekt och det sitter istället en pekare som pekar vidare på var objektet med dess data lagras.
	T.ex. en string är en reference type och en string är ju egentligen bara en sekvens av char. Char är en value type 
	så dess binära värde lagras i minnet så stringen pekar på var vi hittar alla våra chars. Så string objektet tar upp flera 
	minnesplatser och så fungerar alla objekt. 

 3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
	Metoden som använder sig av int i dess originalform ReturnValue(), alltså som value types skriver datan till den variabelns 
	minnespositionen som vi fick. Vi sätter x till 3 på rad 2 i funktionen. Allt annat kan vi egentligen bortse från, det är bara
	till för att förvirra. Vi sätter x till 3 och ändrar aldrig x. Punkt slut. Works as intended. 

	Metoden som använder sig av objekt för att efterspegla en int ReturnValue2() skapar objekt x där vi har en parameter i objektet
	som innehåller ett värde som vi kallar för MyValue. Det sätter vi till 3 på rad 2 i funktionen. Sen tar vi och kopierar in
	den pekaren som pekade mot objektet x till ett objekt y på ett vanskligt sätt. Detta kan inte ses som god kodningssed. 
	Vi har nu två referenser (x och y) som båda pekar till samma objekt. Det objektet har ett värde som heter MyValue. 
	Sen uppdaterar vi objektets MyValue till 4. Vi returnerar därefter x.MyValue och får då tillbaka 4 precis som väntat.
	Vi har ju två olika pekare som pekar till samma objekt. Helt korrekt enligt de uppgifter vi gett vår maskin, men troligen har
	människan som skrivit denna kod tänkt fel. 
*/

namespace SkalProj_Datastrukturer_Minne
{
	internal class Program
	{
		/// <summary>
		/// The main method, will handle the menus for the program
		/// </summary>
		/// <param name="args"></param>
		private static void Main()
		{
			while (true)
			{
				Console.WriteLine(
					"Please navigate through the menu by inputting the number \n(1, 2, 3, 4, 5, 6, 7, 8, 9, 0) of your choice"
					+ "\n1. Examine a List"
					+ "\n2. Examine a Queue"
					+ "\n3. Examine a Stack"
					+ "\n4. CheckParenthesis"
					+ "\n5. ReverseText using Stack"
					+ "\n6. RecursiveEven calculate the n:th number"
					+ "\n7. Fibonacci recursive function"
					+ "\n8. IterativeEven calculate the n:th number"
					+ "\n9. Fibonacci iterative function"
					+ "\n0. Exit the application");

				var (nav, text) = GetInput(); // Replace with cleaner input

				switch (nav)
				{
					case '1':
						ExamineList();
						break;
					case '2':
						ExamineQueue();
						break;
					case '3':
						ExamineStack();
						break;
					case '4':
						CheckParanthesis();
						break;
					case '5':
						ReverseText();
						break;
					case '6':
						RecursiveEven();
						break;
					case '7':
						FibonacciRecursive();
						break;
					case '8':
						IterativeEven();
						break;
					case '9':
						FibonacciIterative();
						break;
					case '0':
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5, 6, 7, 8, 9)");
						break;
				}
			}
		}


		/// <summary>
		/// Examines the datastructure List
		/// </summary>
		private static void ExamineList()
		{
			/*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

			List<string> theList = new List<string>();
			char nav = ' ';

			do
			{
				Console.WriteLine("Write 0 to exit to main menu. +Adam to add Adam to list. -Adam to remove Adam from list.");

				// Fetch user input and break out the +/- operator, and its substring.
				// todo: handle null input from user, maybe break out to other method
				string input = Console.ReadLine();
				nav = input[0];
				string value = input.Substring(1).Trim(); // remove trailing and leading blankspaces
				switch (nav)
				{
					case '+':
						theList.Add(value);
						Console.WriteLine($"Added {value} to the List.");
						Console.WriteLine($"Current list count: {theList.Count}");
						Console.WriteLine($"Current list capacity: {theList.Capacity}");
						break;
					case '-':
						// todo: add logic to find that the list actually contains value before removing
						theList.Remove(value);
						Console.WriteLine($"Removed {value} from the List.");
						Console.WriteLine($"Current list count: {theList.Count}");
						Console.WriteLine($"Current list capacity: {theList.Capacity}");
						break;
					case '0':
						Console.WriteLine("Going back to main menu");
						break;
					default:
						Console.WriteLine("You must start your input with the + or - operator.");
						break;
				}
			} while (nav != '0');


			/*
				Frågor
				2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
				Listans kapacitet fördubblas när den underliggande arrayen blir full. Den börjar med att ha plats för 4 element
				När vi fyllt Listan (och därmed den underliggande arrayen) med 4 element skapas en ny underliggande	array
				med 8 platser upp, och de 4 värdena vi redan hade flyttas över till den nya arrayen. 

				3. Med hur mycket ökar kapaciteten?
				Kapaciteten fördubblas varje gång den underliggande arrayen blir full. Jag trodde dock att listan
				bara skulle öka med 50% tills jag testade, så har jag fått lära mig att det fungerar i andra datastrukturer kurser
				i alla fall. Troligen finns det någon skalning som gör att om vi hamnar över en viss storlek så ökar vi bara med
				50% istället. Men jag hittar ingen sådan dokumentation.

				4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
				Det är en dyr overhead att skapa en ny array och flytta över alla värden, så det är onödigt att göra det för ofta.

				5. Minskar kapaciteten när element tas bort ur listan?
				Nej, troligen därför att vi redan gjort det dyra och skalat upp. Det finns ingen anledning att skala ner arrayen.
				Detta känns dock konstigt, om vi allokerar miljontals med minnesplatser till arrayen och sedan tömmer den, borde
				det vara bra att "fria upp" dessa platser. Det finns dock en metod som heter TrimExcess() som vi kan använda efter
				att vi tömt en array om vi tycker det är viktigt att krympa den. 

				6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
				Om vi vet hur många element vi behöver lagra och aldrig vill ändra detta är det bättre att vi gör en egen array.
				En lista kostar massa overhead, men kommer med en hel del bra extrafunktion. Så det beror på vad som är viktigt: 
				* Enkel tidseffektiv kod att skriva? (billigt att utveckla), välj Lista och använd dess inbyggda funktioner. 
				* Eller är prestanda väldigt viktigt? (dyrt att utveckla), välj Array och skriv dina egna funktioner för att traversera arrayen. 
			*/
		}

		/// <summary>
		/// Examines the datastructure Queue
		/// </summary>
		private static void ExamineQueue()
		{
			/*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
			Queue<string> myQueue = new Queue<string>();
			char nav = ' ';
			string? text;

			while (nav != '0')
			{
				Console.WriteLine(
					"\n" + "Example: Write +Kalle to add \"Kalle\" to queue"
					+ "\n" + "Write - to remove the next person from the queue"
					+ "\n" + "Write 0 to exit to main menu.+" + "\n");
				(nav, text) = GetInput();

				switch (nav)
				{
					case '+':
						myQueue.Enqueue(text);
						Console.WriteLine($"Added {text} to the queue.");
						Console.WriteLine($"Current queue count: {myQueue.Count}");
						break;
					case '-':
						if (myQueue.Count > 0)
						{
							Console.WriteLine($"Removed {myQueue.Peek()} from the queue.");
							myQueue.Dequeue();
						}
						else
						{
							Console.WriteLine("Queue is empty.");
						}
						Console.WriteLine($"Current queue count: {myQueue.Count}");
						break;
					case '0':
						Console.WriteLine("Going back to main menu");
						break;
					default:
						Console.WriteLine("You must start your input with the + or - operator.");
						break;
				}
			}
		}

		/// <summary>
		/// Examines the datastructure Stack
		/// </summary>
		private static void ExamineStack()
		{
			/*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
			Stack<string> myStack = new Stack<string>();
			char nav = ' ';
			string? text;

			while (nav != '0')
			{
				Console.WriteLine(
					"\n" + "Example: Write +Kalle to add \"Kalle\" to stack"
					+ "\n" + "Write - to remove the top item from the stack"
					+ "\n" + "Write 0 to exit to main menu." + "\n");
				(nav, text) = GetInput();

				switch (nav)
				{
					case '+':
						myStack.Push(text);
						Console.WriteLine($"Pushed {text} to the stack.");
						Console.WriteLine($"Current stack count: {myStack.Count}");
						break;
					case '-':
						if (myStack.Count > 0)
						{
							Console.WriteLine($"Removed {myStack.Peek()} from the stack.");
							myStack.Pop();
						}
						else
						{
							Console.WriteLine("Stack is empty.");
						}
						Console.WriteLine($"Current stack count: {myStack.Count}");
						break;
					case '0':
						Console.WriteLine("Going back to main menu");
						break;
					default:
						Console.WriteLine("You must start your input with the + or - operator.");
						break;
				}
			}
			/*
				Frågor
				1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. 
				Varför är det inte så smart att använda en stack i det här fallet?

				Därför att en stack lägger det senaste värdet högst upp på stacken,
				precis som en travle tallrikar där man lägger den senaste tallriken högst upp.
				Så den senaste tallriken som är lagt på stacken är också den första
				som kommer att användas. Om vi verkligen vill använda en stack som en kö
				kan vi traversera till det nedersta itemet i stacken och poppa det.
				Men det är extremt ineffektivt och rekommenderas inte.
			*/
		}

		// todo: make method comment
		private static void ReverseText()
		{
			char nav = ' ';
			string? text;

			while (nav != '0')
			{
				Console.WriteLine(
					"\n" + "Write a string that you want to reverse using a stack"
					+ "\n" + "Write 0 to exit to main menu" + "\n");
				(nav, text) = GetInput();

				switch (nav)
				{
					case '0':
						Console.WriteLine("Going back to main menu");
						break;
					default:
						Console.WriteLine($"Reversed text: {Helpers.ReverseText(text)}");
						break;
				}
			}
		}

		// todo: make method comment
		private static void CheckParanthesis()
		{
			/*
			 * Use this method to check if the paranthesis in a string is Correct or incorrect.
			 * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
			 * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
			 */
			char nav = ' ';
			string? text;

			while (nav != '0')
			{
				Console.WriteLine(
					"\n" + "Write a string that you want to check if paranthesis is correct"
					+ "\n" + "Write 0 to exit to main menu" + "\n");
				(nav, text) = GetInput();

				switch (nav)
				{
					case '0':
						Console.WriteLine("Going back to main menu");
						break;
					default:
						Console.WriteLine($"Paranthesis correct: {Helpers.CheckParanthesis(text)}");
						break;
				}
			}
		}



		// todo: make method comment
		private static void RecursiveEven()
		{
			char nav = ' ';
			string? text;

			while (nav != '0')
			{
				Console.WriteLine(
					"\n" + "Write a number without decimals to calculate the number n:th even number using recursive logic"
					+ "\n" + "Write 0 to exit to main menu" + "\n");
				(nav, text) = GetInput();

				switch (nav)
				{
					case '0':
						Console.WriteLine("Going back to main menu");
						break;
					default:
						if (int.TryParse(text, out int number))
						{
							Console.WriteLine($"The n:th even number using recursive logic: {Helpers.RecursiveEven(number)}");
						}
						else
						{
							Console.WriteLine("Invalid number. Please enter a valid integer.");
						}
						break;
				}
			}
		}



		// todo: reformat and write method comment
		private static void FibonacciRecursive()
		{
			char navigation = ' ';

			while (navigation != '0')
			{
				Console.WriteLine("Write 0 to exit to main menu. Otherwise a number without decimals to calculate the fibonacci number using recursive logic");
				// TODO: validate input, maybe break out to other method
				string input = Console.ReadLine();
				navigation = input[0];
				string value = input.Trim();

				switch (navigation)
				{
					case '0':
						Console.WriteLine("Going back to main menu");
						break;
					default:
						Console.WriteLine($"The fibonacci number using recursive logic: {Helpers.FibonacciRecursive(int.Parse(value))}");
						break;
				}
			}
		}



		// todo: reformat and write method comment
		private static void IterativeEven()
		{
			char navigation = ' ';

			while (navigation != '0')
			{
				Console.WriteLine("Write 0 to exit to main menu. Otherwise a number without decimals to calculate the number n:th even number using iterative logic");
				// TODO: validate input, maybe break out to other method
				string input = Console.ReadLine();
				navigation = input[0];
				string value = input.Trim();

				switch (navigation)
				{
					case '0':
						Console.WriteLine("Going back to main menu");
						break;
					default:
						Console.WriteLine($"The n:th even number using iterative logic: {Helpers.IterativeEven(int.Parse(value))}");
						break;
				}
			}
		}



		// todo: reformat and implement method logic
		private static void FibonacciIterative()
		{
			char navigation = ' ';

			while (navigation != '0')
			{
				Console.WriteLine("Write 0 to exit to main menu. Otherwise a number without decimals to calculate the fibonacci number using recursive logic");
				// TODO: validate input, maybe break out to other method
				string input = Console.ReadLine();
				navigation = input[0];
				string value = input.Trim();

				switch (navigation)
				{
					case '0':
						Console.WriteLine("Going back to main menu");
						break;
					default:
						Console.WriteLine($"The fibonacci number using iterative logic: {Helpers.FibonacciIterative(int.Parse(value))}");
						break;
				}
			}
		}

		private static (char, string) GetInput()
		{
			string input = Console.ReadLine()!;

			// Early exit if user input error
			if (string.IsNullOrEmpty(input))
			{
				return (' ', string.Empty);
			}

			char nav = input[0];
			// If string is long enough to get a substring from set substring, else set empty string
			string subString = input.Length > 1 ? input.Substring(1).Trim() : string.Empty;
			return (nav, subString);
		}


		/* Fråga:
			Q:	Utgå ifrån era nyvunna kunskaper om iteration, rekursion och minneshantering. Vilken av ovanstående funktionerär mest minnesvänlig och varför?
			A:	Gällande fibonacci är rekursiva fallet mest minnesvänligt. Fibonacciexemplet är det klassiska skolboksexemplet på när rekursion är det mest 
				effektiva sättet att lösa uppgiften
		*/
	}
}