using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    class CangKu
    {
        //存储货物 使用父类
        List<List<ProductFather>> list = new List<List<ProductFather>>();

        /// <summary>
        /// 向用户展示货物
        /// </summary>
        public void ShowPros()
        {
            foreach (var item in list)
            {
                Console.WriteLine("仓库有:"+item[0].Name+"\t\t"+"有"+item.Count+"个"+"\t\t每个"+item[0].Price+"元");
            }
        }
        //list[0]存放Acer电脑
        //list[1]存放三星手机
        //list[2]存放酱油
        //list[3]存放酱油
        /// <summary>
        /// 在创建仓库对象时 向仓库中添加货架
        /// </summary>
        public CangKu()
        {
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
        }
        /// <summary>
        /// 进货
        /// </summary>
        /// <param name="strType">货物类型</param>
        /// <param name="count">货物数量</param>
        public void JinPros(String strType,int count)
        {
            for (int i = 0; i < count; i++)
            {
                switch(strType)
                {
                    case "Acer":
                        list[0].Add(new Acer(Guid.NewGuid().ToString(),1000,"鸿基笔记本"));
                        break;
                    case "SamSung":
                        list[1].Add(new SamSung(Guid.NewGuid().ToString(), 800, "三星手机"));
                        break;
                    case "JiangYou":
                        list[2].Add(new JiangYou(Guid.NewGuid().ToString(), 8, "酱油"));
                        break;
                    case "Banana":
                        list[3].Add(new Banana(Guid.NewGuid().ToString(), 3, "香蕉"));
                        break;
                }
            }
        }
        /// <summary>
        /// 从仓库中去货物
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ProductFather[] QuPros(String strType, int count)
        {
            ProductFather[] pros = new ProductFather[count];

            for (int i = 0; i < pros.Length; i++)
            {
                switch (strType)
                {
                    case "Acer":
                        pros[i]=list[0][0];
                        list[0].RemoveAt(0);
                        break;
                    case "SamSung":
                        pros[i] = list[1][0];
                        list[1].RemoveAt(0);
                        break;
                    case "JiangYou":
                        pros[i] = list[2][0];
                        list[2].RemoveAt(0);
                        break;
                    case "Banana":
                        pros[i] = list[3][0];
                        list[3].RemoveAt(0);
                        break;
                    default:
                        break;
                }
            }
            return pros;
        }
    }
}
