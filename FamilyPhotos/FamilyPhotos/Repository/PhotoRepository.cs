using FamilyPhotos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Repository
{
    public class PhotoRepository
    {
        //private List<PhotoModel> data = new List<PhotoModel>() { new PhotoModel() {Id=1,Title = "Ez egy kep" } };

            //Ez csak fejlesztői környezetben jó,nem szálbiztos
        private List<PhotoModel> data = new List<PhotoModel>();

        public IEnumerable<PhotoModel> GetAllPhotos()
        {
            return data;
        }

        public PhotoModel GetPicture(int photoId)
        {
            return data.SingleOrDefault(p => p.Id == photoId);
        }

        //csak DEMO
        public void AddPhoto(PhotoModel model)//Itt az MVC modelbindere a bejövő paramétereket egyezteti a várt osztály propertyjeivel
        {
            data.Add(model);
        }
    }
}
