using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.LeetCodeSolver;

namespace UnitTests.LeetCodeTests
{
    [Category("LeetCode")]
    public class LeetTests
    {
        SolutionCode Code;

        public LeetTests()
        {
            Code = new SolutionCode();
        }

        [Test]
        public void Test_204()
        {
            int n = 499979;
            int res = Code.CountPrimes(n);
            Assert.That(res, Is.EqualTo(41537));
        }
        [Test]
        public void Test_2239()
        {
            //int[] n = { -4, -2, 1, 4, 8 };
            int[] n = { -100000, -100000 };
            int res = Code.FindClosestNumber(n);
            Assert.That(res, Is.EqualTo(-100000));
        }
        [Test]
        public void Test_989()
        {
            //int[] num = { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }; int k = 1;
            int[] num = { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }; int k = 1;
            var res = Code.AddToArrayForm(num, k);
            Assert.That(res, Is.EqualTo(new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
        }
        [Test]
        public void Test_1662()
        {
            string[] word1 = { "ab", "c" }, word2 = { "a", "bc" };
            var res = Code.ArrayStringsAreEqual(word1, word2);
            Assert.That(res, Is.True);
        }

        [Test]
        public void Test_69()
        {
            int x = 4;
            var res = Code.MySqrt(x);
            Assert.That(res, Is.EqualTo(2));
        }

        [Test]
        public void Test_202()
        {
            //int n = 4;
            int n = 19;
            var res = Code.IsHappy(n);
            Assert.That(res, Is.True);
        }
        [Test]
        public void Test_1480()
        {
            int[] nums = { 1, 2, 3, 4 };
            var res = Code.RunningSum(nums);
        }
        [Test]
        public void Test_148()
        {
            // ListNode head = new { 4, 2, 1, 3 };
            var head = Helper.GenerateList(new int[] { 4, 2, 1, 3 });
            var res = Code.SortList(head);
            AssertHelper.AssertLinkList(new int[] { 1, 2, 3, 4 }, res);
        }

        [Test]
        public void Test_2()
        {
            // ListNode head = new { 4, 2, 1, 3 };
            var l1 = Helper.GenerateList(new int[] { 9, 9, 9, 9, 9, 9, 9 });
            var l2 = Helper.GenerateList(new int[] { 9, 9, 9, 9 });
            var res = Code.AddTwoNumbers(l1, l2);
            AssertHelper.AssertLinkList(new int[] { 7, 0, 8 }, res);
        }
        [Test]
        public void Test_387()
        {
            string s = "loveleetcode";
            int res = Code.FirstUniqChar(s);
            Assert.That(res, Is.EqualTo(2));
        }
        [Test]
        public void Test_169()
        {
            int[] nums = { 2, 2, 1, 1, 1, 2, 2 };
            int res = Code.MajorityElement(nums);
            Assert.That(res, Is.EqualTo(2));
        }

        [Test]
        public void Test_268()
        {
            int[] nums = { 3, 0, 1 };
            var res = Code.MissingNumber(nums);
            Assert.That(res, Is.EqualTo(2));
        }

        [Test]
        public void Test_217()
        {
            int[] nums = { 1, 2, 3, 1 };
            var res = Code.ContainsDuplicate(nums);
        }

        //Best Time to Buy and Sell Stock
        [Test]
        public void Test_121()
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            int res = Code.MaxProfit(prices);
            Assert.That(res, Is.EqualTo(5));
        }
        [Test]
        public void Test_414()
        {
            int[] nums = { 1, 1, 2 };
            int res = Code.ThirdMax(nums);
            Assert.That(res, Is.EqualTo(1));
        }

        [Test]
        public void Test_26()
        {
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int res = Code.RemoveDuplicates(nums);
            Assert.That(res, Is.EqualTo(5));
        }

        [Test]
        public void Test_2418()
        {
            string[] names = { "Mary", "John", "Emma" }; int[] heights = { 180, 165, 170 };
            string[] res = Code.SortPeople(names, heights);
            Assert.That(res, Is.EqualTo(new string[] { "Mary", "Emma", "John" }));
        }

        [Test]
        public void Test_189()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 }; int k = 3;
            int[] res = Code.Rotate(nums, k);

        }

        [Test]
        public void Test_290()
        {
            string pattern = "abba", s = "dog cat cat dog";
            string pattern1 = "abba", s1 = "dog dog dog dog";
            bool res = Code.WordPattern(pattern1, s1);
        }

