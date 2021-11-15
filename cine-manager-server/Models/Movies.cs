using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Movies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        // Relationship
        //public string SessionUUID { get; set; }
        public List<Sessions> Sessions { get; set; }
    }
}

/*
title:'Iron Man',
img_url:'www.image.com',
description:'Tony Stark inventou armadura ...',
duration:145,
 */