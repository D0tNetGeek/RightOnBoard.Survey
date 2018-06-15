using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RightOnBoard.Survey.Api.Models;
using RightOnBoard.Survey.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RightOnBoard.Survey.Api.Controllers
{
    [Route("api/Iteration")]
    [EnableCors("CorsPolicy")]
    //[Authorize(Policy = CustomRoles.Admin)]
    [Authorize]
    public class IterationController : Controller
    {
        private readonly IIterationRepository _iterationRepository;
        private readonly IMapper _mapper;

        public IterationController(IIterationRepository iterationRepository, IMapper mapper)
        {
            _iterationRepository = iterationRepository;
            _mapper = mapper;
        }

        //createSurvey
        [IgnoreAntiforgeryToken]
        [HttpPost]
        [Route("createIteration")]
        public async Task<IActionResult> CreateIteration([FromBody]List<IterationInfo> iteration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var iterationModel = _mapper.Map<List<Services.Entities.SurveyIteration>>(iteration);

            var result = await _iterationRepository.CreateIteration(iterationModel);

            if (result)
            //if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}