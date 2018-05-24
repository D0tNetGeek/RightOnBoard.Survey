using System.Collections.Generic;
using RightOnBoard.Survey.Services.Entities;

namespace RightOnBoard.Survey.Services.Interfaces
{
    public interface IHealthCheckRepository
    {
        IEnumerable<SurveyIteration> GetHealthChecks();
    }
}
