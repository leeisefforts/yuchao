using System;
using System.Collections.Generic;
using System.IO;
using yuchao.Entity;
using yuchao.Model.Extends;
using yuchao.Service;


namespace yuchao.Business.Admin
{
    public class ClubBLL
    {
        public ClubServer IService = new ClubServer();
        public UserServer Uervice = new UserServer();
        public GamerecordService GService = new GamerecordService();
        private VenueService LService = new VenueService();

        
        // 查询      
        public Club GetById(int id)
        {
            return IService.Get(id);
        }

        // 增加
        public int Insert(Club entity)
        {

            List<ClubClose> ccList = IService.GetCC(entity.OpenId);
            foreach (var item in ccList)
            {
                DateTime dt1 = DateTime.Now;
                DateTime dt2 = DateTime.Parse(item.CloseTime);
                int Year = dt2.Year - dt1.Year;

                int Month = (dt2.Year - dt1.Year) * 12 + (dt2.Month - dt1.Month);
                if (Month >=1)
                {
                    return -1;
                }

            }

            entity.ClubLogo = Base64ToFileAndSave(entity.ClubLogo);
            int id =  IService.AddReturnId(entity);
            User user = Uervice.GetByOpenId(entity.OpenId);
            user.ClubId = id;

            Uervice.Update(user);
            return id;
        }

        public string Base64ToFileAndSave(string strInput)
        {
            string path = @"C:\\inetpub\\wwwroot\\yc_admin\\images\\";
            string fileName = DateTime.Now.ToFileTime().ToString() + ".png";
            string filePath = path + fileName;
            try
            {
                byte[] buffer = Convert.FromBase64String(strInput);
                FileStream fs = new FileStream(filePath, FileMode.CreateNew);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return fileName;
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
