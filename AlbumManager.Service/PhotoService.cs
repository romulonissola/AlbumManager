using AlbumManager.Domain.Contracts.Integration;
using AlbumManager.Domain.Contracts.Service;
using AlbumManager.Domain.ViewModels;
using AlbumManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumManager.Service
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IAlbumRepository _albumRepository;
        public PhotoService(IPhotoRepository photoRepository, 
                            IAlbumRepository albumRepository)
        {
            _photoRepository = photoRepository;
            _albumRepository = albumRepository;
        }
        public async Task<List<PhotoViewModel>> GetPhotosAsync()
        {
            var albums = await _albumRepository.GetAllAsync();
            var photos = await _photoRepository.GetAllAsync();
            return (from photo in photos
                    join album in albums on photo.AlbumId equals album.Id
                    select new PhotoViewModel()
                    {
                        AlbumName = album.Title,
                        Title = photo.Title,
                        Url = photo.Url,
                        ThumbnailUrl = photo.ThumbnailUrl
                    }).ToList();
        }
    }
}
