using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.IService
{
   public interface IRanking
    {
        /// <summary>
        /// 获取申请单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Ranking Get(int Id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(Ranking entity);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(Ranking entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Dels(dynamic[] ids);

        Ranking GetByUserId(string userId);
    }
}
