using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public interface IMemberRulesEngine
    {
        MemberRules GetRules(Member member);
    }
}
