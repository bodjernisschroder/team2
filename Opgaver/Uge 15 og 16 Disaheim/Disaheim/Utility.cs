//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Disaheim
//{
//    public class Utility
//    {


      


//        public double GetValueOfMerchandise(Merchandise merchandise)
//        {
//            if (merchandise is Book book) return book.Price;
//            else if (merchandise is Amulet amulet)
//            {
//                if (amulet.Quality == Level.low) return LowQualityValue;
//                else if (amulet.Quality == Level.medium) return MediumQualityValue;
//                else return HighQualityValue;
//            }
//            return 0.0;
//        }


//        public double GetValueOfCourse(Course course)
//        {
//            return (Math.Ceiling(course.DurationInMinutes / 60.0)) * CourseHourValue;
//        }
//    }
//}

////public double GetValueOfBook(Book book)
////{
////    return book.Price;
////}
////public double GetValueOfAmulet(Amulet amulet)
////{
////    if (amulet.Quality == Level.low) return 12.5;
////    else if (amulet.Quality == Level.medium) return 20.0;
////    else return 27.5;
////}

////Noter
////Math.Ceiling() runder tallet op til nærmest heltal
//// Math.Floor(2.06) --> 2.00 runder ned til nærmeste heltal

//// Alternativer til GetValueOfCourse løsninger
////double durationRemainder = durationInHours % (int)durationInHours;// 
////double durationRemainder = (course.DurationInMinutes / 60) % ((int)course.DurationInMinutes / 60);// 

////int calcHours = course.DurationInMinutes / 60;
////int remainder = course.DurationInMinutes % 60;
////if (remainder > 0) calcHours += 1;
////return calcHours * 875;

////if (durationInHours % 2 != 0) durationInHours = ((int)durationInHours + 1);
////return (int)durationInHours * courseValue;

////double courseValue = 875.00;
////double durationInHours = course.DurationInMinutes / 60; // Kommatal // 2,8
//////// Beregner prisen
////if (durationInHours % 2 != 0) return ((int)durationInHours + 1.00) * courseValue;
////else if (durationInHours == 0) return 0;
////return (int)durationInHours * courseValue;


//// 2,61 % 2 != 0, derfor return 2 + 1 = 3 * 875
//// 3 % 2 = 1, derfor return 3 + 1 = 4 * 875