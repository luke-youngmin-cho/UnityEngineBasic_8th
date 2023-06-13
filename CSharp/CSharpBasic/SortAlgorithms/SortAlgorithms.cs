using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    internal class SortAlgorithms
    {
        #region Bubble Sort
        /// <summary>
        /// 거품정렬
        /// 처음부터 끝까지 순회하면서 바로뒤의 요소가 현재 요소보다 작으면 스왑
        /// 위 과정을 N - 1 번 수행.
        /// 한번 전체 스왑을 할 때마다 가장 마지막 자리가 고정됨.
        /// Stable. (정렬후에 정렬전의 순서가 보장됨)
        /// O(N^2)
        /// </summary>
        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
        #endregion

        // ref 키워드 
        // 인자를 참조형태로 받을 때 사용
        private static void Swap(ref int a,ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}
