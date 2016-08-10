using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Table365.Core.Repository;
using Table365.Tests.Core.Repository;

namespace Table365.Tests.SpecFlow
{
    [Binding]
    public class PostPictureSteps
    {
        IPhotoRepository _photoRepository = new StubPhotoRepository();
        private byte[] _photo;
        private int _originalPhotoCount;
        [Given(@"I have received a photo from client side")]
        public void GivenIHaveReceivedAPhotoFromClientSide()
        {
            _photo = new byte[256];
        }

        [When(@"save into DB")]
        public void WhenSaveIntoDb()
        {
            _originalPhotoCount = _photoRepository.GetUserPhotoCount();
            _photoRepository.Insert(_photo);
        }

        [Then(@"the count of table Photo should be plus one")]
        public void ThenTheCountOfTablePhotoShouldBePlusOne()
        {
            var currentPhoto = _photoRepository.GetUserPhotoCount();
            Assert.AreEqual(currentPhoto, _originalPhotoCount + 1);
        }
    }
}