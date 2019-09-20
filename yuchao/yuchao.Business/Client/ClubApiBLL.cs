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

        public void addClub(Entity.Club club)
        {
            clubServer.Add(club);
        }
        public List<Club> GetList(string keyword) {
            return clubServer.GetList(keyword);
        }
    }
}
