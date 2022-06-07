﻿using System;
using System.Collections.Generic;

namespace Zadania0706
{
    class Program
    {
        public static void Main(string[] args)
        {
            int points = 0;
            points += Test(() =>
            {
                int p = Zadanie1("aaa145zcdjef133445asd047").Equals("145") ? 2 : 0;
                p += Zadanie1("abcd").Equals("") && Zadanie1("112233").Equals("") ? 1 : 0;
                return p;
            }, "Zadanie 1 ");
            points += Test(() =>
            {
                if (Zadanie2(123) && Zadanie2(546790) && !Zadanie2(1123467) && Zadanie2(1) && !Zadanie2(3009))
                {
                    return 1;
                }

                return 0;
            }, "Zadanie 2");
            points += Test(() =>
            {
                StackTest<int> q = new StackTest<int>();
                q.Push(1);
                q.Push(2);
                q.Push(3);
                StackTest<string> sq = new StackTest<string>();
                sq.Push("abcd");
                sq.Push("");
                if (q.Pop() == 3 && q.Pop() == 2 && q.Pop() == 1 && sq.Pop().Equals("") &&
                    sq.Pop().Equals("abcd") && q.isEmpty() && sq.isEmpty())
                {
                    return 1;
                }

                return 0;
            }, "Zadanie 3");
            points += Test(() =>
            {
                Student[] students =
                {
                new Student() {Birth = new DateTime(200, 10, 10), Name = "Adam", Pesel = "01001001001"},
                new Student() {Birth = new DateTime(200, 10, 11), Name = "Adam", Pesel = "01001001001"},
                new Student() {Birth = new DateTime(200, 10, 10), Name = "Karol", Pesel = "01001001002"},
                new Student() {Birth = new DateTime(200, 10, 10), Name = "Ewa", Pesel = "01001001003"},
                new Student() {Birth = new DateTime(200, 10, 10), Name = "Alicja", Pesel = "01001001001"}
            };
                Student[] s =
                {
                new Student() {Birth = new DateTime(200, 10, 10), Name = "Adam", Pesel = "01001001001"},
                new Student() {Birth = new DateTime(200, 10, 10), Name = "Adam", Pesel = "01001001001"},
                new Student() {Birth = new DateTime(200, 10, 10), Name = "Adam", Pesel = "01001001001"},
            };
                if (CreateStudentGroup(students).Count == 3 && CreateStudentGroup(s).Count == 1)
                {
                    return 1;
                }

                return 0;
            }, "Zadanie 4");
            points += Test(() =>
            {
                TreeNode node = new TreeNode() { Value = 5, Children = new List<TreeNode>() };
                node.Children.Add(new TreeNode()
                {
                    Value = 6,
                    Children = new List<TreeNode>()
                {
                    new TreeNode() {Value = 2, Children = new List<TreeNode>()},
                    new TreeNode() {Value = 2, Children = new List<TreeNode>()},
                    new TreeNode() {Value = 2, Children = new List<TreeNode>()},
                }
                });
                node.Children.Add(new TreeNode()
                {
                    Value = 6,
                    Children = new List<TreeNode>()
                {
                    new TreeNode() {Value = 3, Children = new List<TreeNode>()},
                    new TreeNode() {Value = 3, Children = new List<TreeNode>()},
                    new TreeNode() {Value = 3, Children = new List<TreeNode>()},
                }
                });
                TestTree tree1 = new TestTree() { Root = node };
                TestTree tree2 = new TestTree() { Root = node.Children[0] };
                int sum1 = 0;
                int sum2 = 0;
                tree1.Traverse(node => sum1 += node.Value);
                tree2.Traverse(node => sum2 += node.Value);
                return sum1 == 32 && sum2 == 12 ? 2 : 0;
            }, "Zadanie 5");
            points += Test(() =>
            {
                TestGraph graph = new TestGraph(5);
                graph.AddDirectedEdge(0, 1);
                graph.AddDirectedEdge(1, 2);
                graph.AddDirectedEdge(2, 3);
                graph.AddDirectedEdge(4, 0);
                graph.AddDirectedEdge(2, 4);
                TestGraph g = new TestGraph(3);
                g.AddDirectedEdge(0, 1);
                g.AddDirectedEdge(0, 2);
                g.AddDirectedEdge(1, 2);
                int p = graph.Neighbors(0).Contains(1) && graph.Neighbors(0).Count == 1 ? 1 : 0;
                p += g.Neighbors(0).Contains(1) && !g.Neighbors(0).Contains(3) && g.Neighbors(0).Count == 2 ? 1 : 0;
                return p;
            }, "Zadanie 6");
            Console.WriteLine($"Suma punktów: {points}");
        }

        /**
        ********************************************************************************************************************
        */

