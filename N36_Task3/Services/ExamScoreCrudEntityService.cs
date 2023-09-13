using N36_Task3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_Task3.Services
{
    public class ExamScoreCrudEntityService
    {
        private List<ExamScore> _examScores;
        public ExamScoreCrudEntityService()
        {
            _examScores = new List<ExamScore>();
        }
        public void AddExamscore(ExamScore examScore)
        {
            _examScores.Add(examScore);
        }

        public void UpdateUser(int userId, double newscore)
        {
            var updatedUser = _examScores.FirstOrDefault(user => user.Id == userId);
            if (updatedUser != null)
            {
                _examScores.Remove(updatedUser);
                updatedUser.Score = newscore;
            }
            else
                return;
            _examScores.Add(updatedUser);
        }

        public void DeleteExamScore(int id)
        {
            var removedExamScore = _examScores.FirstOrDefault(user => user.Id == id);
            _examScores.Remove(removedExamScore);
        }
        public double GetUSerScore(int userId)
        {
            var score = _examScores.FirstOrDefault(e => e.UserId == userId).Score;
            return score;
        }
    }
}
