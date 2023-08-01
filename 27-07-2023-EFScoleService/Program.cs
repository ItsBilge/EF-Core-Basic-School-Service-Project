using _27_07_2023_EFScoleService.Model;
using _27_07_2023_EFScoleService.Service;

namespace _27_07_2023_EFScoleService
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var service = new SchoolService();
            bool chose = true;

            while (chose)
            {
                Console.WriteLine("1- Öğrenci ekleme \n2- Kurs ekleme \n3- Öğrenciyi kursa ekleme \n4- Öğrenci bilgilerini güncelleme \n5- Kurs silme \n6- Seçilen öğrencinin aldığı kursu getir \n7- Seçilen kursa kayıtlı öğrencileri getir \n8- Çıkış için 9'a basınız");
                var newChose = int.Parse(Console.ReadLine());
                switch (newChose)
                {
                    case 1:
                        service.addStudent();
                        break;
                    case 2:
                        service.addCourse();
                        break;
                    case 3:
                        service.entrollStudentCourse();
                        break;
                    case 4:
                        service.updateStudent();
                        break; 
                    case 5:
                        service.deleteCourse();
                        break;
                    case 6:
                        service.GetStudentById();
                        break;
                    case 7:
                        service.GetCourseById();
                        break;
                    default:
                        if(newChose == 9)
                        {
                            Console.WriteLine("Uygulamadan çıkıldı.");
                            chose = false;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz giriş yaptınız.");
                        }
                        break;
                }

            }





            //service.addStudent();
            //service.addCourse();
            //service.entrollStudentCourse();

            //service.updateStudent();
            //service.deleteCourse();


        }
    }
}