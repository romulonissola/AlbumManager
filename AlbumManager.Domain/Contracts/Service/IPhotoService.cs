using AlbumManager.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlbumManager.Domain.Contracts.Service
{
    public interface IPhotoService
    {
        Task<List<PhotoViewModel>> GetPhotosAsync();
    }
}
