//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Disaheim
//{
//    public class MerchandiseRepository
//    {
//        private List<Merchandise> merchandises = new List<Merchandise>();

//        public void AddMerchandise(Merchandise merchandise)
//        {
//            merchandises.Add(merchandise);
//        }

//        public Merchandise GetMerchandise(string itemId)
//        {
//            foreach (Merchandise merchandise in merchandises)
//            {
//                if (merchandise.ItemId == itemId) return merchandise;
//            }
//            return null;
//        }

//        //public double GetTotalValue()
//        //{
//        //    Utility utility = new Utility();
//        //    double total = 0.0;
//        //    foreach (Merchandise merchandise in merchandises)
//        //    {
//        //        total += utility.GetValueOfMerchandise(merchandise);
//        //    }
//        //    return total;
//        //}
//    }
//}