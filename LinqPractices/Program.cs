using System;
using System.Linq;
using LinqPractices.DbOperations;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();
            var students = _context.Students.ToList<Student>();

            //Find() => arama yapmayı sağlıyor. mevcut id üzerinden
            Console.WriteLine("****Find****");
            var student = _context.Students.Where(student => student.StudentId == 1).FirstOrDefault(); //linqsuz. first or default hariç.
            student = _context.Students.Find(1);
            Console.WriteLine(student.Name);
            //FirstOrDefault()
            Console.WriteLine();
            Console.WriteLine("****First or Default****");
            student = _context.Students.Where(student => student.Surname == "Arda").FirstOrDefault();
            Console.WriteLine(student.Name);
            student = _context.Students.FirstOrDefault(x => x.Surname == "Arda");
            Console.WriteLine(student.Name);
            //SingleOrDefault()
            Console.WriteLine();
            Console.WriteLine("****SingleOrDefault****");
            student = _context.Students.SingleOrDefault(student => student.Name == "Deniz");
            //student=_context.Students.SingleOrDefault(student=>student.Surname=="Arda"); ==>Single or defaultta 0 veya tek veri gönderilmesi lazım. O yüzden bu kod satırı hata verecektir.
            Console.WriteLine(student.Surname);
            //ToList()
            Console.WriteLine();
            Console.WriteLine("****ToList****");
            var studentList = _context.Students.Where(student => student.ClassId == 2).ToList();
            Console.WriteLine(studentList.Count);
            //OrderBy()
            Console.WriteLine();
            Console.WriteLine("****ToList****");
            students = _context.Students.OrderBy(x => x.StudentId).ToList();
            foreach (var stud in students)
            {
                Console.WriteLine(stud.StudentId + "-" + stud.Name + " " + stud.Surname);
            }

            //OrderByDescending
            Console.WriteLine();
            Console.WriteLine("****ToList****");
            students = _context.Students.OrderByDescending(x => x.StudentId).ToList();
            foreach (var stud in students)
            {
                Console.WriteLine(stud.StudentId + "-" + stud.Name + " " + stud.Surname);
            }
            //Anonymous Object Result
            Console.WriteLine();
            Console.WriteLine("****AnonymousObjectResult****");

            var anonymousObject = _context.Students
                                .Where(x => x.ClassId == 2)
                                .Select(x => new
                                {
                                    Id = x.StudentId,
                                    FullName = x.Name + " " + x.Surname
                                });
            foreach (var obj in anonymousObject)
            {
                System.Console.WriteLine(obj.Id + "-" + obj.FullName);
            }
        }
    }
}
