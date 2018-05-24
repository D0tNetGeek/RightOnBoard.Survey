using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightOnBoard.Survey.Services.Entities;

namespace RightOnBoard.Survey.Services.Interfaces
{
    public interface IQuestionnaireRepository : IDisposable
    {
        IEnumerable<Questionnaire> GetQuestions();
        Questionnaire GetSurveyForIteration(string iterationId);

        Questions GetQuestion(Guid questionId);
        void CreateQuestion(Questions question);
        void UpdateQuestion(Questions question);
        void DeleteQuestion(Guid questionId);
        int SaveQuestion();
        Task<int> SaveAsync();
    }
}
