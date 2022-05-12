namespace Program
{
    public class Node
    {
        public string item;
        public Node next;
        public Node prev;

        public Node(string x)
        {
            item = x;
            prev = null;
            next = null;
        }
    }

    public class LinkedList
    {
        public static Node head;

        public void AddNodeToFront(string item)
        {
            var newNode = new Node(item);

            newNode.next = LinkedList.head;
            newNode.prev = null;


            if (LinkedList.head != null)
                LinkedList.head.prev = newNode;

            LinkedList.head = newNode;
        }

        public void AddNodeToEnd(string item)
        {
            var newNode = new Node(item);

            if (LinkedList.head == null)
            {
                newNode.prev = null;
                LinkedList.head = newNode;
                return;
            }

            var lastNode = GetLastNode();
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }

        public Node GetLastNode()
        {
            Node temp = LinkedList.head;
            while (temp.next != null)
                temp = temp.next;
            return temp;
        }

        public void ListAll()
        {
            var pointer = LinkedList.head;
            while (pointer != null)
            {
                Console.WriteLine(pointer.item);
                pointer = pointer.next;
            }
        }

        public void Delete(string key)
        {
            var temp = LinkedList.head;

            if (temp != null && temp.item == key)
            {
                LinkedList.head = temp.next;
                LinkedList.head.prev = null;
                return;
            }
            while (temp != null && temp.item != key)
                temp = temp.next;
            if (temp == null)
                return;
            if (temp.next != null)
                temp.next.prev = temp.prev;
            if (temp.prev != null)
                temp.prev.next = temp.next;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var mylist = new LinkedList();

            mylist.AddNodeToFront("Adam");
            mylist.AddNodeToFront("Kasia");
            mylist.AddNodeToEnd("Marek");
            mylist.AddNodeToEnd("Sara");
            mylist.Delete("Marek");

            mylist.ListAll();
        }
    }
}
