namespace ProcQuest
{
    public class Queue<T>
    {
        public int Size;
        public Node<T> Head;
        public Node<T> Tail;
    
        public Queue()
        {
            Size = 0;
            Head = null;
            Tail = null;
        }
    
        public int GetSize() { return Size; }
        public Node<T> GetHead() { return Head; }
        public Node<T> GetTail() { return Tail; }
        public bool IsEmpty() => Size == 0;
        public void Clear()
        {
            Size = 0;
            Head = null;
            Tail = null;
        }
    
        public T Front()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }
            return Head.Element;
        }
    
        public void Enqueue(T element)
        {
            Node<T> newNode = new Node<T>{ Element = element };
            if(IsEmpty())
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
            Size++;
        }
    
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }
            T temp = Head.Element;
            if (Size == 1)
            {
                Clear();
            }
            else
            {
                Head = Head.Next;
                Size--;
            }
            return temp;
        }
    }
}