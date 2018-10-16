using AlbumManager.Domain.Entities;
using AlbumManager.Domain.Contracts.Integration.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlbumManager.Domain.Contracts.Integration;

namespace AlbumManager.Integration
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        public PhotoRepository(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }
        public Task<List<Photo>> GetAllAsync()
        {
            var path = "photos";
            return _httpClientWrapper.GetAsync<List<Photo>>(path);
        }
    }
}
