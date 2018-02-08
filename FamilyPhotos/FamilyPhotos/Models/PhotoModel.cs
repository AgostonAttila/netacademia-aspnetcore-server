using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Models
{
    public class PhotoModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        /// <summary>
        /// Ezt fogjuk db be menteni
        /// </summary>
        public byte[] Picture { get; set; }

        public IFormFile PictureFromBrowser { get; set; }        

        public string ContentType { get; set; }
    }
}
