using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_Task3.Services
{
    public class ExamAnalyticsService
    { 
            private UserCrudEntityService _userService;
            private ExamScoreCrudEntityService _scoreService;

            public ExamAnalyticsService(UserCrudEntityService userService, ExamScoreCrudEntityService scoreService)
            {
                _userService = userService;
                _scoreService = scoreService;
            }

            public IEnumerable<(string FullName, double Score)> GetScore()
            {
                return _userService.GetAllUsers.Select(user =>
                {
                    var fullName = $"{user.FirstName} {user.LastName}";
                    var score = _scoreService.GetUSerScore(user.Id);
                    return (fullName, score);
                });
            }
        }
}
