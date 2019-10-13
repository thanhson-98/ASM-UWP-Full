using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_APP_v1.Entity;

namespace UWP_APP_v1.Service
{
    //Thuc hien cac chuc nang lien quan toi member bao gom:
    interface MemberService
    {
        //nhap tham so dau vao la, ra la.. co validate
        string Login(string username, string password);

        Member Register(Member member);

        Member GetInformation(string token);


    }
}
