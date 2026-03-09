namespace LinkedListIntroduction.Lib;

public class SortedIntegerLinkedList : IntegerLinkedList
{
    IntegerNode _head;

    public new void Append(int v)
    {
        Add(v);
    }
    
    public new void Prepend(int v)
    {
        Add(v);
    }

    public void Join(SortedIntegerLinkedList other)
    {
        IntegerNode? current = other._head;
        while (current != null)
        {
            Add(current.Value);
            current = current.Next;
        }
    }

    private void Add(int v)
    {
        IntegerNode? current = _head;

        if (_head == null || v < _head.Value)
        {
            _head = new IntegerNode(v);
            return;
        }
        
        int headValue = _head.Value;
        if (v < headValue)
        {
            IntegerNode? storeHead = _head;
            IntegerNode node = new IntegerNode(v);
            _head = node;
            node.Next = storeHead;
            return;
        }

        if (_head.Next == null)
        {
            _head.Next = new IntegerNode(v);
            return;
        }

        if (v < _head.Next.Value)
        {
            IntegerNode? storeHead = _head;
            IntegerNode node = new IntegerNode(v);
            _head.Next = node;
            node.Next = storeHead;
            return;
        }
        
        current = _head.Next;

        while (current != null)
        {
            if (current.Next == null)
            {
                current.Next = new IntegerNode(v);
                return;
            }
            
            int nextvalue = current.Next.Value;
            if (v < nextvalue)
            {
                IntegerNode? storeNext = current.Next;
                IntegerNode node = new IntegerNode(v);
                current.Next = node;
                node.Next = storeNext;
                return;
            }
            current = current.Next;
        }
    }

    public void Merge(SortedIntegerLinkedList other)
    {
        Join(other);
    }
}