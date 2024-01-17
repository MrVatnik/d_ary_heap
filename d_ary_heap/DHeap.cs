using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace d_ary_heap
{
    internal class DHeap
    {
        int d; //d value of d-ary heap
        List<int> elements; // elements of all elements in heap

        public int heapSize
        {
            get
            {
                return this.elements.Count();
            }
        }

        public string getTree
        {
            get
            {
                string result = "";
                int level = 0;
                int reqForNextLvl = 0;
                for (int i = 0; i < this.heapSize; i++)
                {
                    
                    result += this.elements[i].ToString();
                    if (i  == reqForNextLvl)
                    {
                        result += "\n";
                        level++;
                        reqForNextLvl += (int)Math.Pow(d, level);
                    }
                    else
                    {
                        if (i % d == 0)
                        {
                            result += "   ";
                        }
                        else
                        {
                            if(i!=heapSize-1)
                                result += "_";
                        }
                    }

                }
                return result;
            }
        }

        public override string ToString()
        {
            string res = "";
            foreach (int el in elements)
                res += el + " ";
            return res;
        }

        #region constructors
        public DHeap()
        {
            d = 2;
            this.elements = new List<int>();
        }

        public DHeap(int d)
        {
            this.d = d;
            this.elements = new List<int>();
        }

        public DHeap(int d, List<int> elements)
        {
            this.d = d;
            this.elements = elements;
            buildHeap();
        }

        public DHeap(int d, string str)
        {
            this.d = d;
            elements = new List<int>();

            InputElementsFromString(str);

            buildHeap();
        }

        public DHeap(int d, int[] arr)
        {
            this.d = d;
            elements = arr.ToList();

            buildHeap();
        }


        #region helpful methods for constructors
        private int InputElementsFromString(string str)
        {
            List<string> strings = str.Split(' ').ToList();
            foreach (string s in strings)
            {
                elements.Add(int.Parse(s));
            }

            return elements.Count;
        }
        #endregion

        #endregion




        #region Heap Logic
        private void swap(int indexA, int indexB)
        {
            int temp;

            temp = elements[indexA];
            elements[indexA] = elements[indexB];
            elements[indexB] = temp;
        }

        public int HeapifyDown(int i)//runtime is O(log(n)/log(d))
        {
            int leftmostChild;
            int rightmostChild;
            int largestChild;

            bool PlaceIsFound = false;
            while (!PlaceIsFound)
            {
                leftmostChild = this.d * i + 1;
                rightmostChild = this.d * i + this.d;
                largestChild = i;

                for (int j = leftmostChild; j <= rightmostChild && j < heapSize; j++)
                {
                    if (j < heapSize && elements[j] > elements[largestChild])
                    {
                        largestChild = j;
                    }
                }


                if (largestChild != i)
                {
                    swap(i, largestChild);
                    i = largestChild;
                }
                else
                    PlaceIsFound = true;
            }

            return i;
        }

        public int HeapifyUp(int i)//runtime is O(log(n)/log(d))
        {
            int parent = (i - 1) / d;
            while (parent >= 0)
            {
                if (elements[parent] < elements[i])
                {
                    swap(i, parent);
                    i = parent;
                    parent = (i - 1) / d;
                }
                else
                    break;
            }

            return i;
        }


        private void buildHeap()
        {
            for (int i = (heapSize - 1) / d; i >= 0; i--)
                HeapifyDown(i);
        }

        #endregion




        #region The Assignment
        public int MaxExtract() //runtime is O(d*(log(n)/log(d)))
        {
            if (heapSize != 0)
            {
                int res = elements[0];
                elements[0] = elements[heapSize - 1];
                elements.RemoveAt(heapSize - 1);
                HeapifyDown(0);
                return res;
            }
            else
                return -1;
        }

        public int Insert(int value) //runtime is O(log(n)/log(d))
        {
            elements.Add(value);

            int i = heapSize - 1;
            return HeapifyUp(i);
        }

        public int IncreaseKey(int i, int k) //runtime is O(log(n)/log(d))
        {
            int index = i;
            if (k > elements[i])
            {
                elements[i] = k;
                index = HeapifyUp(i);
                
            }
            return index;
        }

        #endregion



    }
}
