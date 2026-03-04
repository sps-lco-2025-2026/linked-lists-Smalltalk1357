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

    public bool Remove(int v)
    {
        if (_head != null)
            return _head.Delete(v);
        return false;
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

    internal bool Delete(int v)
    {
        if (Next._value == v)
        {
            Next = Next.Next;
            return true;
        }
        else
        {
            if (Next != null)
                return Next.Delete(v);
            return false;
        }
    }
    
    // internal IntegerNode Reverse()
    // {
    //     IntegerNode newMe = new IntegerNode(_value);
    //     if (Next != null)
    //         return newMe;
    //     return Next.Reverse(newMe);
    // }
    //
    // IntegerNode Reverse(IntegerNode previous)
    // {
    //     IntegerNode newMe = new IntegerNode(_value, previous);
    //     if (Next != null)
    //         return newMe;
    //     return Next.Reverse(newMe);
    // }
    
    public override string ToString()
    {
        return Next == null ? _value.ToString() : $"{_value}, {Next}";
    }
}
