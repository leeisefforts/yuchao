using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.IService
{
    public interface ILevel
    {
        /// <summary>
        /// 获取全部段位
        /// </summary>
        /// <returns></returns>
        List<Level> GetAll(); 
    }
}
