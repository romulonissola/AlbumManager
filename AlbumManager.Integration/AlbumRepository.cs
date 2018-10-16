using AlbumManager.Domain.Entities;
using AlbumManager.Domain.Contracts.Integration.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlbumManager.Domain.Contracts.Integration;

namespace AlbumManager.Integration
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        public AlbumRepository(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }
        public Task<List<Album>> GetAllAsync()
        {
            var path = "albums";
            return _httpClientWrapper.GetAsync<List<Album>>(path);
        }
    }
}
