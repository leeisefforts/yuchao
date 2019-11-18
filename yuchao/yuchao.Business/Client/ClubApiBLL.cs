using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.Model.Extends;
using yuchao.Service;

namespace yuchao.Business.Client
{
   public class ClubApiBLL
    {
        //添加俱乐部
        private ClubServer  clubServer= new ClubServer();

        private UserServer uServer = new UserServer();

        public void addClub(Entity.Club club)
        {
            clubServer.Add(club);
        }
        public List<Club> GetList(string keyword) {
            return clubServer.GetList(keyword);
        }

        public Club GetById(int id) {
            return clubServer.Get(id);
        }

        public Club GetByOpenId(string openId)
        {
            return clubServer.GetByOpenId(openId);
        }

        
        public bool Apply(int clubId, string openId) {
            User user = uServer.GetByOpenId(openId);
            user.ClubId = clubId;
            return uServer.Update(user);

        }

        public bool Exit(int clubId, string openId)
        {
            User user = uServer.GetByOpenId(openId);
            user.ClubId = 0;
            return uServer.Update(user);

        }
    }
}
