using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
    public class LevelService: BaseDb, ILevel
    {
        public SimpleClient<Level> rdb = new SimpleClient<Level>(BaseDb.GetClient());

        public List<Level> GetAll()
        {
            return rdb.GetList();
        }

        public bool Insert(Level level) {
            return rdb.Insert(level);
        }

        public Level GetById(int id) {
            return rdb.GetById(id);
        }

        public bool DeleteById(int id) {
            return rdb.DeleteById(id);
        }

        public bool Update(Level level) {
            return rdb.Update(level);
        }
    }
}
