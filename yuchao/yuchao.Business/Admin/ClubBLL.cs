using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Service;


namespace yuchao.Business.Admin
{
    public class ClubBLL
    {
        public ClubServer IService = new Service.ClubServer();
        public UserServer Uervice = new Service.UserServer();
        // 查询      
        public Club GetById(int id)
        {
            return IService.Get(id);
        }

        // 增加
        public bool Insert(string path ,Club entity)
        {
            int id =  IService.AddReturnId(entity);
            User user = Uervice.GetByOpenId(entity.OpenId);
            user.ClubId = id;
            return Uervice.Update(user);
        }
        public List<User> GetClubUser(int clubId)
        {
            List<User> list = Uervice.GetByClubId(clubId);
            return list;
        }
        // 删除
        public object DeleteById(dynamic[] ids)
        {
            return IService.Dels(ids);
        }

        //修改
        public bool Update(Club club)
        {
            Club club1 = IService.Get(club.Id);
            club1.ClubName = club.ClubName;
            club1.ClubCity = club.ClubCity;
            club1.ClubArea = club.ClubArea;
            club1.ClubDesc = club.ClubDesc;
            club1.ClubLogo = club.ClubLogo;
            club1.CreateTime = club.CreateTime;
            club1.Status = club.Status;
            return IService.Update(club);
        }
    }
}
