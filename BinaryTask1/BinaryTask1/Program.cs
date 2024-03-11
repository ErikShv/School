using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class Program
    {
        public static int[] convert(int MemLen, int Num)
        {
            int i = 0;
            int[] result = new int[MemLen];

            for (i = 0; Num > 0; i++)
            {
                result[i] = Num % 2;
                Num /= 2;

            }
            return result;
        }
        public static int[] MashlimLeShtaim(int[] Res)
        {
            bool flag = false;
            for (int i = 0; i < Res.Length; i++)
            {
                if (Res[i] == 1 && flag == false)
                {
                    flag = true;
                    i++;
                }
                if (flag == true)
                {
                    if (Res[i] == 0)
                    {
                        Res[i] = 1;
                    }
                    else
                    {
                        Res[i] = 0;
                    }
                }

            }
            return Res;
        }
        static void Main(string[] args)
        {
            int num = 80;                         //main רק לבדיקה של אם התכנית עובדת

            int mem = 8;
            int[] res1 = convert(mem, num);
            int[] res2 = MashlimLeShtaim(res1);

            for (int i = 1; i <= res2.Length; i++)
            {
                Console.Write(res2[res2.Length - i]);
            }

            string a = Console.ReadLine();
        }
    }

}
