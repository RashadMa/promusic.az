using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Member.Controllers
{
    [Route("member/api/[controller]"), ApiController]
    public class InformationsController : Controller
    {
        private readonly IInformationService _informationService;

        public InformationsController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInformation(int id)
        {
            return Ok(await _informationService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAllInformations(int page = 1)
        {
            return Ok(await _informationService.GetAll(page));
        }

        #endregion
    }
}
