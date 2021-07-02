using System;
using System.Collections.Generic;
using System.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        /// 
        /*
         * Minneshantering

        1. Heapen och Stacken:

        Heapen allt är tillgänligt på en gång. Heapen är som en trädstruktur. Har Garbage Collector. Referenstyperna • class • interface • object • delegate • string lagras I hepen

        Stacken är som en mängd boxar.För att komma åt den andra måste den börsta lyftas av.
        Stacken har koll på anrop och metoder. Självunderhållande.

        Värdetyperna kan både lagras I hepen eller stacken det beror på vart de deklareras.

        • bool • byte • char • decimal • double 
        • enum • float • int • long • sbyte 
        • short • struct • uint • ulong • ushort

        Om de deklareras i en metod så lagras de I stacken och om de lagras I en klass, som är en referens typ, så lagras dem i heapen.

        Lagras de I heapen ligger de där till garbage collection tar hand om dem.

        2. Valuetypes eller värdetyper är de olika typerna en variabel kan vara förutom String. Se ovan. Reference Types eller Referes Typer är: • class • interface • object • delegate • string. Skilnaden är att referenstyperna lagras alltid I hepen medans värdetyperna kan lagras I båda beroende på vart dem deklareras.

        3. Den första metoden där deklareras x till 3 sedan blir y = 3 då y är lika med x.
           Endast y deklareras till 4 där.

        I den andra metoden har y och x MyValue som verkar lagra samma int värde då MyValue får samma värde I både x och y.
         */
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
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
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            /* Övning 1: ExamineList()
            2.Den ökar när listans kapacitet är full.
            3.Listan har default 4 och ökar med det dubbla av listans storlek.
            Dvs. 4, 8, 16, 32
            4.Den använder de platser som finns först och sedan ökar kapaciteten när listan är full.
            5.Nej kapaciteten minskar ej när man tar bort I listan.
            6.Det är fördel när man bara har ett visst antal platser som man skall använda. */

            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting  \n(+, -, q, p) and a string");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Antal element: {theList.Count}, Kapasitet: {theList.Capacity}");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Antal element: {theList.Count}, Kapasitet: {theList.Capacity}");
                        break;
                    case 'q':
                        Main();
                        break;
                    case 'p':
                        Console.WriteLine($"Antal element: {theList.Count}, Kapasitet: {theList.Capacity}");
                        break;
                }
            }
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
            
            Console.WriteLine("Please navigate through the menu by inputting  \n(1 for adding to the queue, 2 for deleting a value to the queue, 3. For se whats in th queue. q for go to main menu.)");
            string input = Console.ReadLine();
            char nav = input[0];
            Queue<string> quevalues = new Queue<string>();

            while (true)
            {
                switch (nav)
                {
                    case '1':
                        Console.WriteLine("Add a string value to the queue  \n(For example Margarin)");
                        string quevalue = Console.ReadLine();
                        string enqueue = "enqueue";
                        TestQueue(quevalue, enqueue, quevalues);
                        Console.WriteLine("Please navigate through the menu by inputting  \n(1 for adding to the queue, 2 for deleting a value from the queue, 3. For se wats in th queue. q for go to main menu.)");
                        input = Console.ReadLine();
                        nav = input[0];
                        break;
                    case '2':
                        Console.WriteLine("If you want to delete the first value in the queue.");
                        string dequeue  = "dequeue";
                        TestQueue("", dequeue, quevalues);
                        Console.WriteLine("Please navigate through the menu by inputting  \n(1 for adding to the queue, 2 for deleting a value from the queue, 3. For se whats in th queue. q for go to main menu.)");
                        input = Console.ReadLine();
                        nav = input[0];
                        break;
                    case '3':
                        TestQueue("", "", quevalues);
                        Console.WriteLine("Please navigate through the menu by inputting  \n(1 for adding to the queue, 2 for deleting a value from the queue, 3. For se whats in th queue. q for go to main menu.)");
                        input = Console.ReadLine();
                        nav = input[0];
                        break;
                    case 'q':
                        Main();
                        break;
                }
            }
        }

        private static void TestQueue(string quevalue,string enqueue_dequeue, Queue<string> quevalues)
        {
          

            if(enqueue_dequeue == "enqueue")
            {
                quevalues.Enqueue(quevalue);
            }
            else if(enqueue_dequeue == "dequeue")
            {
                quevalues.Dequeue();
            }
            else
            {
                foreach (var item in quevalues)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Enter optional key to go on.");
                Console.ReadKey();
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

            // Nakdelen med stack är väl att det inte är så smart att ta bort den som är sist i kön.

            Console.WriteLine("Please navigate through the menu by inputting  \n(1 for adding to the stack, 2 for deleting a value from the stack, 3. For se wats in the stack. 4. Reverse the order of the letters for the text. q for go to main menu.)");
            string input = Console.ReadLine();
            char nav = input[0];
            Stack<string> stackvalues = new Stack<string>();

            while (true)
            {
                switch (nav)
                {
                    case '1':
                        Console.WriteLine("Add a string value to the stack  \n(For example Mjölk)");
                        string stackvalue = Console.ReadLine();
                        stackvalues.Push(stackvalue);
                        Console.WriteLine("Please navigate through the menu by inputting  \n(1 for adding to the stack, 2 for deleting a value from the stack, 3. For se wats in the stack. 4. Reverse the order of the letters for the text. q for go to main menu.)");
                        input = Console.ReadLine();
                        nav = input[0];
                        break;
                    case '2':
                        Console.WriteLine("If you want to delete the first value in the queue.");
                        stackvalues.Pop();
                        Console.WriteLine("Please navigate through the menu by inputting  \n(1 for adding to the que, 2 for deleting a value to the que, 3. For se wats in th que. 4. Reverse the order of the letters for the text. q for go to main menu.)");
                        input = Console.ReadLine();
                        nav = input[0];
                        break;
                    case '3':
                        foreach (var item in stackvalues)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Enter optional key to go on.");
                        Console.ReadKey();
                        Console.WriteLine("Please navigate through the menu by inputting  \n(1 for adding to the que, 2 for deleting a value to the que, 3. For se wats in th que. 4. Reverse the order of the letters for the text. q for go to main menu.)");
                        input = Console.ReadLine();
                        nav = input[0];
                        break;
                    case '4':
                        Console.WriteLine("Add a string value to the stack  \n(For example Jordgubbar):");
                        stackvalue = Console.ReadLine();
                        string reveredtext = ReverseText(stackvalue);
                        Console.WriteLine($"Revered text: {reveredtext}");
                        Console.WriteLine("Please navigate through the menu by inputting  \n(1 for adding to the que, 2 for deleting a value to the que, 3. For se wats in th que. 4. Reverse the order of the letters for the text. q for go to main menu.)");
                        input = Console.ReadLine();
                        nav = input[0];
                        break;
                    case 'q':
                        Main();
                        break;
                }
            }
        }

        private static string ReverseText(string stackvalue)
        {
            var stack = new Stack<char>();
            foreach(char c in stackvalue)
            {
                stack.Push(c);
            }

            stackvalue = string.Empty;

            while(stack.Count > 0)
            {
                stackvalue += stack.Pop();
            }
            return stackvalue;
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("Add a string with values to the stack  \n(For example (()), {}, []");
            string value = Console.ReadLine();
            var stack = new Stack<char>();
            foreach (char c in value)
            {
                stack.Push(c);
            }


            var charsstart = "({[";
            var charsends = ")}]";

            foreach (var item in stack)
            {
                if (charsstart.Contains(item))
                {
               
                 
                }
                if (charsends.Contains(item))
                {
                    Console.WriteLine("This is correct");
                }
                else
                {
                    Console.WriteLine("This is incorrect");
                }
            }




        }

    }
}

