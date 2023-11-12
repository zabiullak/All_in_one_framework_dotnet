using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  WireMockTool_Practice.LeetCodeSolver
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode tail;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
            this.tail = next;
        }

    }
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
    public class LinkedList
    {
        static ListNode head;

        public static ListNode Reverse(ListNode node)
        {
            ListNode prev = null, current = node, next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
            return head;
        }
    }

    static class Helper
    {
        public static ListNode GenerateList(int[] nums)
        {
            if (nums == null || nums.Length == 0) { return null; }

            var i = 0;
            var first = new ListNode(nums[i]);
            var current = first;

            while (++i < nums.Length)
            {
                current.next = new ListNode(nums[i]);
                current = current.next;
            }

            return first;
        }
    }
}
