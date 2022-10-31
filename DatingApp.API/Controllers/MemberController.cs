using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Services;
using DatingApp.API.DTOs;

namespace DatingApp.API.Controllers;

[Route("api/member")]
[ApiController]
public class MemberController : BaseController
{
    private readonly IMemberService _memberService;
    public MemberController(IMemberService memberService)
    {
        this._memberService = memberService;
    }

    [HttpGet]
    public ActionResult<List<MemberDto>> Get()
    {
        return Ok(_memberService.GetMembers());
    }

    [HttpGet("{username}")]
    public ActionResult<MemberDto> Get(string username)
    {
        var member = _memberService.GetMemberByUsername(username);
        if (member == null)
        {
            return NotFound();
        }
        return Ok(member);
    }
}