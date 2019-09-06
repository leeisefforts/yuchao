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

        public List<Gamerecord> GetAll()
        {
            return rdb.GetList();
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
    }
}
