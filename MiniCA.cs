using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/**********************************Solution 1- Double For Loop, complex of algorithm:O(N^2)********************************/
public class MiniCA1
{
    public void ReturntwoIntegers(int[] nums,int sum)
    {
          for(int i=0;i<nums.Length;i++)
        {
            if (i == nums.Length - 1)
            {
                Console.WriteLine("Not found");
                break;
            }
            for (int j=i+1;j<nums.Length;j++)
            {
                if (nums[i] + nums[j] == sum)
                {
                    Console.WriteLine("The first integer is {0} and the index number is {1}", nums[i], i);
                    Console.WriteLine("The second integer is {0} and the index number is {1}", nums[j], j);
                    break;
                }
            }
        }
    }
}

/**********************************Solution 2-sort algorithm with divide-and-conquer thinking, complex of algorithm:O(nlogn)(is the complex of sorting algorithm)********************************/

public class MiniCA2
{
    public void Quicksorts(int[] nums, int left, int right)
    {
        if (left >= right)
        {
            return;
        }
        int pivotIdx = Partition(nums, left, right);


        Quicksorts(nums, left, pivotIdx - 1);
        Quicksorts(nums, pivotIdx + 1, right);


    }

    public int Partition(int[] nums, int left, int right)
    {
        int low = left;
        int pivot = right;
        right = pivot - 1;
        while (true)
        {
            while (left < pivot && nums[left] <= nums[pivot])
            {
                left++;//注意此处为什么要while：因为要保持左边一直先加，加快处理速度，故还要设置限制条件左<pivot
            }
            while (right > low && nums[right] >= nums[pivot])
            {
                right--;//右边的while也与上面同理
            }
            if (left < right)
            {
                int temp1 = nums[left];
                nums[left] = nums[right];
                nums[right] = temp1;//这里囊括了内部与外部的左右所有左右交换处理。故在break之后就只用交换左和中，而在左大于右之后结束，保证交换的那个还是一定是右边那个存了大一些数的“左子”。
            }
            else
            {
                break;
            }
        }

        int temp2 = nums[left];
        nums[left] = nums[pivot];
        nums[pivot] = temp2;
        return left;
    }




    public void returntointegers(int[] nums, int left, int strright, int sum)
    {
        int right = strright;
        Dictionary<int, int> Record = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (Record.ContainsKey(nums[i]) == false)
            {
                Record.Add(nums[i], i);
            }

        }
        Quicksorts(nums, left, strright);
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write(nums[i] + " ");
        }
        Console.WriteLine();
        while (true)
        {
            if (left<right&&nums[left] + nums[right] < sum)
            {
                left++;
                continue;
            }
            else if (right>left&&nums[left] + nums[right] > sum)
            {
                right--;
                continue;
            }
            else if (nums[left] + nums[right] == sum)
            {
                Console.WriteLine("{0},and the location is {1}", nums[left], Record[nums[left]]);
                Console.WriteLine("{0},and the location is {1}", nums[right], Record[nums[right]]);
                break;
            }else if (left == right)
            {
                Console.WriteLine("Not found");
                break;
            }
        }


    }
}

/**********************************Solution 3-a simple Hash Function with a limitation to process collision, the complex of algorithm:O(N) for searching********************************/

public class MiniCA3
{
    public void ReturnTwoIntergers(int[] nums, int sum)
    {
        Dictionary<int, int> num1 = new Dictionary<int, int>();
        int[] map = new int[sum + 1];
        int marks = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int Hashrules = sum - nums[i];
            if (num1.ContainsKey(0) == true && nums[i] == nums[0])
            {
                continue;
            }
            else if (nums[i] <= sum && map[Hashrules] == 0)
            {
                num1.Add(i, nums[i]);
                map[Hashrules] = i;
                if (i == 0)
                {
                    marks = Hashrules;
                }
            }
            else
            {
                continue;
            }

        }
        int left = 0;
        int right = map.Length - 1;
        while ((map[left] == 0 && left != marks) || (map[right] == 0 && right != marks))
        {
            left++;
            right--;
            if (left >= right)
            {
                Console.WriteLine("Not found");
                break;
            }
        }
        if (num1.ContainsKey(left) == true && num1.ContainsKey(right) == true && num1[map[left]] + num1[map[right]] == sum)
        {
            Console.WriteLine("The two index is:{0},{1}", map[left], map[right]);
            Console.WriteLine("The two interger is:{0},{1}", num1[map[left]], num1[map[right]]);
        }
        else
        {
            Console.WriteLine("Not found");
        }
        for (int i = 0; i < map.Length; i++)
        {
            Console.Write(map[i] + " ");
        }

    }
}

/**********************************Main**************************************************************************************************/

public static void Main(string[] args)
{
    int[] nums = { 2, 4, 9, 8, 3, 5, 7, 6, 1, 4 };
    int[] nums1 = { 2, 4, 9, 8, 3, 5, 7, 6, 1, 4 };
    Console.Write("Please enter your Except sum:");
    int sum = int.Parse(Console.ReadLine());
    MiniCA1 mini=new MiniCA1();
    mini.ReturntwoIntegers(nums, sum);
    MiniCA2 mini1= new MiniCA2();
    mini1.returntointegers(nums1, 0, nums1.Length - 1, sum);
    MiniCA3 mini2 = new MiniCA3();
    mini2.ReturnTwoIntergers(nums, sum);


}
