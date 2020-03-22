using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort4
{
    class Program
    {
        /// <summary>
        /// 练习四种排序 选择排序 插入排序 冒泡排序 快速排序 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] values = new int[] {5,16,3,35,77,2,9,11,45,99,342,1,6};

            //测试选择排序
            SelectionSort(values);

             values = new int[] { 5, 16, 3, 35, 77, 2, 9, 11, 45, 99, 342, 1, 6 };
            //测试插入排序
            InsertionSort(values);

             values = new int[] { 5, 16, 3, 35, 77, 2, 9, 11, 45, 99, 342, 1, 6 };
            //测试冒泡排序
            BubbleSort(values);

             values = new int[] { 5, 16, 3, 35, 77, 2, 9, 11, 45, 99, 342, 1, 6 };
            //测试快速排序
            QuickSort(values, 1, values.Length-1);
            foreach (int item in values)
            {
                Console.Write(item+" ");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 快速排序 当选择列表最小或最大元素作为基准时，快速排序复杂度为O(n)
        /// </summary>
        /// <param name="values"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        private static void QuickSort(int[] values, int low, int high)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (low<high)
            {
                int index = Partition(values, low, high);
                QuickSort(values, low, index - 1);
                QuickSort(values, index+1, high);
            }
            stopwatch.Stop();
            //Console.WriteLine("快速排序所耗时：" + stopwatch.Elapsed.ToString());
        }
        /// <summary>
        /// 快速排序的分区方法
        /// </summary>
        /// <param name="values"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private static int Partition(int[] values, int low, int high)
        {
            int pivot = values[high];
            int i = low - 1;
            for (int j = low; j < high-1; j++)
            {
                if (values[j]<=pivot)
                {
                    i++;
                    Swap(ref values[i], ref values[j]);
                }
            }
            i++;
            Swap(ref values[i], ref values[high]);
            return i;
        }

        /// <summary>
        /// 冒泡排序 最优复杂度为O(n) 最坏和平均是O(n2)
        /// </summary>
        /// <param name="values"></param>
        private static void BubbleSort(int[] values)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool swapped;
            for (int i = 0; i < values.Length; i++)
            {
                swapped = false;
                for (int j = values.Length-1; j >i; j--)
                {
                    if (values[j]<values[j-1])
                    {
                        Swap(ref values[j], ref values[j - 1]);
                        swapped = true;
                    }
                    //只有当集合中任意两对都不需要交换位置时，代表排序完成
                }
                if (swapped==false)
                {
                    break;
                }
            }
            stopwatch.Stop();
            Console.WriteLine("冒泡排序所耗时：" + stopwatch.Elapsed.ToString());
        }

        /// <summary>
        /// 插入排序，复杂度也是O(n2)最优复杂度是O(n)
        /// </summary>
        /// <param name="values"></param>
        private static void InsertionSort(int[] values)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (values.Length<=1)
            {
                return;
            }
            int j, value;
            for (int i = 1; i < values.Length; i++)
            {
                //序号i用于跟踪当前未排序的第一个元素
                //序号j用于在当前循环中从后往前跟踪已排序的元素
                value = values[i];
                j = i - 1;
                while (j>=0 && values[j]>value)
                {
                    values[j + 1] = values[j];
                    j--;
                }
                //往右移动元素
                values[j + 1] = value;
            }
            stopwatch.Stop();
            Console.WriteLine("插入排序所耗时：" + stopwatch.Elapsed.ToString());
        }

        /// <summary>
        /// 选择排序 复杂度为O(n2)
        /// </summary>
        /// <param name="values"></param>
        public static void SelectionSort(int[] values)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (values.Length<=1)
            {
                return;
            }
            int  minindex;
            for (int i = 0; i < values.Length-1; i++)
            {
                minindex = i;
                for (int j = i+1; j < values.Length; j++)
                {
                    /*先假设第一个元素是最小的，然后让后面所有元素和第一个比较，如果比它小，
                     * 就把最小值索引更新，并交换这两个值
                    */
                    if (values[j]<values[minindex])
                    {
                        minindex = j;
                    }
                }
                //当内循环结束后，此时索引minindex的元素就是最小值，把最小的放入集合中
                Swap(ref values[minindex], ref values[i]);
            }
            stopwatch.Stop();
            Console.WriteLine("选择排序所耗时：" + stopwatch.Elapsed.ToString());

        }

        private static void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }
    }
}
