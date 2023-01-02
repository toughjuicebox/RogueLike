namespace ProcQuest
{
    public class Node<T>
    {
        public T Element { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
    
        public Node() { }

        public Node(T element)
        {
            this.Element = element;
        }

        public Node(T element, Node<T> previousNode, Node<T> nextNode) : this(element)
        {
            this.Previous = previousNode;
            this.Next = nextNode;
        }
    }
}