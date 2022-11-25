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
            name = "Андрей";
            lastname = "Иванов";
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
        
        public int year
        {
            get { return Bdate.Year; }
            set { year = value; }
        }

        public  string ToFullString ()
        {
            return $"Имя: {name}, фамилия: {lastname}, дата рождения: {BD}";
        }
        
        public  string ToShortString ()
        {
            return $"Имя: {name}, фамилия: {lastname}";
        }
    }
    enum  Education { Specialist, Вachelor, SecondEducation }

     class Exam
    {
        public string nameD;
        public int estimation;
        public DateTime DTExam;

        public Exam (string nameD, int estimation, DateTime DTExam)
        {
            this.nameD = nameD;
            this.estimation = estimation;
            this.DTExam = DTExam;
        }

        public Exam () : this ("Default", 5 , new DateTime(2000,2,2))
        {
        }

        public  string ToFullString()
        {
            return $"Наименование: {nameD}, оценка: {estimation}, дата экзамена: {DTExam}"; ;
        }
    }
    class Student 
    {
        public Person st;
        public Education education;
        public int NG;
        public Exam[] exams;
        public Student(Person st, Education education, int NG)
        {
            this.st = st;
            this.education = education;
            this.NG = NG;
            exams = new Exam[0];

        }
        public Student()
        {
            st = new Person();
            education = Education.Вachelor;
            NG = 1;
            exams = new Exam[0];
        }
        
        public Person ST
        {
            get { return st; }
            set { st = value; }
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
          public string ToFullString()
        {
            string examens = "";
            foreach (var item in exams)
                examens += $"{item.nameD} {item.estimation}\n";
            return $"студент: {st.Name} {st.Lastname} {st.Bdate}, форма обучения:{education}, группа {NG}, результаты экзаменов:\n{examens}";
        }
         public string ToShortString()
        {
            return $"студент: {st.Name} {st.Lastname} {st.Bdate},  форма обучения:{education}, группа {NG}, средний балл {SB}"; ;
        }

    }
     class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Sergey";
            person.Lastname = "Kolesnikov";
            person.Bdate = new DateTime (2005, 5, 5);
            Exam[] examen = new Exam[3];
            examen[0] = new Exam("Математика", 5, new DateTime(2019, 2, 3));
            examen[1] = new Exam("Физика", 3, new DateTime(2020, 4, 8));
            examen[2] = new Exam("Информатика", 4, new DateTime(2021, 9, 5));
            Student stud = new Student(person, Education.Вachelor, 11);
            stud.AddExams(examen);
            Console.WriteLine(stud.ToShortString());
            Console.WriteLine(stud.ToFullString());

        }
    }
}
