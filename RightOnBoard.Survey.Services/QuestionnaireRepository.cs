using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RightOnBoard.JwtAuthTokenServer.Service.Interfaces;
using RightOnBoard.Survey.Data.DbContext;
using RightOnBoard.Survey.Services.Entities;
using RightOnBoard.Survey.Services.Interfaces;

namespace RightOnBoard.Survey.Services
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private ApplicationDbContext _dbContext;
        private IUserService _userService;

        public QuestionnaireRepository(ApplicationDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public IEnumerable<Questionnaire> GetQuestions()
        {
            //Select s.Name, dq.QuestionGroupId, g.QuestionGroupName, dq.DriverId, d.DriverName, dq.QuestionId, q.* from
            //    DriverQuestionGroup dq
            //INNER JOIN QuestionGroup g on dq.QuestionGroupId = g.Id
            //INNER JOIN Driver d on dq.DriverId = d.Id
            //INNER JOIN Questions q on dq.QuestionId = q.id
            //INNER JOIN Survey s on q.SurveyId = s.Id
            //ORder by q.QuestionSequence

            //return new List<Questionnaire>();

            //var questionnaire = from dq in _dbContext.DriverQuestionGroup
            //    join qg in _dbContext.QuestionGroup on dq.QuestionGroupId equals qg.Id
            //    join d in _dbContext.Driver on dq.DriverId equals d.Id
            //    join q in _dbContext.Questions on dq.QuestionId equals q.Id
            //    join s in _dbContext.Survey on q.SurveyId equals s.Id
            //    join qt in _dbContext.QuestionType on q.QuestionTypeId equals qt.Id
            //    orderby q.QuestionSequence
            //    select new Questionnaire
            //    {
            //        SurveyInfo = new SurveyInfo
            //        {
            //            SurveyId = s.Id,
            //            Name = s.Name,
            //            Description = s.Description,
            //            WelcomeMessage = s.WelcomeMessage,
            //            ExitMessage = s.ExitMessage,
            //            StartDate = s.StartDate,
            //            EndDate = s.EndDate,
            //            ExpirationDate = s.ExpirationDate,
            //            PublicationDate = s.PublicationDate
            //        },
            //        QuestionGroups = new List<QuestionGroup>
            //        {
            //            new QuestionGroup
            //            {
            //                QuestionGroupId = qg.Id,
            //                QuestionGroupName = qg.QuestionGroupName,
            //                QuestionGroupDescription = qg.QuestionGroupDescription,
            //                Drivers = new List<Driver>
            //                {
            //                    new Driver
            //                    {
            //                        Id = d.Id,
            //                        DriverName = d.DriverName,
            //                        Questions = new List<Questions>
            //                        {
            //                            new Questions
            //                            {
            //                                Id = q.Id,
            //                                QuestionName = q.QuestionName,
            //                                QuestionText = q.QuestionText,
            //                                QuestionNumber = q.QuestionNumber,
            //                                QuestionAnswerRequired = q.QuestionAnswerRequired,
            //                                QuestionSequence = q.QuestionSequence,
            //                                QuestionTypeName = qt.QuestionTypeName
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    };

            var questionnaire = new List<Questionnaire>
            {
                new Questionnaire
                {
                    SurveyInfo = new SurveyInfo
                    {
                        SurveyId = "CF4252A6-073C-4824-9619-F24B13FC3ED8",
                        Name = "First Questionnaire",
                        Description = "This is first questionnaire",
                        WelcomeMessage = "Welcome to the Questionnaire",
                        ExitMessage = "Thanks for taking part in the questionnaire"
                    },
                    QuestionGroups = new List<QuestionGroup>
                    {
                        new QuestionGroup
                        {
                            QuestionGroupId = "4C47DC55-BA02-4DB6-AEB5-78D29975DFA2",
                            QuestionGroupName = "Confidence",
                            QuestionGroupDescription = "Are you able to indentify who the relevant people are or know someone that you can ask?",
                            Drivers = new List<Driver>
                            {
                                new Driver
                                {
                                    Id = "551B3033-260A-4EE0-9A83-C0E486478E75",
                                    DriverName = "Objective and Short term Goal Setting",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "1E693D2B-A713-4BAC-AD20-90A5C11E5651",
                                            QuestionName = "Question 7",
                                            QuestionNumber = "7",
                                            QuestionSequence = 7,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have an objectives document broken down into shorter term goals?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "DC8CD5B2-DDC8-4061-828E-C691A685513E",
                                            QuestionName = "Question 8",
                                            QuestionNumber = "8",
                                            QuestionSequence = 8,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you had a meeting with your manager to discuss objectives and role expectations?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "32449134-2FE0-431A-8C3D-D72CBCE9D0EE",
                                            QuestionName = "Question 9",
                                            QuestionNumber = "9",
                                            QuestionSequence = 9,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Are your objectives and short term goals clear to you?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "0DF0B619-0905-44FE-BF3A-425A63838067",
                                    DriverName = "Career Development",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "A8CBB644-4153-450A-9D59-39BC01A242F2",
                                            QuestionName = "Question 13",
                                            QuestionNumber = "13",
                                            QuestionSequence = 13,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have a personal development plan in place and a clear understanding of your career / promotion pathway?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "67D63563-3C37-446C-82E6-532E121C1568",
                                            QuestionName = "Question 14",
                                            QuestionNumber = "14",
                                            QuestionSequence = 14,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you had a PDP discussion with your line manager since the organisational change?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "77207EA3-64BA-4B3A-9312-59F9BF4D6A36",
                                            QuestionName = "Question 15",
                                            QuestionNumber = "15",
                                            QuestionSequence = 15,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you feel you have the opportunity for personal development and growth following the organisational change?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "30260E49-D8FB-46F7-BF2B-A0E113A73848",
                                    DriverName = "Resillience following change",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "D7A55176-8D7E-4422-A484-6063E9B441A9",
                                            QuestionName = "Question 4",
                                            QuestionNumber = "4",
                                            QuestionSequence = 4,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have a personal change plan to help you deal effectively with the change?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "A2AE74C8-D2C0-4CA3-A622-6D3271C758F1",
                                            QuestionName = "Question 5",
                                            QuestionNumber = "5",
                                            QuestionSequence = 5,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you had a discussion with a line manager since the reorganisation to acknowledge and discuss the impact of the change on you and support you with a personal change plan?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "59A9DD57-D2DE-43E6-A1F9-6D3B3B055610",
                                            QuestionName = "Question 6",
                                            QuestionNumber = "6",
                                            QuestionSequence = 6,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you feel confident to manage the impact of change?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "3AA35C12-3A6B-4AC4-AC4E-B6465A72A857",
                                    DriverName = "Knowledge and Skills",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "58148731-BACA-43E9-953E-DBF383388D19",
                                            QuestionName = "Question 10",
                                            QuestionNumber = "10",
                                            QuestionSequence = 10,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have the knowledge and skills to do your job effectively?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "CEECC801-E487-4081-B0EB-EFB8FDC46F39",
                                            QuestionName = "Question 11",
                                            QuestionNumber = "11",
                                            QuestionSequence = 11,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you received adequate Knowledge /  skills training to do your job effectively?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "839208F3-B19F-428C-8242-380CFF1E1711",
                                            QuestionName = "Question 12",
                                            QuestionNumber = "12",
                                            QuestionSequence = 12,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you feel confident you have the neccesary knowledge and skills to do your job effectively?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "A6796813-56E7-46EA-9861-71DFA9FC02D9",
                                    DriverName = "Coaching/Mentoring/ Buddying",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "864AC11A-1517-496C-B4E8-6DC765EBF7CE",
                                            QuestionName = "Question 16",
                                            QuestionNumber = "16",
                                            QuestionSequence = 16,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have a designated coach / mentor /buddy within your organisation?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "0D959CD6-ED06-467E-95E8-89E01CAC4613",
                                            QuestionName = "Question 17",
                                            QuestionNumber = "17",
                                            QuestionSequence = 17,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you had / booked a coaching / mentoring/ buddying session since the change has taken place?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "A79A0DF2-67C7-4F58-8272-B571A6FF7BEF",
                                            QuestionName = "Question 18",
                                            QuestionNumber = "18",
                                            QuestionSequence = 18,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you got regular coaching / mentoring / buddying sessions booked in advance ",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "777657E9-F3B6-4DD5-9E74-7AF43D8C1FC1",
                                    DriverName = "Manager Change Training",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "36FAE347-AC62-4DFF-8A84-132FF1A1DD31",
                                            QuestionName = "Question 1",
                                            QuestionNumber = "1",
                                            QuestionSequence = 1,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you know how to diffuse your own stress and lead your team effectively?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "66AB3A50-A029-4B9F-9D9A-317064775A78",
                                            QuestionName = "Question 2",
                                            QuestionNumber = "2",
                                            QuestionSequence = 2,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you received training to address the impact of change with your team?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "F76E66D4-367F-49BB-A217-48658E13BC26",
                                            QuestionName = "Question 3",
                                            QuestionNumber = "3",
                                            QuestionSequence = 3,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you feel confident to support your team members with a personal change plan strategy?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                }
                            }
                        },
                        new QuestionGroup
                        {
                            QuestionGroupId = "4F079C33-FFBC-4DD4-AF3A-7869A998984C",
                            QuestionGroupName = "Culture",
                            QuestionGroupDescription = "Culture description",
                            Drivers = new List<Driver>
                            {
                                new Driver
                                {
                                    Id = "ECDC14AA-D77A-424A-8EC7-D225731559E7",
                                    DriverName = "Innovation",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "4147FF2E-A09D-4531-89FE-8F66804F4598",
                                            QuestionName = "Question 40",
                                            QuestionNumber = "40",
                                            QuestionSequence = 40,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have the opportunity to be innovative?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "F996468F-E080-464F-B729-B5383889BE24",
                                            QuestionName = "Question 41",
                                            QuestionNumber = "41",
                                            QuestionSequence = 41,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Are you empowered to find a solution to a problem?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "4D072BC9-4740-4067-93F2-C9A1EFD241D8",
                                            QuestionName = "Question 42",
                                            QuestionNumber = "42",
                                            QuestionSequence = 42,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Does the company constantly seek ways to improve products and services?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "C8385A3F-187B-42D6-AFBC-4AE8D2B504B9",
                                    DriverName = "Values",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "B12BD9F2-420C-441C-A07F-05B1F8380A9C",
                                            QuestionName = "Question 34",
                                            QuestionNumber = "34",
                                            QuestionSequence = 34,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you know what the company’s stated values are?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "C42B1BC7-2258-43FC-B4B3-0FC24C33785F",
                                            QuestionName = "Question 35",
                                            QuestionNumber = "35",
                                            QuestionSequence = 35,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you apply the company’s values in your everyday work?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "8DC1D928-F984-4B62-87F7-421B5A0D4D31",
                                            QuestionName = "Question 36",
                                            QuestionNumber = "36",
                                            QuestionSequence = 36,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you see the company\'s values applied on a daily basis?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "C6D61319-E50C-49BD-B93A-405B0172FCC8",
                                    DriverName = "Leadership Behaviours",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "8B5B2BE9-9033-4B06-9872-6208DE178AE7",
                                            QuestionName = "Question 37",
                                            QuestionNumber = "37",
                                            QuestionSequence = 37,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Does the Leadership team contribute to a positive work cuture?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "7A118B6A-820A-4BA0-BC45-689AD6CECD8B",
                                            QuestionName = "Question 38",
                                            QuestionNumber = "38",
                                            QuestionSequence = 38,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you see the leaders living the stated values of the culture in the organisation?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "F8B4FED8-D618-4628-8CAB-748F77B71AB6",
                                            QuestionName = "Question 39",
                                            QuestionNumber = "39",
                                            QuestionSequence = 39,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you believe your company has a promising future?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                }
                            }
                        },
                        new QuestionGroup
                        {
                            QuestionGroupId = "85B47983-E718-4945-9DCF-0C3BFA3253C3",
                            QuestionGroupName = "Connection",
                            QuestionGroupDescription = "Connection description.",
                            Drivers = new List<Driver>
                            {
                                new Driver
                                {
                                    Id = "100F966A-1120-405D-845D-8B1994320E59",
                                    DriverName = "Knowing your network",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "53BD7FEB-9297-43AE-9B2A-F8987BA6CEAE",
                                            QuestionName = "Question 28",
                                            QuestionNumber = "28",
                                            QuestionSequence = 28,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you know the key people in the organisation to turm to when you need something?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "DB3FD408-BDA5-462E-B747-FCEC46FDE789",
                                            QuestionName = "Question 29",
                                            QuestionNumber = "29",
                                            QuestionSequence = 29,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you been given/shown a \"Who's Who?\" for the key people in your network?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "26A7CEA1-A7A9-4C4D-84DE-0233663DABFC",
                                            QuestionName = "Question 30",
                                            QuestionNumber = "30",
                                            QuestionSequence = 30,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Are you able to identify who the relevant people are or know someone that you can ask?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "24BAE054-E711-4BBC-B016-650E3DA5196C",
                                    DriverName = "Milestone recognition",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "320E13F9-709C-4D0B-AA84-D6DAFC36ECDC",
                                            QuestionName = "Question 25",
                                            QuestionNumber = "25",
                                            QuestionSequence = 25,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you know what milestones you have been set by your manager?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "34CA975E-C102-4695-81C1-D7AEFD31CE40",
                                            QuestionName = "Question 26",
                                            QuestionNumber = "26",
                                            QuestionSequence = 26,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Are you aware of what milestones have been met by other members of your team?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "8D15CE6A-E05C-4D8E-AD29-E7F46F14CDDF",
                                            QuestionName = "Question 27",
                                            QuestionNumber = "27",
                                            QuestionSequence = 27,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you been recognised for the work you've been doing? (Companies using strategic recognition are 48% more likey to report high engagement)",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "9B165AEA-9AD6-4280-A21D-E98DFBD06F37",
                                    DriverName = "Workplace socialisation",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "C1C02167-8291-4601-8B6B-19AB1479DB2D",
                                            QuestionName = "Question 31",
                                            QuestionNumber = "31",
                                            QuestionSequence = 31,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you got a way of connecting socially with people within your organisation?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "E2D8B16A-53DA-41CB-8B0F-3DEBB50CAF3D",
                                            QuestionName = "Question 32",
                                            QuestionNumber = "32",
                                            QuestionSequence = 32,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Is there platform to connect with the wider organisation?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "173D5063-7DDB-489F-8628-427FB21125ED",
                                            QuestionName = "Question 33",
                                            QuestionNumber = "33",
                                            QuestionSequence = 33,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you use the social network platform?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "A4540C38-3485-4E63-9A82-27D9B2194AC9",
                                    DriverName = "Touchpoint with teams",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "A066234B-F6F7-484C-82F0-9C352FB0EBBF",
                                            QuestionName = "Question 22",
                                            QuestionNumber = "22",
                                            QuestionSequence = 22,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have regular contact with your immediate team?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "1FF397FD-5D3E-4E36-A3E0-A3599038D168",
                                            QuestionName = "Question 23",
                                            QuestionNumber = "23",
                                            QuestionSequence = 23,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Is there good teamwork / cooperation between departments",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "8B3A8FB8-FB19-4C09-A201-CAB1546DA8D1",
                                            QuestionName = "Question 24",
                                            QuestionNumber = "24",
                                            QuestionSequence = 24,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have regular contact with other departments?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "12BF278E-FA75-40C6-AAB4-29C9FA946ABA",
                                    DriverName = "Meaningful Leadership Communication",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "C7E82D3C-AFDF-43AE-BFF6-44FAE6A1E418",
                                            QuestionName = "Question 19",
                                            QuestionNumber = "19",
                                            QuestionSequence = 19,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have regular communication with your manager?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "384F8E49-F591-44D6-A1BE-51874E229941",
                                            QuestionName = "Question 20",
                                            QuestionNumber = "20",
                                            QuestionSequence = 20,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you agreed the best way to work with your manager?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "DDE09D8A-B723-47D5-A684-91A00D247083",
                                            QuestionName = "Question 21",
                                            QuestionNumber = "21",
                                            QuestionSequence = 21,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Is the frequency of communication with your manager appropriate? ",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return questionnaire;
        }

        public Questionnaire GetSurveyForIteration(string iterationId)
        {
            var userId = _userService.GetCurrentUserId();

            //var surveyforIteration = (from q in _dbContext.Questions
            //                          join si in _dbContext.SurveyIteration on q.SurveyId equals si.SurveyId
            //                          join s in _dbContext.Survey on si.SurveyId equals s.Id
            //                          join dqg in _dbContext.DriverQuestionGroup on q.Id equals dqg.QuestionId
            //                          join d in _dbContext.Driver on dqg.DriverId equals d.Id
            //                          join qg in _dbContext.QuestionGroup on dqg.QuestionGroupId equals qg.Id
            //                          join qt in _dbContext.QuestionType on q.QuestionTypeId equals qt.Id
            //                          where si.Id == iterationId &&
            //                          !(
            //                              from r in _dbContext.QuestionResponses
            //                              join q1 in _dbContext.Questions on r.QuestionId equals q1.Id
            //                              join si in _dbContext.SurveyIteration on r.SurveyIterationId equals si.Id
            //                              join si1 in _dbContext.SurveyIteration on si.SurveyId equals si1.SurveyId
            //                              where
            //                              r.UserId == userId
            //                              && q1.QuestionTypeId == "C455A25A-EDB2-4661-B9F7-F08D577164EE"
            //                              && r.BoolResponse == true
            //                              && si1.Id == iterationId
            //                              && si.Id != iterationId
            //                              select r.QuestionId
            //                          ).Any()
            //                          select
            //                              new Questionnaire
            //                              {
            //                                  SurveyInfo = new SurveyInfo
            //                                  {
            //                                      SurveyId = s.Id,
            //                                      Name = s.Name,
            //                                      Description = s.Description,
            //                                      WelcomeMessage = s.WelcomeMessage,
            //                                      StartDate = s.StartDate,
            //                                      EndDate = s.EndDate
            //                                  },
            //                                  QuestionGroups = new List<QuestionGroup>
            //                                    {
            //                                          new QuestionGroup
            //                                          {
            //                                              QuestionGroupId = qg.Id,
            //                                              QuestionGroupName = qg.QuestionGroupName,
            //                                              QuestionGroupDescription = qg.QuestionGroupDescription,
            //                                              Drivers = new List<Driver>
            //                                              {
            //                                                  new Driver
            //                                                  {
            //                                                      Id = d.Id,
            //                                                      DriverName = d.DriverName,
            //                                                      Questions = new List<Questions>
            //                                                      {
            //                                                          new Questions
            //                                                          {
            //                                                              Id = q.Id,
            //                                                              QuestionName = q.QuestionName,
            //                                                              QuestionNumber = q.QuestionNumber,
            //                                                              QuestionSequence = q.QuestionSequence,
            //                                                              QuestionAnswerRequired = q.QuestionAnswerRequired,
            //                                                              QuestionText = q.QuestionText,
            //                                                              QuestionTypeName = qt.QuestionTypeName
            //                                                          }
            //                                                      }
            //                                                  }
            //                                              }
            //                                          }
            //                                    }
            //                                  //q.Id,
            //                                  //q.QuestionAnswerRequired,
            //                                  //q.QuestionName,
            //                                  //q.QuestionNumber,
            //                                  //q.QuestionSequence,
            //                                  //q.QuestionText,
            //                                  //q.QuestionTypeId,
            //                                  //q.SurveyId,
            //                                  //dqg.QuestionGroupId,
            //                                  //dqg.DriverId
            //                              }).FirstOrDefault();

            //return surveyforIteration;

            var surveyforIteration =
                new Questionnaire
                {
                    SurveyInfo = new SurveyInfo
                    {
                        SurveyId = "CF4252A6-073C-4824-9619-F24B13FC3ED8",
                        Name = "First Questionnaire",
                        Description = "This is first questionnaire",
                        WelcomeMessage = "Welcome to the Questionnaire",
                        ExitMessage = "Thanks for taking part in the questionnaire"
                    },
                    QuestionGroups = new List<QuestionGroup>
                    {
                        new QuestionGroup
                        {
                            QuestionGroupId = "4C47DC55-BA02-4DB6-AEB5-78D29975DFA2",
                            QuestionGroupName = "Confidence",
                            QuestionGroupDescription = "Are you able to indentify who the relevant people are or know someone that you can ask?",
                            Drivers = new List<Driver>
                            {
                                new Driver
                                {
                                    Id = "777657E9-F3B6-4DD5-9E74-7AF43D8C1FC1",
                                    DriverName = "Manager Change Training",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "36FAE347-AC62-4DFF-8A84-132FF1A1DD31",
                                            QuestionName = "Question 1",
                                            QuestionNumber = "1",
                                            QuestionSequence = 1,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you know how to diffuse your own stress and lead your team effectively?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "66AB3A50-A029-4B9F-9D9A-317064775A78",
                                            QuestionName = "Question 2",
                                            QuestionNumber = "2",
                                            QuestionSequence = 2,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you received training to address the impact of change with your team?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "F76E66D4-367F-49BB-A217-48658E13BC26",
                                            QuestionName = "Question 3",
                                            QuestionNumber = "3",
                                            QuestionSequence = 3,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you feel confident to support your team members with a personal change plan strategy?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "30260E49-D8FB-46F7-BF2B-A0E113A73848",
                                    DriverName = "Resillience following change",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "D7A55176-8D7E-4422-A484-6063E9B441A9",
                                            QuestionName = "Question 4",
                                            QuestionNumber = "4",
                                            QuestionSequence = 4,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have a personal change plan to help you deal effectively with the change?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "A2AE74C8-D2C0-4CA3-A622-6D3271C758F1",
                                            QuestionName = "Question 5",
                                            QuestionNumber = "5",
                                            QuestionSequence = 5,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you had a discussion with a line manager since the reorganisation to acknowledge and discuss the impact of the change on you and support you with a personal change plan?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "59A9DD57-D2DE-43E6-A1F9-6D3B3B055610",
                                            QuestionName = "Question 6",
                                            QuestionNumber = "6",
                                            QuestionSequence = 6,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you feel confident to manage the impact of change?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "551B3033-260A-4EE0-9A83-C0E486478E75",
                                    DriverName = "Objective and Short term Goal Setting",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "1E693D2B-A713-4BAC-AD20-90A5C11E5651",
                                            QuestionName = "Question 7",
                                            QuestionNumber = "7",
                                            QuestionSequence = 7,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have an objectives document broken down into shorter term goals?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "DC8CD5B2-DDC8-4061-828E-C691A685513E",
                                            QuestionName = "Question 8",
                                            QuestionNumber = "8",
                                            QuestionSequence = 8,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you had a meeting with your manager to discuss objectives and role expectations?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "32449134-2FE0-431A-8C3D-D72CBCE9D0EE",
                                            QuestionName = "Question 9",
                                            QuestionNumber = "9",
                                            QuestionSequence = 9,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Are your objectives and short term goals clear to you?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "3AA35C12-3A6B-4AC4-AC4E-B6465A72A857",
                                    DriverName = "Knowledge and Skills",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "58148731-BACA-43E9-953E-DBF383388D19",
                                            QuestionName = "Question 10",
                                            QuestionNumber = "10",
                                            QuestionSequence = 10,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have the knowledge and skills to do your job effectively?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "CEECC801-E487-4081-B0EB-EFB8FDC46F39",
                                            QuestionName = "Question 11",
                                            QuestionNumber = "11",
                                            QuestionSequence = 11,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you received adequate Knowledge /  skills training to do your job effectively?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "839208F3-B19F-428C-8242-380CFF1E1711",
                                            QuestionName = "Question 12",
                                            QuestionNumber = "12",
                                            QuestionSequence = 12,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you feel confident you have the neccesary knowledge and skills to do your job effectively?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "0DF0B619-0905-44FE-BF3A-425A63838067",
                                    DriverName = "Career Development",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "A8CBB644-4153-450A-9D59-39BC01A242F2",
                                            QuestionName = "Question 13",
                                            QuestionNumber = "13",
                                            QuestionSequence = 13,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have a personal development plan in place and a clear understanding of your career / promotion pathway?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "67D63563-3C37-446C-82E6-532E121C1568",
                                            QuestionName = "Question 14",
                                            QuestionNumber = "14",
                                            QuestionSequence = 14,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you had a PDP discussion with your line manager since the organisational change?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "77207EA3-64BA-4B3A-9312-59F9BF4D6A36",
                                            QuestionName = "Question 15",
                                            QuestionNumber = "15",
                                            QuestionSequence = 15,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you feel you have the opportunity for personal development and growth following the organisational change?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "A6796813-56E7-46EA-9861-71DFA9FC02D9",
                                    DriverName = "Coaching/Mentoring/ Buddying",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "864AC11A-1517-496C-B4E8-6DC765EBF7CE",
                                            QuestionName = "Question 16",
                                            QuestionNumber = "16",
                                            QuestionSequence = 16,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have a designated coach / mentor /buddy within your organisation?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "0D959CD6-ED06-467E-95E8-89E01CAC4613",
                                            QuestionName = "Question 17",
                                            QuestionNumber = "17",
                                            QuestionSequence = 17,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you had / booked a coaching / mentoring/ buddying session since the change has taken place?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "A79A0DF2-67C7-4F58-8272-B571A6FF7BEF",
                                            QuestionName = "Question 18",
                                            QuestionNumber = "18",
                                            QuestionSequence = 18,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you got regular coaching / mentoring / buddying sessions booked in advance ",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                }
                            }
                        },
                        new QuestionGroup
                        {
                            QuestionGroupId = "85B47983-E718-4945-9DCF-0C3BFA3253C3",
                            QuestionGroupName = "Connection",
                            QuestionGroupDescription = "Connection description.",
                            Drivers = new List<Driver>
                            {
                                new Driver
                                {
                                    Id = "12BF278E-FA75-40C6-AAB4-29C9FA946ABA",
                                    DriverName = "Meaningful Leadership Communication",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "C7E82D3C-AFDF-43AE-BFF6-44FAE6A1E418",
                                            QuestionName = "Question 19",
                                            QuestionNumber = "19",
                                            QuestionSequence = 19,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have regular communication with your manager?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "384F8E49-F591-44D6-A1BE-51874E229941",
                                            QuestionName = "Question 20",
                                            QuestionNumber = "20",
                                            QuestionSequence = 20,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you agreed the best way to work with your manager?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "DDE09D8A-B723-47D5-A684-91A00D247083",
                                            QuestionName = "Question 21",
                                            QuestionNumber = "21",
                                            QuestionSequence = 21,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Is the frequency of communication with your manager appropriate? ",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "A4540C38-3485-4E63-9A82-27D9B2194AC9",
                                    DriverName = "Touchpoint with teams",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "A066234B-F6F7-484C-82F0-9C352FB0EBBF",
                                            QuestionName = "Question 22",
                                            QuestionNumber = "22",
                                            QuestionSequence = 22,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have regular contact with your immediate team?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "1FF397FD-5D3E-4E36-A3E0-A3599038D168",
                                            QuestionName = "Question 23",
                                            QuestionNumber = "23",
                                            QuestionSequence = 23,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Is there good teamwork / cooperation between departments",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "8B3A8FB8-FB19-4C09-A201-CAB1546DA8D1",
                                            QuestionName = "Question 24",
                                            QuestionNumber = "24",
                                            QuestionSequence = 24,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have regular contact with other departments?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "24BAE054-E711-4BBC-B016-650E3DA5196C",
                                    DriverName = "Milestone recognition",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "320E13F9-709C-4D0B-AA84-D6DAFC36ECDC",
                                            QuestionName = "Question 25",
                                            QuestionNumber = "25",
                                            QuestionSequence = 25,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you know what milestones you have been set by your manager?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "34CA975E-C102-4695-81C1-D7AEFD31CE40",
                                            QuestionName = "Question 26",
                                            QuestionNumber = "26",
                                            QuestionSequence = 26,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Are you aware of what milestones have been met by other members of your team?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "8D15CE6A-E05C-4D8E-AD29-E7F46F14CDDF",
                                            QuestionName = "Question 27",
                                            QuestionNumber = "27",
                                            QuestionSequence = 27,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you been recognised for the work you've been doing? (Companies using strategic recognition are 48% more likey to report high engagement)",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "100F966A-1120-405D-845D-8B1994320E59",
                                    DriverName = "Knowing your network",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "53BD7FEB-9297-43AE-9B2A-F8987BA6CEAE",
                                            QuestionName = "Question 28",
                                            QuestionNumber = "28",
                                            QuestionSequence = 28,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you know the key people in the organisation to turm to when you need something?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "DB3FD408-BDA5-462E-B747-FCEC46FDE789",
                                            QuestionName = "Question 29",
                                            QuestionNumber = "29",
                                            QuestionSequence = 29,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you been given/shown a \"Who's Who?\" for the key people in your network?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "26A7CEA1-A7A9-4C4D-84DE-0233663DABFC",
                                            QuestionName = "Question 30",
                                            QuestionNumber = "30",
                                            QuestionSequence = 30,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Are you able to identify who the relevant people are or know someone that you can ask?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "9B165AEA-9AD6-4280-A21D-E98DFBD06F37",
                                    DriverName = "Workplace socialisation",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "C1C02167-8291-4601-8B6B-19AB1479DB2D",
                                            QuestionName = "Question 31",
                                            QuestionNumber = "31",
                                            QuestionSequence = 31,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Have you got a way of connecting socially with people within your organisation?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "E2D8B16A-53DA-41CB-8B0F-3DEBB50CAF3D",
                                            QuestionName = "Question 32",
                                            QuestionNumber = "32",
                                            QuestionSequence = 32,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Is there platform to connect with the wider organisation?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "173D5063-7DDB-489F-8628-427FB21125ED",
                                            QuestionName = "Question 33",
                                            QuestionNumber = "33",
                                            QuestionSequence = 33,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you use the social network platform?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                }
                            }
                        },
                        new QuestionGroup
                        {
                            QuestionGroupId = "4F079C33-FFBC-4DD4-AF3A-7869A998984C",
                            QuestionGroupName = "Culture",
                            QuestionGroupDescription = "Culture description",
                            Drivers = new List<Driver>
                            {
                                new Driver
                                {
                                    Id = "C8385A3F-187B-42D6-AFBC-4AE8D2B504B9",
                                    DriverName = "Values",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "B12BD9F2-420C-441C-A07F-05B1F8380A9C",
                                            QuestionName = "Question 34",
                                            QuestionNumber = "34",
                                            QuestionSequence = 34,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you know what the company’s stated values are?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "C42B1BC7-2258-43FC-B4B3-0FC24C33785F",
                                            QuestionName = "Question 35",
                                            QuestionNumber = "35",
                                            QuestionSequence = 35,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you apply the company’s values in your everyday work?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "8DC1D928-F984-4B62-87F7-421B5A0D4D31",
                                            QuestionName = "Question 36",
                                            QuestionNumber = "36",
                                            QuestionSequence = 36,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you see the company\'s values applied on a daily basis?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "C6D61319-E50C-49BD-B93A-405B0172FCC8",
                                    DriverName = "Leadership Behaviours",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "8B5B2BE9-9033-4B06-9872-6208DE178AE7",
                                            QuestionName = "Question 37",
                                            QuestionNumber = "37",
                                            QuestionSequence = 37,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Does the Leadership team contribute to a positive work cuture?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "7A118B6A-820A-4BA0-BC45-689AD6CECD8B",
                                            QuestionName = "Question 38",
                                            QuestionNumber = "38",
                                            QuestionSequence = 38,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you see the leaders living the stated values of the culture in the organisation?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "F8B4FED8-D618-4628-8CAB-748F77B71AB6",
                                            QuestionName = "Question 39",
                                            QuestionNumber = "39",
                                            QuestionSequence = 39,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you believe your company has a promising future?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                },
                                new Driver
                                {
                                    Id = "ECDC14AA-D77A-424A-8EC7-D225731559E7",
                                    DriverName = "Innovation",
                                    Questions = new List<Questions>
                                    {
                                        new Questions
                                        {
                                            Id = "4147FF2E-A09D-4531-89FE-8F66804F4598",
                                            QuestionName = "Question 40",
                                            QuestionNumber = "40",
                                            QuestionSequence = 40,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Do you have the opportunity to be innovative?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "F996468F-E080-464F-B729-B5383889BE24",
                                            QuestionName = "Question 41",
                                            QuestionNumber = "41",
                                            QuestionSequence = 41,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Are you empowered to find a solution to a problem?",
                                            QuestionTypeName = "yes/no"
                                        },
                                        new Questions
                                        {
                                            Id = "4D072BC9-4740-4067-93F2-C9A1EFD241D8",
                                            QuestionName = "Question 42",
                                            QuestionNumber = "42",
                                            QuestionSequence = 42,
                                            QuestionAnswerRequired = true,
                                            QuestionText = "Does the company constantly seek ways to improve products and services?",
                                            QuestionTypeName = "yes/no"
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

            return surveyforIteration;
        }

        public Questions GetQuestion(Guid questionId)
        {
            var questions = _dbContext.Set<Questions>().SingleOrDefault(q => q.Id == questionId.ToString());

            return questions;

        }

        public void CreateQuestion(Questions question)
        {
            //question.CreatedOn = DateTime.Now;
            //question.ModifiedOn = question.CreatedOn;

            _dbContext.Add(question);
        }

        public void UpdateQuestion(Questions question)
        {
            //question.ModifiedOn = DateTime.Now;
            _dbContext.Set<Questions>().Attach(question);

            _dbContext.Entry(question).State = EntityState.Modified;
        }

        public void DeleteQuestion(Guid questionId)
        {
            var question = GetQuestion(questionId);

            if (question != null)
            {
                //question.ModifiedOn = DateTime.Now;
                //question.IsDeleted = true;
            }

            _dbContext.Remove(question ?? throw new InvalidOperationException());
        }

        public int SaveQuestion()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }        
    }
}
