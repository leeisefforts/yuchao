using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;

namespace yuchao.Business.Admin
{
   public class MatchgameBLL
    {
        private IMatchgame IService = new Service.MatchgameService();

        public List<MatchGame> GetAll()
        {
            return IService.GetAll();
        }

        public bool DeleteById(int id)
        {
            return IService.DeleteById(id);
        }
    }
}
