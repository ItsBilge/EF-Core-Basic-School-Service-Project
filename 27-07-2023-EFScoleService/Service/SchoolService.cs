using _27_07_2023_EFScoleService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_07_2023_EFScoleService.Service
{
    public class SchoolService
    {
        private readonly SchoolServiceContext _context;
        public SchoolService()
        {
            _context = new SchoolServiceContext();
        }

        public void addStudent()
        {
            try
            {
                Console.Write("Öğrenci ismi : ");
                var name = Console.ReadLine();
                Console.Write("Doğum tarihi: ");
                var birthDate = DateTime.Parse(Console.ReadLine());

                Student student = new Student()
                {
                    Name = name,
                    BirthDate = birthDate
                };
                _context.Students.Add(student);
                _context.SaveChanges();

                Console.WriteLine("Eklenen öğrenci bilgileri:");
                Console.WriteLine($"Adı: {student.Name} - doğum tarihi {student.BirthDate}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void addCourse()
        {
            try
            {
                Console.Write("Kurs adı: ");
                var courseName = Console.ReadLine();

                Course course = new Course()
                {
                    Title = courseName
                };

                _context.Courses.Add(course);
                _context.SaveChanges();
                Console.WriteLine($"{course.Title} kursu eklenmiştir.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

          
        }

        public void entrollStudentCourse()//Öğrenciyi kursa ekleme
        {
            try
            {
                var students = _context.Students.ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($" ID: {student.Id} Öğrenci adı: {student.Name}");
                }

                Console.Write("Lütfen listede yazan ID'nizi yazınız: ");
                var studentId = int.Parse(Console.ReadLine());

                var courses = _context.Courses.ToList();

                foreach (var course in courses)
                {
                    Console.WriteLine($"ID: {course.Id} Course adı: {course.Title}");
                };

                Console.Write("Lütfen listeden kurs ID'sini yazınız: ");
                var courseID = int.Parse(Console.ReadLine());


                var studentCourse = new StudentCourse()
                {
                    StudentId = studentId,
                    CourseId = courseID
                };
                if (studentCourse != null)
                {
                    var studentToFind = GetStudentById(studentId);
                    var coursesForStudent = _context.StudentCourses.Where(sc => sc.StudentId == studentToFind.Id)
                                                                   .Select(sc => sc.Course);

                    _context.StudentCourses.Add(studentCourse);
                    _context.SaveChanges();

                    Console.WriteLine("Öğrencinin aldığı kurslar: ");
                    foreach (var course in coursesForStudent)
                    {
                        Console.WriteLine(course.Title);
                    }

                }
                else
                {
                    Console.WriteLine("Geçerli bir ID giriniz.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
        }

        public void updateStudent()
        {
            try
            {

                var updateStudent = _context.Students.ToList();
                foreach (var student in updateStudent)
                {
                    Console.WriteLine($"Öğrenci ID: {student.Id} Adı: {student.Name}");
                }

                Console.Write($"Güncelleme yapma istediğiniz öğrenci ID'sini yazınız: ");
                var studentID = int.Parse(Console.ReadLine());

                if (studentID != null && studentID != 0)
                {
                    Student NewStudent = _context.Students.FirstOrDefault(ns => ns.Id == studentID);

                    Console.Write("Yeni isim yazınız: ");
                    var newStudent = Console.ReadLine();
                    NewStudent.Name = newStudent;

                    Console.Write("Doğum tarihi: ");
                    var newBirthDate = DateTime.Parse(Console.ReadLine());
                    NewStudent.BirthDate = newBirthDate;

                    Student student = new Student()
                    {
                        Name = newStudent,
                        BirthDate = newBirthDate
                    };

                    Console.WriteLine("Güncellenen öğrenci bilgileri:");
                    Console.WriteLine($"Öğrenci adı: {student.Name} doğum tarihi: {student.BirthDate}");
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("ID boş geçilemez, lütfen tekrar deneyiniz.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


            
        }

        public void deleteCourse()
        {
            try
            {
                var courses = _context.Courses.ToList();
                foreach (var course in courses)
                {
                    Console.WriteLine($"Kurs ID: {course.Id} Adı: {course.Title}");
                }

                Console.Write("Silmek istdiğiniz kursun ID sini giriniz: ");
                var deleteCourseId = int.Parse(Console.ReadLine());
                var deleteCourse = _context.Courses.Find(deleteCourseId);

                if (deleteCourse != null && deleteCourseId != 0)
                {
                    _context.Courses.Remove(deleteCourse);
                    _context.SaveChanges();
                    Console.WriteLine($"{deleteCourse.Title} kursu silinmiştir");
                }
                else
                {
                    Console.WriteLine("ID alanı boş geçilemez.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            
        }

        public void GetCourseById()
        {
            try
            {
                var courses = _context.Courses.ToList();
                foreach (var course in courses)
                {
                    Console.WriteLine($" ID: {course.Id} Kurs adı: {course.Title}");
                }
                Console.Write("Seçtiğiniz kursun ID'sini giriniz: ");
                var courseID = int.Parse(Console.ReadLine());

                var coursesForStudent = _context.StudentCourses.Where(q => q.CourseId == courseID).Select(q => q.Student);

                if (courseID != null  && courseID != 0)
                {
                    Console.WriteLine($"Seçilen kursa kayıtlı öğrenciler:");
                    foreach (var student in coursesForStudent)
                    {
                        Console.WriteLine(student.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Geçerli bir değer giriniz");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public void GetStudentById()
        {
            try
            {
                var students = _context.Students.ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($" ID: {student.Id} Öğrenci adı: {student.Name}");
                }
                Console.Write("Seçtiğiniz öğrencinin ID'sini giriniz: ");
                var studentId = int.Parse(Console.ReadLine());

                var studentsInCourse = _context.StudentCourses.Where(q => q.StudentId == studentId).Select(q => q.Course);

                if (studentId != null && studentId !=0)
                {
                    Console.WriteLine($"Seçilen öğrencinin aldığı kurslar:");
                    foreach (var course in studentsInCourse)
                    {
                        Console.WriteLine(course.Title);
                    }
                }
                else
                {
                    Console.WriteLine("Geçerli bir değer giriniz");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


           
            
        }

        public Student GetStudentById(int studentId)
        {
            return _context.Students.Find(studentId);
        }
        public Course GetCourseById(int courseId)
        {
            return _context.Courses.Find(courseId);
        }
    }
}
