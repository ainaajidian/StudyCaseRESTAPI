using EnrollmentService.Models;
using System;
using System.Linq;

namespace EnrollmentService.Data
    {
        public class DbInitializer
        {
            public static void Initialize(ApplicationDbContext context)
            {
                context.Database.EnsureCreated();

                if (context.Students.Any())
                {
                    return;
                }

                var students = new Student[]
                {
                new Student{FirstName="Peter", LastName="Parker", EnrollmentDate=DateTime.Now},
                new Student{FirstName="Tony", LastName="Stark", EnrollmentDate=DateTime.Now},
                new Student{FirstName="Steve", LastName="Roger", EnrollmentDate=DateTime.Now},
                new Student{FirstName="Natasha", LastName="Romanoff", EnrollmentDate=DateTime.Now},
                new Student{FirstName="Bruce", LastName="Banner", EnrollmentDate=DateTime.Now}
                };

                foreach (var s in students)
                {
                    context.Students.Add(s);
                }

                context.SaveChanges();

                var courses = new Course[]
                {
                new Course{CourseName="Cloud Fundamentals", CourseCredits=3 },
                new Course{CourseName="Microservices Architecture", CourseCredits=3 },
                new Course{CourseName="Frontend Programming", CourseCredits=3 },
                new Course{CourseName="Backend RESTful API", CourseCredits=3 },
                new Course{CourseName="Entity Frmework Core", CourseCredits=3 }
                };

                foreach (var c in courses)
                {
                    context.Courses.Add(c);
                }

                context.SaveChanges();

                var enrollments = new Enrollment[]
                {
                new Enrollment{StudentID=1, CourseID=1, Grade=Grade.A, Invoice = 300 },
                new Enrollment{StudentID=1, CourseID=2, Grade=Grade.B, Invoice = 500 },
                new Enrollment{StudentID=1, CourseID=3, Grade=Grade.C, Invoice = 200 },
                new Enrollment{StudentID=2, CourseID=1, Grade=Grade.C, Invoice = 350 },
                new Enrollment{StudentID=2, CourseID=2, Grade=Grade.C, Invoice = 700 },
                new Enrollment{StudentID=2, CourseID=3, Grade=Grade.C, Invoice = 800 },
                new Enrollment{StudentID=3, CourseID=1, Grade=Grade.A, Invoice = 100 },
                new Enrollment{StudentID=3, CourseID=2, Grade=Grade.B, Invoice = 200 },
                new Enrollment{StudentID=3, CourseID=3, Grade=Grade.C, Invoice = 300 }
                };

                foreach (var e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
        }
    }