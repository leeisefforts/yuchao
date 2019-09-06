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
        private UserServer IService = new UserServer();
        private LevelService LService = new LevelService();

        public UserExtends GetUserInfoByOpenId(string openId) {
            // 根据OpenId获取User
            User user = IService.GetByOpenId(openId);
            UserExtends userInfo = new UserExtends();
            if (user != null)
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
                userInfo.LevelName = LService.GetById(user.LevelId).LevelName;
                userInfo.NickName = user.NickName;
                userInfo.OpenId = user.OpenId;
                userInfo.Province = user.Province;
                userInfo.Reputation = user.Reputation;
                userInfo.TotalGame = user.TotalGame;

            }
            return userInfo;
        }
    }
}
