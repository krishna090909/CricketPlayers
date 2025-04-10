using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Demo_1.Models
{
    public class SQLPlayerRepository : PlayerInfoInterface
    {
        private readonly AppDbContext context;

        public SQLPlayerRepository(AppDbContext context)
        {
            this.context = context;
        }
        
        public PlayerInfo GetPlayerInfo(int PlayerId)
        {            
            PlayerInfo RequestedPlayerInfo = context.Players.Find(PlayerId);

            return RequestedPlayerInfo;

        }

        public IEnumerable<PlayerInfo> GetAllPlayersInfo()
        {
            return context.Players;
        }

        public PlayerInfo AddNewplayer(PlayerInfo NewPlayerData)
        {
            context.Players.Add(NewPlayerData);
            context.SaveChanges();

            return NewPlayerData;
        }

        public PlayerInfo UpdateExistingPlayerInfo(PlayerInfo ExistingPlayerUpdatedData, int PlayerId)
        {
            ExistingPlayerUpdatedData.PlayerId = PlayerId;
            var UpdatedPlayerInfo = context.Players.Attach(ExistingPlayerUpdatedData);            
            UpdatedPlayerInfo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return ExistingPlayerUpdatedData;

        }

        public PlayerInfo DeleteExistingPlayerInfo(int PlayerId)
        {
            PlayerInfo DeletingPlayerInfo = context.Players.Find(PlayerId);
            if (DeletingPlayerInfo != null)
            {                
                context.Players.Remove(DeletingPlayerInfo);
                context.SaveChanges();                                
            }

            return DeletingPlayerInfo;
        }
    }
}
