using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaHotel_Server.Model
{
    public class BlazorRoom

    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public Double Price { get; set; }
        public bool Active { get; set; }
        public List<BlazorRoomProp> RoomProps { get; set; }
    }
}
