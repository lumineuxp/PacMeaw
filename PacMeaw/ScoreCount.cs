using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMeaw
{
    public class ScoreCount
    {
        private int score;

        public int GetScore()
        {
            return score;
        }

        public void SetScore(int value)
        {
            score = value;
        }

        public void AddToScore(int value)
        {
            score += value;
        }
    }

}
