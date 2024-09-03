//internal class Program2
//{
//    private static void Main2(string[] args)
//    {
//        try
//        {

//            Console.WriteLine("========= Opgave 1.1 =========\n");

//            int alderBo = 31;
//            int alderBurak = 26;
//            int alderAnna = 25;
//            int alderAnja = 47;
//            int alderChanita = 21;

//            decimal gennemsnit = (alderBo + alderBurak + alderAnna + alderAnja + alderChanita) / 5;

//            Console.WriteLine($"Bo er {alderBo} år gammel.");
//            Console.WriteLine($"Burak er {alderBurak} år gammel.");
//            Console.WriteLine($"Anna er {alderAnna} år gammel.");
//            Console.WriteLine($"Anja er {alderAnja} år gammel.");
//            Console.WriteLine($"Chanita er {alderChanita} år gammel.");

//            Console.WriteLine("\nGennemsnitsalderen for gruppen er: " + gennemsnit);



//            Console.WriteLine("\n========= Opgave 1.2 =========\n");

//            int[] alderArray = new int[5] {31,26,25,47,21};

//            decimal gennemsnit2 = 0;

//            for (int i = 0; i < alderArray.Length; i++)
//            {
//                Console.WriteLine(alderArray[i]);
//                gennemsnit2 += alderArray[i];
//            }
//            Console.WriteLine(gennemsnit2/alderArray.Length);



//            Console.WriteLine("\n========= Opgave 1.3 =========\n");

//            Console.Write("Indtast en alder du vil søge efter i gruppen: ");
//            int searchInput = int.Parse(Console.ReadLine());

//            switch (searchInput)
//            {
//                case 31:
//                    Console.WriteLine("Bo er 31!");
//                    break;
//                case 26:
//                    Console.WriteLine("Burak er 26!");
//                    break;
//                case 25:
//                    Console.WriteLine("Anna er 25!");
//                    break;
//                case 47:
//                    Console.WriteLine("Anja er 47");
//                    break;
//                case 21:
//                    Console.WriteLine("Chanita er 21");
//                    break;
//                default:
//                    Console.WriteLine("Alder ikke fundet i gruppen.");
//                    break;
//            }

//            Console.WriteLine("\n========= Opgave 1.4 =========\n");

//            Console.Write("Hvor mange personer er der i gruppen? ");
//            int personer = int.Parse(Console.ReadLine());

//            int[] alderArray2 = new int[personer];

//            for (int i = 0;i < alderArray2.Length; i++)
//            {
//                Console.Write($"Indtast alderen på person nummer {i+1}: ");
//                int alderInput = int.Parse(Console.ReadLine());
//                alderArray2[i] = alderInput;
//            }
//            Console.WriteLine("Gruppens medlemmer er tilsammen " + alderArray2.Sum() + " år gamle.");

//        }  
//        catch (Exception ex) 
//        { 
//            Console.WriteLine(ex.Message); 
//        }
//    }
//}