using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.IService
{
    public interface IVenue
    {
        List<Venue> GetAll();

        bool Insert(Venue level);

        Venue GetById(int id);

        bool DeleteById(int id);

        bool Update(Venue level);
    }
}
