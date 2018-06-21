using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class MemberRulesEngine : IMemberRulesEngine
    {
        public MemberRules GetRules(Member member)
        {
            var rules = new MemberRules();

            if (member.pastCheckoutCount == 0)
            {
                member.pastCheckoutCount = 7;
            } else
            {
                rules.maxCheckoutInDays = 14;
            }

            return rules;
        }
    }
}
