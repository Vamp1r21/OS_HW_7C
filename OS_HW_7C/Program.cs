using System;
using System.Threading;

namespace OS_HW_7C
{
    class Program
    {
        static void Main(string[] args)
        {
            Students students = new Students();
            Action createStudents = () => { students.GenerateStudent(); };
            Action distributionStudents = () => { students.RatingDistribution(); };
            Action printStudents = () => { students.PrintStudents(); };

            using (Activity ascender = new Activity(createStudents))
                using (Activity descender = new Activity(distributionStudents))
                    using (Activity printer = new Activity(printStudents))
            {
                Console.ReadLine();
            }
        }
    }
}
