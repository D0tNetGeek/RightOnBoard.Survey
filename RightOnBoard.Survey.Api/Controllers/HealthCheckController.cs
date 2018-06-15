using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RightOnBoard.JwtAuthTokenServer.Service.Models;
using RightOnBoard.Survey.Api.Models;
using RightOnBoard.Survey.Api.ViewModels;
using RightOnBoard.Survey.Services.Interfaces;

namespace RightOnBoard.Survey.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize(Policy = CustomRoles.User)]
    public class HealthCheckController : Controller
    {
        private readonly IHealthCheckRepository _healthCheckRepository;

        public HealthCheckController(IHealthCheckRepository healthCheckRepository)
        {
            _healthCheckRepository = healthCheckRepository;
        }

        //GET api/healthchecks
        [HttpGet]
        public List<HealthCheckViewModel> Get()
        {
            var healthChecks = _healthCheckRepository.GetHealthChecks();

            return (from checks in healthChecks
                select
                    new HealthCheckViewModel
                    {
                        IterationId = checks.Id,
                        IterationName =  checks.IterationName,
                        SurveyInfo = new SurveyViewModel
                        {
                            SurveyId = checks.SurveyId
                        },
                        StartDate = checks.OpenDateTime,
                        CompletedDate = checks.CloseDateTime//,
                        //SurveyStatus = checks.SurveyStatus

                    }).ToList();
        }
    }
}