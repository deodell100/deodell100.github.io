using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Library;

namespace LibraryTest
{
    [TestClass]
    public class MemberRulesEngineTests
    {
        //Arrange

        [TestMethod]
        public void GetMemberRules_NotGoodStanding_CheckoutNotAllowed()
        {
            var member = new Member
            {
                IsInGoodStanding = false
            };

            ExecuteTest_CheckoutAllowed(member, false);
        }

        [TestMethod]
        public void GetMemberRules_GoodStanding_Checkout()
        {
            var member = new Member
            {
                IsInGoodStanding = true
            };

            ExecuteTest_CheckoutAllowed(member, true);
        }

        [TestMethod]
        public void GetMemberRules_WithNewMember_AllowMaxCheckoutofNDays()
        {
            const int maxCheckoutInDays = 7;

            var member = new Member
            {
                pastCheckoutCount = 0
            };

            ExecuteTest_MaxCheckoutinDays(member, maxCheckoutInDays);
        }

        [TestMethod]
        public void GetMemberRules_WithOldMember_AllowMaxCheckoutofNDays()
        {
            //Arrange
            const int maxCheckoutInDays = 14;
            var rulesEngine = new MemberRulesEngine();

            var member = new Member
            {
                pastCheckoutCount = 0
            };

            //Act
            var rules = rulesEngine.GetRules(member);


            //Assert
            Assert.AreEqual(maxCheckoutInDays, rules.maxCheckoutInDays);

        }

        [TestMethod]
        private void ExecuteTest_MaxCheckoutinDays(Member member, int maxCheckoutInDays)
        {
            var rulesEngine = new MemberRulesEngine();

            //Act
            var rules = rulesEngine.GetRules(member);


            //Assert
            Assert.AreEqual(maxCheckoutInDays, rules.maxCheckoutInDays);
        }

        [TestMethod]
        private void ExecuteTest_CheckoutAllowed(Member member, bool checkout)
        {

        }
    }
}

