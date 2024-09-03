//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace Disaheim
//{
//    public class AmuletRepository
//    {
//        private List<Amulet> amulets = new List<Amulet>();
        

//        public void AddAmulet(Amulet amulet)
//        {
//            amulets.Add(amulet);
//        }

//        public Amulet GetAmulet(string itemId)
//        {
//            foreach (Amulet amulet in amulets)
//            {
//                if (amulet.ItemId == itemId) return amulet;
//            }
//            return null;
//        }

//        public double GetTotalValue()
//        {
//            Utility utility = new Utility();
//            double total = 0.0;
//            foreach (Amulet amulet in amulets ) 
//            {
//                total += utility.GetValueOfAmulet(amulet);
//            }
//            return total;
//        }
//    }
//}