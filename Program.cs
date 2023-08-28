using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForLeetCode
{
    class Program
    {
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

        static int RemoveDuplicates(int[] nums)
        {
            if (nums.Count() == 0) return 0;

            else
            {
                int j = 0;

                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[j] != nums[i])
                    {
                        j++;
                        nums[j] = nums[i];
                    }
                }
                return j + 1;
            }
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
            #endregion
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

            if (nums.Length == 1 || k == 1) return nums;
            int[] result = { };
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int[] window = new int[k];
                Array.Copy(nums, i, window, 0, k);
                result = result.Append(window.Max()).ToArray();
                if (i + k == nums.Length)
                {
                    return result;
                }

            }

            return result;
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

        static int RemoveDuplicates2(int[] nums)
        {
            if (nums.Length == 1) return 1;
            if (nums.Length == 2) return 2;
            int currentInt = nums[0];
            int counter = 1;
            int replacePosition = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (currentInt == nums[i])
                {
                    counter++;
                    if (counter == 3) replacePosition = i;
                }

                else
                {
                    if (replacePosition > 0)
                    {
                        int temp = nums[i];
                        nums[i] = nums[replacePosition];
                        nums[replacePosition] = temp;

                        replacePosition++;
                    }
                    counter = 1;
                    currentInt = nums[i];
                }
            }
            if (replacePosition == 0) return nums.Length;

            else return replacePosition;
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

        static bool EqualFrequency(string word)
        {
            Dictionary<char, int> keywords = new Dictionary<char, int>();
            int counter = 1;

            for (int i = 0; i < word.Length; i++)
            {
                if (keywords.Keys.Contains(word[i]))
                {
                    counter++;
                    keywords.Remove(word[i]);
                    keywords.Add(word[i], counter);
                }

                else
                {
                    keywords.Add(word[i], counter);
                }
            }

            return true;
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

            for(int i = 0; i < candies.Length; i++)
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
            for(int i = 1; i < stones.Length; i++)
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
        static void Main(string[] args)
        {
            #region commented
            //string s = "Hello  World   ";
            //int result = LengthOfLastWord(s);
            //Console.WriteLine(result);

            //ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4, null)));
            //ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(4, null)));

            //ListNode result = MergeTwoLists(list1, list2);



            //string s = "(){}}{";
            //bool result = IsValid(s);


            //string haystack = "mississippi";
            //string needle = "issipi";
            //int result = StrStr(haystack, needle);

            //ListNode list1 = new ListNode(0, new ListNode(1, new ListNode(1, new ListNode(3, new ListNode(4, null)))));
            //list1 = DeleteDuplicates(list1);


            //int num = 4; int t = 1;
            //int result = TheMaximumAchievableX(num, t);

            //string word = "cccaa";
            //bool result = EqualFrequency(word);

            //int[] nums = { 4, 1, 2, 1, 2 };
            //int result = SingleNumber(nums);

            //ListNode head = new ListNode(1, new ListNode(2, new ListNode(6, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, null)))))));




            //ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, null))));
            //ListNode result = ReverseList(head);
            //string input = "A man, a plan, a canal -- Panama";

            //int num = -2147483648;
            //int result = Reverse(num);
            #endregion

            int[] nums  = { 7,7,7,7 };
            int[] result = SmallerNumbersThanCurrent(nums);

            Console.Read();
        }

        static int LengthOfLastWord(string s)
        {
            //string[] words = s.Split(' ');
            //List<string> wordS = words.Where(c => c.Length == 0).FirstOrDefault().Remove(0,0).ToList();
            s = s.Trim();
            List<string> words = s.Split(' ').Where(c => c.Length > 0).ToList();
            return words[words.Count() - 1].Length;
        }
    }
}
