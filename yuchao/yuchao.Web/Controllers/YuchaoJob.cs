using Pomelo.AspNetCore.TimedJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yuchao.Business.Client;
using yuchao.Entity;
using yuchao.Service;

namespace yuchao.Web.Controllers
{
    public class YuchaoJob: Job
    {
        private GamerecordService IService = new GamerecordService();
        private VenueService LService = new VenueService();
        private ClubServer CService = new ClubServer();
        private ScheduleRecordService SrService = new ScheduleRecordService();
        private UserServer UService = new UserServer();
        private OrderService OService = new OrderService();


        [Invoke(Begin = "2020-01-15 00:00", Interval = 10000 * 3600 * 24, SkipWhileExecuting = true)]
        public void MatchGame()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            List<MatchGame> list = IService.GetMatchList(date);
            string openId2 = string.Empty;
            foreach (var item in list)
            {            // 判断当前是否存在正在匹配的人
                List<MatchGame> glist = IService.GetMatchUser(item.MatchTime, item.VenueId, item.OpenId);
                if (list.Count == 0)
                {
                    continue;
                }
                List<int> ilist = new List<int>();
                User user = UService.GetByOpenId(item.OpenId);
                // 选择全天随机匹配
                if (item.MatchDays == 4)
                {
                    Random r = new Random();
                    int i = r.Next(0, list.Count);
                    MatchGame mm = list[i];
                    item.MatchStatus = 2;
                    mm.MatchStatus = 2;

                    User user2 = UService.GetByOpenId(mm.OpenId);
                    if (user2.LevelId != user.LevelId)
                    {
                        continue;
                    }
                    IService.UpdateMatchGame(mm);
                    openId2 = mm.OpenId;

                }
                else
                {
                    foreach (var oo in list)
                    {
                        if (item.MatchDays == oo.MatchDays)
                        {
                            item.MatchStatus = 2;
                            oo.MatchStatus = 2;
                            IService.UpdateMatchGame(item);

                            User user2 = UService.GetByOpenId(oo.OpenId); 
                            if (user2.LevelId != user.LevelId)
                            {
                                continue;
                            }
                            openId2 = item.OpenId;
                            break;
                        }

                    }
                }
                ilist = GetMatchSite(item.VenueId, item.MatchDays, item.MatchTime);

                ScheduledRecord sssssr = SrService.GetById(item.SId);
                sssssr.SiteId = ilist[0];
                sssssr.TimeId = ilist[1];
                SrService.Update(sssssr);

                Gamerecord gr = new Gamerecord()
                {
                    ScheduleRecordId = item.SId,
                    CreateTime = DateTime.Now,
                    SiteId = sssssr.SiteId,
                    VenueId = item.VenueId,
                    Status = 1,
                    IsTeamGame = 0,
                    OpenId = item.OpenId,
                    OpenId2 = openId2,
                    GameTime = item.MatchTime,
                    WinId = string.Empty,
                    LoseId = string.Empty,
                    ClubId = user.ClubId

                };
                IService.Insert(gr);

            }
        }

        [Invoke(Begin = "2020-01-15 00:30", Interval = 10000 * 3600 * 24, SkipWhileExecuting = true)]
        public void RefundPay()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            List<MatchGame> list = IService.GetMatchList(date);
            foreach (var item in list)
            {
                ScheduledRecord sr = SrService.GetById(item.SId);
                Order order = OService.GetBySId(item.SId);

                string orderSn = order.OrderSn;

                bool bb = BasicService.RefundPay(orderSn);

                item.MatchStatus = 3;
                IService.UpdateMatchGame(item);
            }
        }


        public List<int> GetMatchSite(int venueId, int days, string useTime)
        {

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
    }
}