        /**
         * Zadanie 1 (2 pkt.)
         * 
         * Zdefiniuj metodę, która zwróci pierwszy i najdłuższy fragment  łańcucha wejściowego złożony z unikalnych cyfr.
         * W przypadku braku cyfr w łańuchu wejściowym metoda powinna zwrócić łańcuch pusty. Można wykorzytać
         * metodę klasy char IsDigit(znak).
         * Uwaga!!!
         * Metoda ma uwzględniać wyłącznie  ciągi cyfr ograniczone innymi znakami, a nie
         * podzbiór ciągu złożonego z cyfr np. dla wejścia 1122345 powinna zwrócić łańcuch pusty a nnie 2345. 
         * Przykład 1
         * Wejście:
         * a156avdf56vgd346
         * Najdłuższy pierwszy fragment złożony z unikalnych cyfr to: 156 
         * Wyjście
         * 156
         * Przykład 2
         * Wejście:
         * ecbad
         * Wyjście:
         * 
         */
        public static string Zadanie1(string input)
        {
            string maxLanc = "";
            string lanc = "";

            foreach (char z in input.ToCharArray())
            {
                if (char.IsDigit(z))
                {
                    lanc += z;
                }
                else
                {
                    if (lanc.Length > maxLanc.Length)
                    {
                        maxLanc = lanc;
                    }


                    lanc = "";
                }
            }

            return maxLanc;
        }

        /**
         * Zadanie 2 (1 pkt.)
         * Zdefiniuj metodę Zadanie2, która zwraca true, jeśli liczba 'input' składa się z unikalnych cyfr dziesiętnych.
         *
         * Przykład 1
         * Wejście:
         * 1234
         * wyjście:
         * true
         *
         * Przykład 2
         * Wejście:
         * 112233
         * Wyjście
         * false
         */
        public static bool Zadanie2(int input)
        {
            List<int> cyfry = new List<int>();

            while (input > 0)
            {
                int d = input % 10;
                if(cyfry.Contains(d))
                {
                    return false;
                }

                cyfry.Add(d);

                input /= 10;
            }

            return true;
          }

        /**
         * Zadanie 3 (1 pkt.)
         * Dana jest klasa stosu dowiązaniowego
         * Zdefiniuj metodę Pop, która usuwa element ze stosu
         */
        class NodeTest<T>
        {
            public T Value { get; set; }
            public NodeTest<T> Next { get; set; }
        }

        class StackTest<T>
        {
            private NodeTest<T> _head;

            public void Push(T value)
            {
                NodeTest<T> nodeTest = new NodeTest<T>() { Value = value };
                if (isEmpty())
                {
                    _head = nodeTest;
                    return;
                }

                nodeTest.Next = _head;
                _head = nodeTest;
            }

            /**
             * Zaimplementuj metodę usuwania ze stosu
             */
            public T Pop()
            {
                if(isEmpty())
                {
                    throw new NullReferenceException();
                }
                else
                {
                    NodeTest<T> node = _head;
                    
                    
                    return node.Value;
                }
            }

            public bool isEmpty()
            {
                return _head == null;
            }
        }


        /**
         * Zadanie 4 (1 pkt.)
         * Dana jest klasa Student i metoda, która tworzy grupy studenckie.
         * Popraw klasę Student, aby utworzona grupa studencka składała się z unikalnych studentów.
         * Studenci moga mieć identyczne imiona i daty urodzin, ale każdy ma inny pesel.
         */
        public class Student
        {
            public string Pesel { get; set; }
            public string Name { get; set; }
            public DateTime Birth { get; set; }
        }

        public static ISet<Student> CreateStudentGroup(Student[] students)
        {
            return new HashSet<Student>(students);
        }

        /**
         * Zadanie 5 (2 pkt.)
         * Dana jest klasa drzewa. Zaimplementuj metodę do  przeglądania drzewa, aby dla każdego węzła wywołać delegata `action`.
         */
        public class TreeNode
        {
            public int Value { get; set; }
            public List<TreeNode> Children { get; set; }
        }

        public class TestTree
        {
            public TreeNode Root { get; set; }

            public void Traverse(Action<TreeNode> action)
            {
                throw new NotImplementedException();
            }
        }

        /**
         * Zadanie 6 (2 pkt.)
         * Dana jest klasa impe\lmentująca graf nieważony i skierowany w postaci macierzy sąsiedztw.
         * Zaimplementuj metodę 'Neighbors', która zwraca zbiór węzłów, które są sąsiadami węzła 'node'.
         */
        class TestGraph
        {
            private int[,] _matrix;

            public TestGraph(int n)
            {
                _matrix = new int[n, n];
            }

            public bool AddDirectedEdge(int source, int target)
            {
                if (Check(source) && Check(target))
                {
                    _matrix[source, target] = 1;
                    return true;
                }

                return false;
            }

            private bool Check(int node)
            {
                return node >= 0 && node < _matrix.GetLength(0);
            }

            public ISet<int> Neighbors(int node)
            {
                throw new NotImplementedException();
            }
        }

        /**
        *********************************************************************************************************************
        */
        public static int Test(Func<int> action, string message)
        {
            try
            {
                int p = action.Invoke();
                Console.WriteLine($"{message}: {p}");
                return p;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{message}: 0");
                return 0;
            }
        }
    }
}
