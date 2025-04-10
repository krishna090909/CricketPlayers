using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Demo_1.Models
{
    public class PlayerPersonalInfo : PlayerInfoInterface
    {
        private List<PlayerInfo> _PlayersDetails;

        public PlayerPersonalInfo()
        {
            _PlayersDetails = new List<PlayerInfo>()
            {
                new PlayerInfo() { PlayerId=1 ,PlayerName = "Krishna", PlayerAge = 24, PlayerAddress = "Bagyanagaram"},
                new PlayerInfo() { PlayerId=2 ,PlayerName = "Surya", PlayerAge = 25, PlayerAddress = "Nepal"},
                new PlayerInfo() { PlayerId=3 ,PlayerName = "Ali", PlayerAge = 26, PlayerAddress = "Austarlia"},
                new PlayerInfo() { PlayerId=4 ,PlayerName = "Sreekar", PlayerAge = 27, PlayerAddress = "Mexico"},
            };
        }

        public PlayerInfo GetPlayerInfo(int PlayerId)
        {
            return _PlayersDetails.First(Details => Details.PlayerId == PlayerId);
        }

        public IEnumerable<PlayerInfo> GetAllPlayersInfo()
        {
            return _PlayersDetails;
        }

        public PlayerInfo AddNewplayer(PlayerInfo NewPlayerData)
        {
            _PlayersDetails.Add(NewPlayerData);
            return NewPlayerData;
        }

        public PlayerInfo UpdateExistingPlayerInfo(PlayerInfo ExistingPlayerUpdatedData, int PlayerId)
        {
            PlayerInfo UpdatedPlayerInfo = _PlayersDetails.First(Details => Details.PlayerId == ExistingPlayerUpdatedData.PlayerId);
            if (UpdatedPlayerInfo != null)
            {
                UpdatedPlayerInfo.PlayerName = ExistingPlayerUpdatedData.PlayerName;
                UpdatedPlayerInfo.PlayerAge = ExistingPlayerUpdatedData.PlayerAge;
                UpdatedPlayerInfo.PlayerAddress = ExistingPlayerUpdatedData.PlayerAddress;
            }

            return UpdatedPlayerInfo;
        }

        public PlayerInfo DeleteExistingPlayerInfo(int PlayerId)
        {
            PlayerInfo DeletedPlayerInfo = _PlayersDetails.First(Details => Details.PlayerId == PlayerId);
            if (DeletedPlayerInfo != null)
            {
                _PlayersDetails.Remove(DeletedPlayerInfo);
            }

            return DeletedPlayerInfo;
        }
    }
}
