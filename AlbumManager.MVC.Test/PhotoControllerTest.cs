using AlbumManager.Domain.Contracts.Service;
using AlbumManager.Domain.ViewModels;
using AlbumManager.MVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlbumManager.MVC.Test
{
    public class PhotoControllerTest
    {
        [Fact]
        public async Task ShouldReturnPhotoView()
        {
            var photos = new List<PhotoViewModel>()
            {
                new PhotoViewModel()
                {
                    AlbumName = "test",
                    Title = "testt",
                    ThumbnailUrl = "",
                    Url = ""
                }
            };
            Mock<IPhotoService> mockService = new Mock<IPhotoService>(MockBehavior.Strict);
            mockService.Setup(a => a.GetPhotosAsync())
                .ReturnsAsync(photos);
            var controller = new PhotoController(mockService.Object);
            var result = (ViewResult)await controller.Index();
            mockService.Verify(a => a.GetPhotosAsync(), Times.Once);
            Assert.Equal("test", ((List<PhotoViewModel>)result.Model).First().AlbumName);
        }
    }
}
