using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using CarStuff;

namespace MoqCarStuff_UT
{
    // ----------------------------------------------------
    /// <summary>
    ///     We want to actually test Driver. As such, we 
    ///     do not want to test Car (Not here anyway).
    ///     So Driver is the "System Under Test" while
    ///     Car is a good candidate for Mocking.
    /// </summary>

    [TestClass]
    public class Driver_UT
    {
        public Driver_UT()
        { }

        private TestContext testContextInstance;

        // ------------------------------------------------
        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        ///</summary>

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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        // ------------------------------------------------
        /// <summary>
        ///     Here, we are testing Driver.Drive. To do so,
        ///     we will use Moq'ed cars.
        /// </summary>

        [DeploymentItem("TestData\\Car_TD.xml"),
         DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                    "|DataDirectory|\\Car_TD.xml",
                    "Drive",
                    DataAccessMethod.Sequential),
        TestMethod, 
        TestCategory("Driver")]
        public void Drive()
        {
            var expectedResult = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);
            var maxAllowedSpeed = Convert.ToInt32(TestContext.DataRow["MaxAllowedSpeed"]);

            // ------------------------
            // Create a MOQ Car object.

            var car = new Mock<ICar>();

            // -----------------------------------------
            // When GetSpeed() is called on the Moq Car,
            // return whatever the local method GetMoqSpeed()
            // returns.
            // (Thus Controling what car.GetSpeed() returns)

            car.Setup(c => c.GetSpeed())
                .Returns(GetMoqSpeed());

            // --------------------------------------------
            // Use the Moq'ed Car in the Driver Constructor
            // use .Object to gain access to the actual car object

            var sutDriver = new Driver(car.Object, maxAllowedSpeed);

            // -------------------------------------------
            // driver.Drive will make a call to GetSpeed()
            // (On the Mocked Object)

            var resp = sutDriver.Drive();

            // --------------------------------------------
            // Stipulate that GetSpeed is only called once.

            car.Verify(c => c.GetSpeed(), Times.Exactly(1));

            Assert.AreEqual(expectedResult, resp);
        }

        // ------------------------------------------------

        [DeploymentItem("TestData\\Car_TD.xml"),
         DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                    "|DataDirectory|\\Car_TD.xml",
                    "Options",
                    DataAccessMethod.Sequential),
        TestMethod,
        TestCategory("Driver")]
        public void Options()
        {
            var color = Convert.ToString(TestContext.DataRow["Color"]);
            var tireSet = Convert.ToString(TestContext.DataRow["TireSet"]);
            var sportsPackage = Convert.ToBoolean(TestContext.DataRow["SportsPackage"]);
            var maxAllowedSpeed = Convert.ToInt32(TestContext.DataRow["MaxAllowedSpeed"]);

            // ------------------------
            // Create a MOQ Car object.

            var car = new Mock<ICar>();

            // -----------------------------------------
            // When GetOptions() is called on the Moq Car,
            // return whatever the local method GetOptions() returns.
            // (Control what car.GetOptions() returns)
            // Use a local method to keep from building the 
            // Moq Return object inline.

            car.Setup(c => c.Options).Returns(GetMoqOptions());

            // -----------------------------------------
            // Use the Moq Car in the Driver Constructor

            var sutDriver = new Driver(car.Object, maxAllowedSpeed);

            // --------------------------------------------
            // These properties of Driver make calls to the 
            // OptionsPackage of the Car object.

            Assert.AreEqual(color, sutDriver.CarColor);
            Assert.AreEqual(tireSet.ToString(), sutDriver.TireOption);
            Assert.AreEqual(sportsPackage, sutDriver.PurchasedSportsPackage);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Control the return of Moq'ed Car.GetSpeed()
        /// </summary>
        /// <remarks>
        ///     This method is called from a Test Method Proper.
        ///     The Test Method recieves the TestContext along
        ///     with the input data.
        ///     So, this method can retrieve data from the XML.
        /// </remarks>
        /// <returns></returns>

        private int GetMoqSpeed()
        {
            return Convert.ToInt32(TestContext.DataRow["Speed"]);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Control the contents of the Moq'ed 
        ///     Car.OptionsPackage object.
        /// </summary>
        /// <remarks>
        ///     This method is called from a Test Method Proper.
        ///     The Test Method recieves the TestContext along
        ///     with the input data.
        ///     So, this method can retrieve data from the XML.
        /// </remarks>
        /// <returns></returns>

        private OptionsPackage GetMoqOptions()
        {
            return new OptionsPackage()
            {
                SportsPackage = Convert.ToBoolean(TestContext.DataRow["SportsPackage"]),
                Tires = (eTireSet)Enum.Parse(typeof(eTireSet), Convert.ToString(TestContext.DataRow["TireSet"])),
                Color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Convert.ToString(TestContext.DataRow["Color"]))
            };
        }
    }
}
