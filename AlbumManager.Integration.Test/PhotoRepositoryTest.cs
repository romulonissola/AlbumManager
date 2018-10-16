using AlbumManager.Integration.Utils;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AlbumManager.Integration.Test
{
    public class PhotoRepositoryTest
    {
        private const string BASE_ADDRESS = "http://jsonplaceholder.typicode.com";

        [Fact]
        public async Task ShouldReturnPhotos()
        {
            var httpClientWrapper = new HttpClientWrapper(BASE_ADDRESS);
            var repository = new PhotoRepository(httpClientWrapper);
            var entities = await repository.GetAllAsync();
            Assert.True(entities.Count > 0);
        }
    }
}
