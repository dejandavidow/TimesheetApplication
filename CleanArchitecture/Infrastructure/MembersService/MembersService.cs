using Infrastructure.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Service.DTOs;

namespace Infrastructure.MembersService
{
    public class MembersService : IMembersService
    {
        private readonly UserManager<Member> _userManager;
        public MembersService(UserManager<Member> userManager)
        {
            _userManager = userManager;
        }
        public async Task RegisterMember(MemberRegister memberRegister)
        {
           var user = memberRegister.Adapt<Member>();
            await _userManager.CreateAsync(user,memberRegister.Password);
            await _userManager.AddToRoleAsync(user, "Employee");
        }
    }
}
