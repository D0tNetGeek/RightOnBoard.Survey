using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RightOnBoard.Survey.Api.Models;
using RightOnBoard.Survey.Api.ViewModels;
using RightOnBoard.Survey.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RightOnBoard.Survey.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    //[Authorize(Policy = CustomRoles.Admin)]
    [Authorize]
    public class SurveyController : Controller
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;

        public SurveyController(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        //Get/Survey
        [HttpGet]
        [Route("getSurveysListForAdmin")]
        public List<SurveyViewModel> GetSurveysListForAdmin()
        {
            //This is test comment and one more.
            var surveyList = _surveyRepository.GetAdminSurveyList();

            return surveyList.Select(x => new SurveyViewModel
            {
                SurveyId = x.SurveyId,
                Name = x.Name,
                Description = x.Description,
                WelcomeMessage = x.WelcomeMessage,
                ExitMessage = x.ExitMessage,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                ExpirationDate = x.ExpirationDate,
                PublicationDate = x.PublicationDate,
                CompanyName = x.CompanyName
            }).ToList();
        }

        //createSurvey
        [IgnoreAntiforgeryToken]
        [HttpPost]
        [Route("createSurvey")]
        public async Task<IActionResult> CreateSurvey([FromBody]SurveyInfo survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var surveyModel = _mapper.Map<Services.Entities.SurveyInfo>(survey);

            var surveyModel = new Services.Entities.SurveyInfo
            {
                CompanyId = survey.CompanyId,
                Name = survey.Name,
                Description =survey.Description,
                WelcomeMessage = survey.WelcomeMessage,
                ExitMessage=survey.ExitMessage,
                StartDate = survey.StartDate,
                EndDate = survey.EndDate,
                PublicationDate = survey.PublicationDate,
                ExpirationDate =survey.ExpirationDate            };

            var result = await _surveyRepository.CreateSurvey(surveyModel);

            if(result != null)
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