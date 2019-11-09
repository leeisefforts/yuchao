using System.Collections.Generic;
using yuchao.Entity;
using yuchao.IService;

namespace yuchao.Business.Admin
{
    public class VenueAccountBLL
    {
        private IVenueAccount IService = new Service.VenueAccountService();

        public List<VenueAccount> GetAll()
        {
            return IService.GetAll();
        }
        public bool DeleteById(int id)
        {
            return IService.DeleteById(id);
        }
    }
}
