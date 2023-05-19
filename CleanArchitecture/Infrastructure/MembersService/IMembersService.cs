using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MembersService
{
    public interface IMembersService
    {
        Task RegisterMember(MemberRegister memberRegister);
    }
}
