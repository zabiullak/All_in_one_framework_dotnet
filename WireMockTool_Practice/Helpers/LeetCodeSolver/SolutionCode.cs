using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace  WireMockTool_Practice.LeetCodeSolver
{
    public class SolutionCode
    {
        public int FirstUniqChar(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return -1;
            }
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dic.TryGetValue(s[i], out int value1))
                {
                    dic[s[i]] = value1 + 1;
                }
                else
                {
                    dic.Add(s[i], 0);
                }
                //dic.TryAdd(s[i], dic.TryGetValue(s[i], out int value) ? value + 1:0);
            }

            for (int j = 0; j < s.Length; j++)
            {
                if (dic[s[j]] == 0)
                {
                    return j;
                }
            }
            return -1;
            // if(s.Length == 0){
            //     return -1;
            // }
            // if(s.Length == 1){
            //     return 0;
            // }
            // //s = "loveleetcode"
            // char[] input = s.ToCharArray();
            // int index = -1;
            // bool flag =false;
            // for(int a = 0;a<input.Length;a++){
            //     for(int b=0;b<input.Length;b++){
            //         if(a!=b){
            //             if(input[a]==input[b]){
            //                 flag =true;
            //                 break;
            //             }
            //         }
            //     }
            //     if(flag is false){
            //         index = a;
            //     }

            // }
            // return index;
        }
        public int MySqrt(int x)
        {
            return (int)Math.Sqrt(x);
        }
        public bool IsHappy(int n)
        {
            if (n == 1) return true;
            if (n <= 3) return false;
            int rotation = 0;
            while (n != 1)
            {
                n = GetSquareSum(n);
                if (rotation++ > 750) return false;
            }
            return true;
        }



        private int GetSquareSum(int n)
        {
            int sum = 0;

            while (n > 0)
            {
                int lastDigit = n % 10;
                sum += lastDigit * lastDigit;
                n /= 10;
            }
            return sum;
        }
        // public bool IsHappy(int n)
        // {
        //     //192
        //     if (n == 1 || n <= 3)
        //     {
        //         return false;
        //     }
        //     int rotation = 0;
        //     while (n != 1)
        //     {
        //         n = GetSquareSum(n);
        //         if (rotation++ > 750) return false;
        //     }
        //     return true;
        // bool flag = true;
        // while(flag){
        //     int sum = 0;
        //     while (n > 0)
        //     {
        //         int lstDigit = n % 10;
        //         sum += lstDigit*lstDigit;
        //         if(sum == 1){
        //             //flag = false;
        //             return true;
        //         }
        //         n /= 10;
        //     }
        //     n = sum;
        // }
        // return false;
        // }

        public int[] RunningSum(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
            {
                return nums;
            }
            int sum = 0;
            int[] output = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                output[i] = sum;
            }
            return output;


        }
        public int MajorityElement(int[] nums)
        {
            int length = nums.Length;
            if (length == 1)
            {
                return nums[0];
            }
            Array.Sort(nums);

            int k = length / 2;
            int i = 0;
            while (i < length)
            {
                int temp = 1;
                int a = nums[i], b = nums[++i];
                while (a == b)
                {
                    temp++;
                    ++i;
                    if (i < length)
                    {
                        b = nums[i];
                    }
                    else
                    {
                        break;
                    }
                }
                if (temp > k)
                {
                    return a;
                }
            }
            return 0;
        }

        public string[] SortPeople(string[] names, int[] heights)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            for (int i = 0; i < names.Length; i++)
            {
                dic.Add(heights[i], names[i]);
            }
            //int maxHgt = dic.Keys.Max();
            // from entry in myDict orderby entry.Value ascending select entry;
            var SortedDic = from entry in dic orderby entry.Key descending select entry;
            //dic = dic.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int index = 0;
            foreach (var entry in SortedDic)
            {
                names[index++] = entry.Value;
            }
            return names;
        }

        public int MissingNumber(int[] nums)
        {
            int length = nums.Length;
            HashSet<int> hst = new HashSet<int>();
            foreach (var val in nums)
            {
                if (hst.Contains(val))
                {
                    continue;
                }
                else
                {
                    hst.Add(val);
                }
            }
            for (int i = 1; i <= length; i++)
            {
                if (!hst.Contains(i))
                {
                    return i;
                }
            }
            return 0;
        }

        public IList<int> AddToArrayForm(int[] num, int k)
        {
            List<int> lst = new List<int>();

            int start = num.Length - 1;

            while ((start >= 0 || k > 0))
            {
                if (start >= 0)
                {
                    lst.Add((num[start] + k) % 10);
                    k = (num[start] + k) / 10;
                }
                else
                {
                    lst.Add(k % 10);
                    k /= 10;
                }
                start--;
            }

            lst.Reverse();
            return lst;


            //long sum = 0;
            //long place = 1;

            //num.ToList();
            //for (int i = num.Length - 1; i >= 0; i--)
            //{
            //    sum = sum + (num[i] * place);
            //    place *= 10;
            //}
            //sum = sum + k;
            //var OuputList = new List<int>();

            //var value = sum.ToString().ToCharArray().ToList();

            //foreach(var val in value)
            //{
            //    OuputList.Add(Convert.ToInt32(val.ToString()));
            //}
            ////OuputList.Reverse();
            //return OuputList;
        }
        public int FindClosestNumber(int[] nums)
        {
            List<int> positiveVal = new List<int>();
            List<int> negativeVal = new List<int>();

            foreach (int num in nums)
            {
                if (num == 0) return 0;
                if (num > 0) positiveVal.Add(num);
                else negativeVal.Add(num);
            }
            positiveVal.Sort();
            negativeVal.Sort();

            if (positiveVal.Count == 0)
            {
                return negativeVal[negativeVal.Count - 1];
            }
            else if (negativeVal.Count == 0)
            {
                return positiveVal[0];
            }
            else if (positiveVal[0] == -negativeVal[negativeVal.Count - 1])
            {
                return positiveVal[0];
            }
            else if (positiveVal[0] > -negativeVal[negativeVal.Count - 1])
            {
                return negativeVal[negativeVal.Count - 1];
            }
            else if (positiveVal[0] < -negativeVal[negativeVal.Count - 1])
            {
                return positiveVal[0];
            }

            return 0;
        }
        public int CountPrimes(int n)
        {
            if (n <= 1) return 0;

            List<int> PrimeList = new List<int>();

            for (int i = 2; i < n; i++)
            {
                if (PrimeList.Count == 0) PrimeList.Add(i);
                else
                {
                    int index = 0;
                    while (i % PrimeList[index] != 0)
                    {
                        index++;
                        if (!(index < PrimeList.Count))
                        {
                            PrimeList.Add(i);
                            break;
                        }
                    }
                }
            }
            return PrimeList.Count;

        }
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            string w1 = "";
            string w2 = "";

            for (int i = 0; i < word1.Length; i++)
            {
                w1 = w1 + word1[i];
            }

            for (int j = 0; j < word2.Length; j++)
            {
                w2 = w2 + word2[j];
            }

            if (w1.Equals(w2))
            {
                return true;
            }
            return false;
        }
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> hSet = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (hSet.Contains(nums[i]))
                {
                    return true;
                }
                hSet.Add(nums[i]);
            }
            return false;
            // int length = nums.Length;
            // if (length == 0 || length == 1)
            // {
            //     return false;
            // }
            // Array.Sort(nums);
            // for (int i = 0; i < length; i++)
            // {
            //     for (int j = 0; j < length; j++)
            //     {
            //         if (i != j)
            //         {
            //             if (nums[i] == nums[j])
            //             {
            //                 return true;
            //             }
            //         }
            //     }
            // }
            // return false;
        }
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0 || prices is null)
            {
                return 0;
            }
            int minVal = int.MaxValue;
            int maxVal = int.MinValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minVal)
                {
                    minVal = prices[i];
                }
                else if ((prices[i] - minVal) > maxVal)
                {
                    maxVal = prices[i] - minVal;
                }
            }
            return maxVal;
        }

        public int ThirdMax(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            else if (nums.Length == 1)
            {
                return nums[0];
            }
            else if (nums.Length == 2)
            {
                Array.Sort(nums);
                nums = RemoveDuplicatesFromArray(nums);
                return nums[nums.Length - 1];
            }
            Array.Sort(nums);
            nums = RemoveDuplicatesFromArray(nums);
            int index = nums.Length - 3;
            if (index >= 0)
            {
                return nums[index];
            }
            return nums[0];
        }

        public int[] RemoveDuplicatesFromArray(int[] nums)
        {
            int lenght = nums.Length;
            if (lenght == 0) return new int[0];
            else if (lenght == 1) return nums;
            Array.Sort(nums);
            int a = 0, b = 1;

            while (b < lenght)
            {
                if (nums[a] == nums[b])
                {
                    b++;
                }
                else
                {
                    nums[++a] = nums[b++];
                }
            }
            var res = nums.Skip(0).Take(++a);
            return res.ToArray();
        }
        public int RemoveDuplicates(int[] nums)
        {
            int lenght = nums.Length;
            if (lenght == 0) return 0;
            else if (lenght == 1) return 1;

            int a = 0, b = 1;

            while (b < lenght)
            {
                if (nums[a] == nums[b])
                {
                    b++;
                }
                else
                {
                    nums[++a] = nums[b++];
                }
            }
            return ++a;
        }
        public int[] Rotate(int[] nums, int k)
        {
            int arrLenght = nums.Length;
            int[] output = new int[arrLenght];
            for (int i = 0; i < arrLenght; i++)
            {
                output[(i + k) % arrLenght] = nums[i];
            }
            for (int j = 0; j < arrLenght; j++)
            {
                nums[j] = output[j];
            }
            return nums;
        }
        public IList<string> CommonChars(string[] words)
        {
            //string[] words = {"bella", "label", "roller"};

            int[,] chars = new int[words.Length, 26];

            IList<string> result = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                foreach (var val in words[i])
                {
                    chars[i, val - 'a']++;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                int min = Int32.MaxValue;
                for (int j = 0; j < words.Length; j++)
                {
                    if (chars[j, i] < min)
                    {
                        min = chars[j, i];
                    }
                }

                if (min > 0)
                {
                    for (int k = 0; k < min; k++)
                    {
                        result.Add(((char)(i + 'a')).ToString());
                    }
                }
            }
            return result;
        }

        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] res = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i] == nums2[j])
                    {
                        int index = j;
                        while (index < nums2.Length)
                        {
                            if (index == nums2.Length - 1)
                            {
                                res[i] = -1;
                                break;
                            }
                            if (nums2[index + 1] > nums1[i])
                            {
                                res[i] = nums2[index + 1];
                                break;
                            }
                            else
                            {
                                index++;
                            }
                        }
                    }
                }
            }

            return res;


            //int[] result = new int[nums1.Length];
            //int index;
            //for (int i = 0; i < nums1.Length; i++)
            //{
            //    int a = nums1[i];
            //    for (int j = 0; j < nums2.Length; j++)
            //    {
            //        int b = nums2[j];
            //        if (a == b)
            //        {
            //            index = j;
            //            if (index >= nums2.Length)
            //            {
            //                result[i] = -1;
            //                break;
            //            }
            //            while (index < nums2.Length)
            //            {
            //                if (index >= nums2.Length)
            //                {
            //                    result[i] = -1;
            //                    break;
            //                }
            //                if (nums2[index + 1] > a)
            //                {
            //                    result[i] = nums2[index + 1];
            //                    break;
            //                }
            //                else
            //                {
            //                    index++;
            //                }
            //            }
            //        }
            //    }
            //}
            //return result;




        }
        public void DuplicateZeros(int[] arr)
        {
            int l = arr.Length;
            int[] output = new int[l];

            int index = 0;
            for (int i = 0; i < l; i++)
            {
                if (arr[i] == 0)
                {
                    if (index < l - 1)
                    {
                        output[index++] = 0;
                        output[index++] = 0;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (index <= l - 1)
                    {
                        output[index++] = arr[i];
                    }
                    else break;
                }
            }

            for (int i = 0; i < output.Length; i++)
                arr[i] = output[i];
        }

        public bool CheckIfExist(int[] arr)
        {
            //[7,1,14,11]
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i != j)
                    {
                        if (arr[i] * 2 == arr[j])
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            IList<int> lst = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i] == nums2[j])
                    {
                        lst.Add(nums1[i]);
                        nums2[j] = -1;
                        break;
                    }
                }
            }
            return lst.ToArray();
        }

        public IList<string> FizzBuzz(int n)
        {
            IList<string> lst = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    lst.Add("FizzBuzz");
                else if (i % 3 == 0)
                    lst.Add("Fizz");
                else if (i % 5 == 0)
                    lst.Add("Buzz");
                else
                    lst.Add(i.ToString());
            }

            return lst;
        }

        public int BalancedStringSplit(string s)
        {
            int result = 0;
            int Count_R = 0, Count_L = 0;
            s = s + "R";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'R')
                {
                    if (i != 0)
                    {
                        if (Count_R == Count_L)
                        {
                            result++;
                            Count_R = 0;
                            Count_L = 0;
                        }
                    }
                    Count_R++;
                }
                if (s[i] == 'L')
                {
                    if (i != 0)
                    {
                        if (Count_R == Count_L)
                        {
                            result++;
                            Count_R = 0;
                            Count_L = 0;
                        }
                    }
                    Count_L++;
                }
            }
            return result;
        }

        public int RomanToInt(string s)
        {
            int I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000;

            int[] nums = new int[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'I')
                    nums[i] = I;
                if (s[i] == 'V')
                    nums[i] = V;
                if (s[i] == 'X')
                    nums[i] = X;
                if (s[i] == 'L')
                    nums[i] = L;
                if (s[i] == 'C')
                    nums[i] = C;
                if (s[i] == 'D')
                    nums[i] = D;
                if (s[i] == 'M')
                    nums[i] = M;
            }
            int sum = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (nums[i] < nums[i + 1])
                    sum -= nums[i];
                else
                    sum += nums[i];
            }
            return sum += nums[s.Length - 1];
        }
        public int TitleToNumber(string columnTitle)
        {
            //if (columnTitle == null || columnTitle == string.Empty)
            //    return 0;

            //int res = 0;

            //for (int i = columnTitle.Length - 1; i > -1; i--)
            //{
            //    res += (columnTitle[i] - 'A' + 1) * (int)Math.Pow(26, columnTitle.Length - 1 - i);
            //}

            //return res;
            //if (columnTitle == null || columnTitle == string.Empty)
            //       return 0;

            //int res = 0;
            //int position = 0;

            //for(int i = columnTitle.Length - 1; i >= 0; i--)
            //{
            //    char c = columnTitle[i];
            //    res += (c - 'A' + 1) + position;
            //    position += 25;
            //}

            //return res;

            int index = 0;
            int sum = 0;
            int titleLength = columnTitle.Length - 1;
            while (titleLength >= 0)
            {
                char currentChar = columnTitle[index];
                int charVal = (currentChar - 'A' + 1);
                sum += (int)Math.Pow(26, titleLength) * charVal;

                titleLength--;
                index++;
            }
            return sum;
        }
        public string LongestCommonPrefix(string[] strs)
        {
            // strs = ["flower","flow","flight"]

            if (strs.Length == 1)
            {
                return strs[0];
            }

            string prifixString = "";

            for (int i = 0; i < strs[0].Length; i++)
            {
                foreach (string s in strs)
                {
                    if (i > s.Length - 1)
                    {
                        return prifixString;
                    }

                    if (strs[0][i] != s[i])
                    {
                        return prifixString;
                    }
                }
                prifixString += strs[0][i];
            }

            return prifixString;
        }
        public int DominantIndex(int[] nums)
        {
            int LargeVal = 0;
            int LargeIndexVal = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > LargeVal)
                {
                    LargeVal = nums[i];
                    LargeIndexVal = i;
                }
            }
            Array.Sort(nums);
            int val = nums[nums.Length - 2];
            if (LargeVal >= (val + val))
            {
                return LargeIndexVal;
            }
            return -1;
        }
        public int[] SortArrayByParity(int[] nums)
        {
            //List<int> lst = new List<int>();
            //foreach(var val in nums)
            //{
            //    if(val%2 == 0)
            //    {
            //        lst.Add(val);
            //    }
            //}
            //foreach (var val in nums)
            //{
            //    if (val % 2 == 1)
            //    {
            //        lst.Add(val);
            //    }
            //}

            //return lst.ToArray();


            return nums.Where(x => x % 2 == 0).ToArray().Concat(nums.Where(x => x % 2 == 1).ToArray()).ToArray();

        }

        public string AddBinary(string a, string b)
        {
            StringBuilder res = new StringBuilder();
            int i = a.Length - 1;
            int j = b.Length - 1;
            int carry = 0;
            while (i >= 0 || j >= 0)
            {
                int sum = carry;
                if (i >= 0) sum += a[i--] - '0';
                if (j >= 0) sum += b[j--] - '0';
                carry = sum > 1 ? 1 : 0;
                res.Insert(0, sum % 2);
            }
            if (carry != 0) res.Insert(0, carry);
            return res.ToString();
        }
        public bool WordPattern(string pattern, string s)
        {
            var dict1 = new Dictionary<char, string>();
            var dict2 = new Dictionary<string, char>();

            var sSplitted = s.Split(' ');

            if (sSplitted.Length != pattern.Length)
                return false;

            for (int i = 0; i < pattern.Length; i++)
            {
                // check if at least one of dictionaries has the (string <-> pattern) bijection 
                if (dict1.ContainsKey(pattern[i]) || dict2.ContainsKey(sSplitted[i]))
                {
                    // if both of them have same mappings then everything is correct and we continue
                    if (dict1.ContainsKey(pattern[i]) && dict1[pattern[i]] == sSplitted[i]
                        && dict2.ContainsKey(sSplitted[i]) && dict2[sSplitted[i]] == pattern[i])
                    {
                        continue;
                    }

                    //  (string <-> pattern) bijection is invalid
                    return false;
                }
                else
                {
                    // we set bijection if it wasnt added
                    dict1.Add(pattern[i], sSplitted[i]);
                    dict2.Add(sSplitted[i], pattern[i]);
                }
            }
            return true;
        }
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j)
                    {
                        int res = nums[i] + nums[j];
                        if (res == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
            }
            return new int[0];
        }

        public int[] TwoSum_2(int[] numbers, int target)
        {
            int[] retVal = default;
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right)
            {
                if (numbers[left] + numbers[right] == target) return new int[] { left + 1, right + 1 };
                if (numbers[left] + numbers[right] < target) left++;
                if (numbers[left] + numbers[right] > target) right--;
            }
            return retVal;
        }

        public bool FindTarget(TreeNode root, int k)
        {
            ISet<int> set = new HashSet<int>();
            return Helper(root, k, set);
        }

        private bool Helper(TreeNode node, int k, ISet<int> set)
        {
            if (node is null)
            {
                return false;
            }
            if (set.Contains(node.val))
            {
                return true;
            }
            var remains = k - node.val;
            set.Add(remains);

            if (remains < node.val)
            {
                if (Helper(node.left, k, set)) return true;
                return Helper(node.right, k, set);
            }
            else
            {
                if (Helper(node.right, k, set)) return true;
                return Helper(node.left, k, set);
            }
        }

        public char FindTheDifference(string s, string t)
        {
            char c = (char)0;
            foreach (char cs in s.ToCharArray()) c ^= cs;
            foreach (char ct in t.ToCharArray()) c ^= ct;
            return c;
            // if(string.IsNullOrWhiteSpace(s)){
            //     return Convert.ToChar(t);
            // }
            // char[] aa = s.ToCharArray();
            // char[] bb=  t.ToCharArray();


            // char result =' ';
            // for(int i = 0; i<bb.Length; i++){
            //     for(int j = 0; j<aa.Length; j++){


            //     }
            //     result =  bb[i];
            // }
            // return result;
        }

        public int[] PlusOne(int[] digits)
        {
            int carrier = 1;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int temp = digits[i] + carrier;

                digits[i] = temp % 10;
                carrier = temp / 10;
            }

            if (carrier == 1)
            {
                List<int> temp = new List<int>();

                temp.Add(carrier);

                foreach (var n in digits)
                    temp.Add(n);

                return temp.ToArray();
            }

            return digits;
            // string totals = "";
            // for (int i = 0; i < digits.Length; i++)
            // {
            //     totals = string.Concat(totals, digits[i].ToString());

            // }

            // int val = Convert.ToInt32(totals) + 1;

            // int countDigit = CountDigits(val);
            // digits = new int[countDigit];
            // int index = digits.Length - 1;
            // while (val > 0)
            // {
            //     int rem = val % 10;
            //     digits[index--] = rem;
            //     val = val / 10;
            // }
            // return digits;
        }

        public int CountDigits(int n)
        {
            if (n / 10 == 0)
            {
                return 1;
            }
            return 1 + CountDigits(n / 10);
        }

        public int LengthOfLastWord(string s)
        {
            s = s.TrimEnd();
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            List<string> lst = s.Split(" ").ToList();
            return lst.LastOrDefault().Length;
        }
        public bool IsValid(string s)
        {
            Stack<char> sign = new Stack<char>();

            foreach (char item in s.ToCharArray())
            {
                if (item == '{')
                {
                    sign.Push('}');
                }
                else if (item.Equals('('))
                {
                    sign.Push(')');
                }
                else if (item.Equals('['))
                {
                    sign.Push(']');
                }
                else if (sign.Count == 0 || sign.Pop() != item)
                {
                    return false;
                }
            }
            return sign.Count == 0;
        }

        public bool IsPalindrome(string s)
        {
            s = Regex.Replace(s, @"[^a-zA-Z0-9]|[ ]", "").ToLower();
            if (string.IsNullOrEmpty(s) || s.Equals(" ") || s.Length == 1)
            {
                return true;
            }
            string revVal = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                revVal = revVal + s[i];
            }
            if (revVal == s)
            {
                return true;
            }
            return false;
        }



        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode node1 = head, node2 = head.next;

            while (!(node2 is null))
            {
                if (node1.val == node2.val)
                {
                    node1.next = node2.next;
                    node2.next = null;
                    node2 = node1.next;
                }
                else
                {
                    node1 = node2;
                    node2 = node1.next;
                }
            }
            return head;
        }
        public class Foo
        {

            TaskCompletionSource<bool> t1 = new TaskCompletionSource<bool>();
            TaskCompletionSource<bool> t2 = new TaskCompletionSource<bool>();
            public Foo()
            {

            }

            public void First(Action printFirst)
            {

                // printFirst() outputs "first". Do not change or remove this line.

                printFirst();
                t1.SetResult(true);
            }

            public void Second(Action printSecond)
            {
                t1.Task.Wait();
                // printSecond() outputs "second". Do not change or remove this line.
                printSecond();
                t2.SetResult(true);
            }

            public void Third(Action printThird)
            {
                t2.Task.Wait();
                // printThird() outputs "third". Do not change or remove this line.
                printThird();
            }
        }

        public ListNode SortList(ListNode head)
        {
            if (head is null) return head;

            List<int> lst = new List<int>();

            while (!(head is null))
            {
                lst.Add(head.val);
                head = head.next;
            }
            lst.Sort();

            ListNode head2 = null;

            for (int i = lst.Count - 1; i >= 0; i--)
            {
                //head2.val = lst[i];
                //head2 = head2.next;

                head2 = new ListNode(lst[i], head2);
            }

            return head2;
        }

        public void SortColors(int[] nums)
        {
            //Array.Sort(nums);

            List<int> lst1 = new List<int>();
            List<int> lst2 = new List<int>();
            List<int> lst3 = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 2)
                {
                    lst3.Add(2);
                }
                else if (nums[i] == 1)
                {
                    lst2.Add(1);
                }
                else if (nums[i] == 0)
                {
                    lst1.Add(0);
                }
            }

            lst1 = lst1.Concat(lst2).Concat(lst3).ToList();

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = lst1[i];
            }
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode _newNode = null;

            int carryOver = 0;
            while (l1 != null && l2 != null)
            {
                int l1_val = l1.val;
                l1 = l1.next;
                int l2_val = l2.val;
                l2 = l2.next;
                int sumVal = (l1_val + l2_val + carryOver) % 10;
                _newNode = new ListNode(sumVal, _newNode);
                carryOver = (l1_val + l2_val + carryOver) / 10;
            }

            while (l1 != null)
            {
                int l1_val = l1.val;
                l1 = l1.next;
                int sumVal = (l1_val + carryOver) % 10;
                _newNode = new ListNode(sumVal, _newNode);
                carryOver = (l1_val + carryOver) / 10;
            }

            while (l2 != null)
            {
                int l2_val = l2.val;
                l2 = l2.next;
                int sumVal = (l2_val + carryOver) % 10;
                _newNode = new ListNode(sumVal, _newNode);
                carryOver = (l2_val + carryOver) / 10;
            }
            if (carryOver != 0) _newNode = new ListNode(carryOver, _newNode);
            _newNode = LinkedList.Reverse(_newNode);
            return _newNode;
        }

        public string AddStrings(string num1, string num2)
        {
            /*
             * Input: num1 = "11", num2 = "123"
               Output: "134"
            */
            if (num1 is null || num1 == "") return num2;
            if (num2 is null || num2 == "") return num1;

            int num1Length = num1.Length - 1;
            int num2Length = num2.Length - 1;
            bool flag = true;
            int carry = 0;
            string TotalSum = null;
            while (flag)
            {
                int total = 0;
                int sum = 0;
                if (num1Length < 0 || num2Length < 0)
                {
                    if (num1Length < 0 && num2Length < 0) flag = false;
                    if (num1Length >= 0)
                    {
                        total = Convert.ToInt32(num1[num1Length--].ToString()) + carry;
                        sum = total % 10;
                        carry = total / 10;
                        TotalSum = sum.ToString() + TotalSum;
                    }
                    else if (num2Length >= 0)
                    {
                        total = Convert.ToInt32(num2[num2Length--].ToString()) + carry;
                        sum = total % 10;
                        carry = total / 10;
                        TotalSum = sum.ToString() + TotalSum;
                    }
                }
                else
                {
                    total = Convert.ToInt32(num1[num1Length--].ToString()) + Convert.ToInt32(num2[num2Length--].ToString()) + carry;
                    sum = total % 10;
                    carry = total / 10;
                    TotalSum = sum.ToString() + TotalSum;
                }


            }
            if (carry > 0) { TotalSum = carry + TotalSum; }
            return TotalSum.ToString();
        }
        public string Multiply(string num1, string num2)
        {
            /*        Input: num1 = "2", num2 = "3"
                      Output: "6"
            */
            return "";
        }

        public string DecodeString(string s)
        {
            int r = s.IndexOf("]");

            while (r != -1)
            {
                int l = s.LastIndexOf("[", r);

                string right = s.Substring(r + 1);

                string left = s.Substring(0, l);
            }



            //int r = s.IndexOf("]");
            //while (r != -1)
            //{
            //    int l = s.LastIndexOf("[", r);

            //    string right = s.Substring(r + 1);

            //    string left = s.Substring(0, l);
            //    string num = string.Concat(left.ToArray().Reverse().TakeWhile(char.IsNumber).Reverse());
            //    left = left.Substring(0, left.Length - num.Length);

            //    string repeat = s.Substring(l + 1, r - l - 1);

            //    s = left + string.Join("", Enumerable.Repeat(repeat, int.Parse(num))) + right;

            //    r = s.IndexOf("]");
            //}

            return "";
        }
        public int FindDuplicate(int[] nums)
        {
            List<int> lst = nums.ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst.IndexOf(nums[i]) != i)
                {
                    return lst[i];
                }
            }

            return 0;
        }
        public int FirstMissingPositive(int[] nums)
        {
            nums = RemoveDuplicatesFromArray(nums);
            List<int> lst = nums.Where(n => n > 0).ToList();
            if (lst.Count == 0) return 1;
            int bigNum = lst[lst.Count - 1];
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return bigNum + 1;
        }
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (HasDuplicates(nums.ToList()))
            {
                int res;
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (i != j)
                        {
                            if (nums[i] == nums[j])
                            {
                                res = Math.Abs(i - j);
                                if (res <= k)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
        private bool HasDuplicates(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers.IndexOf(numbers[i]) != i)
                {
                    return true;
                }
            }
            return false;
        }

        public int AddDigits(int num)
        {
            int sum = 0;
            if (num < 10) sum = num;
            while (num >= 10)
            {
                sum += num % 10;
                num /= 10;
                //if (sum >= 10) num = sum;
            }

            sum += num;
            num = sum;
            while (num >= 10)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        public int Reverse(int x)
        {
            int maxVal = int.MaxValue;
            int minVal = int.MinValue;
            if (x > maxVal || x < minVal) return 0;
            string num = x.ToString();
            bool isNegative = false;
            if (num[0] == '-') isNegative = true;
            string _ = ReverseString(num);
            if (isNegative) _ = _.Remove(_.Length - 1);
            if (Int32.TryParse(_.ToString(), out x))
            {
                if (isNegative) x = -x;
                return x;
            }

            return 0;
        }

        public string ReverseString(string num)
        {
            string res = string.Empty;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                res += num[i];
            }

            return res;
        }

        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            List<string> res = new List<string>();
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < list1.Length; i++)
            {
                for (int j = 0; j < list2.Length; j++)
                {
                    if (list1[i] == list2[j])
                    {
                        dic.Add(list1[i], (i + j));
                        break;
                    }
                }
            }
            int minIndex = dic.Values.Min();
            foreach (var d in dic)
            {
                if (d.Value == minIndex)
                {
                    res.Add(d.Key);
                }
            }
            return res.ToArray();
        }
        public bool HasCycle(ListNode head)
        {
            if (head is null || head.next is null) return false;

            Dictionary<ListNode, int> dl = new Dictionary<ListNode, int>();

            while (head.next != null)
            {
                if (dl.ContainsKey(head))
                {
                    return true;
                }
                else
                {
                    dl.Add(head, head.val);
                }

                head = head.next;
            }
            return false;
        }
        public IList<string> LetterCombinations(string digits)
        {
            Dictionary<char, List<string>> phoneBooth = new Dictionary<char, List<string>>();
            var result = new List<string>();
            if (digits.Length == 0) return result;

            phoneBooth.Add('2', new List<string>() { "a", "b", "c" });
            phoneBooth.Add('3', new List<string>() { "d", "e", "f" });
            phoneBooth.Add('4', new List<string>() { "g", "h", "i" });
            phoneBooth.Add('5', new List<string>() { "j", "k", "l" });
            phoneBooth.Add('6', new List<string>() { "m", "n", "o" });
            phoneBooth.Add('7', new List<string>() { "p", "q", "r", "s" });
            phoneBooth.Add('8', new List<string>() { "t", "u", "v" });
            phoneBooth.Add('9', new List<string>() { "w", "x", "y", "z" });

            result.Add("");
            foreach (char c in digits)
            {
                var next = new List<string>();
                //int digit = Convert.ToInt32(digits[i]);
                //int digit = c
                //if (digit < 2 && digit > 9) Assert.Fail("digits are out of boundry");
                var letterList = phoneBooth[c];
                foreach (string letter in letterList)
                {
                    foreach (string s in result)
                    {
                        next.Add(s + letter);
                    }
                }
                result = next;
            }
            return result;
        }

        internal string[] ReverseArray(string[] input)
        {
            int p1 = 0;
            int p2 = input.Length - 1;

            while(p1 < p2 )
            {
                string temp = input[p1];
                input[p1++] = input[p2];
                input[p2--] = temp;
            }
            return input;
        }

        internal string ReverseWords(string input)
        {
            //string input = "india is bharath";
            //string output = "bharth is india";
            string[] splittedWords = input.Split(" ");

            return string.Join(" ", ReverseArray(splittedWords));
        }

        internal bool IsPrime(int input)
        {
            for(int i = 2; i <= input/2; i++)
            {
                if(input % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        internal int FindMaxFromArray(int[] input)
        {
            int MaxDigit = input[0];
            for (int i = 0; i < input.Length - 1; i++)
            {
                if(input[i]>MaxDigit)
                    MaxDigit = input[i];
            }
            return MaxDigit;
        }

        internal int FindMinFromArray(int[] input)
        {
            //Array.Sort(input);
            //return input[0];
            int MinDigit = input[0];
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] < MinDigit)
                    MinDigit = input[i];
            }
            return MinDigit;
        }

        internal int FindSecondMinFromArray(int[] input)
        {
            Array.Sort(input);
            return input[1];
        }

        internal int FindSecondMaxFromArray(int[] input)
        {
            Array.Sort(input);
            return input[input.Length-2];
        }

        internal bool IsDigitPalindrome(int input)
        {
            throw new NotImplementedException();
        }

        internal bool IsStringPalindrome(string input)
        {
            //string input = "abcba";
            char[] chars = input.ToCharArray();
            int p1 = 0;
            int p2 = input.Length - 1;

            while(p1 < p2)
            {
                char temp = chars[p1];
                chars[p1++] = chars[p2];
                chars[p2--] = temp;

                if (!chars.IsCharArrayMatched(input.ToCharArray())) return false;
            }
            return true;
        }
    }
}
