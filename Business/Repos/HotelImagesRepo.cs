using AutoMapper;
using Business.Repos.iRepos;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repos
{
    public class HotelImagesRepo : IHotelImagesRepo
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public HotelImagesRepo(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<int> CreateHotelRoomImage(ImagesDTO imageDTO)
        {
            var image = _mapper.Map<ImagesDTO, HotelPictures>(imageDTO);
            await _db.Pictures.AddAsync(image);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByImageId(int imageID)
        {
            var image = await _db.Pictures.FindAsync(imageID);
            _db.Pictures.Remove(image);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByImageUrl(string imageURL)
        {
            var allImages = await _db.Pictures.FirstOrDefaultAsync
                (x => x.PictureURL.ToLower() == imageURL.ToLower());
            _db.Pictures.Remove(allImages);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByRoomId(int roomId)
        {
            var imageList = await _db.Pictures.Where(x=>x.RoomId== roomId).ToListAsync();
            _db.Pictures.RemoveRange(imageList);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ImagesDTO>> GetHotelRoomImages(int roomId)
        {
            return _mapper.Map<IEnumerable<HotelPictures>, IEnumerable<ImagesDTO>>(
            await _db.Pictures.Where(x => x.RoomId == roomId).ToListAsync());

        }
    }
}
