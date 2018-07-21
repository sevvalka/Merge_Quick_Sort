using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Quick_Sort
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] test1 = new int[10];
            int[] test2 = new int[100];
            int[] test3 = new int[1000];
            int[] quicky = new int[10];
            int[] quicky2 = new int[100];
            int[] quicky3 = new int[1000];

            Console.WriteLine("Merge Sort için Random Dizi :");
            for (int i = 0; i < 10; i++)
            {
                test1[i] = rand.Next(0, 10000);
                Console.Write(test1[i] + " ");
            }
            Console.WriteLine(" "); Console.WriteLine(" ");
            Console.WriteLine("Quick Sort için Random Dizi :");
            for (int i = 0; i < 10; i++)
            {
                quicky[i] = rand.Next(0, 10000);
                Console.Write(quicky[i] + " ");
            }
            for (int i = 0; i < 100; i++)
            {
                quicky2[i] = rand.Next(0, 10000);
            }
            for (int i = 0; i < 1000; i++)
            {
                quicky3[i] = rand.Next(0, 10000);
            }
            Console.WriteLine(" "); Console.WriteLine(" ");
            for (int j = 0; j < 100; j++)
            {
                test2[j] = rand.Next(0, 10000);
            }
            for (int k = 0; k < 1000; k++)
            {
                test3[k] = rand.Next(0, 10000);
            }
         
            
            Merge_Sort(test1, 0, test1.Length - 1); Console.WriteLine("1.Merge Sort Count= " + MergeSortCounter); Console.WriteLine("1.Merge Count= " + MergeCounter);
            Merge_Sort(test2, 0, test2.Length - 1); Console.WriteLine("2.Merge Sort Count= " + MergeSortCounter); Console.WriteLine("2.Merge Count= " + MergeCounter);
            Merge_Sort(test3, 0, test3.Length - 1); Console.WriteLine("3.Merge Sort Count= " + MergeSortCounter); Console.WriteLine("3.Merge Count= " + MergeCounter);
            Console.WriteLine("Merge Sort ile Sıralanmış: ");

            foreach (int a in test1)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" "); Console.WriteLine(" ");
           
            Quick_Sort(quicky, 0, quicky.Length - 1); Console.WriteLine("1.Quick Sort Count= " + QuickSortCounter); Console.WriteLine("1.Partition Count= " + PartitionCounter);
            Quick_Sort(quicky2, 0, quicky2.Length - 1); Console.WriteLine("2.Quick Sort Count= " + QuickSortCounter); Console.WriteLine("2.Partition Count= " + PartitionCounter);
            Quick_Sort(quicky3, 0, quicky3.Length - 1); Console.WriteLine("3.Quick Sort Count= " + QuickSortCounter); Console.WriteLine("3.Partition Count= " + PartitionCounter);
            Console.WriteLine("Quick Sort ile Sıralanmış: ");
            foreach (int a in quicky)
            {
                Console.Write(a + " ");
            }

            Console.Read();
        }
        static int QuickSortCounter = 0;
        static int PartitionCounter = 0;
        static public void Quick_Sort(int[] A, int b, int s)
        {
            QuickSortCounter++;
            int r;
            if (b < s)
            {
                r = Partition(A, b, s);
                Quick_Sort(A, b, r - 1);
                Quick_Sort(A, r + 1, s);
            }
        }
        static public int Partition(int[] A, int b, int s)
        {

            PartitionCounter++;
            int temp;
            int pivot = A[s];
            int i = b - 1;
            for (int j = b; j <= s - 1; j++)
            {
                if (A[j] <= pivot)
                {
                    i++;
                    temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }

            }
            temp = A[i + 1];
            A[i + 1] = A[s];
            A[s] = temp;
            return i + 1;


        }

      static int MergeSortCounter = 0;
      static int MergeCounter = 0;
        static public void Merge_Sort(int[] A, int p, int r)
        {
          MergeSortCounter++;
            int q;
            if (p < r)
            {
                q = (p + r) / 2;
                Merge_Sort(A, p, q);
                Merge_Sort(A, q + 1, r);
                Merge(A, p, q, r);
            }




        }
        static public void Merge(int[] A, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1 + 1];
            int[] R = new int[n2 + 1];

            for (int i = 0; i < n1; i++)
            {
                L[i] = A[p + i];
             MergeCounter++;
            }

            for (int j = 0; j < n2; j++)
            {
                R[j] = A[q + j + 1];
           MergeCounter++;
            }

            L[n1] = Int32.MaxValue;
            R[n2] = Int32.MaxValue;

            int x = 0, y = 0;

            for (int k = p; k <= r; k++)
            {
             MergeCounter++;
                if (L[x] <= R[y])
                {
                    A[k] = L[x];
                    x++;
                }
                else
                {
                    A[k] = R[y];
                    y++;
                }
            }
           
        }
    }
}



