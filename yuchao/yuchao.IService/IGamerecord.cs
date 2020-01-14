using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.IService
{
   public interface IGamerecord
    {

        List<Gamerecord> GetAll(string openId);

        bool Insert(Gamerecord gamerecord);

        Gamerecord GetById(int id);

        Gamerecord GetBySId(int sid);

        bool DeleteById(int id);

        bool Update(Gamerecord gamerecord);

        Gamerecord GetByVenueId(string venueId);

        List<Gamerecord> GetClubGame(int clubId);

        List<TeamGameDetail> GetByOpenId(string openId);
    }
}
