using System.Collections.Generic;
using System.Threading.Tasks;
using RightOnBoard.Survey.Services.Entities;

namespace RightOnBoard.Survey.Services.Interfaces
{
    public interface IIterationRepository
    {
        Task<bool> CreateIteration(List<SurveyIteration> iterationInfo);
    }
}
