
using Moq;
using CarStuff;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SF_MSTest_Car_UT
{
    [Binding]
    public class SF_Car_Drive_Steps
    {
        protected int resp = 0;
        protected const int SPEED_UP = 1;
        protected const int SLOW_DOWN = -1;
        protected const int SPEED_LIMIT = 65;
        protected const int REMAIN_CONSTANT = 0;
        protected Mock<ICar> m_car = new Mock<ICar>();

        // ------------------------------------------------

        [Given(@"I enter the speed that I am driving which is over the speed limit")]
        public void GivenIEnterTheSpeedThatIAmDrivingWhichIsOverTheSpeedLimit()
        {
            m_car.Setup(c => c.GetSpeed()).Returns(SPEED_LIMIT + 10);
        }

        // ------------------------------------------------

        [Given(@"I enter the speed that I am driving which is under the speed limit")]
        public void GivenIEnterTheSpeedThatIAmDrivingWhichIsUnderTheSpeedLimit()
        {
            m_car.Setup(c => c.GetSpeed()).Returns(SPEED_LIMIT - 10);
        }

        // ------------------------------------------------

        [Given(@"I enter the speed that I am driving which is exactly the speed limit")]
        public void GivenIEnterTheSpeedThatIAmDrivingWhichIsExactlyTheSpeedLimit()
        {
            m_car.Setup(c => c.GetSpeed()).Returns(SPEED_LIMIT);
        }

        // ------------------------------------------------
        // This is the one and only implementation of Drive
        // Even though it appears in all three scenarios

        [When(@"I Drive the car")]
        public void WhenIDriveTheCar()
        {
            Driver sut = new Driver(m_car.Object, SPEED_LIMIT);
            resp = sut.Drive();
        }

        // ------------------------------------------------

        [Then(@"I am prompted to slow down")]
        public void ThenIAmPromptedToSlowDown()
        {
            Assert.AreEqual(SLOW_DOWN, resp);
        }

        // ------------------------------------------------

        [Then(@"I am prompted to Speed Up")]
        public void ThenIAmPromptedToSpeedUp()
        {
            Assert.AreEqual(SPEED_UP, resp);
        }

        // ------------------------------------------------
        
        [Then(@"I am prompted to remain constant")]
        public void ThenIAmPromptedToRemainConstant()
        {
            Assert.AreEqual(REMAIN_CONSTANT, resp);
        }
    }
}

/*
    // ------------------------------------------------------
    // Install The Specflow Plugin

    01) Start up Visual Studio 2017 (I am not sure about earlier versions)
    02) Select "Tools" menu
    03) Select "Extensions and Updates"
    04) Search for "SpecFlow"
    05) Install "SpecFlow for Visual Studio 2017"

    // ------------------------------------------------------
    // Finish the SpecFlow input BEFORE Generating the Tests.
    // Otherwise, the tests will be in multiple files 
    // (Unless that is what you want).

    01) Create a Test Project in the existing Solution Project.
    02) Add a Nuget Reference to SpecFlow to your Test
    03) If you plan to use MOQ (Recommended by me), Ad
    04) Add a reference to your Library Project to you
    05) Add a "New Item" to your Test Project
    06) Select "SpecFlow Feature File"
    07) Edit the entry/Add new entries to the feature file
    08) To Generate The tests:
        A) Right-Click inside the body of the feature file onpen in the editor
            a) Not the Tab
            b) Not the file in the list in the Solution Explorer
        B) Select "Generate Step Definitions"
        C) Implement the tests stubbed out by SpecFlow

    // -----------------------------------------------------------
    // Add this to the App.config of the Test MSTest based Project
    // http://specflow.org/documentation/Configuration/

    <configuration>
        <configSections>
            <section name="specFlow" 
                     type="TechTalk.SpecFlow.Configuration.ConfigurationSectionHandler, TechTalk.SpecFlow" />
        </configSections>
        <specFlow>
            <unitTestProvider name="MSTest"></unitTestProvider>
        </specFlow>
    </configuration>

    // ------------------------------------------------------
    // If the New MSTest tests do not appear in Test Explorer

    01) Close all Visual Studio instances
    02) Go to %TEMP%\VisualStudioTestExplorerExtensions\
    03) Delete all the folders in here
    04) Try again 
 */
