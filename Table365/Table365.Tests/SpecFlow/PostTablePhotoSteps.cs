using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Table365.Core.Repository;
using Table365.Core.Repository.Interface;
using Table365.Tests.Core.Repository;
using TechTalk.SpecFlow;

namespace Table365.Tests.SpecFlow
{
    [Binding]
    public class PostTablePhotoSteps
    {
        ITablePhotoRepository _tablePhotoRepository = new StubTablePhotoRepository();
        private byte[] _photo;
        private int _originalPhotoCount;

        [Given(@"I have received a photo from client side")]
        public void GivenIHaveReceivedAPhotoFromClientSide()
        {
            _photo = new byte[256];
        }
        
        [When(@"save into DB")]
        public void WhenSaveIntoDB()
        {
            _originalPhotoCount = _tablePhotoRepository.GetTablePhotoCount();
            _tablePhotoRepository.Insert(_photo);
        }
        
        [Then(@"the count of table Photo should be plus one")]
        public void ThenTheCountOfTablePhotoShouldBePlusOne()
        {
            var currentPhoto = _tablePhotoRepository.GetTablePhotoCount();
            Assert.AreEqual(currentPhoto, _originalPhotoCount + 1);
        }
    }
}
