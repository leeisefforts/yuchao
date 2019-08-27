using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Model;

namespace yuchao.Service
{
   public class ClubServer: BaseDb, IClub
    {
        public SimpleClient<Club> rdb = new SimpleClient<Club>(BaseDb.GetClient());

        public Club Get(int id)
        {
            return rdb.GetSingle(p => p.ApplyUserId == id);
        }

        public bool Add(Club entity)
        {
            return rdb.Insert(entity);
        }

        public bool Update(Club entity)
        {
            return rdb.Update(entity);
        }

        public bool Dels(dynamic[] ids)
        {
            return rdb.DeleteByIds(ids);
        }
    }
}
