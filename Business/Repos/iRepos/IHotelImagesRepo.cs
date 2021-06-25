using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Business.Repos.iRepos
{
    public interface IHotelImagesRepo
    {
        public Task<int> CreateHotelRoomImage(ImagesDTO images);
        public Task<int> DeleteHotelRoomImageByImageId(int imageID);
        public Task<int> DeleteHotelRoomImageByRoomId(int roomId);
        public Task<int> DeleteHotelRoomImageByImageUrl(string imageURL);

        public Task<IEnumerable<ImagesDTO>> GetHotelRoomImages(int roomId);


    }
}