        [Test]
        public void Test_1()
        {
            int[] nums = { 2, 7, 11, 15 }; int target = 9;
            int[] res = Code.TwoSum(nums, target);

        }
        //167. Two Sum II - Input Array Is Sorted
        [Test]
        public void Test_167()
        {
            int[] nums = { 2, 7, 11, 15 }; int target = 9;
            int[] res = Code.TwoSum_2(nums, target);
            Assert.That(res, Is.EqualTo(new int[] { 1, 2 }));
        }

        //653. Two Sum IV - Input is a BST
        [Test]
        public void Test_653()
        {
            //solved
        }
        [Test]
        public void Test_14()
        {
            string[] strs = { "flower", "flow", "flight" };
            var res = Code.LongestCommonPrefix(strs);
            Assert.That(res, Is.EqualTo("fl"));
        }

        [Test]
        public void Test_13()
        {
            string s = "LVIII";
            var res = Code.RomanToInt(s);
            Assert.That(res, Is.EqualTo(58));
        }

        [Test]
        public void Test_905()
        {
            int[] nums = { 3, 1, 2, 4 };
            var res = Code.SortArrayByParity(nums);
            //Assert.That(res, Is.EqualTo(0));
        }

        [Test]
        public void Test_747()
        {
            int[] nums = { 3, 6, 1, 0 };
            var res = Code.DominantIndex(nums);
            Assert.That(res, Is.EqualTo(1));
        }

        [Test]
        public void Test_412()
        {
            int n = 3;
            var res = Code.FizzBuzz(n);
            Assert.That(res, Is.EqualTo(new List<string>() { "1", "2", "Fizz" }));
        }

        [Test]
        public void Test_171()
        {
            string columnTitle = "ZY";
            var res = Code.TitleToNumber(columnTitle);
            Assert.That(res, Is.EqualTo(701));
        }

        [Test]
        public void Test_350()
        {
            int[] nums1 = { 6, 6, 4, 4, 0, 0, 8, 1, 2 }, nums2 = { 6 };
            var res = Code.Intersect(nums1, nums2);
            Assert.That(res, Is.EqualTo(new int[] { 6 }));
        }
        [Test]
        public void Test_496()
        {
            int[] nums1 = { 4, 1, 2 }, nums2 = { 1, 3, 4, 2 };
            var res = Code.NextGreaterElement(nums1, nums2);
            Assert.That(res, Is.EqualTo(new int[] { -1, 3, -1 }));
        }
        [Test]
        public void Test_1089()
        {
            int[] arr = { 1, 0, 2, 3, 0, 4, 5, 0 };
            Code.DuplicateZeros(arr);
            //Assert.That(res, Is.EqualTo(new int[] { -1, 3, -1 }));
        }
        [Test]
        public void Test_1346()
        {
            int[] arr = { 10, 2, 5, 3 };
            var res = Code.CheckIfExist(arr);
            Assert.That(res, Is.EqualTo(true));
        }

        [Test]
        public void Test_1002()
        {
            string[] words = { "bella", "label", "roller" };
            var res = Code.CommonChars(words);
            Assert.That(res, Is.EqualTo(new string[] { "e", "l", "l" }));
        }

        [Test]
        public void Test_67()
        {
            string a = "1010", b = "1011";
            string result = Code.AddBinary(a, b);
            Assert.That(result, Is.EqualTo("10101"));
        }
        [Test]
        public void Test_389()
        {
            string s = "abc", t = "abcd";
            string s1 = "", t1 = "y";
            char c = Code.FindTheDifference(s1, t1);
        }

