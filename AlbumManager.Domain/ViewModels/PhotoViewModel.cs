using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumManager.Domain.ViewModels
{
    public class PhotoViewModel
    {
        public string Title { get; set; }
        public string AlbumName { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
