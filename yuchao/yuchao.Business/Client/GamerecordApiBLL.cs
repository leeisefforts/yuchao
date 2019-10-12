using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model.Extends;
using yuchao.Service;

namespace yuchao.Business.Client
{
  public  class GamerecordApiBLL
    {
        //比赛
        private GamerecordService IService = new GamerecordService();
        private VenueService LService = new VenueService();
        private ScheduleRecordService SrService = new ScheduleRecordService();
        private UserServer UService = new UserServer();

        private OrderApiBLL orderApiBLL = new OrderApiBLL();

        public GamerecordExtends GetGamerecordInfoByVenueId(string venueId)
        {
            // 根据venueId获取Gamerecord
            Gamerecord gamerecord = IService.GetByVenueId(venueId);
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
            return gamerecordInfo;
        }
        //查询全部
        public List<GamerecordExtends> GetAll(string openId)
        {
            List<GamerecordExtends> list = new List<GamerecordExtends>();
            List < Gamerecord > res = IService.GetAll(openId);
            foreach (var item in res)
            {
                GamerecordExtends gamerecordInfo = new GamerecordExtends();
                Venue venue = LService.GetById(item.VenueId);
                gamerecordInfo.Id = item.Id;
                gamerecordInfo.CreateTime = item.CreateTime;
                gamerecordInfo.GameTime = item.GameTime;
                gamerecordInfo.IsTeamGame = item.IsTeamGame;
                gamerecordInfo.LoseId = item.LoseId;
                gamerecordInfo.RefereeId = item.RefereeId;
                gamerecordInfo.Status = item.Status;
                gamerecordInfo.VenueId = item.VenueId;
                gamerecordInfo.WinId = item.WinId;
                gamerecordInfo.AvePrice = venue.AvePrice;
                gamerecordInfo.VenueName = venue.VenueName;
                gamerecordInfo.Score = venue.Score;
                gamerecordInfo.VenueAddress = venue.VenueAddress;
                gamerecordInfo.VenueImg = venue.VenueImg;
                gamerecordInfo.OpenId = item.OpenId;
                list.Add(gamerecordInfo);

            }
            return list;
        }
        public bool CreateGame(string openId , JObject values) {

            int venueId = Convert.ToInt32(values["venueId"]);
            int days = Convert.ToInt32(values["days"]);
            string matchTime = values["matchTime"].ToString();

            User user = UService.GetByOpenId(openId);

            Order order = orderApiBLL.CreateOrder(openId, values);
            // 获取场馆下所有的场地


            // 判断当前是否存在正在匹配的人
            List<MatchGame> list = IService.GetMatchUser(matchTime, venueId);
            if (list.Count == 0)
            {
                MatchGame mg = new MatchGame() {
                    MatchDays = days,
                    MatchStatus = 1,
                    CreateTime =DateTime.Now,
                    MatchTime = matchTime ,
                    OpenId = openId,
                    VenueId = venueId
                };
                IService.AddMatchGame(mg);
                return false;
            }

            // 选择全天随机匹配
            if (days == 4)
            {
                Random r = new Random();
                int i = r.Next(0, list.Count);
                MatchGame mm = list[i];

                int siteId = GetMatchSite(venueId, days , matchTime);
                if (siteId == -1) return false;

                return true;
            }
            foreach (var item in list)
            {

            }

            return false;
        }

        public int GetMatchSite(int venueId, int days, string useTime) {
            List<Site> slist = LService.GetSiteById(venueId);
            List<ScheduledRecord> sr = SrService.MatchGame(venueId, useTime, days);
            foreach (var item in slist)
            {
                // 按时间顺序优先匹配
                switch (days)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }
            return -1;
        }
    }
}
