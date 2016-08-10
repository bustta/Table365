using TechTalk.SpecFlow;

namespace Table365.Tests.SpecFlow
{
    [Binding]
    public class PostPictureSteps
    {
        [Given(@"I have received a photo from client side")]
        public void GivenIHaveReceivedAPhotoFromClientSide()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"save into DB")]
        public void WhenSaveIntoDb()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the count of table Photo should be plus one")]
        public void ThenTheCountOfTablePhotoShouldBePlusOne()
        {
            ScenarioContext.Current.Pending();
        }
    }
}