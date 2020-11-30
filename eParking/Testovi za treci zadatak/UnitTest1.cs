using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using eParking;

namespace Testovi_za_treci_zadatak
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio,TestTools.DataSource.CSV", "|DataDirectory|\\TextFile1.csv",
            "TextFile1#csv", DataAccessMethod.Sequential), DeploymentItem("TextFile1.csv")]
        public void TestUspjesneValidacijeCSV()
        {
            string user = Convert.ToString(TestContext.DataRow["user"]),
                pass = Convert.ToString(TestContext.DataRow["pass"]),
                adress = Convert.ToString(TestContext.DataRow["adress"]),
                typeOfVehicle = Convert.ToString(TestContext.DataRow["typeOfVehicle"]),
                plates = Convert.ToString(TestContext.DataRow["plates"]);
            int endDateDay = Convert.ToInt32(TestContext.DataRow["enddateday"]),
                endDateMonth = Convert.ToInt32(TestContext.DataRow["enddatemonth"]),
                endDateYear = Convert.ToInt32(TestContext.DataRow["enddateyear"]),
                numberOfSeats = Convert.ToInt32(TestContext.DataRow["numberofseats"]);

            DateTime endDate = new DateTime(endDateYear, endDateMonth, endDateDay);
            Vozilo vozilo = new Vozilo(typeOfVehicle, plates, numberOfSeats);
            Clan clan = new Clan(user, pass, adress, vozilo, endDate);
        }

        [DataSource("Microsoft.VisualStudio,TestTools.DataSource.XML", "|DataDirectory|\\XMLFile1.xml",
            "Clan", DataAccessMethod.Sequential), DeploymentItem("XMLFile1.xml"), TestMethod]
        public void TestNeuspjesneValidacijeXML()
        {
            string user = Convert.ToString(TestContext.DataRow["user"]),
                pass = Convert.ToString(TestContext.DataRow["pass"]),
                adress = Convert.ToString(TestContext.DataRow["adress"]),
                typeOfVehicle = Convert.ToString(TestContext.DataRow["typeOfVehicle"]),
                plates = Convert.ToString(TestContext.DataRow["plates"]);
            int endDateDay = Convert.ToInt32(TestContext.DataRow["enddateday"]),
                endDateMonth = Convert.ToInt32(TestContext.DataRow["enddatemonth"]),
                endDateYear = Convert.ToInt32(TestContext.DataRow["enddateyear"]),
                numberOfSeats = Convert.ToInt32(TestContext.DataRow["numberofseats"]);

            DateTime endDate = new DateTime(endDateYear, endDateMonth, endDateDay);

            Vozilo vozilo = new Vozilo(typeOfVehicle, plates, numberOfSeats);
            Clan clan = new Clan(user, pass, adress, vozilo, endDate);
        }
    }
}
