using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
   public class User
    {
             public int Id { get; set; }

        public string NickName { get; set; }

        public string Language { get; set; }
        public int Gender { get; set; }

        public string AvatarUrl { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public string Province { get; set; }
    }
}
