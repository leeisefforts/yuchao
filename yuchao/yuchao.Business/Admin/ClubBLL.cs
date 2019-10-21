using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model.Extends;
using yuchao.Service;


namespace yuchao.Business.Admin
{
    public class ClubBLL
    {
        public ClubServer IService = new Service.ClubServer();
        public UserServer Uervice = new Service.UserServer();
        public GamerecordService GService = new Service.GamerecordService();
        private VenueService LService = new VenueService();
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
        public Dictionary<string, object> GetClubUser(int clubId)
        {
            List<User> list = Uervice.GetByClubId(clubId);
            List<Gamerecord> glist = GService.GetByClubId(clubId);
            List<GamerecordExtends> gglist = new List<GamerecordExtends>();
            foreach (var gamerecord in glist)
            {
                GamerecordExtends gamerecordInfo = new GamerecordExtends();
                if (gamerecord != null)
                {
                    gamerecordInfo.Id = gamerecord.Id;
                    gamerecordInfo.CreateTime = gamerecord.CreateTime;
                    gamerecordInfo.GameTime = gamerecord.GameTime;
                    gamerecordInfo.IsTeamGame = gamerecord.IsTeamGame;
                    gamerecordInfo.LoseId = gamerecord.LoseId;
                    gamerecordInfo.RefereeId = gamerecord.RefereeId;
                    gamerecordInfo.Status = gamerecord.Status;
                    gamerecordInfo.VenueId = gamerecord.VenueId;
                    gamerecordInfo.WinId = gamerecord.WinId;
                    gamerecordInfo.AvePrice = LService.GetById(gamerecord.VenueId).AvePrice;
                    gamerecordInfo.VenueName = LService.GetById(gamerecord.VenueId).VenueName;
                    gamerecordInfo.Score = LService.GetById(gamerecord.VenueId).Score;
                    gamerecordInfo.VenueAddress = LService.GetById(gamerecord.VenueId).VenueAddress;
                    gamerecordInfo.VenueImg = LService.GetById(gamerecord.VenueId).VenueImg;
                }
                gglist.Add(gamerecordInfo);
            }
            ClubTotal tlist = IService.GetClubTotalByClubId(clubId);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("1", list);
            dic.Add("2", gglist);
            dic.Add("3", tlist);
            return dic;
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
