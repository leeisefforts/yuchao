using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Model
{
    public class ApiResult
    {
        public int Status { get; set; }

        public string Error { get; set; }

        public Object Obj { get; set; }
    }
}
