using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.Model.Extends;
using yuchao.Service;

namespace yuchao.Business.Client
{
    public class UserApiBLL
    {
        //个人基本信息
        private UserServer IService = new UserServer();
        private LevelService LService = new LevelService();
        private RankingServer RService = new RankingServer();
        

        public UserExtends GetUserInfoByOpenId(string openId) {
            // 根据OpenId获取User
            User user = IService.GetByOpenId(openId);
            UserExtends userInfo = new UserExtends();
            if (user!= null)
            {

                userInfo.Id = user.Id;
                userInfo.IsReferee = user.IsReferee;
                userInfo.AvatarUrl = user.AvatarUrl;
                userInfo.City = user.City;
                userInfo.Status = user.Status;
                userInfo.CoinNum = user.CoinNum;
                userInfo.Country = user.Country;
                userInfo.Gender = user.Gender;
                userInfo.Language = user.Language;
                userInfo.LevelId = user.LevelId;
                userInfo.LevelName = user.LevelId ==0? "无段位" : LService.GetById(user.LevelId).LevelName;
                userInfo.NickName = user.NickName;
                userInfo.WinCount = user.WinCount;
                userInfo.LosCount = user.LosCount;
                userInfo.OpenId = user.OpenId;
                userInfo.Province = user.Province;
                userInfo.Reputation = user.Reputation;
                userInfo.TotalGame = user.TotalGame;

            }
            return userInfo;
        }


        public bool OpsUserInfo(string openId , JObject values) {

            User old = IService.GetByOpenId(openId);
            bool result = false;
            if (old != null)
            {
                old.NickName = values["nickName"].ToString();
                old.Language = values["language"].ToString();
                old.Gender = Convert.ToInt32(values["gender"]);
                old.AvatarUrl = values["avatarUrl"].ToString();
                old.Country = values["country"].ToString();
                old.City = values["city"].ToString();
                old.Province = values["province"].ToString();
                
                result = IService.Update(old);
                
            }
            else {
                User obj = new User()
                {
                    OpenId = openId,
                    NickName = values["nickName"].ToString(),
                    Language = values["language"].ToString(),
                    Gender = Convert.ToInt32(values["gender"]),
                    AvatarUrl = values["avatarUrl"].ToString(),
                    Country = values["country"].ToString(),
                    City = values["city"].ToString(),
                    Province = values["province"].ToString()
                };
                result = IService.Insert(obj);

                Ranking rank = new Ranking()
                {
                    UserId = obj.OpenId,
                    Rank = IService.GetAllCount()
                };
                RService.Add(rank);

            }

            return result;

        }

        public bool SaveTel(string openId, string tel) {
            User old = IService.GetByOpenId(openId);
            old.Tel = tel;
            return IService.Update(old);
        }
    }
}
