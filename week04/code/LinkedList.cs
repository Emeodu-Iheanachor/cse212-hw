using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new(value);

        // Empty list
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Insert a new node at the back (tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new(value);

        // Empty list
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // Empty list or one node
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head = _head.Next;
            _head!.Prev = null;
        }
    }

    /// <summary>
    /// Remove the last node (tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // Empty list or one node
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_tail is not null)
        {
            _tail = _tail.Prev;
            _tail!.Next = null;
        }
    }

    /// <summary>
    /// Insert newValue after the first occurrence of value.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // Insert after tail
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);

                    newNode.Prev = curr;
                    newNode.Next = curr.Next;

                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }

                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Remove the first node containing value.
    /// </summary>
    public void Remove(int value)
    {
        // Empty list
        if (_head is null)
        {
            return;
        }

        // Remove head
        if (_head.Data == value)
        {
            RemoveHead();
            return;
        }

        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // Remove tail
                if (curr == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }

                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Replace all occurrences of oldValue with newValue.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Iterate forward through the Linked List.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        Node? curr = _head;

        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate backward through the Linked List.
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        Node? curr = _tail;

        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public bool HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public bool HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}



public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}

