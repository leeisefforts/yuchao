﻿using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
  public class Club
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string ClubDesc { get; set; }
        public string ClubLogo { get; set; }

        public Club GetType(int id)
        {
            throw new NotImplementedException();
        }

        public string ClubCity { get; set; }
        public int ClubArea { get; set; }
        public int Status { get; set; }

       
    }
}
