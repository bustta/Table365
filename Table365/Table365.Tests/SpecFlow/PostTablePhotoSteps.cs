using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Table365.Core.Models.POCO;
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
        private TablePhoto _tablePhoto;
        private int _originalPhotoCount;

        
        [Given(@"I have received a photo from client side")]
        public void GivenIHaveReceivedAPhotoFromClientSide()
        {
            _tablePhoto = new TablePhoto {Photo = new byte[256]};
        }
        
        [When(@"save into DB")]
        public void WhenSaveIntoDB()
        {
            _originalPhotoCount = _tablePhotoRepository.GetTablePhotoCount();
            _tablePhotoRepository.Create(_tablePhoto);
        }
        
        [Then(@"the count of table Photo should be plus one")]
        public void ThenTheCountOfTablePhotoShouldBePlusOne()
        {
            var currentPhoto = _tablePhotoRepository.GetTablePhotoCount();
            Assert.AreEqual(currentPhoto, _originalPhotoCount + 1);
        }
    }
}
