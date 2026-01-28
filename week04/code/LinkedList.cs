using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create a new node with the given value
        Node newNode = new(value);

        // If the list is empty, head and tail both point to the new node
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // Otherwise, link the new node before the current head
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // Create a new node with the given value
        Node newNode = new(value);

        // If the list is empty, head and tail both point to the new node
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // Otherwise, link the new node after the current tail
        else
        {
            newNode.Prev = _tail;     // Connect new node to current tail
            _tail.Next = newNode;     // Connect current tail to new node
            _tail = newNode;          // Update tail reference
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If there is only one node (or the list is empty)
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If there are multiple nodes, move head forward
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect old head
            _head = _head.Next;      // Update head
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // If there is only one node (or the list is empty)
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If there are multiple nodes, move tail backward
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // Disconnect old tail
            _tail = _tail.Prev;      // Update tail
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;

        // Traverse the list to find the target value
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If inserting after the tail, reuse InsertTail
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
                return; // Stop after first insertion
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;

        // Traverse the list to find the value
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If removing the head
                if (curr == _head)
                {
                    RemoveHead();
                }
                // If removing the tail
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // Removing a middle node
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return; // Remove only the first occurrence
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;

        // Traverse entire list and replace matching values
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
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
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

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        Node? curr = _tail;

        // Traverse backward from tail to head
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
