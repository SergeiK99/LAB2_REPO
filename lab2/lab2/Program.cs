using System;

namespace lab2
{
    public class Person
    {
        private string name;
        private string lastname;
        private DateTime BD;

        public Person (string name, string lastname, DateTime BD )
        {
            this.name = name;
            this.lastname = lastname;
            this.BD = BD;
        }

        public Person()
        {
            name = "Andrey";
            lastname = "Ivanov";
            BD = new DateTime(2003, 2, 22);
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public DateTime Bdate
        {
            get { return BD; }
            set { BD = value; }
        }
        
        public int iBdate
        {
            get { return Convert.ToInt32(BD); }
            set { BD = Convert.ToDateTime(value); }
        }

        public string ToFullString ()
        {
            return string.Format(name," ", lastname," ", BD);
        }
        
        public string ToShortString ()
        {
            return name + " " + lastname; 
        }
    }
    enum  Education { Specialist, Вachelor, SecondEducation }

    public class Exam
    {
        public string name { get; set; }
        public int estimation { get; set; }
        public DateTime DTExam { get; set; }

        public Exam (string name, int estimation, DateTime DTExam)
        {
            this.name = name;
            this.estimation = estimation;
            this.DTExam = DTExam;
        }

        public Exam ()
        {
            name = name;
            estimation = estimation;
            DTExam = DTExam;
        }

        public string ToFullString()
        {
            return string.Format(name, " ", estimation, " ", DTExam);
        }
    }
    class Student : Person
    {
        private Person student;
        private Education education;
        private int NG;
        private Exam[] exams;
        public Student(Person person, Education education, int NG)
        {
            person = new Person();
            this.education = education;
            this.NG = NG;
            exams = new Exam[0];

        }
        public Student()
        {
            student = new Person();
            education = Education.Вachelor;
            NG = 1;
            exams = new Exam[0];
        }
        public Exam[] Exams
        {
            get { return exams; }
            set { exams = value; }
        }
        public Person Person
        {
            get { return student; }
            set { student = value; }
        }
        public Education Education
        {
            get { return education; }
            set { education = value; }
        }
        public int NumG
        {
            get { return NG; }
            set { NG = value; }
        }
        public double SB
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < exams.Length; i++)
                {
                    sum = sum + exams[i].estimation;

                }
                if (exams.Length != 0)
                {
                    return sum / exams.Length;
                }
                else 
                    return 0;
            }
        }
        public void AddExams(params Exam[] examAdd)
        {
            int Length = exams.Length;
            Array.Resize<Exam>(ref exams, Length + examAdd.Length);
            examAdd.CopyTo(exams, Length);
        }
        new public string ToFullString()
        {
            string res = education.ToString() + " " + NG.ToString() + " " + exams.ToString();
            return res;
        }
        new public string ToShortString()
        {
            string res = education.ToString() + " " + NG.ToString() + " " + SB.ToString();
            return res;
        }

    }
     class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Console.WriteLine(student.ToShortString());
            Console.WriteLine();
            student.AddExams(new Exam());
            student.NumG = 120;
            student.Lastname = "Kolesnikov";
            student.Name = "Sergey";
            Console.WriteLine(student.ToFullString());
        }
    }
}
