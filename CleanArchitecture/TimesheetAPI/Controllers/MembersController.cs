using Infrastructure.MembersService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;

namespace TimesheetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _memberService;
        public MembersController(IMembersService membersService)
        {
            _memberService = membersService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(MemberRegister member)
        {
            await _memberService.RegisterMember(member);
            return Ok(member);
        }
    }
}
