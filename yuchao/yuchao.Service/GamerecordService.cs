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
        public SimpleClient<GameDetail> ddb = new SimpleClient<GameDetail>(BaseDb.GetClient());
        public SimpleClient<TeamGameDetail> tgdb = new SimpleClient<TeamGameDetail>(BaseDb.GetClient());

        public List<Gamerecord> GetAll(string openId)
        {
            return rdb.GetList(p => (p.OpenId.Equals(openId) || p.OpenId2.Equals(openId)) && p.IsTeamGame == 0);
        }
        public bool Insert(Gamerecord gamerecord)
        {
            return rdb.Insert(gamerecord);
        }

        public int InsertRId(Gamerecord gamerecord)
        {
            return rdb.InsertReturnIdentity(gamerecord);
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

        public Gamerecord GetBySId(int sid)
        {
            return rdb.GetSingle(p => p.ScheduleRecordId == sid);
        }

        public List<Gamerecord> GetByClubId(int clubId)
        {
            return rdb.GetList(p => p.ClubId == clubId);
        }

        public List<Gamerecord> GetAllByGameTime(string gameTime, int venueId)
        {
            return rdb.GetList(p => p.GameTime.Equals(gameTime) && p.VenueId == venueId);
        }

        public List<MatchGame> GetMatchUser(string gameTime, int venueId, string openId) {
            return mdb.GetList(p => p.MatchTime.Equals(gameTime) && p.VenueId == venueId && p.MatchStatus == 1 && !p.OpenId.Equals(openId));
        }
        public List<MatchGame> GetMatchTeamUser(string gameTime, int venueId, string openId)
        {
            return mdb.GetList(p => p.MatchTime.Equals(gameTime) && p.VenueId == venueId && p.MatchStatus == 1 && !p.OpenId.Equals(openId) && p.IsTeam == 1);
        }
        public bool AddMatchGame(MatchGame mg) {
            return mdb.Insert(mg);
        }

        public bool UpdateMatchGame(MatchGame mg)
        {
            return mdb.Update(mg);
        }

        public List<Gamerecord> GetClubGame(int clubId) {
            return rdb.GetList(p => p.ClubId == clubId);
        }

        public List<Gamerecord> GetGameAll() {
            return rdb.GetList(p => p.Status == 1 && p.RefereeId == 0 && p.IsTeamGame == 0);
        }

        public List<Gamerecord> GetTeamGameAll()
        {
            return rdb.GetList(p => p.Status == 1 && p.RefereeId == 0 && p.IsTeamGame == 1);
        }

        public List<Gamerecord> GetGameAllByReId(int id, int status)
        {
            return rdb.GetList(p => p.Status == status && p.RefereeId == id && p.IsTeamGame == 0);
        }

        public List<Gamerecord> GetTeamGameAllByReId(int id, int status)
        {
            return rdb.GetList(p => p.Status == status && p.RefereeId == id && p.IsTeamGame == 1);
        }


        public bool AddGameDetail(GameDetail gd) {
            return ddb.Insert(gd);
        }
        public bool AddTeamGameDetail(TeamGameDetail gd)
        {
            return tgdb.Insert(gd);
        }

        public bool UpdateGameDetail(GameDetail gd)
        {
            return ddb.Update(gd);
        }
        public bool UpdateTGameDetail(TeamGameDetail gd)
        {
            return tgdb.Update(gd);
        }

        public int AddGameDetailRId(GameDetail gd)
        {
            return ddb.InsertReturnIdentity(gd);
        }


        public List<GameDetail> GdList(int gid) {
            return ddb.GetList(p=>p.GId == gid);
        }

        public TeamGameDetail GetGameDetail(int gid)
        {
            return tgdb.GetSingle(p => p.GId == gid);
        }

        public TeamGameDetail GetGameDetailByOid(int oid)
        {
            return tgdb.GetSingle(p => p.Id == oid);
        }

        public List<TeamGameDetail> GetByOpenId(string openId ) {

            return tgdb.GetList(p=>p.WSOpenId.Equals(openId) || p.HDOpenId.Contains(openId) || p.MDOpenId.Contains(openId) || p.MSOpenId.Equals(openId));
        }
    }
}
