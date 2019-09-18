using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.Model.Extends;
using yuchao.Service;

namespace yuchao.Business.Client
{
    public class RankingApiBLL
    {
        //排名
        private RankingServer IService = new RankingServer();
        private UserServer LService = new UserServer();

        public RankingExtends GetRankingInfoByUserId(string userId)
        {
            // 根据userId获取Ranking
            Ranking ranking = IService.GetByUserId(userId);
            RankingExtends rankingInfo = new RankingExtends();
            if (ranking != null)
            {
                rankingInfo.Id = ranking.Id;
                rankingInfo.UserId = ranking.UserId;
                rankingInfo.Rank = ranking.Rank;
                rankingInfo.NickName = LService.GetById(ranking.UserId).NickName;
                rankingInfo.Language = LService.GetById(ranking.UserId).Language;
                rankingInfo.Gender = LService.GetById(ranking.UserId).Gender;
                rankingInfo.AvatarUrl = LService.GetById(ranking.UserId).AvatarUrl;
                rankingInfo.Country = LService.GetById(ranking.UserId).Country;
                rankingInfo.City = LService.GetById(ranking.UserId).City;
                rankingInfo.Province = LService.GetById(ranking.UserId).Province;
                rankingInfo.OpenId = LService.GetById(ranking.UserId).OpenId;
                rankingInfo.LevelId = LService.GetById(ranking.UserId).LevelId;
                rankingInfo.CoinNum = LService.GetById(ranking.UserId).CoinNum;
                rankingInfo.TotalGame = LService.GetById(ranking.UserId).TotalGame;
                rankingInfo.Reputation = LService.GetById(ranking.UserId).Reputation;
                rankingInfo.IsReferee = LService.GetById(ranking.UserId).IsReferee;
                rankingInfo.Status = LService.GetById(ranking.UserId).Status;

            }
            return rankingInfo;
        }
    }
}
