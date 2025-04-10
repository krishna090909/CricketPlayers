using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Demo_1.Models
{
    public class PlayerInfo
    {       
        [Key]
        public int PlayerId { get; set; }
        
        [Required]
        public string PlayerName { get; set; }

        [Required]
        public int? PlayerAge { get; set; }

        [Required]
        public string PlayerAddress { get; set; }

        public int PlayerScore { get; set; }

        public int PlayerNoOfMatches { get; set; }  

        public string PlayerPhotopath { get; set; }
    }
}
