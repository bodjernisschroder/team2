namespace StringExtensions
{
    [TestClass]

    public class UnitTest1

    {

        [TestMethod]

        public void TestCapitalize1()

        {

            // Arrange

            string s = null;



            // Act

            string s2 = s.Capitalize();



            // Assert

            Assert.AreEqual(null, s2);

        }

        [TestMethod]

        public void TestCapitalize2()

        {

            // Arrange

            string s = "";



            // Act

            string s2 = s.Capitalize();



            // Assert

            Assert.AreEqual("", s2);

        }

        [TestMethod]

        public void TestCapitalize3()

        {

            // Arrange

            string s = "opgave";



            // Act

            string s2 = s.Capitalize();



            // Assert

            Assert.AreEqual("Opgave", s2);

        }

        [TestMethod]

        public void TestCapitalize4()

        {

            // Arrange

            string s = "Opgave";



            // Act

            string s2 = s.Capitalize();



            // Assert

            Assert.AreEqual("Opgave", s2);

        }

        [TestMethod]

        public void TestCapitalize5()

        {

            // Arrange

            string s = "o";



            // Act

            string s2 = s.Capitalize();



            // Assert

            Assert.AreEqual("O", s2);

        }

        [TestMethod]

        public void TestCapitalize6()

        {

            // Arrange

            string s = "O";



            // Act

            string s2 = s.Capitalize();



            // Assert

            Assert.AreEqual("O", s2);

        }

    }
}