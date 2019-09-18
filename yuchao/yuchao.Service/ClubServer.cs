using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
   public class ClubServer: BaseDb, IClub
    {
        public SimpleClient<Club> rdb = new SimpleClient<Club>(BaseDb.GetClient());
        //查询
        public Club Get(int Id)
        {
            return rdb.GetSingle(p => p.Id == Id);
        }
        //增加
        public bool Add(Club entity)
        {
            return rdb.Insert(entity);
        }
        //修改
        public bool Update(Club entity)
        {
            return rdb.Update(entity);
        }
        //删除
        public bool Dels(dynamic[] ids)
        {
            return rdb.DeleteByIds(ids);
            
        }

        
    }
}
