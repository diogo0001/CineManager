using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Sessions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SessionId { get; set; }
        public DateTime IniTime { get; set; }
        public DateTime EndTime { get; set; }
        public float TicketPrice { get; set; }
        public string Animation { get; set; }
        public string Audio { get; set; }

        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public Movies Movie { get; set; }
        public Rooms Room { get; set; }
    }
}

