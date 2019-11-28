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

        public GamerecordReExtends GetGamerecordInfoByVenueId(string venueId)
        {
            // 根据venueId获取Gamerecord
            Gamerecord gamerecord = IService.GetByVenueId(venueId);
            GamerecordReExtends gamerecordInfo = new GamerecordReExtends();
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

                gamerecordInfo.OpenId2 = gamerecord.OpenId2;
            }
            return gamerecordInfo;
        }

        public List<GamerecordReExtends> GetGamerecordInfoByRe()
        {
            // 根据venueId获取Gamerecord
            List<Gamerecord> gamerecord = IService.GetGameAll();
            List<GamerecordReExtends> list = new List<GamerecordReExtends>();
            foreach (var item in gamerecord)
            {
                GamerecordReExtends gamerecordInfo = new GamerecordReExtends();
                var user1 = UService.GetByOpenId(item.OpenId);
                var user2 = UService.GetByOpenId(item.OpenId2);
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
                gamerecordInfo.OpenId2 = item.OpenId2;
                gamerecordInfo.OpenName1 = user1.NickName;
                gamerecordInfo.OpenName2 = user2.NickName;
                gamerecordInfo.Phone1 = user1.Tel;
                gamerecordInfo.Phone2 = user2.Tel;
                list.Add(gamerecordInfo);

            }
            return list;
        }


        //查询全部
        public List<GamerecordReExtends> GetAll(string openId)
        {
            List<GamerecordReExtends> list = new List<GamerecordReExtends>();
            List < Gamerecord > res = IService.GetAll(openId);
            foreach (var item in res)
            {
                GamerecordReExtends gamerecordInfo = new GamerecordReExtends();

                var user1 = UService.GetByOpenId(item.OpenId);
                var user2 = UService.GetByOpenId(item.OpenId2);
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
                gamerecordInfo.OpenId2 = item.OpenId2;
                gamerecordInfo.OpenName1 = user1.NickName;
                gamerecordInfo.OpenName2 = user2.NickName;
                gamerecordInfo.Phone1 = user1.Tel;
                gamerecordInfo.Phone2 = user2.Tel;
                list.Add(gamerecordInfo);

            }
            return list;
        }
        public Order CreateGame(string openId , JObject values) {

            int venueId = Convert.ToInt32(values["venueId"]);
            int days = Convert.ToInt32(values["days"]);
            string matchTime = values["matchTime"].ToString();
            string openId2 = string.Empty;
            User user = UService.GetByOpenId(openId);

            Order order = orderApiBLL.CreateOrder(openId, values);

            MatchGame mg = new MatchGame()
            {
                MatchDays = days,
                MatchStatus = 1,
                CreateTime = DateTime.Now,
                MatchTime = matchTime,
                OpenId = openId,
                VenueId = venueId

            };

            // 判断当前是否存在正在匹配的人
            List<MatchGame> list = IService.GetMatchUser(matchTime, venueId, openId);
            if (list.Count == 0)
            {
                IService.AddMatchGame(mg);
                return order;
            }
            List<int> ilist = new List<int>();
            // 选择全天随机匹配
            if (days == 4)
            {
                Random r = new Random();
                int i = r.Next(0, list.Count);
                MatchGame mm = list[i];
                mg.MatchStatus = 2;
                mm.MatchStatus = 2;
                IService.AddMatchGame(mg);
                IService.UpdateMatchGame(mm);
                openId2 = mm.OpenId;

            }
            else
            {
                foreach (var item in list)
                {
                    if (days == item.MatchDays)
                    {
                        mg.MatchStatus = 2;
                        item.MatchStatus = 2;
                        IService.AddMatchGame(mg);
                        IService.UpdateMatchGame(item);

                        openId2 = item.OpenId;
                        break;
                    }

                }
            }

            ilist = GetMatchSite(venueId, days, matchTime);
            if (ilist.Count == 0) return order;

            ScheduledRecord scheduledRecord = new ScheduledRecord()
            {
                OpenId = openId,
                CreateTime = DateTime.Now,
                SiteId = ilist[0],
                TimeId = ilist[1],
                UseTime = matchTime,
                VenueId = venueId,
                Week = 0,
                IsGame = 1
            };
            int c = SrService.InsertRId(scheduledRecord);

            Gamerecord gr = new Gamerecord()
            {
                ScheduleRecordId = c,
                CreateTime = DateTime.Now,
                SiteId = scheduledRecord.SiteId,
                VenueId = venueId,
                Status = 1,
                IsTeamGame = 0,
                OpenId = openId,
                OpenId2 = openId2,
                GameTime = matchTime
            };


            IService.Insert(gr);

            return order;
        }

        public List<int> GetMatchSite(int venueId, int days, string useTime) {

            List<int> list = new List<int>();
            List<Site> slist = LService.GetSiteById(venueId);
            List<ScheduledRecord> sr = SrService.MatchGame(venueId, useTime, days);

            foreach (var item in slist)
            {
                if (list.Count >= 2) break;
                // 按时间顺序优先匹配
                switch (days)
                {
                    case 1:
                        for (int i = 1; i <= 3; i++)
                        {
                            if (sr.FindIndex(ss => ss.TimeId == i) == -1)
                            {
                                list.Add(item.Id);
                                list.Add(i);
                                break;
                            }
                        }
                        break;
                    case 2:
                        for (int i = 4; i <= 8; i++)
                        {
                            if (sr.FindIndex(ss => ss.TimeId == i) == -1)
                            {
                                list.Add(item.Id);
                                list.Add(i);
                                break;
                            }
                        }
                        break;
                    case 3:
                        for (int i = 9; i <= 13; i++)
                        {
                            if (sr.FindIndex(ss => ss.TimeId == i) == -1)
                            {
                                list.Add(item.Id);
                                list.Add(i);
                                break;
                            }
                        }
                        break;
                    case 4:
                        for (int i = 1; i <= 13; i++)
                        {
                            if (sr.FindIndex(ss => ss.TimeId == i) == -1)
                            {
                                list.Add(item.Id);
                                list.Add(i);
                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return list;
        }

        public bool SetReferee(int id, int rid) {
            Gamerecord gr = IService.GetById(id);
            gr.RefereeId = rid;
            return IService.Update(gr);
        }


        public List<GamerecordReExtends> GetGameByReId(int id, int status) {

            // 根据venueId获取Gamerecord
            List<Gamerecord> gamerecord = IService.GetGameAllByReId(id, status);
            List<GamerecordReExtends> list = new List<GamerecordReExtends>();
            foreach (var item in gamerecord)
            {
                GamerecordReExtends gamerecordInfo = new GamerecordReExtends();
                var user1 = UService.GetByOpenId(item.OpenId);
                var user2 = UService.GetByOpenId(item.OpenId2);

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
                gamerecordInfo.OpenId2= item.OpenId2;
                gamerecordInfo.OpenName1 = user1.NickName;
                gamerecordInfo.OpenName2 = user2.NickName;
                gamerecordInfo.Phone1 = user1.Tel;
                gamerecordInfo.Phone2 = user2.Tel;
                list.Add(gamerecordInfo);

            }
            return list;
        }

        public GameDetail SetResult(JObject values) {

            GameDetail gd1 =  new GameDetail()
            {
                Id = Convert.ToInt32(values["id"]),
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                GId = Convert.ToInt32(values["gid"]),
                Point1 = Convert.ToInt32(values["point1"]),
                Point2 = Convert.ToInt32(values["point2"]),
                GameTime = Convert.ToInt32(values["gametime"]),
                Sort = Convert.ToInt32(values["sort"]),
                OpenId1 = values["openId1"].ToString(),
                OpenId2 = values["openId2"].ToString(),
                Status = 2,

            };

            IService.UpdateGameDetail(gd1); ;

            GameDetail gd = new GameDetail()
            {
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                GId = 0,
                Point1 = 0,
                Point2 = 0,
                GameTime = 0,
                OpenId1 = string.Empty,
                OpenId2 = string.Empty,
                Status = 1,
                Sort = 1
            };
            int id = IService.AddGameDetailRId(gd);
            gd.Id = id;
            return gd;
        }

        public GameDetail InitResult()
        {
            GameDetail gd = new GameDetail()
            {
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                GId = 0,
                Point1 = 0,
                Point2 = 0,
                GameTime = 0,
                OpenId1 = string.Empty,
                OpenId2 = string.Empty,
                Status = 1,
                Sort = 1
            };
            int id = IService.AddGameDetailRId(gd);
            gd.Id = id;
            return gd;
        }

        public object SetGameOver(JObject values) {

            int id = Convert.ToInt32(values["id"].ToString());
 
            string windId = values["winId"].ToString();
            string losId = values["losId"].ToString();
            Gamerecord gr = IService.GetById(id);
            if (gr == null)
            {
                return false;
            }
            gr.Status = 2;
            gr.WinId = windId;
            gr.LoseId = losId;

            return IService.Update(gr);


        }
        public List<GameDetail> GameDetailList(int id)
        {
            return IService.GdList(id);
        }

        
    }
}
