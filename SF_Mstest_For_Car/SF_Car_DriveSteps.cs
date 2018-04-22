using System;
using TechTalk.SpecFlow;

namespace SF_Mstest_For_Car
{
    [Binding]
    public class SF_Car_DriveSteps
    {
        [Given(@"I enter the speed that I am driving which is over the speed limit")]
        public void GivenIEnterTheSpeedThatIAmDrivingWhichIsOverTheSpeedLimit()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I Drive the car")]
        public void WhenIDriveTheCar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am prompted to slow down")]
        public void ThenIAmPromptedToSlowDown()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
