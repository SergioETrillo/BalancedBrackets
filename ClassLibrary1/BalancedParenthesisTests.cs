using NUnit.Framework;
using BalancedParenthesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParenthesis.Tests
{
    [TestFixture]
    public class BalancedParenthesisTests
    {

        [Test]
        public void EmptyStringIsTrue()
        {
            Assert.That(Program.IsBalanced(""), Is.True);
        }

        [Test]
        public void StringContainingNoBracketsIsTrue()
        {
            Assert.That(Program.IsBalanced("asdfas2224a"), Is.True);
        }

        [Test]
        public void StringContainingOneOpeningBracketIsFalse()
        {
            Assert.That(Program.IsBalanced("ada(dasdf"), Is.False);
        }

        [Test]
        public void StringCurlyBracketsTwiceCloseParenthesisIsFalse() {
            Assert.That(Program.IsBalanced("{{)(}}"), Is.False);
        }

        //
        [Test, Description("[({})] is balanced")]
        public void BalancedCombinationIsTrue()
        {
            Assert.That(Program.IsBalanced("[({})]"), Is.True);
        }

        [Test, Description("({)} is not balanced")]
        public void BalancedCombinationIsFalse()
        {
            Assert.That(Program.IsBalanced("a({)}"), Is.False);
        }

        [Test, Description(") is not balanced")]
        public void UnBalancedCloseBracketIsFalse()
        {
            Assert.That(Program.IsBalanced(")"), Is.False);
        }

    }
}
