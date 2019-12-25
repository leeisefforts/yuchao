using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    /// <summary>
    /// 父亲- 基类
    /// </summary>
    public class Father
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Father()
        {
            Console.WriteLine("New Father ....");
        }

        /// <summary>
        /// 一个秘密
        /// </summary>
        private string MsgSecret { get; set; }

        /// <summary>
        /// 银行卡密码
        /// </summary>
        protected string BankSecret { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// 汽车
        /// </summary>
        public string Car { get; set; }


        /// <summary>
        /// 测试函数
        /// </summary>
        protected void test() { }

    }

    /// <summary>
    /// 儿子 - 子类 (派生类)
    /// </summary>
    public class Son : Father
    {

        public Son()
        {
            Console.WriteLine("New Son.....");
        }

        //隐式的生成了这三个字段
        //protected string BankSecret;
        //public string Name;
        //public string Car;

        /// <summary>
        /// 子类的汽车
        /// </summary>
        public string Car;


        public void getCar()
        {
            string fCar = base.Car;
            string sCar = this.Car;//子类
            base.test();//调用父类方法，如果签名不冲突，可以省略base
        }
    }

}