        [Test]
        public void Test_20()
        {
            string s = "()[]{}";
            bool result = Code.IsValid(s);
            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_1221()
        {
            string s = "LLLLRRRR";
            int result = Code.BalancedStringSplit(s);
            Assert.That(result, Is.EqualTo(1));
        }

        //[Test]
        //public void Test_83()
        //{
        //    ListNode head = 1, 1, 2, 3, 3;
        //    int result = Code.DeleteDuplicates(head);
        //    Assert.That(result, Is.EqualTo({ 1,2,3}));
        //}

        [Test]
        public void Test_415()
        {
            //string num1 = "3876620623801494171", num2 = "6529364523802684779";
            string num1 = "11", num2 = "123";
            string result = Code.AddStrings(num1, num2);
            Assert.That(result, Is.EqualTo("134"));
        }
        [Test]
        public void Test_394()
        {
            string s = "3[a2[c]]";
            //string s = "3[a]2[bc]";
            //string s = "2[abc]3[cd]ef";
            //string res = Code.DecodeString(s);
        }

        [Test]
        public void Test_599()
        {
            string[] list1 = { "happy", "sad", "good" }, list2 = { "sad", "happy", "good" };

            var res = Code.FindRestaurant(list1, list2);
        }

        [Test]
        public void Test_219()
        {
            int[] lnums = { 1, 2, 3, 1, 2, 3 }; int k = 2;

            var res = Code.ContainsNearbyDuplicate(lnums, k);
            Assert.That(res, Is.False);
        }

        [Test]
        public void Test_41()
        {
            int[] lnums = { 1, 2, 2, 1, 3, 1, 0, 4, 0 };

            var res = Code.FirstMissingPositive(lnums);
            Assert.That(res, Is.EqualTo(5));
        }
        [Test]
        public void Test_7()
        {
            int x = 1534236469;

            var res = Code.Reverse(x);
            Assert.That(res, Is.EqualTo(321));
        }
        [Test]
        public void Test_287()
        {
            int[] lnums = { 1, 3, 4, 2, 2 };

            var res = Code.FindDuplicate(lnums);
            Assert.That(res, Is.EqualTo(2));
        }

        [Test]
        public void Test_58()
        {
            string s = "   fly me   to   the moon  ";
            int count = Code.LengthOfLastWord(s);
        }

        [Test]
        public void Test_125()
        {
            string s = "A man, a plan, a canal: Panama";

            bool result = Code.IsPalindrome(s);
        }

        [Test]
        public void Test_66()
        {
            int[] sam1 = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] result = Code.PlusOne(sam1);
        }

        //17. Letter Combinations of a Phone Number
        [Test]
        public void Test_17()
        {
            string digits = "23";
            var res = Code.LetterCombinations(digits);
        }

        [Test]
        public void StringReverse()
        {
            string input = "mohamad";
            Assert.That(Code.ReverseString(input), Is.EqualTo("damahom"));
        }

        [Test]
        public void ArrayReverse()
        {
            string[] input = { "India", "is", "Bharath" };
            string[] output = { "Bharath", "is", "India" };
            Assert.That(Code.ReverseArray(input), Is.EqualTo(output));
        }

        [Test]
        public void ReverseWords()
        {
            string input = "india is bharath";
            string output = "bharath is india";
            Assert.That(Code.ReverseWords(input),Is.EqualTo(output));
        }

        [Test]
        public void PrimeNumber()
        {
            int input1 = 3;
            int input2 = 4;
            int input3 = 19;
            Assert.That(Code.IsPrime(input1), Is.True);
            Assert.That(Code.IsPrime(input2), Is.False);
            Assert.That(Code.IsPrime(input3), Is.True);
        }

        [Test]
        public void MaxAndMinNumberFromAnArray()
        {
            int[] input = { 5, 1, 4, 56, 6 };

            Assert.That(Code.FindMaxFromArray(input), Is.EqualTo(56));
            Assert.That(Code.FindMinFromArray(input), Is.EqualTo(1));
        }

        [Test]
        public void FindSecondeMaxAndMinNumberFromAnArray()
        {
            int[] input = { 5, 1, 4, 56, 6 };

            Assert.That(Code.FindSecondMaxFromArray(input), Is.EqualTo(6));
            Assert.That(Code.FindSecondMinFromArray(input), Is.EqualTo(4));
        }

        [Test]
        public void StringPalindrome()
        {
            string input = "abcba";
            string input1 = "abcbb";
            Assert.That(Code.IsStringPalindrome(input), Is.True);
            Assert.That(Code.IsStringPalindrome(input1), Is.False);
        }

        [Test]
        public void NumberPalindrome()
        {
            int input =12121;
            int input1 =12122;
            Assert.That(Code.IsDigitPalindrome(input), Is.True);
            Assert.That(Code.IsDigitPalindrome(input1), Is.False);
        }

        //[Test]
        //public void test()
        //{
        //}

        //[Test]
        //public void test()
        //{
        //}


    }
}
