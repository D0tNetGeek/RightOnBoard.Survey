using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using RightOnBoard.JwtAuthTokenServer.Service.Interfaces;
using RightOnBoard.Survey.Data.DbContext;
using RightOnBoard.Survey.Services.Entities;
using RightOnBoard.Survey.Services.Interfaces;
using RightOnBoard.Survey.Services.Models;

namespace RightOnBoard.Survey.Services
{
    public class SurveyRepository : ISurveyRepository
    {
        private ApplicationDbContext _dbContext;
        private IUserService _userService;
        private readonly IMapper _mapper;

        public SurveyRepository(ApplicationDbContext dbContext, IUserService userService, IMapper mapper)
        {
            _dbContext = dbContext;
            _userService = userService;
            _mapper = mapper;
        }

        public IEnumerable<SurveyViewModel> GetAdminSurveyList()
        {
            //var userId = _userService.GetCurrentUserId();

            //var companyId = _dbContext.Customers.FirstOrDefault(x => x.UserId == userId).CompanyId;
            
            //    //var surveyList = _dbContext.SurveyInfo.FromSql("Survey_GetList_ByCompany @p0, @p1", "0A7CCADC-F6AA-49F6-87A0-476F43C74756", "74f4db91-8998-4e56-80e2-f91619630269");

            //var surveyList = (from si in _dbContext.SurveyInfo
            //                  join sc in _dbContext.SurveyCompany on si.Id equals sc.SurveyId
            //                  join cust in _dbContext.Customers on sc.CompanyId equals cust.CompanyId
            //                  join c in _dbContext.Company on sc.CompanyId equals c.CompanyId
            //                  where cust.UserId == userId //sc.CompanyId == companyId && 
            //                  select new SurveyViewModel
            //                  {
            //                      SurveyId = si.Id,
            //                      Name = si.Name,
            //                      Description = si.Description,
            //                      WelcomeMessage = si.WelcomeMessage,
            //                      ExitMessage = si.ExitMessage,
            //                      StartDate = si.StartDate,
            //                      EndDate = si.EndDate,
            //                      ExpirationDate = si.ExpirationDate,
            //                      PublicationDate = si.PublicationDate,
            //                      CompanyName = c.CompanyName
            //                  });

            var surveyList = (from si in _dbContext.SurveyInfo
                              join sc in _dbContext.SurveyCompany on si.Id equals sc.SurveyId
                              join c in _dbContext.Company on sc.CompanyId equals c.CompanyId
                              select new SurveyViewModel
                              {
                                  SurveyId = si.Id,
                                  Name = si.Name,
                                  Description = si.Description,
                                  WelcomeMessage = si.WelcomeMessage,
                                  ExitMessage = si.ExitMessage,
                                  StartDate = si.StartDate,
                                  EndDate = si.EndDate,
                                  ExpirationDate = si.ExpirationDate,
                                  PublicationDate = si.PublicationDate,
                                  CompanyName = c.CompanyName
                              });

            return surveyList;
        }

        public async Task<SurveyInfo> CreateSurvey(SurveyInfo survey)
        {
            try
            {
                //var surveyModel = _mapper.Map<Data.Models.SurveyViewModel>(survey);

                var surveyId = Guid.NewGuid().ToString();

                var surveyModel = new Data.Models.SurveyInfo
                {
                    Id = surveyId,
                    Name = survey.Name,
                    Description = survey.Description,
                    WelcomeMessage = survey.WelcomeMessage,
                    ExitMessage = survey.ExitMessage,
                    StartDate = survey.StartDate,
                    EndDate = survey.EndDate,
                    PublicationDate = survey.PublicationDate,
                    ExpirationDate = survey.ExpirationDate
                };

                var result = await _dbContext.SurveyInfo.AddAsync(surveyModel);

                if (result.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    await _dbContext.SaveChangesAsync();

                    await _dbContext.SurveyCompany.AddAsync(new Data.Models.SurveyCompany
                    {
                        Id = Guid.NewGuid().ToString(),
                        SurveyId = surveyId,
                        CompanyId = survey.CompanyId
                    });

                    await _dbContext.SaveChangesAsync();

                    //var response = new HttpResponseMessage (HttpStatusCode.OK) {Content = new StringContent(surveyId, System.Text.Encoding.UTF8, "text/plain")};

                    //var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(surveyId, System.Text.Encoding.UTF8, "text/json") };


                    var response = new SurveyInfo
                    {
                        SurveyId = surveyId,
                        Name = survey.Name,
                        Description = survey.Description,
                        WelcomeMessage = survey.WelcomeMessage,
                        ExitMessage = survey.ExitMessage,
                        StartDate = survey.StartDate,
                        EndDate = survey.EndDate,
                        PublicationDate = survey.PublicationDate,
                        ExpirationDate = survey.ExpirationDate,
                        CompanyId = survey.CompanyId,
                        CompanyName = survey.CompanyName
                    };

                    return response;
                }

            }
            catch(Exception e)
            {
                throw e;
            }

            return new SurveyInfo { };
        }
    }
}
