using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree
            {
                Root = new Child
                {
                    Value = "0",
                    Children = {
                        new Child { Value = "1",
                            Children = {
                                new Child { Value = "12",
                                    Children = {
                                        new Child { Value = "123",
                                            Children = {
                                                new Child { Value = "1234" }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new Child { Value = "2",
                            Children = {
                                new Child { Value = "22",
                                    Children = {
                                        new Child { Value = "223" } } },
                                        new Child { Value = "2210",
                                        Children = {
                                                new Child { Value = "22103" } } } } },
                        new Child { Value = "3",
                            Children = {
                                new Child { Value = "32",
                                Children = {
                                        new Child { Value = "323" } } } } },
                        new Child { Value = "4",
                            Children = {
                                new Child { Value = "42",
                                    Children = {
                                        new Child { Value = "423" } } } } },
                        new Child { Value = "5",
                            Children = {
                                new Child { Value = "52",
                                Children = {
                                        new Child { Value = "523" } } } } }
                    }
                }
            };

            Console.Write(tree.DeptFirstDraw());
            Console.Write(tree.BreadthFirstDraw());

            Console.ReadKey();
        }
    }
}
