using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMeaw
{
    internal class LifePoint
    {
        private int life;

        public int GetPoint()
        {
            return life;
        }

        public void SetPoint(int value)
        {
            life = value;
        }

        public void RemoveToScore(int value)
        {
            life -= value;
        }
    }
}
