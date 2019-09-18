using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Service
{
    public class BasicService
    {
        public static string InitOrderSn() {

            return Guid.NewGuid().ToString();
        }
    }
}
