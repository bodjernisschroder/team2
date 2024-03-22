namespace OrangeTreeSim
{
    public class OrangeTree
    {
        private int _age;
        private int _height;
        private bool _treeAlive;
        private int _numOranges;
        private int _orangesEaten;


        // OBS! Alle get og set skal tjekkes for, om de automatisk getter og setter _age osv, eller om det skal skrives explicitly
        public int Age
        {
            get { return _age; }
            set { if (value >= 0) _age = value; }
        }

        public int Height { get; set; }

        public bool TreeAlive { get; set; }

        public int NumOranges { get; }

        public int OrangesEaten { get; }

        //public void SetAge(int age)
        //{
        //    this.age += age;
        //}

        //public int GetAge()
        //{
        //    return age;
        //}

        //public void SetHeight(int height) 
        //{
        //    this.height += height;
        //}
        //public int GetHeight()
        //{
        //    return height;
        //}

        //public void SetTreeAlive(bool treeAlive)
        //{
        //    this.treeAlive = treeAlive;
        //}
        
        //public bool GetTreeAlive() 
        //{
        //    return treeAlive;
        //}

        //public int GetNumOranges()
        //{
        //    return numOranges;
        //}

        //public int GetOrangesEaten() 
        //{
        //    return orangesEaten;
        //}

        public void OneYearPasses()
        {
            _age += 1;

            //if (GetTreeAlive() == true) /*SetHeight(2);*/

            if (_age < 80)
            { 
                _treeAlive = true;
                _height += 2;
            }
            else
            {
                _numOranges = 0;
                _treeAlive = false;
            }
            
            _orangesEaten = 0;

            if (_age > 1 && _treeAlive == true) _numOranges = ((_age-1) * 5);
        }

        //numOranges = Produktion for hvert år 
        //orangesEaten = hvor mange vi har spist for hele levetide
        //count = hvor mange vi har spist for det pågældende år
        public void EatOrange(int count)
        {
            if (_numOranges >= count)
            {
                _orangesEaten += count;
                _numOranges -= count; 
                Console.WriteLine("Nom nom nom");
            }
            else Console.WriteLine("There is not enough oranges");

        }

    }
}
