using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RightOnBoard.Survey.Api.Models;
using RightOnBoard.Survey.Api.ViewModels;
using RightOnBoard.Survey.Services.Interfaces;

namespace RightOnBoard.Survey.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireRepository _questionnaireRepository;

        public QuestionnaireController(IQuestionnaireRepository questionnaireRepository)
        {
            _questionnaireRepository = questionnaireRepository;
        }

        // GET api/questionnaire
        [HttpGet]
        public List<QuestionnaireViewModel> Get()
        {
            //return new List<QuestionnaireViewModel>();

            var questions = _questionnaireRepository.GetQuestions();

            var list = (from qvm in questions
                        select new QuestionnaireViewModel
                        {
                            SurveyInfo = new SurveyInfo
                            {
                                SurveyId = qvm.SurveyInfo.SurveyId,
                                Name = qvm.SurveyInfo.Name,
                                Description = qvm.SurveyInfo.Description,
                                WelcomeMessage = qvm.SurveyInfo.WelcomeMessage,
                                ExitMessage = qvm.SurveyInfo.ExitMessage,
                                StartDate = qvm.SurveyInfo.StartDate,
                                EndDate = qvm.SurveyInfo.EndDate,
                                ExpirationDate = qvm.SurveyInfo.ExpirationDate,
                                PublicationDate = qvm.SurveyInfo.PublicationDate
                            },
                            QuestionGroups = (from qg in qvm.QuestionGroups
                                              select new QuestionGroup
                                              {
                                                  QuestionGroupId = qg.QuestionGroupId,
                                                  QuestionGroupName = qg.QuestionGroupName,
                                                  QuestionGroupDescription = qg.QuestionGroupDescription,

                                                  Drivers = (from d in qg.Drivers
                                                             select new Driver
                                                             {
                                                                 Id = d.Id,
                                                                 DriverName = d.DriverName,
                                                                 Questions = (from q in d.Questions
                                                                              select new Questions
                                                                              {
                                                                                  Id = q.Id,
                                                                                  QuestionName = q.QuestionName,
                                                                                  QuestionText = q.QuestionText,
                                                                                  QuestionNumber = q.QuestionNumber,
                                                                                  QuestionAnswerRequired = q.QuestionAnswerRequired,
                                                                                  QuestionSequence = q.QuestionSequence,
                                                                                  QuestionTypeName = q.QuestionTypeName
                                                                              }).ToList()
                                                             }).ToList()

                                              }).ToList()
                        }).ToList();

            return list;
        }

        // GET api/getSurveyforUser
        [HttpGet]
        [Route("GetSurveyForIteration/{iterationId}")]
        public QuestionnaireViewModel GetSurveyForIteration(string iterationId)
        {
            var questions = _questionnaireRepository.GetSurveyForIteration(iterationId);

            var list = new QuestionnaireViewModel
            {
                SurveyInfo = new SurveyInfo
                {
                    SurveyId = questions.SurveyInfo.SurveyId,
                    Name = questions.SurveyInfo.Name,
                    Description = questions.SurveyInfo.Description,
                    WelcomeMessage = questions.SurveyInfo.WelcomeMessage,
                    ExitMessage = questions.SurveyInfo.ExitMessage,
                    StartDate = questions.SurveyInfo.StartDate,
                    EndDate = questions.SurveyInfo.EndDate,
                    ExpirationDate = questions.SurveyInfo.ExpirationDate,
                    PublicationDate = questions.SurveyInfo.PublicationDate
                },
                QuestionGroups = (from qg in questions.QuestionGroups
                                  select new QuestionGroup
                                  {
                                      QuestionGroupId = qg.QuestionGroupId,
                                      QuestionGroupName = qg.QuestionGroupName,
                                      QuestionGroupDescription = qg.QuestionGroupDescription,

                                      Drivers = (from d in qg.Drivers
                                                 select new Driver
                                                 {
                                                     Id = d.Id,
                                                     DriverName = d.DriverName,
                                                     Questions = (from q in d.Questions
                                                                  select new Questions
                                                                  {
                                                                      Id = q.Id,
                                                                      QuestionName = q.QuestionName,
                                                                      QuestionText = q.QuestionText,
                                                                      QuestionNumber = q.QuestionNumber,
                                                                      QuestionAnswerRequired = q.QuestionAnswerRequired,
                                                                      QuestionSequence = q.QuestionSequence,
                                                                      QuestionTypeName = q.QuestionTypeName
                                                                  }).ToList()
                                                 }).ToList()

                                  }).ToList()
            };

            //var list1 = (from qvm in questions
            //            select new QuestionnaireViewModel
            //            {
            //                SurveyInfo = new SurveyInfo
            //                {
            //                    SurveyId = qvm.SurveyInfo.SurveyId,
            //                    Name = qvm.SurveyInfo.Name,
            //                    Description = qvm.SurveyInfo.Description,
            //                    WelcomeMessage = qvm.SurveyInfo.WelcomeMessage,
            //                    ExitMessage = qvm.SurveyInfo.ExitMessage,
            //                    StartDate = qvm.SurveyInfo.StartDate,
            //                    EndDate = qvm.SurveyInfo.EndDate,
            //                    ExpirationDate = qvm.SurveyInfo.ExpirationDate,
            //                    PublicationDate = qvm.SurveyInfo.PublicationDate
            //                },
            //                QuestionGroups = (from qg in qvm.QuestionGroups
            //                                  select new QuestionGroup
            //                                  {
            //                                      QuestionGroupId = qg.QuestionGroupId,
            //                                      QuestionGroupName = qg.QuestionGroupName,
            //                                      QuestionGroupDescription = qg.QuestionGroupDescription,

            //                                      Drivers = (from d in qg.Drivers
            //                                                 select new Driver
            //                                                 {
            //                                                     Id = d.Id,
            //                                                     DriverName = d.DriverName,
            //                                                     Questions = (from q in d.Questions
            //                                                                  select new Questions
            //                                                                  {
            //                                                                      Id = q.Id,
            //                                                                      QuestionName = q.QuestionName,
            //                                                                      QuestionText = q.QuestionText,
            //                                                                      QuestionNumber = q.QuestionNumber,
            //                                                                      QuestionAnswerRequired = q.QuestionAnswerRequired,
            //                                                                      QuestionSequence = q.QuestionSequence,
            //                                                                      QuestionTypeName = q.QuestionTypeName
            //                                                                  }).ToList()
            //                                                 }).ToList()

            //                                  }).ToList()
            //            }).ToList();

            return list;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
