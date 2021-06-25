using Business.Repos.iRepos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaHotel_Api.Controllers
{
    //med hjälp av dependancy injection och våra repositories lyckade vi att skapa en funktion som hämtar alla rummen som är registrerade till en Api.

    [Route("api/[controller]")]
    public class HotelRoomController : Controller
    { 
        
        
            public readonly iHotelRoomRepo _hotelRoomRepo;

        public HotelRoomController(iHotelRoomRepo hotelRoomRepo)
        {
            _hotelRoomRepo = hotelRoomRepo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetHotelRooms()
        {
            var ShowRooms = await _hotelRoomRepo.GetAllHotelRoom();
            return Ok(ShowRooms);
        }


        
    }
}
