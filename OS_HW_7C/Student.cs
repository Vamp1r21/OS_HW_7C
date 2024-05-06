using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_HW_7C
{
    class Student
    {
        string _name;
        int[] _rating;

        public Student(string name, int[] rating)
        {
            _name = name;
            _rating = rating;
        }

        public string GetName()
        {
            return _name;
        }
        public string GetStatus()
        {
            int fives = GetCountStatistic(5);
            int fours = GetCountStatistic(4);
            int threes = GetCountStatistic(3);
            return DefinitionStatus(fives, fours, threes);
        }

        string DefinitionStatus(int fives, int fours, int threes)
        {
            if (threes == 0 && fives > fours)
            {
                return "Отличник";
            }
            else if (fours + fives > threes)
            {
                return "Хорошист";
            }
            else if (fives == 0 && threes > fours)
            {
                return "Троечник";
            }
            return "not information";
        }
        int GetCountStatistic(int numb)
        {
            int sumRating = 0;
            foreach(int number in _rating)
            {
                if(number == numb)
                {
                    sumRating++;
                }
            }
            return sumRating;
        }

    }
}
