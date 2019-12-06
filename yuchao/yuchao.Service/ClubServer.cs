using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
   public class ClubServer: BaseDb, IClub
    {
        public SimpleClient<Club> rdb = new SimpleClient<Club>(BaseDb.GetClient());
        public SimpleClient<ClubTotal> tdb = new SimpleClient<ClubTotal>(BaseDb.GetClient());
        public SimpleClient<User> udb = new SimpleClient<User>(BaseDb.GetClient());
        public SimpleClient<ClubClose> cdb = new SimpleClient<ClubClose>(BaseDb.GetClient());
        //查询
        public Club Get(int Id)
        {
            return rdb.GetSingle(p => p.Id == Id);
        }

        public Club GetByOpenId(string openId)
        {
            return rdb.GetSingle(p => p.OpenId.Equals(openId));
        }

        public ClubTotal GetClubTotalByClubId(int clubId)
        {
            return tdb.GetSingle(p => p.ClubId == clubId);
        }
        //增加
        public bool Add(Club entity)
        {
            return rdb.Insert(entity);
        }

        public int AddReturnId(Club entity)
        {
            return rdb.InsertReturnIdentity(entity);
        }
        //修改
        public bool Update(Club entity)
        {
            return rdb.Update(entity);
        }
        //删除
        public bool Dels(dynamic[] ids)
        {
            return rdb.DeleteByIds(ids);
            
        }

        public List<Club> GetList(string keyword)
        {
            List<Club> list = rdb.GetList(p => p.Status == 1);
            if (string.IsNullOrEmpty(keyword))
            {
                list = list.FindAll(p => p.ClubName.Contains(keyword));
            }
            return list;
        }

        public List<User> GetListByClubId(int clubId) {
            return udb.GetList(p=>p.ClubId == clubId);
        }

        public bool InsertCloseData(ClubClose cc) {
            return cdb.Insert(cc);
        }

        public List<ClubClose> GetCC(string openId) {
            return cdb.GetList(p=>p.OpenId.Equals(openId));
        }
    }
}
