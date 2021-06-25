using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Data;
using Models;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // mapper profiler som används för dependancy injection för att därefter kunna komma åt datan i den lokala databasen

            CreateMap<HotelRoomDTO, HotelRoom>();
            CreateMap<HotelRoom , HotelRoomDTO>();

            CreateMap<HotelAmenity, HotelAmenityDTO>().ReverseMap();

            CreateMap<HotelPictures, ImagesDTO>().ReverseMap(); 


        }
    }
}
