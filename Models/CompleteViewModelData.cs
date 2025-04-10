using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Demo_1.Models
{
    public class CompleteViewModelData
    {
        public PlayerInfo CompletePlayerInfo { get; set; }

        public IEnumerable<PlayerInfo> GetAllPlayersList { get; set; }

        public string ViewModelPageTitle { get; set; }  
        
        public IFormFile PlayerPhoto { get; set; }
    }
}
