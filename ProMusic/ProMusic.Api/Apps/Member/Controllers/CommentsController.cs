using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs.CommentDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Member.Controllers
{
    [Route("member/api/[controller]"), ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;


        public CommentsController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        #region Post

        [HttpPost("")]
        public async Task<IActionResult> Create(CommentPostDto commentPostDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(commentPostDto.AppUserId);
            if (user is null) return NotFound();
            commentPostDto.AppUserId = user.Id;
            var comment = await _commentService.CreateAsync(commentPostDto);
            return StatusCode(201, comment);
        }

        #endregion

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _commentService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            return Ok(await _commentService.GetAll(page));
        }

        #endregion
    }
}
