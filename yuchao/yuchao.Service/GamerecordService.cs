using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
    public class GamerecordService : BaseDb, IGamerecord
    {
        public SimpleClient<Gamerecord> rdb = new SimpleClient<Gamerecord>(BaseDb.GetClient());
        public SimpleClient<MatchGame> mdb = new SimpleClient<MatchGame>(BaseDb.GetClient());

        public List<Gamerecord> GetAll(string openId)
        {
            return rdb.GetList(p=>p.OpenId.Equals(openId));
        }
        public bool Insert(Gamerecord gamerecord)
        {
            return rdb.Insert(gamerecord);
        }

        public Gamerecord GetById(int id)
        {
            return rdb.GetById(id);
        }
        public bool DeleteById(int id)
        {
            return rdb.DeleteById(id);
        }
        public bool Update(Gamerecord gamerecord)
        {
            return rdb.Update(gamerecord);
        }
        public Gamerecord GetByVenueId(string venueId)
        {
            return rdb.GetSingle(p => p.VenueId.Equals(venueId));
        }

        public List<Gamerecord> GetAllByGameTime(string gameTime, int venueId)
        {
            return rdb.GetList(p => p.GameTime.Equals(gameTime) && p.VenueId == venueId);
        }

        public List<MatchGame> GetMatchUser(string gameTime, int venueId) {
            return mdb.GetList(p => p.MatchTime.Equals(gameTime) && p.VenueId == venueId);
        }

        public bool AddMatchGame(MatchGame mg) {
            return mdb.Insert(mg);
        }
    }
}
