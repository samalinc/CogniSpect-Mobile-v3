using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSMobile.Domain.Models.Tests;

namespace CSMobile.Domain.Services.Tests
{
    internal class TestsService : ITestsService
    {
        public async Task<Test> GetSessionTest(Guid sessionId)
        {
            return await Task.FromResult(GetDummyTest());
        }

        public async Task EndTest(Test test)
        {
            await Task.CompletedTask;
        }

        private Test GetDummyTest()
        {
            var dummyData = new List<Question>
            {
                new Question
                {
                    Text = "Чему равен косинус алкена предельного метала сила протеводействия рвному массе ускорения алкадиенов в силе углеводородный свидени гравитоционых кенитических энергий 2х микробловых кенетики ДНК с 2 метохондревыми младшего разряда?",
                    Variants = new []
                    {
                        new QuestionAnswerVariant
                        {
                            Text = "2."
                        },
                        new QuestionAnswerVariant
                        {
                            Text = "Нет, так как нельзя посчитать количество дыр."
                        },
                        new QuestionAnswerVariant
                        {
                            Text = "Добавление пирофосфатазы может увеличить выход ПЦР-реакции."
                        },
                        new QuestionAnswerVariant
                        {
                            Text = "Трём зелёным свисткам."
                        },
                    }
                },
                new Question
                {
                    Text = "Сколько ног у паука?",
                    Variants = new []
                    {
                        new QuestionAnswerVariant
                        {
                            Text = "3."
                        },
                        new QuestionAnswerVariant
                        {
                            Text = "4."
                        },
                        new QuestionAnswerVariant
                        {
                            Text = "6."
                        },
                        new QuestionAnswerVariant
                        {
                            Text = "8."
                        },
                    }
                },
            };

            return new Test
            {
                Name = "Test test fgertert",
                Questions = dummyData
            };
        }
    }
}