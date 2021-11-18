using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Rooms
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int SeatsNumber { get; set; }

        public List<Sessions> Sessions { get; set; }
    }
}

