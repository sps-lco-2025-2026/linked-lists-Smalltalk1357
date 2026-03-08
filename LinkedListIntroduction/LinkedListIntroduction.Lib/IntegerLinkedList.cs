namespace LinkedListIntroduction.Lib;

public class IntegerLinkedList
{
    IntegerNode _head;
    
    public IntegerLinkedList()
    {
        _head = null;
    }
    
    public IntegerLinkedList(int v)
    {
        _head = new IntegerNode(v);
    }
    
    public int Count => _head == null ? 0 : _head.Count;
    public int Sum => _head == null ? 0 : _head.Sum;
    
    public void Append(int v)
    {
        if (_head == null)
            _head = new IntegerNode(v);
        else
            _head.Append(v);
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
        if (index < 1)
        {
            Prepend(v);
            return;
        }

        int counter = 0;
        
    }
    
    public override string ToString()
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }
}

internal class IntegerNode
{
    int _value;
    internal IntegerNode Next;
    
    internal int Count => Next == null ? 1 : 1 + Next.Count;
    
    internal int Sum => Next == null ? _value : _value + Next.Sum;
    
    
    internal IntegerNode(int v)
    {
        _value = v;
        Next = null;
    }
    
    internal void Append(int v)
    {
        if (Next == null)
            Next = new IntegerNode(v);
        else
            Next.Append(v);
    }

    /**
        If v is found, it will return the current node.
        If v is not found, it will return null.
    */
    internal IntegerNode Delete(int v)
    {
        if (_value == v)
        {
            if (Next == null)
                return null;
            
            return Next;
        }
        
        if (Next != null)
            Next = Next.Delete(v);
        
        return this;
    }
    
    
    
    public override string ToString()
    {
        return Next == null ? _value.ToString() : $"{_value}, {Next}";
    }
}
