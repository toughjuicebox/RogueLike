namespace ProcQuest
{
    public class Stack<T>
    {
        private Node<T> head;
        private int size;

        public Stack()
        {
            this.head = null;
            this.size = 0;
        }

        public bool IsEmpty() => size == 0;

        public Node<T> Head { get { return head; } }
        public int Size { get { return size; } }

        public void Clear()
        {
            this.head = null;
            this.size = 0;
        }

        public T Top()
        {
            if (IsEmpty()) { throw new ApplicationException(); }
            return this.head.Element;
        }

        public T Pop()
        {
            if (IsEmpty()) { throw new ApplicationException(); }
            T element = this.head.Element;
            this.head = this.head.Previous;
            this.size--;
            return element;
        }

        public void Push(T element)
        {
            Node<T> newNode =  new Node<T> { Element = element, Previous = this.head };
            this.head = newNode;
            this.size++;
        }

    }
}