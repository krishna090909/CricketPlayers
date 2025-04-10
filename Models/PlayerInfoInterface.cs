using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Demo_1.Models
{
    public interface PlayerInfoInterface
    {
        PlayerInfo GetPlayerInfo(int PlayerId);
        IEnumerable<PlayerInfo> GetAllPlayersInfo();

        PlayerInfo AddNewplayer(PlayerInfo NewPlayerData);

        PlayerInfo UpdateExistingPlayerInfo(PlayerInfo ExistingPlayerUpdatedData, int PlayerId);

        PlayerInfo DeleteExistingPlayerInfo(int PlayerId);
        
    }
}
