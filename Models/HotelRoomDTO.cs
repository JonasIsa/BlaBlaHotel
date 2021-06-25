using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HotelRoomDTO
    {
        //Data transfer object för att kunna komma åt den lokala databasen

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter room name")]
        public string Name { get; set; }
        public int Occupancy { get; set; }
        
        [Required]
        [Range(200, 3000, ErrorMessage = "Max rate 3000, min rate 200")]
        public double RegularRate { get; set; }

        public string Details { get; set; }
        public string m2 { get; set; }
        public virtual ICollection<ImagesDTO> Images { get; set; }

        public List<string> imageURLs { get; set; }
    }
}
