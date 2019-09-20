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
        private LevelService LlService = new LevelService();

        public RankingExtends GetRankingInfoByUserId(string userId)
        {
            // 根据userId获取Ranking
            Ranking ranking = IService.GetByUserId(userId);
            User user = LService.GetByOpenId(userId);
            RankingExtends rankingInfo = new RankingExtends();
            if (ranking != null)
            {
                rankingInfo.Id = ranking.Id;
                rankingInfo.UserId = ranking.UserId;
                rankingInfo.Rank = ranking.Rank;
                rankingInfo.AvatarUrl = user.AvatarUrl;
                rankingInfo.City = user.City;
                rankingInfo.Country = user.Country;
                rankingInfo.Province = user.Province;
                rankingInfo.NickName = user.NickName;
                rankingInfo.LevelName = LlService.GetById(user.LevelId).LevelName;
            }
            return rankingInfo;
        }
        public List<RankingExtends> GetAllRanking() {
            List<Ranking> list = IService.GetList();
            List<RankingExtends> result = new List<RankingExtends>();
            foreach (var item in list)
            {
                RankingExtends rankingInfo = new RankingExtends();
                User user = LService.GetByOpenId(item.UserId);
                rankingInfo.Id = item.Id;
                rankingInfo.UserId = item.UserId;
                rankingInfo.Rank = item.Rank;
                rankingInfo.AvatarUrl = user.AvatarUrl;
                rankingInfo.City = user.City;
                rankingInfo.Country = user.Country;
                rankingInfo.Province = user.Province;
                rankingInfo.NickName = user.NickName;
                rankingInfo.LevelName = LlService.GetById(user.LevelId).LevelName;

                result.Add(rankingInfo);
            }
            return result;
        }
    }
}
