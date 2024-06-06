using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
	class Program
	{
		/// <summary>
		/// The main method, vill handle the menues for the program
		/// </summary>
		/// <param name="args"></param>
		static void Main()
		{

			while (true)
			{
				Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3, 4, 5, 6, 7, 8, 9, 0) of your choice"
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
				char input = ' '; //Creates the character input to be used with the switch-case below.
				try
				{
					input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
				}
				catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
				{
					Console.Clear();
					Console.WriteLine("Please enter some input!");
				}
				switch (input)
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
					/*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
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
		static void ExamineList()
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
		static void ExamineQueue()
		{
			/*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
			Queue<string> myQueue = new Queue<string>();
			char navigation = ' ';

			while (navigation != '0')
			{
				Console.WriteLine("Write 0 to exit to main menu. +Kalle to add to queue. - to remove from queue");
				// TODO: validate input, maybe break out to other method
				string input = Console.ReadLine();
				navigation = input[0];
				string value = input.Substring(1).Trim();

				switch (navigation)
				{
					case '+':
						myQueue.Enqueue(value);
						Console.WriteLine($"Added {value} to the Queue.");
						Console.WriteLine($"Current queue count: {myQueue.Count}");
						break;
					case '-':
						Console.WriteLine($"Removed {myQueue.Peek()} from the queue.");
						// todo: add logic to check peek before dequeue, use tryPeek maybe
						myQueue.Dequeue();
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
		static void ExamineStack()
		{
			/*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
			Stack<string> myStack = new Stack<string>();
			char navigation = ' ';

			while (navigation != '0')
			{
				Console.WriteLine("Write 0 to exit to main menu. +Kalle to add to stack. - to remove from stack");
				// TODO: validate input, maybe break out to other method
				string input = Console.ReadLine();
				navigation = input[0];
				string value = input.Substring(1).Trim();

				switch (navigation)
				{
					case '+':
						myStack.Push(value);
						Console.WriteLine($"Pushed {value} to the stack.");
						Console.WriteLine($"Current stack count: {myStack.Count}");
						break;
					case '-':
						Console.WriteLine($"Removed {myStack.Peek()} from the stack.");
						// todo: add logic to check peek before pop, use tryPeek maybe
						myStack.Pop();
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
		static void ReverseText()
		{
			char navigation = ' ';

			while (navigation != '0')
			{
				Console.WriteLine("Write 0 to exit to main menu. Otherwise write a string that you want to reverse using a stack");
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
						Console.WriteLine($"Reversed text: {ReverseText(value)}");
						break;
				}
			}
		}

		// todo: make method comment
		static string ReverseText(string text)
		{
			Stack<char> characters = new Stack<char>(text.Length); // create stack correct size

			// Add each character to the stack
			foreach (char c in text)
			{
				characters.Push(c);
			}

			// Build string to return
			StringBuilder result = new StringBuilder();

			// Pop each char off the stack
			foreach (char c in characters)
			{
				result.Append(c);
			}

			return result.ToString();
		}

		static void CheckParanthesis()
		{
			/*
			 * Use this method to check if the paranthesis in a string is Correct or incorrect.
			 * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
			 * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
			 */

			// setup rules datastructure where we have what matches what
			// 1. get input
			// 2. iterate string and put all opening chars to some datastructure and push all closing chars to other datastructure
			// 3. iterate the opening datastructure and try find its corresponding closer in other datastructure, if match remove both
			// 4. do above until empty one empty. if both empty its success otherwise its false.
			// 5. present result.

			char navigation = ' ';

			while (navigation != '0')
			{
				Console.WriteLine("Write 0 to exit to main menu. Otherwise write a string that you want to check if paranthesis is correct");
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
						Console.WriteLine($"Paranthesis correct: {CheckParanthesis(value)}");
						break;
				}
			}
		}

		// todo: fix implementation of algorithm. ({)} case not ok
		static bool CheckParanthesis(string text)
		{
			// define the pairs, key = openeing and value = closing
			Dictionary<char, char> pairs = new Dictionary<char, char>
			{
				{ '(', ')' },
				{ '{', '}' },
				{ '[', ']' },
				{ '<', '>' }
			};

			// create datastructures
			Stack<char> openers = new Stack<char>(); // doesnt matter which order we iterate so stack is efficient
			LinkedList<char> closers = new LinkedList<char>(); // because of lots of remove in the middle of the list randomly

			// fill datastructures with openers and closers
			foreach (char c in text)
			{
				// check openers
				if (pairs.ContainsKey(c))
				{
					openers.Push(c);

				} // check closers
				else if (pairs.ContainsValue(c))
				{
					closers.AddLast(c);
				}
			}

			// easy exit if mismatch in size
			if (openers.Count != closers.Count)
			{
				return false;
			}

			// now attempt to empty the stack
			while (openers.Count > 0)
			{
				char opener = openers.Peek();
				char closer = pairs[opener];

				if (closers.Contains(closer))
				{
					openers.Pop();
					closers.Remove(closer);
				}
				else
				{
					return false;
				}
			}

			// we should end up here if both datastructures was cleared successfully
			if (openers.Count == 0 && closers.Count == 0)
			{
				return true;
			}
			return false;
		}

		// todo: reformat and write method comment
		private static void RecursiveEven()
		{
			char navigation = ' ';

			while (navigation != '0')
			{
				Console.WriteLine("Write 0 to exit to main menu. Otherwise a number without decimals to calculate the number n:th even number using recursive logic");
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
						Console.WriteLine($"The n:th even number using recursive logic: {RecursiveEven(int.Parse(value))}");
						break;
				}
			}
		}

		// todo: implement
		private static int RecursiveEven(int n)
		{
			// Base case 
			if (n == 1)
			{
				return 0;
			}
			// Recursive case
			else
			{
				return (RecursiveEven(n - 1) + 2);
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
						Console.WriteLine($"The fibonacci number using recursive logic: {FibonacciRecursive(int.Parse(value))}");
						break;
				}
			}
		}

		// todo: implement logic
		private static int FibonacciRecursive(int n)
		{
			// Base case
			if (n <= 1) // or actually "n == 0 || n == 1" to make it clearer. both start points return n.
			{
				return n;
			}
			// Recursive case f(n) = f(n-1) + f(n-2), function is same as return statement
			else
			{
				return (FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2));
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
						Console.WriteLine($"The n:th even number using iterative logic: {IterativeEven(int.Parse(value))}");
						break;
				}
			}
		}

		// Todo: implement logic
		private static int IterativeEven(int value)
		{
			throw new NotImplementedException();
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
						Console.WriteLine($"The fibonacci number using iterative logic: {FibonacciIterative(int.Parse(value))}");
						break;
				}
			}
		}

		// todo: implement logic
		private static int FibonacciIterative(int n)
		{
			int current = 1; // fib current
			int prev = current - 1; // fib one behind
			int tmp = 0; // temp storage 

			// base case, same here - it actually represents both "n == 0 || n == 1" since they are the starting points
			if (n <= 1)
			{
				current = n;
			}
			else
			{
				for (int i = 2; i <= n; i++) // start at n = 2 since base case covers 0 and 1 by default
				{
					tmp = current; // will become one behind
					current = current + prev; // add fib current with fib one behind to get new current
					prev = tmp; // fib one behind will be whatever fib current was before the move
				}
			}
			return current;
		}
	}
}