using AlbumManager.Domain.Contracts.Integration;
using AlbumManager.Domain.Entities;
using AlbumManager.Domain.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AlbumManager.Service.Test
{
    public class PhotoServiceTest
    {
        private Mock<IPhotoRepository> _photoRepositoryMock;
        private Mock<IAlbumRepository> _albumRepositoryMock;

        public PhotoServiceTest()
        {
            _photoRepositoryMock = new Mock<IPhotoRepository>(MockBehavior.Strict);
            _albumRepositoryMock = new Mock<IAlbumRepository>(MockBehavior.Strict);
        }
        [Fact]
        public async Task ShouldReturnPhotoViewModel()
        {
            var photosMock = new List<Photo>()
            {
                new Photo()
                {
                    AlbumId = 1,
                    Id = 1,
                    ThumbnailUrl = "",
                    Title = "test",
                    Url = ""
                }
            };
            _photoRepositoryMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(photosMock);

            var albumsMock = new List<Album>()
            {
                new Album()
                {
                    Id = 1,
                    Title = "test",
                    UserId = 1
                }
            };
            _albumRepositoryMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(albumsMock);

            var service = new PhotoService(_photoRepositoryMock.Object, _albumRepositoryMock.Object);
            var photos = await service.GetPhotosAsync();
            Assert.IsType<List<PhotoViewModel>>(photos);
            _photoRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _albumRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task ShouldReturnTwoPhotoViewModelWhenHaveTwoPhotos()
        {

            var photosMock = new List<Photo>()
            {
                new Photo()
                {
                    AlbumId = 1,
                    Id = 1,
                    ThumbnailUrl = "",
                    Title = "test",
                    Url = ""
                },
                new Photo()
                {
                    AlbumId = 1,
                    Id = 2,
                    ThumbnailUrl = "",
                    Title = "test2",
                    Url = ""
                }
            };
            _photoRepositoryMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(photosMock);

            var albumsMock = new List<Album>()
            {
                new Album()
                {
                    Id = 1,
                    Title = "test",
                    UserId = 1
                }
            };
            _albumRepositoryMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(albumsMock);

            var service = new PhotoService(_photoRepositoryMock.Object, _albumRepositoryMock.Object);
            var photos = await service.GetPhotosAsync();
            _photoRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _albumRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            Assert.Equal(2, photos.Count);
        }
    }
}
