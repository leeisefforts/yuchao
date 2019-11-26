using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.IService
{

    public interface IVenueAccount
    {
        VenueAccount Login(string loginName, string loginPwd);

        VenueAccount Login2(string loginName, string loginPwd);

        bool Insert(VenueAccount venue);

        List<VenueAccount> GetAll();

        bool DeleteById(int id);
    }
}
