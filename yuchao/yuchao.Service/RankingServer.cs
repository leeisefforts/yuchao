using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
   public class RankingServer : BaseDb, IRanking
    {
        public SimpleClient<Ranking> rdb = new SimpleClient<Ranking>(BaseDb.GetClient());
        //查询
        public Ranking Get(int Id)
        {
            return rdb.GetSingle(p => p.Id == Id);
        }
        //增加
        public bool Add(Ranking entity)
        {
            return rdb.Insert(entity);
        }
        //修改
        public bool Update(Ranking entity)
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
