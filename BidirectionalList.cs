namespace Practice;

public class BidirectionalList
{
    private Node Head;
        private Node Tail;
        private int Count;
        private Node iterationNode = null;

        public BidirectionalList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public int count
        {
            get
            {
                return Count;
            }
        }

        //Insert Middle
        public void InsertMiddle(SportsEquipment data)
        {
            Node newNode = new Node(data);

            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                int middle = Count / 2;
                Node current = Head;
                for (int i = 0; i < middle; i++)
                {
                    current = current.Next;
                }

                Node prevNode = current.Prev;
                
                newNode.Prev = prevNode;

                newNode.Next = current;

                if (prevNode != null)
                {
                    prevNode.Next = newNode;
                }
                else
                {
                    Head = newNode;
                }
                
                current.Prev = newNode;
            }
            Count++;
        }

        //RemoveAt
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            Node current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current.Prev != null)
            {
                current.Prev.Next = current.Next;
            }
            else
            {
                Head = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Prev = current.Prev;
            }
            else
            {
                Tail = current.Prev;
            }

            Count--;
        }
        
        //Indexer
        public SportsEquipment this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }

                Node current = Head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                return current.Data;
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }

                Node current = Head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                current.Data = value;
            }
        }
        
        //Length
        public int Length
        {
            get
            {
                return Count;
            }
        }
        
        //Iteration
        //Method for getting the last element
        public SportsEquipment GetLastNode()
        {
            iterationNode = Tail;
            if (iterationNode == null)
            {
                return null;
            }
            return iterationNode.Data;
        }
        
        //Method of getting the next value
        public SportsEquipment GetPrevious()
        {
            if (iterationNode == null)
            {
                return null;
            }
            iterationNode = iterationNode.Prev;
            if (iterationNode == null)
            {
                return null;
            }
            return iterationNode.Data;
        }
        
        //Sorting the list
        public void BubbleSortByWeight()
        {
            if (Head == null || Head.Next == null) return;

            bool swapped;

            do
            {
                swapped = false;
                Node current = Head;

                while (current != null && current.Next != null)
                {
                    if (current.Data.Weight > current.Next.Data.Weight)
                    {
                        var temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;

                        swapped = true;
                    }

                    current = current.Next;
                }

            } while (swapped);
        }
        
        //Search
        public List<SportsEquipment> Search()
        {
            List<SportsEquipment> result = new List<SportsEquipment>();
            Node current = Head;

            while (current != null)
            {
                if (current.Data.ProGrade && 
                    current.Data.SportType == SportType.Tennis &&
                    current.Data.Weight < 1.0f)
                {
                    result.Add(current.Data);
                }

                current = current.Next;
            }

            return result;
        }
        
        
        //PrintList
        public void PrintList()
        {
            Console.WriteLine("Index | Sport type | Weight | ProGrade");
            Console.WriteLine("-----------------------------------------------");
            Node current = Head;
            int index = 0;

            while (current != null)
            {
                var data = current.Data;
                Console.WriteLine($"{index, 5} | {data.SportType, -10} | {data.Weight, -6} | {data.ProGrade}");
                current = current.Next;
                index++;
            }
        }

        public List<SportsEquipment> ToList()
        {
            List<SportsEquipment> result = new List<SportsEquipment>();
            Node current = Head;
            while (current != null)
            {
                result.Add(current.Data);
                current = current.Next;
            }

            return result;
        }
}