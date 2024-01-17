using System;
using System.ComponentModel.Design;

namespace d_ary_heap
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int d = inputD();

            DHeap heap = inputStack(d);

            while (true)
            {
                Console.WriteLine(heap.ToString());

                Console.WriteLine(heap.getTree);

                heap = menu(heap);
            }

        }


        public static int inputD()
        {
            int d=-1000;
            bool flagIsRead = false;

            while (!flagIsRead)
            {
                Console.WriteLine("Input d for d-ary heap: ");
                try
                {
                    d = int.Parse(Console.ReadLine());
                    flagIsRead = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Written value is not an integer number, please try again");
                }
            }
            return d;
        }

        public static DHeap inputStack(int d) {
            DHeap heap = new DHeap();

            bool inputMethodCorrect = false;

            int inputMethod = 0;
            while (!inputMethodCorrect)
            {
                Console.WriteLine("Choose stack input method:\n1 - via keyboard\n2 - via file");

                try
                {
                    inputMethod = int.Parse(Console.ReadLine());
                    if (inputMethod == 1 || inputMethod == 2)
                        inputMethodCorrect = true;
                    else
                        throw new Exception("wrong input type");
                }
                catch (Exception e)
                {
                    Console.WriteLine("input method wasnt correctly entered. Please, try again");
                }
            }





            bool flagStackIsReaded = false;
            while (!flagStackIsReaded)
            {
                string stackLine = "";
                switch (inputMethod)
                {
                    case 1:
                        Console.WriteLine("Write stack one by one with numbers divided with space:");
                        stackLine = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Numbers in file should be divided with spaces. Please input filename:");
                        stackLine = File.ReadAllText(Console.ReadLine());

                        break;
                    default:
                        break;
                }

                try
                {
                    if (stackLine != "" || stackLine != null)
                    {
                        heap = new DHeap(d, stackLine);
                        flagStackIsReaded = true;
                    }
                    else
                    {
                        throw new Exception("Stack line is empty");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("There is an error in stack input. please, try input it again.");
                }
            }

            return heap;
        }


        public static DHeap menu(DHeap heap)
        {

            

            bool MenuItemCorrect = false;

            int MenuItemChosen = 0;
            while (!MenuItemCorrect)
            {
                Console.WriteLine("1 - MAX-EXTRACT");
                Console.WriteLine("2 - INSERT");
                Console.WriteLine("3 - INCREASE-KEY");
                Console.WriteLine("0 - close app");

                int[] MenuOptions = {1, 2, 3, 0};
                try
                {
                    MenuItemChosen = int.Parse(Console.ReadLine());
                    if (MenuOptions.Contains(MenuItemChosen))
                        MenuItemCorrect = true;
                    else
                        throw new Exception("wrong Menu Item");
                }
                catch (Exception e)
                {
                    Console.WriteLine("There is no such item in the menu. Please, try again");
                }
            }


            switch (MenuItemChosen)
            {
                case 1:
                    Console.WriteLine("Extracted Max was: " + heap.MaxExtract());
                    break;

                case 2:
                    {
                        int n = -1000;
                        bool IsNumber = false;

                        while(!IsNumber)
                        {
                            Console.WriteLine("Input number to insert");

                            try
                            {
                                n = int.Parse(Console.ReadLine());
                                IsNumber = true;
                            }
                            catch
                            {
                                Console.WriteLine("It wasn't a number. Please, try again.");
                            }
                        }

                        heap.Insert(n);
                        break;
                    }

                case 3:
                    {
                        int i = -1000;
                        int k = -1000;
                        bool IsNumber = false;

                        while (!IsNumber)
                        {
                            Console.WriteLine(heap.ToString());
                            Console.WriteLine("Input index to increase key in");

                            try
                            {
                                i = int.Parse(Console.ReadLine());
                                IsNumber = true;
                            }
                            catch
                            {
                                Console.WriteLine("It wasn't a number. Please, try again.");
                            }
                        }


                        IsNumber = false;
                        while (!IsNumber)
                        {
                            Console.WriteLine("Input Key Value to try to increase key in " + i);

                            try
                            {
                                k = int.Parse(Console.ReadLine());
                                IsNumber = true;
                            }
                            catch
                            {
                                Console.WriteLine("It wasn't a number. Please, try again.");
                            }
                        }

                        heap.IncreaseKey(i, k);
                        break;
                    }

                case 0:
                    System.Environment.Exit(0);
                    break;
            }

            return heap;

        }

        

    }
}