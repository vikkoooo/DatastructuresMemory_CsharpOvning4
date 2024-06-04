using System;

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
				Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
					+ "\n1. Examine a List"
					+ "\n2. Examine a Queue"
					+ "\n3. Examine a Stack"
					+ "\n4. CheckParenthesis"
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
					/*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
					case '0':
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
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

			//List<string> theList = new List<string>();
			//string input = Console.ReadLine();
			//char nav = input[0];
			//string value = input.substring(1);

			//switch(nav){...}
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
		}

		static void CheckParanthesis()
		{
			/*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

		}

	}
}

