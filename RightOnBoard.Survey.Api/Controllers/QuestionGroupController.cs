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
    [Route("api/QuestionGroup")]
    [EnableCors("CorsPolicy")]
    [Authorize]
    public class QuestionGroupController : Controller
    {
        private readonly IQuestionGroupRepository _questionGroupRepository;
        private readonly IMapper _mapper;

        public QuestionGroupController(IQuestionGroupRepository questionGroupRepository, IMapper mapper)
        {
            _questionGroupRepository = questionGroupRepository;
            _mapper = mapper;
        }

        //createQuestionGroup
        [IgnoreAntiforgeryToken]
        [HttpPost]
        [Route("createQuestionGroup")]
        public async Task<IActionResult> CreateQuestionGroup([FromBody]List<QuestionGroup> questionGroups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var iterationModel = _mapper.Map<List<Services.Entities.SurveyIteration>>(iteration);

            var questionGroupModel = (from questionGroup in questionGroups
                                      select new Services.Entities.QuestionGroup
                                      {
                                          QuestionGroupId = Guid.NewGuid().ToString(),
                                          QuestionGroupName = questionGroup.QuestionGroupName,
                                          QuestionGroupDescription = questionGroup.QuestionGroupDescription,
                                          SurveyId = questionGroup.SurveyId
                                      }).ToList();

            var result = await _questionGroupRepository.CreateQuestionGroups(questionGroupModel);

            if (result)
            //if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new OkObjectResult(questionGroupModel);
            }
            else
            {
                return BadRequest();
            }
        }

        [IgnoreAntiforgeryToken]
        [HttpGet]
        [Route("getquestiongroupsforsurvey")]
        public IActionResult GetQuestionGroupsForSurvey(string surveyId)
        {
            var questionGroups =  _questionGroupRepository.GetQuestionGroupsForSurvey(surveyId);

            var result = (from questionGroup in questionGroups
                          select new QuestionGroup
                          {
                              QuestionGroupId = questionGroup.QuestionGroupId,
                              QuestionGroupName = questionGroup.QuestionGroupName,
                              QuestionGroupDescription = questionGroup.QuestionGroupDescription,
                              SurveyId = questionGroup.SurveyId
                          }).ToList();

            if (result.Count > 0)
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