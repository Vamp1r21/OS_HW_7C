using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OS_HW_7C
{
    class Students
    {
        string[] _names = { "Иванов" ,"Петров","Сидоров","Васечкин"};
        List<Student> _students = new List<Student>();

        List<Student> _studentsExcellent = new List<Student>();//отличники
        List<Student> _studentsGood = new List<Student>();//хорошисты
        List<Student> _studentsC = new List<Student>();//троечники

        int countStudent = 10;
        Semaphore _emptyAccess;
        Semaphore _fullAccess;

        public Students()
        {
            _emptyAccess = new Semaphore(0, countStudent);
            _fullAccess = new Semaphore(countStudent, countStudent);
        }
        public void GenerateStudent()
        {

            Random rand = new Random();

            _fullAccess.WaitOne();
            lock (this)
            {
                for (int i = 0; i < countStudent; i++)
                {
                    int numberOfRatings = rand.Next(5, 10);
                    int numberName = rand.Next(0, 3);

                    int[] ratings = new int[numberOfRatings];
                    for (int j = 0; j < numberOfRatings; j++)
                    {
                        ratings[j] = rand.Next(3, 6);
                    }
                    _students.Add(new Student(_names[numberName], ratings));
                }
            }
            _emptyAccess.Release();

        }

        public void RatingDistribution()
        {
            _fullAccess.WaitOne();
            lock (this)
            {
                foreach (Student student in _students)
                {
                    Status(student);
                }
            }
            _emptyAccess.Release();
        }

        void Status(Student student)
        {
            if (student.GetStatus() == "Отличник")
            {
                _studentsExcellent.Add(student);
            }
            else
            if (student.GetStatus() == "Хорошист")
            {
                _studentsGood.Add(student);
            }
            else
            if(student.GetStatus() == "Троечник")
            {
                _studentsC.Add(student);
            }
        }

        public void PrintStudents()
        {
            _emptyAccess.WaitOne();
            lock (this)
            {
                PrintStudentsFromStatus("Отличники:", _studentsExcellent);
                PrintStudentsFromStatus("Хорошисты:", _studentsGood);
                PrintStudentsFromStatus("Троечники:", _studentsC);
            }
            _fullAccess.Release();
        }

        void PrintStudentsFromStatus(string status, List<Student> students)
        {
            Console.WriteLine(status);
            foreach(Student student in students)
            {
                Console.WriteLine($"-{student.GetName()}");
            }
        }

    }
}
