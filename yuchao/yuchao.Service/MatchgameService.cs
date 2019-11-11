using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
   public class MatchgameService: BaseDb, IMatchgame
    {
        public SimpleClient<MatchGame> rdb = new SimpleClient<MatchGame>(BaseDb.GetClient());
        

        public List<MatchGame> GetAll()
        {
            return rdb.GetList();
        }
        public bool DeleteById(int id)
        {
            return rdb.DeleteById(id);
        }
    }
}
