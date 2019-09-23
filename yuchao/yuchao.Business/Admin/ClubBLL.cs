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
        // 查询      
        public Club GetById(int id)
        {
            return IService.Get(id);
        }

        // 增加
        public string Insert(string path ,Club entity)
        {
            bool isAdd =  IService.Add(entity);
            if (isAdd)
            {
                string url = string.Format("{0}/api/clubApplyApi/{1}/{2}", path, entity.Id);
                return BasicService.InitQrCode(url);
            }
            else {
                return "false";
            }
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
