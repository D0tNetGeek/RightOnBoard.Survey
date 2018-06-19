using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RightOnBoard.Survey.Api.Models;
using RightOnBoard.Survey.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //createIteration
        [IgnoreAntiforgeryToken]
        [HttpPost]
        [Route("createIteration")]
        public async Task<IActionResult> CreateIteration([FromBody]List<IterationInfo> iterations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var iterationModel = _mapper.Map<List<Services.Entities.SurveyIteration>>(iteration);

            var iterationModel = (from iteration in iterations
                                  select new Services.Entities.SurveyIteration
                                  {
                                      Id = Guid.NewGuid().ToString(),
                                      IterationName = iteration.IterationName,
                                      OpenDateTime = iteration.OpenDateTime,
                                      CloseDateTime = iteration.CloseDateTime,
                                      ReminderDateTime = iteration.ReminderDateTime,
                                      ReminderFrequency = iteration.ReminderFrequency,
                                      SurveyId = iteration.SurveyId
                                  }).ToList();

            var result = await _iterationRepository.CreateIteration(iterationModel);

            if (result)
            //if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new OkObjectResult(iterationModel);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}