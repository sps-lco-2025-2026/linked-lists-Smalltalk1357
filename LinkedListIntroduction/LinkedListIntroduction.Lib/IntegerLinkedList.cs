namespace LinkedListIntroduction.Lib;

public class IntegerLinkedList
{
    IntegerNode? _head;
    
    public IntegerLinkedList()
    {
        _head = null;
    }
    
    public IntegerLinkedList(int v)
    {
        _head = new IntegerNode(v);
    }
    
    public int Count => _head?.Count ?? 0;
    public int Sum => _head?.Sum ?? 0;
    
    public void Append(int v)
    {
        if (_head == null)
            _head = new IntegerNode(v);
        else
            _head.Append(v);
    }
    
    private void Append(IntegerNode? other)
    {
        if (_head == null)
            _head = other;
        else
            _head.Append(other);
    }
    
    public void Prepend(int v)
    {
        if (_head == null)
            _head = new IntegerNode(v);
        else
        {
            IntegerNode node = new IntegerNode(v);
            node.Next = _head;
            _head = node;
        }
    }

    public bool Delete(int v)
    {
        int originalCount = Count;
        if (_head == null)
            return false;
        _head = _head.Delete(v);
        return (originalCount != Count);
    }

    public void Insert(int v, int index)
    {
        if (index <= 0)
        {
            Prepend(v);
            return;
        }

        if (_head == null)
        {
            _head = new IntegerNode(v);
            return;
        }

        IntegerNode currentNode = _head;
        int currentIndex = 0;

        while (currentIndex < (index - 1) && currentNode.Next != null)
        {
            currentNode = currentNode.Next;
            currentIndex++;
        }

        IntegerNode newNode = new IntegerNode(v);
        newNode.Next = currentNode.Next;
        currentNode.Next = newNode;
    }

    /**
     * Sets tail.Next to other.Head - does NOT prevent infinite loops
     */
    public void Join(IntegerLinkedList other)
    {
        Append(other._head);
    }

    public bool Contains(int v)
    {
        if (_head == null)
            return false;
        return _head.Contains(v);
    }

    /**
     * Save the current node, then delete all nodes with the same value.
     * Then restore the current node at the current position, iterate through the list
     */
    public void RemoveDuplicates()
    {
        IntegerNode? currentNode = _head;
        while (currentNode != null)
        {
            int value = currentNode.Value;
            bool unchanged = false;
            while (!unchanged)
            {
                int startCount = Count;
                if (currentNode!.Next == null)
                {
                    currentNode = null;
                    unchanged = true;
                }
                else
                {
                    currentNode.Next = currentNode.Next.Delete(value);
                    if (startCount == Count)
                    {
                        currentNode = currentNode.Next;
                        unchanged = true;
                    }
                }
            }
        }
    }

    public void MeshLists(IntegerLinkedList other)
    {
        IntegerNode? currentNode = other._head;
        if (currentNode == null)
            return;
        if (this == other)
            return;
        if (_head == null)
        {
            _head = other._head;
            return;
        }

        int index = 1;
        while (currentNode != null)
        {
            Insert(currentNode.Value, index);
            currentNode = currentNode.Next;
            index += 2;
        }
    }

    public IntegerLinkedList Reverse()
    {
        IntegerLinkedList reversed = new IntegerLinkedList();
        IntegerNode? currentNode = _head;
        
        while (currentNode != null)
        {
            reversed.Prepend(currentNode.Value);
            currentNode = currentNode.Next;
        }
        return reversed;
    }
    
    public override string ToString()
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }
}

internal class IntegerNode
{
    public int Value { get; }
    internal IntegerNode? Next;
    
    internal int Count => Next == null ? 1 : 1 + Next.Count;
    
    internal int Sum => Value + Next?.Sum ?? Value;
    
    
    internal IntegerNode(int v)
    {
        Value = v;
        Next = null;
    }
    
    internal void Append(int v)
    {
        if (Next == null)
            Next = new IntegerNode(v);
        else
            Next.Append(v);
    }

    internal void Append(IntegerNode? other)
    {
        if (Next == null)
            Next = other;
        else
            Next.Append(other);
    }
    
    /**
        If v is found, it will return the current node.
        If v is not found, it will return null.
    */
    internal IntegerNode? Delete(int v)
    {
        if (Value == v)
        {
            if (Next == null)
                return null;
            
            return Next;
        }
        
        if (Next != null)
            Next = Next.Delete(v);
        
        return this;
    }

    internal bool Contains(int v)
    {
        if (Value == v)
            return true;
        
        if (Next != null)
            return Next.Contains(v);
        
        return false;
    }
    
    public override string ToString()
    {
        return Next == null ? Value.ToString() : $"{Value}, {Next}";
    }
}
