using SqlSugar;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Service
{
    public class DxService
    {
        private static string userName = "hnwkkj";
        private static string userPwd = "888666";

        private static SimpleClient<PhoneVerification> rdb = new SimpleClient<PhoneVerification>(BaseDb.GetClient());
        private static SimpleClient<User> udb = new SimpleClient<User>(BaseDb.GetClient());

        private static int InitCode() {

            return 1;
        }

        public static bool SendMsg(int code, string phone, string openId) {
            string msg = string.Format("您的验证码为{0},  【羽巢赛事】", code);
            string url = string.Format("http://www.qybor.com:8500/shortMessage?username={0}&passwd={1}&phone={2}&msg={3}&needstatus=false", userName, userPwd, phone, msg);

            string result = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                string statusCode = response.StatusCode.ToString();

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }

                PhoneVerification pf = rdb.AsQueryable().First(p => p.UserId.Equals(openId) && p.Status == 0);
                if (pf != null)
                {
                    pf.Status = 2;
                    rdb.Update(pf);
                }

                PhoneVerification pp = new PhoneVerification();
                pp.Code = code;
                pp.UserId = openId;
                pp.CreateTime = DateTime.Now;
                pp.Status = 0;
                rdb.Insert(pp);
            }

            return true;
        }

        public static bool ValidCode(int code, string openId, string phone) {

            

            PhoneVerification pf = rdb.AsQueryable().First(p => p.UserId.Equals(openId) && p.Status == 0 && p.Code == code);
            if (pf != null)
            {
                pf.Status = 1;
                rdb.Update(pf);

                User user = udb.GetSingle(p => p.OpenId.Equals(openId));
                user.Tel = phone;
                udb.Update(user);
                return true;
            }


            return false;
        }
    }
}
