using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab_06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
            // Tablica 20 użytkowników
            new User { Name = "Adrian", Role = "ADMIN", Age = 40, Marks = null, CreatedAt = new DateTime(2021, 9, 25), RemovedAt = null },
            new User { Name = "Beata", Role = "MODERATOR", Age = 23, Marks = null, CreatedAt = new DateTime(2021, 9, 26), RemovedAt = null },
            new User { Name = "Krzysztof", Role = "MODERATOR", Age = 26, Marks = null, CreatedAt = new DateTime(2021, 9, 26), RemovedAt = null },
            new User { Name = "Filip", Role = "TEACHER", Age = 36, Marks = null, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Bartłomiej", Role = "TEACHER", Age = 45, Marks = null, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Agnieszka", Role = "TEACHER", Age = 39, Marks = null, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Zbigniew", Role = "TEACHER", Age = 50, Marks = null, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Filip", Role = "STUDENT", Age = 17, Marks = new int[] { 1, 1, 1, 5, 3 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Bartłomiej", Role = "STUDENT", Age = 18, Marks = new int[] { 1, 5, 5, 5, 2 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Sebastian", Role = "STUDENT", Age = 18, Marks = new int[] { 2, 4, 5, 5, 3 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Kamil", Role = "STUDENT", Age = 17, Marks = new int[] { 1, 3, 4, 3, 3 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Andrzej", Role = "STUDENT", Age = 19, Marks = new int[] { 3, 2, 1, 5, 3 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Zbyszek", Role = "STUDENT", Age = 18, Marks = new int[] { 1, 1, 1, 5, 3 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Oliwia", Role = "STUDENT", Age = 17, Marks = new int[] { 2, 2, 1, 5, 3 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Michał", Role = "STUDENT", Age = 18, Marks = new int[] { 2, 1, 1, 5, 3 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Ania", Role = "STUDENT", Age = 17, Marks = new int[] { 2, 1, 3, 5, 6 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Martyna", Role = "STUDENT", Age = 18, Marks = new int[] { 3, 3, 1, 5, 3 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Zuzia", Role = "STUDENT", Age = 19, Marks = new int[] { 5, 3 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Oskar", Role = "STUDENT", Age = 19, Marks = new int[] { 3, 3, 3 }, CreatedAt = new DateTime(2021, 10, 1), RemovedAt = null },
            new User { Name = "Kacper", Role = "STUDENT", Age = 18, Marks = new int[] { 2, 1, 2, 2 }, CreatedAt = new DateTime(2021, 10, 24), RemovedAt = null },

            };

            // --- 1 ---    
            Console.WriteLine("--------------------");
            Console.WriteLine(users.Count());
            Console.WriteLine((from user in users
                               select user).Count());

            // --- 2 ---
            Console.WriteLine("--------------------");
            List<string> names_01 = users.Select(user => user.Name).ToList();
            List<string> names_02 = (from user in users
                                      select user.Name).ToList();

            foreach (string name in names_01)
                Console.WriteLine(name);
            foreach (string name in names_02)
                Console.WriteLine(name);

            // --- 3 ---
            Console.WriteLine("--------------------");
            List<User> users_01 = users.OrderBy(user => user.Name).ToList();
            List<User> users_02 = (from user in users
                                   orderby user.Name
                                   select user).ToList();

            foreach (User user in users_01)
                Console.WriteLine(user.Name);
            foreach (User user in users_02)
                Console.WriteLine(user.Name);

            // --- 4 ---
            Console.WriteLine("--------------------");
            var roles_01 = users.GroupBy(user => user.Role).Select(role => role.First()).ToList();
            var roles_02 = (from user in users                
                                   select user.Role).First();
            foreach (User user in roles_01)
                Console.WriteLine(user.Role);
            //foreach (User user in roles_02)
            //    Console.WriteLine(user);          !!!

            // --- 5 --- 
            Console.WriteLine("--------------------");
            var roles_group_01 = users.GroupBy(user => user.Role);
            var roles_group_02 = (from user in users
                                  group user by user.Role);
            foreach (var grupa in roles_group_01)
            {
                Console.WriteLine(grupa.Key);
                foreach (var user in grupa)
                    Console.WriteLine(user.Name);
            }
            foreach (var grupa in roles_group_02)
            {
                Console.WriteLine(grupa.Key);
                foreach (var user in grupa)
                    Console.WriteLine(user.Name);
            }

            // --- 6 ---
            Console.WriteLine("--------------------");
            var marks_count_01 = users.Where(user => user.Marks != null && user.Marks.Length > 0).Select(user => user).Count();
            var marks_count_02 = (from user in users
                                  where user.Marks != null && user.Marks.Length > 0
                                  select user).Count();

            Console.WriteLine(marks_count_01);
            Console.WriteLine(marks_count_02);

            // --- 7 ---
            Console.WriteLine("--------------------");
            var sum_01= users.Where(user => user.Marks != null).Select(user => user.Marks.Sum()).Sum();
            var count_01 = users.Where(user => user.Marks != null).Select(user => user.Marks.Count()).Sum();
            var avr_01 = users.Where(user => user.Marks != null).Select(user => user.Marks.Average()).Average();
            var sum_02 = (from user in users
                          where user.Marks != null
                          select user.Marks.Sum()).Sum();
            var count_02 = (from user in users
                          where user.Marks != null
                          select user.Marks.Count()).Sum();
            var avr_02 = (from user in users
                          where user.Marks != null
                          select user.Marks.Average()).Average();

            Console.WriteLine($"Suma wysztkich ocen: {sum_01}\n" +
                              $"Ilość wszystkich ocen: {count_01}\n" +
                              $"Średnia wszystkich ocen: {Math.Round(avr_01, 2)}");
            Console.WriteLine($"Suma wysztkich ocen: {sum_02}\n" +
                              $"Ilość wszystkich ocen: {count_02}\n" +
                              $"Średnia wszystkich ocen: {Math.Round(avr_02, 2)}");

            // --- 8 ---
            Console.WriteLine("--------------------");
            var max_grade_01 = users.Where(user => user.Marks != null && user.Marks.Length > 0).
                OrderByDescending(user => user.Marks.Max()).Select(user => user.Marks.Max());
            var max_grade_02 = from user in users
                               where user.Marks != null
                               orderby user.Marks.Max() descending
                               select user.Marks.Max();

            foreach (var grade in max_grade_01.Take(1))
            {
                Console.WriteLine(grade);
            }
            foreach (var grade in max_grade_02.Take(1))
            {
                Console.WriteLine(grade);
            }

            // --- 9 ---
            Console.WriteLine("--------------------");
            var min_grade_01 = users.Where(user => user.Marks != null).
                OrderBy(user => user.Marks.Min()).Select(user => user.Marks.Min());
            var min_grade_02 = from user in users
                               where user.Marks != null
                               orderby user.Marks.Min() ascending
                               select user.Marks.Min();
            foreach (var grade in min_grade_01.Take(1))
            {
                Console.WriteLine(grade);
            }
            foreach (var grade in min_grade_02.Take(1))
            {
                Console.WriteLine(grade);
            }

            // --- 10 ---
            Console.WriteLine("--------------------");
            var best_student_01 = users.Where(user => user.Marks != null).
                OrderByDescending(user => user.Marks.Average()).Select(user => user.Name + " " + user.Marks.Average());
            var best_student_02 = from user in users
                                  where user.Marks != null
                                  orderby user.Marks.Average() descending
                                  select user.Name + " " + user.Marks.Average();

            foreach (var student in best_student_01.Take(1))
            {
                Console.WriteLine(student);
            }
            foreach (var student in best_student_02.Take(1))
            {
                Console.WriteLine(student);
            }

            // --- 11 ---
            Console.WriteLine("--------------------");
            var lower_grades_01 = users.Where(user => user.Marks != null).
                OrderBy(user => user.Marks.Length).Select(user => user);
            var lower_grades_02 = (from user in users
                              where user.Marks != null
                              orderby user.Marks.Length ascending
                              select user);

            foreach (var user in lower_grades_01.Take(5))
            {
                Console.WriteLine(user.Name);
            }
            foreach (var user in lower_grades_02.Take(5))
            {
                Console.WriteLine(user.Name);
            }

            // --- 12 ---
            Console.WriteLine("--------------------");
            var higher_grades_01 = users.Where(user => user.Marks != null).
                OrderBy(user => -user.Marks.Length).Select(user => user);
            var higher_grades_02 = (from user in users
                                   where user.Marks != null
                                   orderby user.Marks.Length descending
                                   select user);

            foreach (var user in higher_grades_01.Take(5))
            {
                Console.WriteLine(user.Name);
            }
            foreach (var user in higher_grades_02.Take(5))
            {
                Console.WriteLine(user.Name);
            }

            // --- 13 ---
            Console.WriteLine("--------------------");
            var name_mark_01 = users.Where(user => user.Marks != null).
                OrderByDescending(user => user.Marks.Average()).Select(user => user.Name + " " + user.Marks.Average());
            var name_mark_02 = from user in users
                                  where user.Marks != null
                                  orderby user.Marks.Average() descending
                                  select user.Name + " " + user.Marks.Average();
            foreach (var student in name_mark_01)
            {
                Console.WriteLine(student);
            }
            foreach (var student in name_mark_02)
            {
                Console.WriteLine(student);
            }

            // --- 14 ---
            Console.WriteLine("--------------------");
            var best_sort_01 = users.Where(user => user.Marks != null).
                OrderByDescending(user => user.Marks.Average()).Select(user => user.Name);
            var best_sort_02 = from user in users
                               where user.Marks != null
                               orderby user.Marks.Average() descending
                               select user.Name;
            foreach (var user in best_sort_01)
            {
                Console.WriteLine(user);
            }
            foreach (var user in best_sort_02)
            {
                Console.WriteLine(user);
            }

            // --- 15 ---
            Console.WriteLine("--------------------");
            var avr_all_01 = users.Where(user => user.Marks != null).Select(user => user.Marks.Average()).Average();
            var avr_all_02 = (from user in users
                             where user.Marks != null
                             select user.Marks.Average()).Average();

            Console.WriteLine("Średnia ocena wszystkich studentów: " + Math.Round(avr_all_01, 2));
            Console.WriteLine("Średnia ocena wszystkich studentów: " + Math.Round(avr_all_02, 2));

            // --- 16 ---
            Console.WriteLine("--------------------");
            var add_sort_01 = users.Where(user => user.CreatedAt != null).OrderByDescending(user => user.CreatedAt).Select(user => user.Name + " " + user.CreatedAt);
            var add_sort_02 = from user in users
                              where user.CreatedAt != null
                              orderby user.CreatedAt descending
                              select user.Name + " " + user.CreatedAt;
            foreach (var user in add_sort_01)
                Console.WriteLine(user);
            foreach (var user in add_sort_02)
                Console.WriteLine(user);

            // --- 17 ---
            Console.WriteLine("--------------------");
            var not_removed_01 = users.Where(user => user.RemovedAt == null).Select(user => user);
            var not_removed_02 = from user in users
                                 where user.RemovedAt == null
                                 select user;

            foreach (var user in not_removed_01)
                Console.WriteLine(user.Name);
            foreach (var user in not_removed_02)
                Console.WriteLine(user.Name);

            // --- 18 ---
            var newest_student_01 = users.Where(user => user.CreatedAt != null).OrderByDescending(user => user.CreatedAt).Select(user => user.Name);
            var newest_student_02 = from user in users
                                    where user.CreatedAt != null
                                    orderby user.CreatedAt descending
                                    select user.Name;

            foreach (var user in newest_student_01.Take(1))
                Console.WriteLine(user);
            foreach (var user in newest_student_02.Take(1))
                Console.WriteLine(user);
        }
    }


    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
        public int Age { get; set; }
        public int[] Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
}

