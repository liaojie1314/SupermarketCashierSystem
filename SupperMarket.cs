using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    class SupperMarket
    {
        //创建仓库对象
        CangKu ck = new CangKu();
        /// <summary>
        /// 创建超市对象时给仓库货架上导入货物
        /// </summary>
        public SupperMarket()
        {
            ck.JinPros("Acer", 1000);
            ck.JinPros("SamSung", 1000);
            ck.JinPros("JiangYou", 1000);
            ck.JinPros("Banana", 1000);

        }
        /// <summary>
        /// 与用户交互
        /// </summary>
        public void AskBuying()
        {
            Console.WriteLine("欢迎光临,请问你要什么");
            Console.WriteLine("我们有Acer、SamSung、JiangYou、Banana");
            string strType = Console.ReadLine();
            Console.WriteLine("你需要多少");
            int count = Convert.ToInt32(Console.ReadLine());
            //去仓库取货
            ProductFather[] pros = ck.QuPros(strType, count);
            double realMoney = GetMoney(pros);
            Console.WriteLine("你总共消费{0}元", realMoney);
            Console.WriteLine("请选择打折方式:1--不打折,2--打9折,3--打85折,4--满300减50,5--满500减100");
            string input = Console.ReadLine();
            //通过简单工厂设计模式根据用户输入获得一个打折对象
            CalFather cal = GetCal(input);
            double totalMoney=cal.GetTotalMoney(realMoney);
            Console.WriteLine("打折后价钱:{0}", totalMoney);
            Console.WriteLine("以下是你的小票:");
            foreach (var item in pros)
            {
                Console.WriteLine("货物名称:{0}\t货物单价:{1}\t货物编号:{2}", item.Name, item.Price, item.ID);
            }
        }
        /// <summary>
        /// 根据用户选择的打折方式返回一个打折对象
        /// </summary>
        /// <param name="input">用户选择</param>
        /// <returns>返回的是父类对象 但是里面装的是子类对象</returns>
        public CalFather GetCal(string input)
        {
            CalFather cal = null;
            switch (input)
            {
                case "1":
                    cal=new CalNormal();
                    break;
                case "2":
                    cal = new CalRate(0.9);
                    break;
                case "3":
                    cal = new CalRate(0.85);
                    break;
                case "4":
                    cal = new CalMN(300,50);
                    break;
                case "5":
                    cal = new CalMN(500,100);
                    break;
                default:
                    break;
            }
            return cal;

        }
        /// <summary>
        /// 根据用户买的货物计算总价钱
        /// </summary>
        /// <param name="pros"></param>
        /// <returns></returns>
        public double GetMoney(ProductFather[] pros)
        {
            double realMoney = 0;
            for (int i = 0; i < pros.Length; i++)
            {
                realMoney += pros[i].Price;
            }
            return realMoney;
        }
        public void ShowPros()
        {
            ck.ShowPros();
        }
    }
}
