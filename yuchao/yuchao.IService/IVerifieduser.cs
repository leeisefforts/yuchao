using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.IService
{
   public interface IVerifieduser
    {
        List<Verifieduser> GetAll();

        bool Insert(Verifieduser level);

        Verifieduser GetById(int id);

        bool DeleteById(int id);

        bool Update(Verifieduser level);
    }
}
