using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.LeetCodeSolver
{
    public sealed class AssertHelper
    {
        public static void AssertLinkList(int[] expected, ListNode actual)
        {
            Assert.IsNotNull(actual);
            Assert.IsNotNull(expected);
            Assert.IsTrue(expected.Length > 0);

            var current = actual;
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsNotNull(current);
                Assert.That(current.val, Is.EqualTo(expected[i]));
                current = current.next;
            }

            Assert.IsNull(current);
        }
    }
}
