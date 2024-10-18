using System;
namespace std
{
    class Person
    {
        public string name { get; set; }
        public Person() { name = null; }
        public Person(string name)
        { this.name = name; }
    }
    class Student : Person
    {
        public string regNo { get; set; }
        public int age { get; set; }    
        public string program { get; set; }
        public Student()
        {
            regNo = null;
            age = 0;
            program = null;
        }
        public Student(string regNo, int age, string program)
        {
            this.regNo = regNo;
            this.age = age;
            this.program = program;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.name = "Salman";
            student.regNo = "233547";
            student.age = 22;
            student.program = "BSCS";

            Console.WriteLine($"Name : {student.name} ");
            Console.WriteLine($"registraton number : {student.regNo} ");
            Console.WriteLine($"Age : {student.age}" );
            Console.WriteLine($"Program {student.program}: ");

        }
    }   
}