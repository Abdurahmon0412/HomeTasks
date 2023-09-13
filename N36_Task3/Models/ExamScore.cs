namespace N36_Task3.Models
{
    public class ExamScore 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Score { get; set; }
        public ExamScore(int id,int userId,double score = 0)
        {
            Id = id;
            UserId = userId;
            Score = score;
        }

    }
}
