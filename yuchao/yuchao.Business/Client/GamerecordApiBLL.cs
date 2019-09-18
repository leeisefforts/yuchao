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

        public GamerecordExtends GetGamerecordInfoByVenueId(string venueId)
        {
            // 根据OpenId获取User
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
                list.Add(gamerecordInfo);

            }
            return list;
        }


        public bool CreateGame(string openId , JObject values) {

            int venueId = Convert.ToInt32(values["venueId"]);
            int siteId = Convert.ToInt32(values["siteId"]);

            List<ScheduledRecord> sr = SrService.GetByVenueId(venueId, siteId);
            
            foreach (var item in sr)
            {

            }
            return false;
        }
    }
}
