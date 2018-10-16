using System.Threading.Tasks;

namespace AlbumManager.Domain.Contracts.Integration.Utils
{
    public interface IHttpClientWrapper
    {
        Task<T> GetAsync<T>(string path);
    }
}