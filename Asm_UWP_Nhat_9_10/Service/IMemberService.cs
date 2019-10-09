using Asm_UWP_Nhat_9_10.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm_UWP_Nhat_9_10.Service
{
    interface IMemberService
    {
        string Login(String username, String password);

        Member Register(Member member);

        Member GetInformation(String token);
    }
}
