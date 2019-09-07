using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.IService
{
   public interface IGamerecord
    {
        /// <summary>
        /// 获取全部段位
        /// </summary>
        /// <returns></returns>
        List<Gamerecord> GetAll();

        bool Insert(Gamerecord gamerecord);

        Gamerecord GetById(int id);

        bool DeleteById(int id);

        bool Update(Gamerecord gamerecord);
        Gamerecord GetByVenueId(string venueId);
    }
}
