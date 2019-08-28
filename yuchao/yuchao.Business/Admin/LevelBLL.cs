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
    }
}
