using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflowProject.DomainModels;

namespace StackOverflowProject.Repositories
{
    public interface IVotesRepository
    {
        void UpdateVote(int aid, int uid, int value);
    }
    public class VotesRepository: IVotesRepository
    {
        StackOverflowDatabaseDbContext db;
        public VotesRepository()
        {
            db = new StackOverflowDatabaseDbContext();
        }
        public void UpdateVote(int aid, int uid, int value)
        {
            int UpdateValue;
            if (value > 0) UpdateValue = 1;
            if (value < 0) UpdateValue = -1;
            else UpdateValue = 0;
            Vote vote = db.Votes.Where(temp => temp.AnswerID == aid && temp.UserID == uid).FirstOrDefault();
            if(vote != null)
            {
                vote.VoteValue = UpdateValue;
            }
            else
            {
                Vote newVote = new Vote()
                {
                    AnswerID = aid,
                    UserID = uid,
                    VoteValue = UpdateValue
                };
                db.Votes.Add(newVote);
            }
            db.SaveChanges();
        }
    }
}
