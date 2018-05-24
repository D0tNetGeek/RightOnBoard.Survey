using System.Threading.Tasks;
using RightOnBoard.Survey.Api.Models;

namespace RightOnBoard.Survey.Api.Interfaces
{
    interface IQuestionnaire
    {
        void CreateQuestionnaire(Questions question);
        Task<bool> UpdateQuestionnaire(int questionId);
        Task<bool> DeleteQuestionnaire(int questionId);
        Task<Questions> DisplayQuestionnaire();
        Task<Questions> DisplayQuestionnaireById(int questionId);
    }
}
