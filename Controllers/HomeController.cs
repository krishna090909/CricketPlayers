using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Project_Demo_1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Demo_1.Conrtollers
{
    public class HomeController : Controller
    {
        readonly PlayerInfoInterface _playerInfoObject;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(PlayerInfoInterface playerInfoInjection, IHostingEnvironment hostingEnvironment)
        {
            _playerInfoObject = playerInfoInjection;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index()
        {
            return View(); 
        }

        public ViewResult PlayersList()
        {
            CompleteViewModelData _completeModelData = new CompleteViewModelData();
            _completeModelData.ViewModelPageTitle = "View plage to all list players";            
            _completeModelData.GetAllPlayersList = _playerInfoObject.GetAllPlayersInfo();            

            return View("PlayersListView", _completeModelData);
        }

        public ViewResult PlayerInfo(int PlayerId)
        {
            CompleteViewModelData _completeModelData = new CompleteViewModelData();
            _completeModelData.ViewModelPageTitle = "View page to display Player personal information";
            _completeModelData.CompletePlayerInfo = _playerInfoObject.GetPlayerInfo(PlayerId);            

            return View("PlayerPersonalInfoView", _completeModelData);
        }

        [HttpGet]
        public ViewResult UpdatePlayerInfo(int PlayerId)
        {
            ViewData["PageTitle"] = "View page to Update Player personal info";
            PlayerInfo playerPersonalInfo = _playerInfoObject.GetPlayerInfo(PlayerId);

            return View("UpdatePlayerInfoView", playerPersonalInfo);
        }

        [HttpPost]
        public IActionResult UpdatePlayerInfo(PlayerInfo UpdatedPlayerInfo)
        {                                  
            _playerInfoObject.UpdateExistingPlayerInfo(UpdatedPlayerInfo, UpdatedPlayerInfo.PlayerId);

            return RedirectToAction("PlayerInfo", new { PlayerId = UpdatedPlayerInfo.PlayerId });
        }

        public IActionResult DeletePlayer(int PlayerId)
        {
            _playerInfoObject.DeleteExistingPlayerInfo(PlayerId);                        
            return RedirectToAction("PlayersList");
        }

        [HttpGet]
        public ViewResult AddNewPlayerToPlayerDetails()
        {
            return View("AddNewPlayerWithValidationFormView");
        }

        [HttpPost]
        public IActionResult AddNewPlayerToPlayerDetails(CompleteViewModelData NewPlayerInfo)
        {
            if (ModelState.IsValid)
            {
                string ImageUniqueFileName;
                string ImageUploadFolder;
                string PlayerImagePath;

                if (NewPlayerInfo.PlayerPhoto != null)
                {
                    ImageUniqueFileName = Guid.NewGuid().ToString() + "_" + NewPlayerInfo.PlayerPhoto.FileName;

                    ImageUploadFolder = Path.Combine(hostingEnvironment.WebRootPath , "images");

                    PlayerImagePath = Path.Combine(ImageUploadFolder, ImageUniqueFileName);

                    NewPlayerInfo.PlayerPhoto.CopyTo(new FileStream(PlayerImagePath, FileMode.Create));

                    NewPlayerInfo.CompletePlayerInfo.PlayerPhotopath = ImageUniqueFileName;

                }                

                _playerInfoObject.AddNewplayer(NewPlayerInfo.CompletePlayerInfo);
                return RedirectToAction("PlayersList");
            }

            return View("AddNewPlayerWithValidationFormView");

        }
    }
}
