using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity_Framework_DI
{
    class StudentContext : DbContext
    {
        public StudentContext()
            : base("DbConnection")
        { }

        public DbSet<Student> Students { get; set; }
    }
    public class Student
    {
        private int age;
        private string fio;
        private string group;
        public int Id { get; set; }
        public string Fio
        {
            set
            {
                if (!(value.Trim()==""))
                {
                    fio = value;
                }
            }

            get
            {
                return fio;
            }
        }
        public int Age
        {
            set
            {
                if (value<0)
                {
                    Console.WriteLine("Возраст не может быть отрицательным");
                }
                else
                {
                    age = value;
                }
            }
            get { return age; }
        }
        public string Group
        {
            set
            {
                if (!(value.Trim() == ""))
                {
                    group = value;
                }
            }

            get
            {
                return group;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (StudentContext db = new StudentContext())
            {

                Student st1 = new Student { Fio = "Сергеев Сергей Сергеевич", Age = 18, Group = "19-11-2" };
                Student st2 = new Student { Fio = "Иванов Иван Иванович", Age = 19, Group = "19-11-1" };
                Student st3 = new Student { Fio = "Олегов Олег Олегович", Age = 20, Group = "18-11-1" };
                Student st4 = new Student { Fio = "Ананина Анна Анатольевна", Age = 18, Group = "19-11-3" };
                Student st5 = new Student { Fio = "Щербаков Артём Никитич", Age = 19, Group = "19-11-3" };
                Student st6 = new Student { Fio = "Дмитриева Мария Александровна", Age = 20, Group = "18-11-1" };
                Student st7 = new Student { Fio = "Романов Григорий Саввич", Age = 20, Group = "19-11-1" };
                Student st8 = new Student { Fio = "Лапшин Артём Александрович", Age = 18, Group = "19-11-2" };
                Student st9 = new Student { Fio = "Бородина Валерия Ильинична", Age = 19, Group = "19-11-1" };
                Student st10 = new Student { Fio = "Кузнецова Алиса Алексеевна", Age = 18, Group = "19-11-1" };

                // добавляем их в бд
                db.Students.Add(st1);
                db.Students.Add(st2);
                db.Students.Add(st3);
                db.Students.Add(st4);
                db.Students.Add(st5);
                db.Students.Add(st6);
                db.Students.Add(st7);
                db.Students.Add(st8);
                db.Students.Add(st9);
                db.Students.Add(st10);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var Students = db.Students;
                Console.WriteLine("Список объектов:");
                foreach (Student u in Students)
                {
                    Console.WriteLine("{0}, {1} лет, {2} группа", u.Fio, u.Age, u.Group);
                }
                Console.ReadKey();
            }

        }

        }
    }
