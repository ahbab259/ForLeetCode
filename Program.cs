﻿using Lucene.Net.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NetTopologySuite;
using Collections.Generic;
namespace ForLeetCode
{
    class Program
    {
        #region Classes
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        #endregion

        #region functions


        static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {

            ListNode head = new ListNode(0);
            ListNode handler = head;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    handler.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    handler.next = l2;
                    l2 = l2.next;
                }
                handler = handler.next;
            }

            if (l1 != null)
            {
                handler.next = l1;
            }
            else if (l2 != null)
            {
                handler.next = l2;
            }

            return head.next;
        }
        //static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        //{

        //    if (list1 == null && list2 != null) return list2;
        //    if (list2 == null && list1 != null) return list1;

        //    ListNode temp = new ListNode();

        //    if(list1.val < list2.val)
        //    {
        //        temp = list1;
        //        temp.next = MergeTwoLists(list1.next, list2);
        //    }

        //    else
        //    {
        //        temp = list2;
        //        temp.next = MergeTwoLists(list1, list2.next);
        //    }



        //    return temp;
        //}
        static bool IsValid(string s)
        {
            s = s.Trim();


            //[{()}]
            for (int i = 0; i < s.Length; i++)
            {
                if (s.StartsWith("}") || s.StartsWith(")") || s.StartsWith("]")) return false;
                if (s[i] == ')' || s[i] == '}' || s[i] == ']')
                {
                    if (s[i] == ')')
                    {
                        if (s[i - 1] == '(')
                        {
                            s = s.Remove(i - 1, 2);
                            //s = s.Remove(i-1,1);
                            i -= 2;
                            continue;
                        }
                    }
                    if (s[i] == '}')
                    {
                        if (s[i - 1] == '{')
                        {
                            s = s.Remove(i - 1, 2);
                            i -= 2;
                            continue;
                        }
                    }
                    if (s[i] == ']')
                    {
                        if (s[i - 1] == '[')
                        {
                            s = s.Remove(i - 1, 2);
                            i -= 2;
                            continue;
                        }
                    }
                }
            }


            if (s.Length == 0) return true;
            else return false;

        }
        static int RemoveElement(int[] nums, int val)
        {
            int match = 0;
            int j = 0;
            int[] newNums = new int[100];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    match++;
                }
                else
                {
                    nums[j] = nums[i];
                    j++;
                }
            }

            //nums = newNums;

            return nums.Length - match;
        }
        static int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (i == digits.Length - 1) digits[i] += 1;

                if (i != 0 && digits[i] == 10)
                {
                    digits[i] = 0;
                    digits[i - 1] += 1;
                }

                if (i == 0 && digits[i] == 10)
                {
                    digits = digits.Append(0).ToArray();
                    for (int j = digits.Length - 1; j >= 1; j--)
                    {
                        digits[j] = digits[j - 1];
                    }
                    digits[0] = 1;
                    digits[1] = 0;
                }
            }
            return digits;
        }
        static int SearchInsert(int[] nums, int target)
        {
            if (target < nums[0]) return 0;
            if (target > nums[nums.Length - 1]) return nums.Length;

            int start = 0;
            int end = nums.Length - 1;
            int mid = (int)Math.Floor(Convert.ToDecimal((end - start) / 2));

            if (nums[mid] >= target)
            {
                for (int i = 0; i <= mid; i++)
                {
                    if (nums[i] >= target) return i;
                }
            }
            else
            {
                for (int i = mid; i <= nums.Length - 1; i++)
                {
                    if (nums[i] >= target) return i;
                }
            }

            return 0;
        }
        static int StrStr(string haystack, string needle)
        {
            #region commented
            //int p = 0;
            //int j = 0;
            //int counter = 0;
            //int startIndex = 0;
            //Dictionary<int, char> startLetter = new Dictionary<int, char>();
            //for (int i = startIndex; i<haystack.Length; i++)
            //{
            //    if (p < haystack.Length)
            //    {
            //        if (haystack[p] == needle[0])
            //        {
            //            startLetter.Add(i, haystack[p]);
            //        }
            //    }
            //    p++;

            //    if (haystack[i] == needle[j])
            //    {
            //        if (j == 0)
            //        {
            //            startIndex = i;
            //            startLetter.Remove(startLetter.Keys.First());
            //        }
            //        j++;
            //        counter++;
            //        if (counter == needle.Length) return startIndex;
            //    }
            //    else
            //    {
            //        j = 0;
            //        if (startLetter.Keys.Count != 0)
            //        {
            //            i = startLetter.Keys.Last() - 1;
            //        }
            //        else startIndex = 0;
            //        counter = 0;
            //    }
            //}
            #endregion

            #region 2nd attempt
            //int j = 0;
            //int startIndex = 0;
            //int next = 0;
            //int p = 0;

            //for (int i = 0; i < haystack.Length - 1; i++)
            //{
            //    if (haystack[p] == needle[0])
            //    {
            //        next = p;                    
            //    }
            //    p++;

            //    if (haystack[i] == needle[j])
            //    {
            //        if (j == 0) 
            //            startIndex = i;
            //        j++;
            //        if (needle.Length == j) return startIndex;
            //    }

            //    else
            //    {
            //        if (j > 0) i = next - 1;
            //        startIndex = 0;
            //        j = 0;
            //    }
            //}

            //return -1;
            #endregion

            int haylength = haystack.Length;
            int needlelength = needle.Length;
            if (haylength < needlelength)
                return -1;
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                int j = 0;
                while (j < needle.Length && haystack[i + j] == needle[j])
                    j++;
                if (j == needle.Length)
                {
                    return i;
                }
            }
            return -1;
        }
        static ListNode DeleteDuplicates(ListNode head)
        {
            ListNode temp = new ListNode();
            temp = head;
            if (head == null)
            {
                return head;
            }
            while (temp.next != null)
            {
                if (temp.val != temp.next.val)
                {
                    temp = temp.next;
                }
                else temp.next = temp.next.next;
            }

            return head;
        }
        static int[] GetConcatenation(int[] nums)
        {
            //Array.Resize(ref nums, nums.Length * 2);
            //Array.Copy(nums, 0, nums, nums.Length/2 ,nums.Length/2);

            int length = nums.Length;
            for (int i = 0; i < length; i++)
            {
                nums = nums.Append(nums[i]).ToArray();
            }

            return nums;
        }
        static int[] RunningSum(int[] nums)
        {
            //int [] ans = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0) continue;

                nums[i] = nums[i] + nums[i - 1];


            }
            return nums;
        }
        static int[] Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1; //nums1 pointer
            int j = n - 1; //nums2 pointer
            int k = nums1.Length - 1; //final array pointer

            // Now traversing the nums2 array
            while (j >= 0)
            {
                if (i >= 0 && nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    k--;
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    k--;
                    j--;
                }
            }

            return nums1;
        }
        static int TheMaximumAchievableX(int num, int t)
        {
            //int num = 4; int t = 1; answer will be x = 6

            return num + (2 * t);

        }
        static string DefangIPaddr(string address)
        {
            //return address.Replace(".", "[.]");
            string newAddress = "";

            foreach (char c in address)
            {
                if (c == '.')
                {
                    newAddress += "[.]";
                }
                else
                {
                    newAddress += c;
                }
            }

            return newAddress;

        }
        static int[] BuildArray(int[] nums)
        {
            int[] ans = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                ans[i] = nums[nums[i]];
            }

            return ans;
        }
        static double[] ConvertTemperature(double celsius)
        {
            double[] ans = new double[2];

            ans[0] = celsius + 273.15;

            ans[1] = celsius * 1.8 + 32;

            return ans;
        }
        static int NumIdenticalPairs(int[] nums)
        {
            Dictionary<int, int> catalogs = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (catalogs.Keys.Contains(nums[i]))
                {
                    int existingAmount = catalogs.Where(c => c.Key == nums[i]).FirstOrDefault().Value;
                    existingAmount++;
                    catalogs.Remove(nums[i]);
                    catalogs.Add(nums[i], existingAmount);
                }

                else
                {
                    int counter = 1;
                    catalogs.Add(nums[i], counter);
                }
            }

            int result = 0;

            foreach (int k in catalogs.Values)
            {
                if (k == 1) continue;

                result += ((k * (k - 1)) / 2);
            }

            return result;
        }
        static int SingleNumber(int[] nums)
        {
            Dictionary<int, int> catalogs = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (catalogs.Keys.Contains(nums[i]))
                {
                    //int existingAmount = catalogs.Where(c => c.Key == nums[i]).FirstOrDefault().Value;
                    //existingAmount++;
                    //catalogs.Remove(nums[i]);
                    //catalogs.Add(nums[i], existingAmount);


                    catalogs[nums[i]] += 1;

                }

                else
                {
                    catalogs.Add(nums[i], 1);
                }
            }

            int result = catalogs.Where(c => c.Value == 1).FirstOrDefault().Key;

            return result;
        }
        static ListNode RemoveElements(ListNode head, int val)
        {
            ListNode temp = new ListNode();
            temp = head;

            if (head == null)
            {
                return head;
            }
            while (temp.next != null)
            {
                if (temp.next.val == val)
                {
                    temp.next = temp.next.next;
                }

                else temp = temp.next;
            }

            if (head.val == val) return head.next;
            else return head;
        }
        static bool IsPalindrome(string s)
        {
            char[] arr = s.ToCharArray();

            arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c))));
            s = new string(arr);

            s = s.Replace(" ", "");
            s = s.ToLower();

            string compare = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                compare += s[i];
            }
            if (s == compare) return true;
            else return false;
        }
        static bool ContainsDuplicate(int[] nums)
        {
            List<int> history = new List<int>();
            for (int i = 0; i < nums.Count(); i++)
            {
                if (history.Contains(nums[i])) return true;
                else history.Add(nums[i]);
            }

            return false;
        }
        static ListNode ReverseList(ListNode head)
        {
            ListNode temp = head;
            int[] tempArr = { };

            while (temp != null)
            {
                tempArr = tempArr.Append(temp.val).ToArray();
                temp = temp.next;
            }

            temp = head;
            int i = tempArr.Length - 1;

            while (temp != null)
            {
                temp.val = tempArr[i];
                temp = temp.next;
                i--;
            }

            return head;
        }
        static int[] Shuffle(int[] nums, int n)
        {
            int[] result = new int[2 * n];
            int i = 0;
            int before = 0;
            int after = n;
            while (i < n * 2)
            {
                if (i % 2 == 0)
                {
                    result[i] = nums[before];
                    before++;
                }
                else
                {
                    result[i] = nums[after];
                    after++;
                }

                i++;
            }
            //result[i] = nums[i];
            //result[i + 1] = nums[n + i];
            GC.Collect();
            return result;
        }
        static int LargestAltitude(int[] gain)
        {
            int[] latitudes = new int[gain.Length + 1];
            latitudes[0] = 0;

            for (int i = 1; i < latitudes.Length; i++)
            {
                latitudes[i] = latitudes[i - 1] + gain[i - 1];
            }
            GC.Collect();
            return latitudes.Max();
        }
        //2147483647
        //1534236469 -> test case
        static int Reverse(int x)
        {
            if (Math.Abs(Convert.ToInt64(x)) > 2147483647) return 0;

            int y = 0;
            if (x < 0) y = x * -1;
            else y = x;
            string s = Convert.ToString(y);
            char[] c = s.ToCharArray();

            c = c.Reverse().ToArray();
            string p = new string(c);

            if (Convert.ToInt64(p) > 2147483647)
            {
                return 0;
            }

            int result = Convert.ToInt32(p);
            if (x >= 0) return result;
            else return result * -1;
        }
        static int MaxProfit(int[] prices)
        {
            #region 1st attempt
            if (prices.Length == 1) return 0;

            int currentBuyPrice = prices[0];
            int currentProfit = 0;
            int currentSellPrice = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < currentBuyPrice)
                {
                    currentBuyPrice = prices[i];
                    continue;
                }

                if (prices[i] > currentBuyPrice)
                {
                    int tempProfit = prices[i] - currentBuyPrice;
                    if (tempProfit > currentProfit)
                    {
                        currentSellPrice = prices[i];
                        currentProfit = tempProfit;
                    }
                }
            }

            GC.Collect();
            return currentProfit;
            #endregion
        }
        static List<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            List<bool> result = new List<bool>();

            int maxCandies = candies.Max();

            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] + extraCandies >= maxCandies) result.Add(true);
                else result.Add(false);
            }
            GC.Collect();
            return result;
        }
        static bool CanCross(int[] stones)
        {
            int currentJump = 1;
            for (int i = 1; i < stones.Length; i++)
            {

            }

            return true;
        }
        static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            //int l = nums.Length;
            //List<int> temp = new List<int>();
            //int[] ans = new int[l];
            //temp.AddRange(nums);
            //temp.Sort();
            //for (int i = 0; i < l; i++)
            //{
            //    ans[i] = temp.IndexOf(nums[i]);
            //}
            //return ans;

            int counter = 0;
            int[] result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j) continue;

                    if (nums[j] < nums[i]) counter++;
                }

                result[i] = counter;
                counter = 0;
            }
            GC.Collect();
            return result;
        }
        static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == q) return true;
            if (p == null || q == null) return false;
            if (p.val != q.val) return false;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
        static List<string> BinaryTreePaths(TreeNode root)
        {//unfinished
            List<string> result = new List<string>();

            TreeNode temp = root;
            string path = "";

            while (temp != null)
            {
                path += Convert.ToString(temp.val + "->");
                if (temp.left == null && temp.right != null) temp = temp.right;
                else if (temp.right == null && temp.left != null) temp = temp.left;
            }

            result.Add(path);

            return result;
        }
        static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> entries = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (entries.Keys.Contains(nums[i]))
                {
                    entries[nums[i]] += 1;
                }
                else
                {
                    entries.Add(nums[i], 1);
                }
            }

            return entries.Where(c => c.Value > (nums.Length / 2)).FirstOrDefault().Key;
        }
        static int MissingNumber(int[] nums)
        {
            if (!nums.Contains(nums.Length)) return nums.Length;

            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != nums[i]) return i;
            }
            return 0;
        }
        static List<List<int>> Generate(int numRows)
        {
            if (numRows == 1)
            {
                List<List<int>> result = new List<List<int>>();
                List<int> temp = new List<int>();
                temp.Add(1);
                result.Add(temp);
                return result;
            }

            else if (numRows == 2)
            {
                List<List<int>> result = new List<List<int>>();
                List<int> temp = new List<int>();
                temp.Add(1);
                result.Add(temp);
                result.Add(temp);
                return result;
            }

            else
            {
                List<List<int>> result = new List<List<int>>();
                List<int> temp = new List<int>();

                for (int i = 0; i <= numRows; i++)
                {
                    Generate(i - 1);
                    temp[i] = result[i - 1][i] + result[i - 1][i + 1];
                    result.Add(temp);
                }

                return result;
            }

        }
        static int NumJewelsInStones(string jewels, string stones)
        {
            int counter = 0;
            foreach (char c in stones)
            {
                if (jewels.Contains(c))
                {
                    counter++;
                }
            }
            GC.Collect();
            return counter;
        }
        static int GetSum(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;

            if (b < 0)
            {
                for (int i = b; i <= -1; i++)
                {
                    a--;
                }
            }
            else
            {
                for (int i = b; i >= 1; i--)
                {
                    a++;
                }
            }

            return a;
        }
        static int CountDigits(int num)
        {
            int original = num;
            int length = num.ToString().Length;
            int counter = 0;

            for (int i = 0; i < length; i++)
            {
                int remainder = num % 10;

                if (original % remainder == 0) counter++;

                num -= remainder;
                num /= 10;
            }
            return counter;
        }
        static int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }
        static bool IsPowerOfTwo(int n)
        {
            int temp = n;
            if (n < 0)
            {
                temp = -1 * n;
            }

            double d = Math.Log(temp, 2);
            d = Math.Round(d, 10);

            if (d % 1 == 0) return true;
            else return false;
        }
        static bool IsPalindrome(ListNode head)
        {
            #region first attempt
            //int[] arr = new int[] { };

            //while(head != null)
            //{
            //    int p = head.val;
            //    arr = arr.Append(p).ToArray();
            //    head = head.next;
            //}

            //int[] arrRev = new int[arr.Length];

            //arrRev = arr;

            //Array.Reverse(arr);

            //if (arr == arrRev) return true;
            //else return false;
            #endregion

            Dictionary<int, int> catalog = new Dictionary<int, int>();

            ListNode temp = head;

            int i = 0;

            while (temp != null)
            {
                catalog.Add(i, temp.val);
                temp = temp.next;
                i++;
            }

            temp = head;

            int mid = (catalog.Count / 2) + 1;

            for (int j = 0; j < mid; j++)
            {
                if (temp.val == catalog[catalog.Count - 1 - j])
                {
                    temp = temp.next;
                    continue;
                }

                else return false;
            }

            return true;
        }
        static int Fib(int n)
        {
            if (n == 0) return 0;
            else if (n == 1) return 1;
            else return Fib(n - 1) + Fib(n - 2);
        }
        static double MyPow(double x, int n)
        {
            if (n >= 0)
            {
                if (n == 0) return 1;
                else if (n == 1) return x;
                else if (n > 1000) return Math.Pow(x, n);
                else
                {
                    return x * MyPow(x, n - 1);
                }
            }

            else
            {
                if (n == -1) return 1 / x;
                else
                {
                    n = n * -1;
                    GC.Collect();
                    return 1 / (x * MyPow(x, n - 1));
                }
            }

        }
        static int FinalValueAfterOperations(string[] operations)
        {
            int result = 0;

            for (int i = 0; i < operations.Count(); i++)
            {
                if (operations[i].Contains("++")) result++;
                else if (operations[i].Contains("--")) result--;
            }

            return result;
        }
        static int MaximumWealth(int[][] accounts)
        {
            List<int> totals = new List<int>();
            for (int i = 0; i < accounts.Length; i++)
            {
                int sum = 0;

                for (int j = 0; j < accounts[i].Count(); j++)
                {
                    sum += accounts[i][j];
                }

                totals.Add(sum);
            }

            return totals.Max();
        }
        static string SortSentence(string s)
        {
            string output = "";
            List<string> words = s.Split(' ').ToList();
            Dictionary<int, string> catalog = new Dictionary<int, string>(words.Count());

            for (int i = 0; i < words.Count(); i++)
            {
                int index = Convert.ToInt32(words[i][words[i].Length - 1]) - '0'; //converting ascii to int
                words[i] = words[i].Remove(words[i].Length - 1, 1);
                catalog[index] = words[i];

            }

            for (int j = 0; j < catalog.Count(); j++)
            {
                output += catalog[j + 1];
                output += " ";
            }

            output = output.Remove(output.Length - 1, 1);

            return output;
        }
        static int PeakIndexInMountainArray(int[] arr)
        {
            int leftIndex = 0;
            int rightIndex = arr.Length - 1 - leftIndex;
            int midIndex = (rightIndex - leftIndex) / 2;

            if (arr[midIndex] == arr.Max()) return midIndex;



            return 0;
        }
        static int LengthOfLastWord(string s)
        {
            //string[] words = s.Split(' ');
            //List<string> wordS = words.Where(c => c.Length == 0).FirstOrDefault().Remove(0,0).ToList();
            s = s.Trim();
            List<string> words = s.Split(' ').Where(c => c.Length > 0).ToList();
            return words[words.Count() - 1].Length;
        }
        static int CountNegatives(int[][] grid)
        {
            int numOfNegatives = 0;
            for (int i = 0; i < grid.Count(); i++)
            {
                for (int j = grid[i].Length - 1; j >= 0; j--)
                {
                    if (grid[i][j] >= 0)
                    {
                        break;
                    }
                    numOfNegatives++;
                }
            }
            return numOfNegatives;
        }
        static List<int> TargetIndices(int[] nums, int target)
        {
            List<int> result = new List<int>();
            #region sort
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
            #endregion

            //for (int p = 0; p < nums.Length; p++)
            //{
            //    if (target == nums[p]) result.Add(p);
            //    if (nums[p] > target) break;
            //}

            int left = 0;
            int right = nums.Length - 1;

            int mid = left + (right - left) / 2;
            if (target > nums[mid])
            {
                left = mid + 1;
            }

            else if (target < nums[mid])
            {
                right = mid;
            }


            for (int p = left; p <= right; p++)
            {
                if (target == nums[p]) result.Add(p);
            }



            return result;
        }
        static int[] Intersection(int[] nums1, int[] nums2)
        {
            //int size = nums1.Length > nums2.Length ? nums1.Length : nums2.Length;
            List<int> p = new List<int>();

            foreach (int c in nums2)
            {
                if (p.Contains(c)) continue;
                if (nums1.Contains(c))
                {
                    p.Add(c);
                }
            }

            int[] result = new int[p.Count()];

            result = p.ToArray();
            p = null;
            return result;
        }
        static int GuessNumber(int n)
        {
            //2^31 = 2147483648

            int guess = 1073741824;
            int result = 0;



            int Calc(int a, int b)
            {
                if (b == -1)
                {
                    a = Convert.ToInt32(Math.Ceiling(a + (a * .5)));
                }
                return a;
            }

            return 0;
        }
        static int ClimbStairs(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            // recursive approach 
            // return ClimbStairs(n-1)+ ClimbStairs(n-2);
            int c = 0;
            int a = 1;
            int b = 2;

            for (int i = 2; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return b;
        }
        static int SubtractProductAndSum(int n)
        {
            //int index = Convert.ToInt32(words[i][words[i].Length - 1]) - '0';

            int product = 1;
            int sum = 0;

            string s = Convert.ToString(n);

            foreach (char c in s)
            {
                product *= (Convert.ToInt32(c) - '0');
                sum += (Convert.ToInt32(c) - '0');
            }

            return product - sum;
        }
        static List<List<int>> ThreeSum(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();


            for (int i = 0; i < nums.Length - 1; i++)
            {
                Dictionary<int, int> catalog = new Dictionary<int, int>();
                List<int> numbers = new List<int>();
                int sum = 0;

                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    sum = nums[i] + nums[j];
                    catalog.Add(j, sum);


                    for (int k = j + 1; k < nums.Length - 1; k++)
                    {
                        if (sum + nums[k] == 0)
                        {
                            numbers.Add(nums[i]);
                            numbers.Add(catalog[j]);
                            numbers.Add(nums[k]);

                            result.Add(numbers);
                        }
                    }
                }
            }

            return result;
        }
        static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 1) return 1;
            if (nums.Length == 2) return 2;
            int currentInt = nums[0];
            int counter = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (currentInt == nums[i])
                {
                    counter++;
                    if (counter == 3)
                    {
                        int temp = nums[i];
                        for (int j = i; j < nums.Length; j++)
                        {

                            if (j != nums.Length - 1) nums[j] = nums[j + 1];
                            else nums[j] = temp;

                        }

                    }
                }

                else
                {
                    currentInt = nums[i];
                    counter = 1;
                }
            }

            return 0;
        }
        static int[] SortedSquares(int[] nums)
        {
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[i] * nums[i];
            }

            for (int j = 0; j < result.Length; j++)
            {
                for (int k = 0; k < result.Length - 1 - j; k++)
                {
                    if (result[k] > result[k + 1])
                    {
                        int temp = result[k];
                        result[k] = result[k + 1];
                        result[k + 1] = temp;
                    }
                }
            }

            return result;
        }
        static int FindJudge(int n, int[][] trust)
        {
            List<int> norm = new List<int>();
            int judge = trust[0][1];

            for (int i = 0; i < trust.Length; i++)
            {
                norm.Add(trust[i][0]);
            }

            return judge;
        }
        static int HeightChecker(int[] heights)
        {
            int result = 0;

            Dictionary<int, int> catalog = new Dictionary<int, int>();

            for (int i = 0; i < heights.Length; i++)
            {
                catalog.Add(i, heights[i]);
            }

            for (int j = 0; j < heights.Length; j++)
            {
                for (int k = 0; k < heights.Length - 1 - j; k++)
                {
                    if (heights[k] > heights[k + 1])
                    {
                        int p = heights[k];
                        heights[k] = heights[k + 1];
                        heights[k + 1] = p;
                    }
                }
            }

            for (int j = 0; j < heights.Length; j++)
            {
                if (heights[j] != catalog[j]) result++;
            }

            return result;
        }
        static int[] ArrayRankTransform(int[] arr)
        {
            if (arr.Length == 0) return new int[0];
            List<int> unsortedList = new List<int>();
            int[] result = new int[arr.Length];
            unsortedList = arr.OfType<int>().ToList();
            Array.Sort(arr);
            int currentRank = 1;
            int prevNum = arr[0];
            List<KeyValuePair<int, int>> catalog = new List<KeyValuePair<int, int>>();

            catalog.Add(new KeyValuePair<int, int>(currentRank, arr[0]));

            for (int k = 1; k < arr.Count(); k++)
            {
                if (arr[k] > prevNum) currentRank++;
                catalog.Add(new KeyValuePair<int, int>(currentRank, arr[k]));
                prevNum = arr[k];
            }

            for (int k = 0; k < arr.Count(); k++)
            {
                result[k] = catalog.Where(c => c.Value == unsortedList[k]).FirstOrDefault().Key;
            }

            return result;
        }
        static int MaximizeSum(int[] nums, int k)
        {
            Array.Sort(nums);
            int sum = 0;

            for (int i = 0; i < k; i++)
            {
                sum += nums[nums.Length - 1];
                nums[nums.Length - 1] += 1;
            }

            return sum;
        }
        static string RemoveTrailingZeros(string num)
        {
            for (int i = num.Length - 1; i >= 0; i--)
            {
                if (num[i] != '0') return num;
                else num = num.Remove(num.Length - 1);
            }
            return num;
        }
        static ListNode SortList(ListNode head)
        {
            List<int> nums = new List<int>();
            ListNode temp = head;

            while (temp != null)
            {
                nums.Add(temp.val);
                temp = temp.next;
            }

            int[] arr = new int[nums.Count()];
            arr = nums.ToArray();
            Array.Sort(arr);

            temp = head;
            int i = 0;

            while (temp != null)
            {
                temp.val = arr[i];
                temp = temp.next;
                i++;
            }
            return head;
        }
        static int CountPairs(List<int> nums, int target)
        {
            int[] arr = new int[nums.Count()];
            arr = nums.ToArray();
            Array.Sort(arr);

            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                //if (arr[i] >= target) break;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] >= target) break;
                    sum++;
                }
            }


            return sum;
        }
        static int ThirdMax(int[] nums)
        {
            quickSort(nums, 0, nums.Length - 1);

            nums = nums.Distinct().ToList().ToArray();

            if (nums.Length < 3) return nums[nums.Length - 1];
            else return nums[nums.Length - 3];

            void quickSort(int[] numbers, int min, int max)
            {
                if (min >= max)
                {
                    return;
                }

                int pivotIndex = partition(numbers, min, max);
                quickSort(numbers, min, pivotIndex - 1);
                quickSort(numbers, pivotIndex + 1, max);

                int partition(int[] arr, int low, int high)
                {
                    int pivot = arr[high];
                    int index = low - 1;
                    for (int i = low; i < high; i++)
                    {
                        if (arr[i] <= pivot)
                        {
                            index++;
                            int temp = arr[i];
                            arr[i] = arr[index];
                            arr[index] = temp;
                        }

                    }

                    index++;
                    arr[high] = arr[index];
                    arr[index] = pivot;

                    return index;
                }

            }
        }
        static string[] SortPeople(string[] names, int[] heights)
        {
            quickSort(heights, names, 0, heights.Length - 1);

            void quickSort(int[] nums, string[] name, int min, int max)
            {
                if (min >= max)
                {
                    return;
                }

                int pivotIndex = partition(nums, name, min, max);
                quickSort(nums, name, min, pivotIndex - 1);
                quickSort(nums, name, pivotIndex + 1, max);

                int partition(int[] arr, string[] nm, int low, int high)
                {
                    string pvStr = nm[high];
                    int pivot = arr[high];
                    int index = low - 1;
                    for (int i = low; i < high; i++)
                    {
                        if (arr[i] <= pivot)
                        {
                            index++;
                            int temp = arr[i];
                            arr[i] = arr[index];
                            arr[index] = temp;

                            string tmpry = nm[i];
                            nm[i] = nm[index];
                            nm[index] = tmpry;
                        }

                    }

                    index++;
                    arr[high] = arr[index];
                    arr[index] = pivot;

                    nm[high] = nm[index];
                    nm[index] = pvStr;

                    return index;
                }

            }

            for (int i = 0, j = names.Length - 1; i < names.Length / 2; i++, j--)
            {
                string poo = names[i];
                names[i] = names[j];
                names[j] = poo;
            }

            return names;
        }
        static string[] FindRelativeRanks(int[] score)
        {
            string[] ranks = new string[score.Length];
            if (score.Length < 3)
            {
                int i = 0;
                foreach (int sc in score)
                {
                    if (sc == score.Max()) ranks[i] = "Gold Medal";
                    else if (sc == score.Min()) ranks[i] = "Silver Medal";

                    i++;
                }
            }

            else
            {
                Dictionary<int, string> catalog = new Dictionary<int, string>();
                List<int> temp = score.ToList();
                Array.Sort(score);
                Array.Reverse(score);
                List<int> sortedList = score.ToList();
                int goldVal = score[0];
                int silverVal = score[1];
                int bronzeVal = score[2];
                for (int p = 0; p < score.Length; p++)
                {
                    if (temp[p] == goldVal)
                    {
                        ranks[p] = "Gold Medal";
                    }
                    else if (temp[p] == silverVal)
                    {
                        ranks[p] = "Silver Medal";
                    }
                    else if (temp[p] == bronzeVal)
                    {
                        ranks[p] = "Bronze Medal";
                    }
                    else
                    {
                        ranks[p] = Convert.ToString(sortedList.IndexOf(temp[p]) + 1);
                    }
                }
            }
            return ranks;
        }
        static int RangeSumBST(TreeNode root, int low, int high)
        {
            int sum = 0;
            sum = sum + walk(root, high, low);
            int walk(TreeNode node, int lo, int hi)
            {
                int total = 0;

                if (node == null)
                    return 0;

                if (node.val >= lo && node.val <= hi)
                {
                    total += node.val;
                }

                total += walk(node.left, lo, hi);
                total += walk(node.right, lo, hi);

                return total;
            }
            return sum;
        }
        static string Interpret(string command)
        {
            //"()" as the string "o"
            //"G" as the string "G"
            //"(al)" as the string "al"

            string result = "";
            string sub = "";

            foreach (char c in command)
            {
                sub += c;
                if (c == ')' || c == 'G')
                {
                    if (sub == "()" || sub == "G" || sub == "(al)")
                    {
                        if (sub == "()") result += "o";
                        else if (sub == "G") result += "G";
                        else if (sub == "(al)") result += "al";

                        sub = "";
                    }
                }
            }


            return result;
        }
        static string ReplaceDigits(string s)
        {
            string temp = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0)
                {
                    temp += s[i];
                }
                else
                {
                    temp += shift(s[i - 1], s[i] - '0');
                }
            }

            char shift(char c, int x)
            {
                return (char)((c + x));
            }

            return temp;
        }
        static void Rotate(int[] a, int k)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (i + k < a.Length - 1)
                {
                    int temp = a[i + k];
                    a[i + k] = a[i];
                    a[i] = temp;
                }
                else
                {

                }
            }
        }
        static TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return null;
            if (root.val == val) return root;
            if (root.val < val) return SearchBST(root.right, val);
            else return SearchBST(root.left, val);
        }
        static void MoveZeroes(int[] nums)
        {
            //for(int i = 0; i < nums.Length; i++)
            //{
            //    for(int j = 0; j< nums.Length - 1 - i; j++)
            //    {
            //        if(nums[j] == 0)
            //        {
            //            int temp = nums[j];
            //            nums[j] = nums[j + 1];
            //            nums[j + 1] = temp;
            //        }
            //    }
            //}
            int left = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] != 0)
                {
                    (nums[left], nums[right]) = (nums[right], nums[left]);
                    left++;
                }
            }
        }
        static IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            walk(root, result);

            void walk(TreeNode r, IList<int> p)
            {
                if (r == null) return;
                walk(r.left, p);
                p.Add(r.val);
                walk(r.right, p);
            }
            return result;
        }
        static int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = MaxDepth(root.left);
            int right = MaxDepth(root.right);

            return Math.Max(left, right) + 1;
        }
        static int[] SortArrayByParity(int[] nums)
        {
            int currentStart = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 != 0) continue;

                else
                {
                    int temp = nums[currentStart];
                    nums[currentStart] = nums[i];
                    nums[i] = temp;

                    currentStart++;
                }
            }

            return nums;
        }
        static bool IsMonotonic(int[] nums)
        {
            bool is_greater = true;
            int firstNum = nums[0];
            int flag = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != firstNum)
                {
                    if (flag != 1)
                    {
                        if (nums[i] > firstNum) is_greater = true;
                        else is_greater = false;
                        flag = 1;
                    }
                }

                if (flag == 1)
                {
                    if (is_greater == true && nums[i] < nums[i - 1])//greater but decreasing
                    {
                        return false;
                    }

                    if (is_greater == false && nums[i] > nums[i - 1])//smaller but increasing
                    {
                        return false;
                    }
                }

            }

            return true;
        }
        static string ReverseWords(string s)
        {
            string[] words = s.Split(' ');

            string result = "";

            foreach (string word in words)
            {
                string rev = "";
                for (int j = word.Length - 1; j >= 0; j--)
                {
                    rev += word[j];
                }

                result += rev + ' ';
            }

            return result.TrimEnd();
        }
        static int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
        {
            quickSort(hours, 0, hours.Length - 1);

            int count = 0;
            for (int i = hours.Length - 1; i >= 0; i--)
            {
                if (target <= hours[i]) count++;
                else break;
            }

            void quickSort(int[] nums, int min, int max)
            {
                if (min >= max)
                {
                    return;
                }
                int pivotIndex = partition(nums, min, max);
                quickSort(nums, min, pivotIndex - 1);
                quickSort(nums, pivotIndex + 1, max);

                int partition(int[] arr, int low, int high)
                {
                    int pivot = arr[high];
                    int index = low - 1;
                    for (int i = low; i < high; i++)
                    {
                        if (arr[i] <= pivot)
                        {
                            index++;
                            int temp = arr[i];
                            arr[i] = arr[index];
                            arr[index] = temp;
                        }
                    }
                    index++;
                    arr[high] = arr[index];
                    arr[index] = pivot;
                    return index;
                }
            }
            return count;
        }
        static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode temp = head;
            int count = 0;

            while (temp != null)
            {
                count++;
                temp = temp.next;
            }

            temp = head;
            if (count == 1 && n == 1) return new ListNode();
            if (count == n)
            {
                temp = temp.next;
                return temp;
            }

            int removeIdx = count - n;

            int i = 0;
            while (i <= removeIdx)
            {
                i++;
                if (i == removeIdx)
                {
                    temp.next = temp.next.next;
                    break;
                }
                else temp = temp.next;
            }

            return head;

            //ListNode dummy = new ListNode(0, head); // Create a dummy node
            //ListNode slow = dummy, fast = dummy;

            //// Gap of fast and slow is n
            //for (int i = 0; i < n; i++)
            //{
            //    fast = fast.next;
            //}

            //// Move slow to the node behind the node to delete
            //while (fast?.next != null)
            //{
            //    slow = slow.next;
            //    fast = fast.next;
            //}

            //// Delete the node
            //slow.next = slow.next.next;

            //return dummy.next;
        }
        static List<int> MajorityElement2(int[] nums)
        {
            Dictionary<int, int> catalogs = new Dictionary<int, int>();
            List<int> result = new List<int>();

            decimal minRepeat = Convert.ToDecimal(nums.Length) / 3;

            for (int i = 0; i < nums.Length; i++)
            {

                if (!catalogs.ContainsKey(nums[i])) catalogs.Add(nums[i], 1);
                else catalogs[nums[i]]++;
            }

            foreach (var kvp in catalogs)
            {
                if (kvp.Value > minRepeat) result.Add(kvp.Key);
            }

            return result;
        }
        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int count1 = 0;
            int count2 = 0;
            ListNode p = l1;
            while (p != null)
            {
                count1++;
                p = p.next;
            }
            p = l2;
            while (p != null)
            {
                count2++;
                p = p.next;
            }
            if (count2 > count1)
            {
                ListNode tmp = l1;
                l1 = l2;
                l2 = tmp;
            }

            int carry = 0;

            ListNode temp = l1;

            while (temp != null || l2 != null)
            {
                if (temp == null)
                    temp = new ListNode(0, null);
                if (l2 == null)
                    l2 = new ListNode(0, null);

                temp.val += (l2.val + carry);
                carry = 0;

                if (temp.val > 9)
                {
                    temp.val -= 10;
                    carry = 1;
                }

                temp = temp.next;
                l2 = l2.next;
            }

            if (carry == 1)
            {
                temp = l1;


                while (temp != null)
                {
                    if (temp.next == null)
                    {
                        temp.next = new ListNode(1, null);
                        return l1;
                    }

                    else
                    {
                        temp = temp.next;
                    }
                }
            }
            return l1;
        }
        static int[] SeparateDigits(int[] nums)
        {
            List<int> digits = new List<int>();

            foreach (int c in nums)
            {
                if (c < 10)
                {
                    digits.Add(c);
                }

                else
                {
                    int temp = c;
                    List<int> temp_digits = new List<int>();
                    while (temp > 0)
                    {
                        temp_digits.Add(temp % 10);
                        temp = temp / 10;
                    }
                    temp_digits.Reverse();

                    digits.AddRange(temp_digits);
                }
            }

            return digits.ToArray();
        }
        static int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 1)
            {
                int[] answer = { 0, 0 };
                if (target == nums[0])
                {
                    answer[0] = 0;
                    answer[1] = 0;
                    return answer;
                }

                else
                {
                    answer[0] = -1;
                    answer[1] = -1;
                    return answer;
                }
            }
            int lo = 0;
            int hi = nums.Length;
            int testIdx = -1;
            int startIdx = -1;
            int endIdx = -1;
            int[] result = { startIdx, endIdx };

            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (nums[mid] == target)
                {
                    testIdx = mid;
                    break;
                }

                else if (target > nums[mid])
                {
                    lo = mid + 1;
                }

                else if (target < nums[mid])
                {
                    hi = mid;
                }
            }

            if (testIdx == -1) return result;

            int flag = 0;
            startIdx = testIdx;

            while (flag == 0)
            {
                if (startIdx != 0 && nums[startIdx - 1] == target)
                {
                    startIdx--;
                }
                else
                {
                    flag = 1;
                }
            }


            endIdx = testIdx;
            flag = 0;
            while (flag == 0 && endIdx + 1 < nums.Length)
            {
                if (nums[endIdx + 1] == target)
                {
                    endIdx++;
                }
                else
                {
                    flag = 1;
                }
            }

            result[0] = startIdx;
            result[1] = endIdx;

            return result;
        }
        static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0) return 0;
            if (String.IsNullOrWhiteSpace(s)) return 1;
            Dictionary<string, int> catalog = new Dictionary<string, int>();

            string temp = s;
            int i = 0;
            string p = "";


            #region commented
            while (i < temp.Length)
            {
                if (p.Contains(temp[i]))
                {
                    if (!catalog.ContainsKey(p))
                    {
                        catalog.Add(p, p.Length);
                    }
                    //temp = temp.Substring(p.Length, temp.Length - p.Length);
                    temp = temp.Substring(1, temp.Length - 1);
                    p = "";
                    i = 0;
                }
                else
                {
                    p += temp[i];
                    i++;
                }
            }

            if (p != "" && !catalog.ContainsKey(p))
            {
                catalog.Add(p, p.Length);
            }
            #endregion

            return catalog.Max(t => t.Key.Length);
        }
        static int RemoveDuplicates2(int[] nums)
        {
            if (nums.Length == 1) return 1;
            if (nums.Length == 2) return 2;
            int currentInt = nums[0];
            int counter = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (currentInt == nums[i])
                {
                    counter++;
                    if (counter == 3)
                    {
                        int tmp = nums[i];
                        for (int j = i; j < nums.Length; j++)
                        {
                            if (j == nums.Length - 1)
                            {
                                nums[j] = tmp;
                            }
                            else
                                nums[j] = nums[j + 1];
                        }

                        i--;
                        counter--;
                    }
                }
                else
                {
                    counter = 1;
                    currentInt = nums[i];
                }
            }

            for (int p = 1; p < nums.Length; p++)
            {
                if (nums[p] < nums[p - 1])
                    return p;
            }

            return 0;
        }
        static int SumOfMultiples(int n)
        {
            int sum = 0;
            //3 5 7
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0 || i % 7 == 0) sum += i;
            }

            return sum;
        }
        static int DifferenceOfSums(int n, int m)
        {
            int num1 = 0;
            int num2 = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i % m == 0) num2 += i;
                else num1 += i;
            }

            return num1 - num2;
        }
        static int Divide(int dividend, int divisor)
        {
            int quotient = 0;

            if (dividend >= 0 && divisor >= 0)
            {

                while (dividend - divisor >= 0)
                {
                    dividend -= divisor;
                    quotient++;
                }
            }

            else if (dividend < 0 && divisor < 0)
            {
                dividend *= -1; divisor *= -1;
                while (dividend - divisor >= 0)
                {
                    dividend -= divisor;
                    quotient++;
                }
            }

            else
            {
                if (divisor < 0 && dividend >= 0) divisor *= -1;
                else if (dividend < 0 && divisor >= 0) dividend *= -1;

                while (dividend - divisor >= 0)
                {
                    dividend -= divisor;
                    quotient++;
                }
                quotient *= -1;
            }

            return quotient;
        }
        static ListNode SwapPairs(ListNode head)
        {
            ListNode temp = head;

            int nodeCount = 0;

            while (temp != null)
            {
                nodeCount++;
                temp = temp.next;
            }

            if (nodeCount <= 1) return head;

            temp = head;
            int hop = 0;

            while (temp != null)
            {
                if (hop % 2 == 0 && temp.next != null)
                {
                    int p = temp.val;
                    temp.val = temp.next.val;
                    temp.next.val = p;
                    hop++;
                    temp = temp.next;
                }

                else
                {
                    hop++;
                    temp = temp.next;
                }

            }

            return head;
        }
        static bool Find132pattern(int[] nums)
        {
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = i + 2;

                if (nums[i] < nums[k] && nums[k] < nums[j]) return true;
            }

            return false;
        }
        static int TrailingZeroes(int n)
        {
            int result = 0;
            while (n > 0)
            {
                result += n / 5;
                n /= 5;
            }
            return result;
        }
        static int MaximumGap(int[] nums)
        {
            Array.Sort(nums);

            if (nums.Length <= 2)
            {
                if (nums.Length == 1) return 0;
                else return nums[1] - nums[0];
            }

            int midPoint = nums.Length / 2;

            int maxDiff = nums[1] - nums[0];
            int j = midPoint + 1;

            for (int i = 1; i <= midPoint; i++)
            {
                int firstHalfDiff = nums[i] - nums[i - 1];

                int secondHalfDiff = nums[j] - nums[j - 1];

                if (firstHalfDiff > secondHalfDiff)
                {
                    if (firstHalfDiff > maxDiff) maxDiff = firstHalfDiff;
                }

                if (secondHalfDiff > firstHalfDiff)
                {
                    if (secondHalfDiff > maxDiff) maxDiff = secondHalfDiff;
                }

                j++;
                if (j == nums.Length)
                    j--;
            }

            return maxDiff;
        }
        static ListNode RotateRight(ListNode head, int k)
        {
            ListNode temp = head;
            int totalNodes = 0;

            while (temp != null)
            {
                totalNodes++;
                temp = temp.next;
            }

            if (k == totalNodes) return head;
            int realCount = totalNodes - k;
            temp = head;
            ListNode p = temp;

            for (int i = 0; i <= totalNodes; i++)
            {
                if (i == realCount)
                {
                    head = temp;
                    temp = temp.next;
                }
                else if (i == totalNodes)
                {
                    temp.next = p;
                }
                else
                {
                    temp = temp.next;
                    p.next = temp;
                }
            }
            return head;
        }
        static int RepeatedNTimes(int[] nums)
        {
            int n = nums.Length / 2;

            Dictionary<int, int> catalog = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!catalog.Keys.Contains(nums[i]))
                {
                    catalog.Add(nums[i], 1);
                }

                else
                {
                    catalog[nums[i]]++;
                }
            }

            return catalog.Where(c => c.Value == n).SingleOrDefault().Key;
        }
        static int[] TwoSum(int[] numbers, int target)
        {
            if (numbers.Length == 2) return new int[] { 0, 1 };
            int x = 0;
            int y = numbers.Length - 1;
            while (y >= 0)
            {
                for (int i = 0; i <= y; i++)
                {
                    if (numbers[i] == target - numbers[y])
                    {
                        x = i;
                        return new int[] { x + 1, y + 1 };
                    }
                }
                y--;
            }
            return new int[] { x, y };
        }
        static bool BackspaceCompare(string s, string t)
        {
            string removeBeginningHash(string p)
            {
                if (p[0] == '#')
                {
                    p = p.Remove(0, 1);
                }

                return p;
            }
            s = removeBeginningHash(s);
            t = removeBeginningHash(t);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[0] == '#')
                {
                    s = s.Remove(0, 1);
                    i--;
                    continue;
                }

                if (s[i] == '#')
                {
                    s = s.Remove(i - 1, 2);
                    i -= 2;
                }
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (t[0] == '#')
                {
                    t = t.Remove(0, 1);
                    i--;
                    continue;
                }

                if (t[i] == '#')
                {
                    t = t.Remove(i - 1, 2);
                    i -= 2;
                }
            }

            if (s == t) return true;
            else return false;
        }
        static ListNode MergeNodes(ListNode head)
        {
            ListNode temp = head.next;
            bool flag = true;
            ListNode result = new ListNode(0, null);
            ListNode resultTmp = new ListNode();
            resultTmp = result;

            int sum = 0;
            while (temp != null)
            {
                if (flag)
                {
                    if (temp.val == 0)
                    {
                        flag = false;
                        continue;
                    }
                    sum += temp.val;
                    temp = temp.next;
                    continue;
                }

                else
                {
                    temp.val = sum;
                    resultTmp.next = temp;
                    if (temp.next != null)
                    {
                        temp = temp.next;
                        resultTmp = resultTmp.next;
                    }
                    flag = true;
                    sum = 0;
                }

            }

            return result.next;
        }
        static int interview()
        {
            int hare = 5;
            int tortoise = 11;
            int j = 0;

            for (j = 0; j < 20; j++)
            {
                if (hare < tortoise)
                    hare *= 2;
                else if (hare == tortoise)
                    break;
                else
                    tortoise += 1;
            }
            return hare + tortoise;

        }
        static int NumSquares(int n)
        {
            int[] dp = new int[n + 1];
            //Array.Fill(dp, -1);
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = -1;
            }
            int solve(int x)
            {
                if (x == 0) return 0;
                if (dp[x] != -1) return dp[x];
                int min = Int32.MaxValue;
                for (int i = 1; i * i <= x; i++)
                {
                    min = Math.Min(min, solve(x - i * i));
                }
                return dp[x] = min + 1;
            }
            return solve(n);

        }
        static List<IList<int>> Generate2(int numRows)
        {
            #region commented code but it works just fine
            //List<List<int>> result = new List<List<int>>();

            //for (int j = 1; j <= numRows; j++)
            //{
            //    result.Add(GenList(j));
            //}      

            //List<int>GenList(int n)
            //{
            //    List<int> p = new List<int>();
            //    if(n == 1)
            //    {
            //        p.Add(1);
            //        return p;
            //    }
            //    else if(n == 2)
            //    {
            //        p.Add(1);
            //        p.Add(1);
            //        return p;
            //    }
            //    else
            //    {
            //        p.Add(1);
            //        for (int i = 1; i < n - 1; i++) 
            //        {
            //            p.Add(GenList(n - 1)[i - 1] + GenList(n - 1)[i]);
            //        }
            //        p.Add(1);
            //        return p;
            //    }
            //}
            //return result;
            #endregion

            List<IList<int>> result = new List<IList<int>>();
            List<int> temp = new List<int>();//prev

            for (int i = 1; i <= numRows; i++)
            {
                List<int> res = new List<int>();//current

                for (int j = 0; j < i; j++)
                {
                    if (j == 0 || j == i - 1)
                    {
                        res.Add(1);
                        continue;
                    }

                    res.Add(temp[j - 1] + temp[j]);
                }

                temp = res;
                result.Add(res);
            }

            return result;
        }
        static bool EqualFrequency(string word)
        {
            Dictionary<char, int> keywords = new Dictionary<char, int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (keywords.Keys.Contains(word[i]))
                {
                    keywords[word[i]]++;
                }
                else
                {
                    keywords.Add(word[i], 1);
                }
            }
            int maxFreq = keywords.Values.Max();
            int minFreq = keywords.Values.Min();
            if (maxFreq == minFreq && minFreq == 1) return true;
            if (maxFreq == minFreq) return false;
            List<int> frequencies = keywords.Values.ToList();
            int minFreqCount = frequencies.Where(c => c == minFreq).FirstOrDefault();
            int maxFreqCount = frequencies.Where(c => c == maxFreq).FirstOrDefault();
            if (minFreqCount > 1 && maxFreqCount > 1 && (int)Math.Abs(minFreqCount - maxFreqCount) != 1) return false;
            if ((int)Math.Abs(minFreqCount - maxFreqCount) == 1) return true;

            return false;
        }
        static List<int> LargestValues(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<int> result = new List<int>();
            queue.Enqueue(root);
            result.Add(root.val);


            while (queue.Count > 0)
            {

                root = queue.Dequeue();

                if (root.left != null)
                {
                    queue.Enqueue(root.left);
                }
                if (root.right != null)
                {
                    queue.Enqueue(root.right);
                }
            }

            return result;
        }
        static int KthGrammar(int n, int k)
        {
            string test = generateString(n);
            int answer = test[k - 1] - '0';
            return answer;
            string generateString(int p)
            {
                if (p == 1) return "0";
                else if (p == 2) return "01";
                else
                {
                    string curr = generateString(2);
                    int level = 2;
                    while (level <= p)
                    {
                        string ong = curr;

                        string firstPart = curr;
                        string secondPart = curr.Substring(curr.Length / 2);
                        string lastPart = curr.Substring(0, curr.Length / 2);

                        ong = firstPart + secondPart + lastPart;
                        curr = ong;
                        level++;
                    }
                    return curr;
                }
            }
        }
        static int CountOperations(int num1, int num2)
        {
            if (num1 == 0 && num2 == 0) return 0;
            if (num1 == num2) return 1;

            int ops = 0;

            while (num1 != 0 && num2 != 0)
            {
                if (num1 >= num2)
                {
                    num1 -= num2;
                }

                else if (num2 >= num1)
                {
                    num2 -= num1;
                }
                ops++;
            }

            return ops;
        }
        static List<int> FindDuplicates(int[] nums)
        {
            Dictionary<int, int> catalog = new Dictionary<int, int>();

            foreach (int c in nums)
            {
                if (catalog.ContainsKey(c))
                {
                    catalog[c]++;
                }
                else
                {
                    catalog.Add(c, 1);
                }
            }
            List<int> res = new List<int>();
            foreach (int p in catalog.Keys)
            {
                if (catalog[p] == 2) res.Add(p);
            }

            return res;
        }
        static string RemoveStars(string s)
        {
            //for(int i = 0; i < s.Length; i++)
            //{
            //    if(s[i] == '*')
            //    {
            //        s = s.Remove(i - 1, 2);
            //        i-=2;
            //    }
            //}

            //return s;
            Stack<char> stk = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '*')
                {
                    stk.Pop();
                }
                else
                {
                    stk.Push(c);
                }
            }
            return string.Concat(stk.Reverse().ToArray());
        }
        static int[] RearrangeArray(int[] nums)
        {
            List<int> result = new List<int>();
            int[] pos = new int[nums.Length / 2];
            int[] neg = new int[nums.Length / 2];

            int posIdx = 0;
            int negIdx = 0;

            for (int i = 0; i < nums.Length; i++)
            {

                if (nums[i] > 0)
                {
                    pos[posIdx] = nums[i];
                    posIdx++;
                }

                else
                {
                    neg[negIdx] = nums[i];
                    negIdx++;
                }
            }

            for (int j = 0; j < pos.Length; j++)
            {
                result.Add(pos[j]);
                result.Add(neg[j]);
            }


            return result.ToArray();
        }
        static int CountDistinctIntegers(int[] nums)
        {
            List<int> numbers = nums.ToList();

            foreach (int c in nums)
            {
                //char[] rev = c.ToString().ToCharArray();
                //Array.Reverse(rev);
                //int n = Convert.ToInt32(string.Concat(rev));
                //numbers.Add(n);
                //GC.Collect(n);

                int res = 0;
                int num = c;
                while (num != 0)
                {
                    res = res * 10 + num % 10;
                    num /= 10;
                }

                numbers.Add(res);
            }

            int result = numbers.Distinct().ToList().Count();

            return result;
            #region better solution
            //static int CountDistinctIntegers(int[] nums)
            //{
            //    var numbers = new HashSet<int>();

            //    foreach (var number in nums)
            //    {
            //        numbers.Add(number);
            //        numbers.Add(Reverse(number));
            //    }

            //    return numbers.Count();

            //    int Reverse(int n)
            //    {
            //        var result = 0;

            //        while (n != 0)
            //        {
            //            result = result * 10 + n % 10;
            //            n /= 10;
            //        }
            //        return result;
            //    }
            //}
            #endregion
        }
        static int PairSum(ListNode head)
        {

            ListNode temp = head;

            int n = 0;

            while (temp != null)
            {
                temp = temp.next;
                n++;
            }
            int[] sums = new int[n / 2];
            temp = head;
            for (int i = 0; i < n; i++)
            {
                if (i < n / 2)
                {
                    sums[i] = temp.val;
                }
                else
                {
                    sums[n - 1 - i] += temp.val;
                }

                temp = temp.next;
            }
            return sums.Max();
        }
        static int[] MaxSlidingWindow(int[] nums, int k)
        {
            #region commented
            //first attempt
            //int [] result = new int [nums.Length - 2];
            ////int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };

            //for(int i = 1; i<= nums.Length -2; i++)
            //{
            //    int[] window = new int[k];
            //    int p = 0;
            //    for (int j = i-1; j< i+k-1 ; j++)
            //    {                    
            //        window[p] = nums[j];
            //        p++;
            //    }
            //    result[i-1] = window.Max();
            //}

            //2nd attempt
            //int[] nums = { 9,11,14 };
            //if (nums.Length == 1 || k == 1) return nums;
            //int[] result = { };
            //for (int i = 0; i < nums.Length - 1 ; i++)
            //{
            //    int[] window = new int[k];
            //    int p = 0;
            //    for (int j = i ; j <= i + k - 1; j++)
            //    {
            //        window[p] = nums[j];
            //        if(j == nums.Length - 1)
            //        {
            //            result = result.Append(window.Max()).ToArray();
            //            return result;
            //        }
            //        p++;
            //    }
            //    result = result.Append(window.Max()).ToArray();
            //}

            //return result;


            //3rd Attempt

            //if (nums.Length == 1 || k == 1) return nums;
            //int[] result = { };
            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    int[] window = new int[k];
            //    Array.Copy(nums, i, window, 0, k);
            //    result = result.Append(window.Max()).ToArray();
            //    if (i + k == nums.Length)
            //    {
            //        return result;
            //    }

            //}
            #endregion
            //3rd Attempt

            if (nums.Length == 1 || k == 1) return nums;
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int[] window = new int[k];
                Array.Copy(nums, i, window, 0, k);
                result.Add(window.Max());
                if (i + k == nums.Length)
                {
                    return result.ToArray();
                }

            }

            return result.ToArray();
        }
        static ListNode InsertGreatestCommonDivisors(ListNode head)
        {
            ListNode temp = head;

            while (temp.next != null)
            {
                int gcdValue = GCD(temp.val, temp.next.val);

                ListNode newNode = new ListNode();
                newNode.val = gcdValue;
                newNode.next = temp.next;
                temp.next = newNode;
                temp = temp.next.next;
            }
            return head;
            int GCD(int a, int b)
            {
                while (a != 0 && b != 0)
                {
                    if (a > b)
                        a %= b;
                    else
                        b %= a;
                }
                return a | b;
            }
        }
        static int FindGCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }
        static int[] PivotArray(int[] nums, int pivot)
        {
            int pivotIndex = -1;

            for (int i = 0; i < nums.Length; i++)
            {

                if (nums[i] <= pivot)
                {
                    pivotIndex++;//0,1
                    int temp = nums[i];
                    nums[i] = nums[pivotIndex];
                    nums[pivotIndex] = temp;
                }
            }

            return nums;
        }
        static int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int prev1 = 0;
            int prev2 = 0;
            foreach (int num in nums)
            {
                int tmp = prev1;
                prev1 = Math.Max(prev2 + num, prev1);
                prev2 = tmp;
            }
            return prev1;
        }
        static int MostWordsFound(string[] sentences)
        {
            List<int> lengths = new List<int>();

            foreach (string s in sentences)
            {
                int length = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ') length++;
                }

                lengths.Add(length + 1);
            }
            return lengths.Max();
        }
        static int FindDuplicate(int[] nums)
        {
            List<int> res = new List<int>();

            foreach (int c in nums)
            {
                if (!res.Contains(c))
                {
                    res.Add(c);
                }
                else return c;
            }

            return 0;

            //int index = 0;

            //foreach (int num in nums)
            //{
            //    index = Math.Abs(num) - 1;
            //    if (nums[index] < 0) return Math.Abs(num);
            //    else nums[index] = -nums[index];
            //}

            //return 0;
        }
        static int SumOfUnique(int[] nums)
        {
            Dictionary<int, int> catalog = new Dictionary<int, int>();

            foreach (int c in nums)
            {
                if (catalog.ContainsKey(c))
                {
                    catalog[c]++;
                }
                else
                {
                    catalog.Add(c, 1);
                }
            }

            int sum = 0;

            foreach (var p in catalog)
            {
                if (p.Value == 1) sum += p.Key;
            }

            return sum;
        }
        static ListNode MiddleNode(ListNode head)
        {
            ListNode temp = head;
            int numOfNodes = 0;
            while (temp != null)
            {
                numOfNodes++;
                temp = temp.next;
            }
            temp = head;
            int retVal = numOfNodes / 2;
            int iterator = 0;
            while (temp != null)
            {
                iterator++;
                if (iterator == retVal + 1)
                {
                    return temp;
                }
                else
                {
                    temp = temp.next;
                }
            }
            return temp;
        }
        static ListNode SwapNodes(ListNode head, int k)
        {
            int firstVal = -1;
            int lastVal = -1;
            int firstIterator = k;
            int lastIterator = 1;
            int totalNodes = 0;
            ListNode temp = head;

            while (temp != null)
            {
                totalNodes++;
                temp = temp.next;
            }

            lastIterator = totalNodes - k + 1;
            temp = head;
            int iterator = 0;

            while (temp != null)
            {
                iterator++;

                if (iterator == firstIterator || iterator == lastIterator)
                {
                    if (iterator == firstIterator)
                    {
                        lastVal = temp.val;
                    }
                    if (iterator == lastIterator)
                    {
                        firstVal = temp.val;
                    }
                }

                temp = temp.next;
            }

            temp = head;
            iterator = 0;
            while (temp != null)
            {
                iterator++;

                if (iterator == firstIterator || iterator == lastIterator)
                {
                    if (iterator == firstIterator)
                    {
                        temp.val = firstVal;
                    }
                    if (iterator == lastIterator)
                    {
                        temp.val = lastVal;
                    }
                }

                temp = temp.next;
            }

            return head;
        }
        static int GetDecimalValue(ListNode head)
        {
            string num = "";

            while (head != null)
            {
                num += head.val.ToString();
                head = head.next;
            }

            return Convert.ToInt32(num, 2);
        }
        static string FinalString(string s)
        {
            if (!s.Contains('i')) return s;
            string res = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'i')
                {
                    char[] charArray = res.ToCharArray();
                    Array.Reverse(charArray);
                    res = new string(charArray);
                }

                else
                {
                    res += s[i];
                }
            }

            return res;
        }
        static int Search1(int[] nums, int target)
        {
            if (nums.Length == 1 && nums[0] == target) return 0;
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                if (nums[left] == target) return left;
                if (nums[right] == target) return right;
                int mid = left + (right - left) / 2;
                if (target == nums[mid])
                    return mid;
                if (nums[left] < nums[mid])
                {
                    if (target < nums[left] || target > nums[mid])
                    {
                        left = mid;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                else
                {
                    left++;
                    if (nums[left] == target) return left;
                }
            }
            return -1;
        }
        static int[] LeftRightDifference(int[] nums)
        {
            if (nums.Length == 1)
            {
                nums[0] = 0;
                return nums;
            }
            int[] rightSum = new int[nums.Length];
            int[] leftSum = new int[nums.Length];

            for (int i = 1, j = nums.Length - 2; i < nums.Length; i++, j--)
            {
                rightSum[j] = rightSum[j + 1] + nums[j + 1];
                leftSum[i] = nums[i - 1] + leftSum[i - 1];
            }

            int[] res = new int[nums.Length];

            for (int p = 0; p < nums.Length; p++)
            {
                res[p] = Math.Abs(rightSum[p] - leftSum[p]);
            }

            return res;
        }
        static bool DivideArray(int[] nums)
        {
            HashSet<int> catalog = new HashSet<int>();

            foreach (int p in nums)
            {
                if (!catalog.Contains(p))
                {
                    catalog.Add(p);
                }

                else
                {
                    catalog.Remove(p);
                }
            }

            if (catalog.Count == 0) return true;
            else return false;
        }
        static void ReverseString(char[] s)
        {
            for (int i = 0; i < s.Count() / 2; i++)
            {
                int last = s.Count() - 1 - i;

                char temp = s[i];
                s[i] = s[last];
                s[last] = temp;
            }
        }
        static string FindDifferentBinaryString(string[] nums)
        {
            string num = "";
            for (int i = 0; i < nums.Length; i++)
            {
                string n = nums[i];
                if (n[i] == '0')
                {
                    num += '1';
                }
                else
                {
                    num += '0';
                }
            }
            return num;
        }
        static int FindNumbers(int[] nums)
        {
            int numOfEvenDigits = 0;

            foreach (int c in nums)
            {
                int p = c;
                int len = 0;

                while (p > 0)
                {
                    len++;
                    p = p / 10;
                }

                if (len % 2 == 0) numOfEvenDigits++;
            }

            return numOfEvenDigits;
        }
        static int SmallestEqual(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 10 == nums[i]) return i;
            }

            return -1;
        }

        static int CountPrefixes(string[] words, string s)
        {
            int res = 0;
            for(int i = 0; i< words.Count(); i++)
            {
                if (s.StartsWith(words[i])) res++;
            }

            return res;
        }

        #endregion
        static void Main(string[] args)
        {
            string[] words = { "a", "b", "c", "ab", "bc", "abc" };
            string s = "abc";
            int res = CountPrefixes(words, s);

            //int[] nums = { 0, 1, 2 };
            //int res = SmallestEqual(nums);

            Console.Read();


            #region commented
            //int[] nums = { 3, 2, 3, 2, 2, 2 };
            //rightSum is [15,11,3,0].
            //leftSum is [0,10,14,22] 
            //bool res = DivideArray(nums);
            Console.Read();

            //string s = "strng";
            //string res = FinalString(s);
            //ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null)))));
            //ListNode head = new ListNode(1, new ListNode(0, new ListNode(1, new ListNode(1, new ListNode(0, null)))));
            //int res = GetDecimalValue(head);

            //string[] sentences = { "alice and bob love leetcode", "i think so too", "this is great thanks very much" };
            //int result = MostWordsFound(sentences);
            //Console.Read();
            //int[] nums = { 1,2,3,2 };
            //int result = SumOfUnique(nums);

            //int[] res = PivotArray(nums, pivot);
            //ListNode head = new ListNode(18, new ListNode(6, new ListNode(10, new ListNode(3, null))));
            //ListNode res = InsertGreatestCommonDivisors(head);
            //int reso = FindGCD(10,5);

            //int p = KthGrammar(25, 22);
            //int[] nums = { 1, 13, 10, 12, 31 };
            //int result = CountDistinctIntegers(nums);

            //List<int> result = FindDuplicates(nums);
            //string s = "(){}}{";
            //bool result = IsValid(s);        
            //double result = MyPow(x, n);
            //{ { 2, 8, 7 }, { 7, 1, 3 }, { 1, 9, 5 } }
            //int[][] accounts =  {new int[] { 2, 8, 7 }, 
            //                     new int[] { 7, 1, 3 }, 
            //                     new int[] { 1, 9, 5 },
            //                     new int[] { 8, 6, 0 }};
            //int result = MaximumWealth(accounts);

            //int[] nums = { -1, 0, 3, 5, 9, 12 };
            //int target = 9;
            //int result = Search(nums, target);

            //string input = "Myself2 Me1 I4 and3";
            //string output = SortSentence(input);
            //int[] nums = { 0, 1, 6, 5, 4, 3, 2 };
            //int result = PeakIndexInMountainArray(nums);

            //int[][] grid =  {new int[] { 4,3,2,-1 },
            //                 new int[] { 3,2,1,-1 },
            //                 new int[] { 1,1,-1,-2 },
            //                 new int[] { -1,-1,-2,-3 }};
            //int result = CountNegatives(grid);


            //TreeNode p = new TreeNode(10, new TreeNode(5, new TreeNode(3), new TreeNode(7)), new TreeNode(15, null, new TreeNode(18)));

            //TreeNode p = new TreeNode(3, new TreeNode(9, null, null), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            //TreeNode q = new TreeNode(3, new TreeNode(9, null, null), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

            //int[] nums = { 1,3,2 };
            //bool result = IsMonotonic(nums);
            //string s = "Let's take LeetCode contest";
            //string result = ReverseWords(s);
            //int[] nums = { 91, 23, 69, 7, 98, 47, 23, 65, 77, 12, 54 };
            //quickSort(nums, 0, nums.Length - 1);

            //int [] nums = { 0, 1, 2, 3, 4 };
            //int target = 2;
            //int result = NumberOfEmployeesWhoMetTarget(nums, target);


            /*
            TreeNode p =                            new TreeNode(3,
                        new TreeNode(9,  
               new TreeNode(24), new TreeNode(73)),                 new TreeNode(20,
                                                            new TreeNode(15), new TreeNode(7)));
            */
            //BFS(p);
            //Console.WriteLine();
            //DFS(p);
            //int[] arr = { 3, 1, 2 };
            //quickSort(arr, 0, arr.Length - 1);         

            //int[] nums = { 2, 3, 4 };
            //int target = 6;
            //int[] nums = { -3, 3, 4, 90 };
            //int target = 0;
            //int[] result = TwoSum(nums, target);

            //string s = "a##c", t = "#a#c";
            //bool result = BackspaceCompare(s, t);

            //ListNode head = new ListNode(0, new ListNode(3, new ListNode(1, new ListNode(0, new ListNode(4, new ListNode(5, new ListNode(2, new ListNode(0, null))))))));
            //ListNode result = MergeNodes(head);
            //int p = interview();
            //List<IList<int>> result = Generate2(11);
            //string word = "cccaa";
            //bool res = EqualFrequency(word);
            //TreeNode p =                    new TreeNode(3,
            //            new TreeNode(9,
            //   new TreeNode(24), new TreeNode(73)),                 new TreeNode(20,
            //                                                new TreeNode(15), new TreeNode(7)));

            //List<int> result = LargestValues(p);
            #endregion
        }
        static void BFS(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                root = queue.Dequeue();
                Console.Write(root.val + " ");

                if (root.left != null) queue.Enqueue(root.left);
                if (root.right != null) queue.Enqueue(root.right);
            }
        }
        static void DFS(TreeNode root)
        {
            if (root == null) return;

            DFS(root.left);
            Console.Write(root.val + " ");
            DFS(root.right);

        }
        static void quickSort(int[] nums, int min, int max)
        {
            if (min >= max)
            {
                return;
            }
            int pivotIndex = partition(nums, min, max);
            quickSort(nums, min, pivotIndex - 1);
            quickSort(nums, pivotIndex + 1, max);

            int partition(int[] arr, int low, int high)
            {
                int pivot = arr[high];
                int index = low - 1;
                for (int i = low; i < high; i++)
                {
                    if (arr[i] <= pivot)
                    {
                        index++;
                        int temp = arr[i];
                        arr[i] = arr[index];
                        arr[index] = temp;
                    }
                }
                index++;
                arr[high] = arr[index];
                arr[index] = pivot;

                return index;
            }
        }
        static int Search(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length;

            while (low < high)
            {
                int mid = low + ((high - low) / 2);

                if (target == nums[mid]) return mid;

                else if (target > nums[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return -1;
        }
    }
}
