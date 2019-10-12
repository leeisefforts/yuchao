using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;

namespace yuchao.Business.Admin
{
   public class GamerecordBLL
    {
        private IGamerecord IService = new Service.GamerecordService();

        public List<Gamerecord> GetAll(string openId)
        {
            return IService.GetAll(openId);
        }

        public bool Insert(Gamerecord gamerecord)
        {
            return IService.Insert(gamerecord);
        }

        public bool DeleteById(int id)
        {
            return IService.DeleteById(id);
        }

        public bool Update(Gamerecord gamerecord)
        {
            Gamerecord gamerecord1 = IService.GetById(gamerecord.Id);
            gamerecord1.GameTime = gamerecord.GameTime;
            gamerecord1.GameTime = gamerecord.GameTime;
            gamerecord1.IsTeamGame = gamerecord.IsTeamGame;
            gamerecord1.LoseId = gamerecord.LoseId;
            gamerecord1.RefereeId = gamerecord.RefereeId;
            gamerecord1.Status = gamerecord.Status;
            gamerecord1.WinId = gamerecord.WinId;            
            gamerecord1.OpenId = gamerecord.OpenId;            
            return IService.Update(gamerecord);

        }
    }
}
