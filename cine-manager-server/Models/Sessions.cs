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

        //Foreign
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public Movies Movie { get; set; }
        public Rooms Room { get; set; }
    }
}

/*

date:'14/11/2021',
ini_time:'17:00',
end_time:'18:30',
ticket_price:'30,00',
animation:'3D',
audio:'Legendado',
movie:'Senhor dos Anéis',
room:'Sala 03'
 */