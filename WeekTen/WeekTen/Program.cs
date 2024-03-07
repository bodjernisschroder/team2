using System;

class Program
{
    static void Main(string[] args)
    {
        //Øvelse 1.1

        /*int alderBurak = 26;
        int alderBo = 31;
        int alderAnna = 25;
        int alderAnja = 47;
        int alderChanita = 21;
        decimal gennemsnit = ( alderAnja + alderChanita + alderBo + alderBurak + alderAnna ) / 5;
        
        Console.WriteLine("Bo's alder er: " + alderBo);
        Console.WriteLine("Buraks alder er " + alderBurak);
        Console.WriteLine("Annas alder er: " + alderAnna);
        Console.WriteLine("Anjas alder er: " + alderAnja);
        Console.WriteLine("Chanita alder er: " + alderChanita);

        Console.WriteLine("Gruppens gennemsnitsalder er: " + gennemsnit);*/

        //Øvelse 1.2

        /*int[] allesAlder = new int[5] { 26, 31, 25, 47, 21 };

        decimal gennemsnit = 0;

        for (int i = 0; i < allesAlder.Length; i++)
        {
            Console.WriteLine(allesAlder[i]);
            gennemsnit += allesAlder[i];
        }

        Console.WriteLine(gennemsnit / allesAlder.Length);*/

        //Øvelse 1.3

        int[] allesAlder = new int[5] { 26, 31, 25, 47, 21 };
                
        bool rigtigt = false;

        while (rigtigt == false) { 
            Console.Write("Gæt en alder i gruppen: ");
            int gaet = Convert.ToInt32(Console.ReadLine()); 

            switch (gaet)
            {
                case 26:
                    Console.WriteLine("Rigtigt! Burak er " + allesAlder[0]);
                    rigtigt = true;
                    break;
            
                case 31:
                    Console.WriteLine("Rigtigt! Bo er " + allesAlder[1]);
                    rigtigt = true;
                    break;

                case 25:
                    Console.WriteLine("Rigtigt! Anna er " + allesAlder[2]);
                    rigtigt = true;
                    break;
                    

                case 47:
                    Console.WriteLine("Rigtigt! Anja er " + allesAlder[3]);
                    rigtigt = true;
                    break;
                    

                case 21:
                    Console.WriteLine("Rigtigt! Chanita er " + allesAlder[4]);
                    rigtigt = true;
                    break;
                    

                default:
                    Console.WriteLine("Forkert! Prøv igen");
                    Console.ReadLine();
                    break;
            }
        }

        ////decimal gennemsnit = 0;

        //for (int i = 0; i < allesAlder.Length; i++)
        //{
        //    Console.WriteLine(allesAlder[i]);
        //    gennemsnit += allesAlder[i];
        //}

        //Console.WriteLine(gennemsnit / allesAlder.Length);
    }
}