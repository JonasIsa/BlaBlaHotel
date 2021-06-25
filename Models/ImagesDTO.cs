using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ImagesDTO
    {
        //Data transfer object för att kunna komma åt den lokala databasen

        public int Id { get; set; }
        public int RoomId { get; set; }
        public string PictureURL { get; set; } 
    }
}
