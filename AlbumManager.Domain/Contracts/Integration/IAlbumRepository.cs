using System.Collections.Generic;
using System.Threading.Tasks;
using AlbumManager.Domain.Entities;

namespace AlbumManager.Domain.Contracts.Integration
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetAllAsync();
    }
}