using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;

namespace yuchao.Business.Admin
{
    public class LevelBLL
    {
        private ILevel IService = new Service.LevelService();

        public List<Level> GetAll()
        {
            return IService.GetAll();
        }

        public bool Insert(Level level) {
            return IService.Insert(level);
        }

        public bool DeleteById(int id) {
            return IService.DeleteById(id);
        }

        public bool Update(Level level) {
            Level l = IService.GetById(level.Id);
            l.LevelName = level.LevelName;
            l.LevelSort = level.LevelSort;
            return IService.Update(level);

        }
    }
}
