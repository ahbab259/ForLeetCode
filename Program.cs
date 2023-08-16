using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                if(temp.val != temp.next.val)
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
            #endregion

            int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 }; 
            int k = 3;
            int[] result = MaxSlidingWindow(nums, k);

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
