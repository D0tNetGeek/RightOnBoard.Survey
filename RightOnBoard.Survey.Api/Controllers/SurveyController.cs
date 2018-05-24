using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RightOnBoard.Survey.Api.Models;
using RightOnBoard.Survey.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RightOnBoard.Survey.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class SurveyController : Controller
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyController(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        //Get/Survey
        [HttpGet]
        [Route("getSurveysListForAdmin")]
        public List<SurveyInfo> GetSurveysListForAdmin()
        {
            //This is test comment
            var surveyList = _surveyRepository.GetAdminSurveyList();

            return surveyList.Select(x => new SurveyInfo
            {
                SurveyId = x.SurveyId,
                Name = x.Name,
                Description = x.Description,
                WelcomeMessage = x.WelcomeMessage,
                ExitMessage = x.ExitMessage,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                ExpirationDate = x.ExpirationDate,
                PublicationDate = x.PublicationDate
            }).ToList();
        }
    }
}