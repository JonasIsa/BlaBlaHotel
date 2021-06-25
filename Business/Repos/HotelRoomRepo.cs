using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repos.iRepos;
using DataAccess.Data;
using Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Business.Repos
{
    public class HotelRoomRepo : iHotelRoomRepo
    {
        // Dependancy Injection

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public HotelRoomRepo(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO)
        {
            HotelRoom hotelroom = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO);
            hotelroom.CreatedDate = DateTime.Now;
            hotelroom.CreatedBy = "";
            var addedHotelRoom = await _db.HotelRooms.AddAsync(hotelroom);
            await _db.SaveChangesAsync();
            return _mapper.Map<HotelRoom, HotelRoomDTO>(addedHotelRoom.Entity);
        }

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var roomDetail = await _db.HotelRooms.FindAsync(roomId);
            if(roomDetail != null)
            {
                var allimages = await _db.Pictures.Where(x => x.RoomId == roomId).ToListAsync();

                _db.HotelRooms.Remove(roomDetail);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRoom()
        {
            try 
            {
                IEnumerable<HotelRoomDTO> hotelRoomDTOs = 
                    _mapper.Map<IEnumerable<HotelRoom>,IEnumerable<HotelRoomDTO>>
                    (_db.HotelRooms.Include(x => x.Images));

                return hotelRoomDTOs;
            }
            catch(Exception e) 
            { return null; }
        }


        public async Task<HotelRoomDTO> GetHotelRoom(int roomId)
        {
            try 
            {
                HotelRoomDTO Hotelroom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                    await _db.HotelRooms.Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == roomId));

                return Hotelroom;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDTO> IsRoomUnique(string name, int roomId=0)
        {
            try
            {
                if (roomId == 0)
                {
                    HotelRoomDTO hotelroom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                     await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));

                    return hotelroom;
                }
                else
                {
                    HotelRoomDTO hotelroom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                                        await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()
                                        && x.Id!=roomId));

                    return hotelroom;
                }



            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO)
        {
            try
            {
                if (roomId == hotelRoomDTO.Id)
                {
                    var roomDetails = await _db.HotelRooms.FindAsync(roomId);
                    var room = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO, roomDetails);
                    room.UpdatedBy = "";
                    room.UpdatedDate = DateTime.Now;
                    var updaterRoom = _db.HotelRooms.Update(room);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<HotelRoom, HotelRoomDTO>(updaterRoom.Entity);
                    

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

