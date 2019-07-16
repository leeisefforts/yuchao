using System;
using yuchao.Entity;

namespace yuchao.IService
{
    public interface IRefereeApply
    {
        /// <summary>
        /// 获取申请单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RefereeApplyEntity Get(int id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(RefereeApplyEntity entity);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(RefereeApplyEntity entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Dels(dynamic[] ids);

    }
}
