using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.Model.Extends;
using yuchao.Service;

namespace yuchao.Business.Admin
{
   public class RankingBLL
    {
        public RankingServer IService = new Service.RankingServer();
        // 查询      
        public Ranking GetById(int id)
        {
            return IService.Get(id);
        }
        // 增加
        public bool Insert(Ranking entity)
        {
            return IService.Add(entity);
        }
        // 删除
        public object DeleteById(dynamic[] ids)
        {
            return IService.Dels(ids);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public bool Update(Ranking ranking)
        {
            Ranking ranking1 = IService.Get(ranking.Id);
            ranking1.UserId = ranking.UserId;
            ranking1.Rank = ranking.Rank;
            return IService.Update(ranking);
        }

       
    }
}
