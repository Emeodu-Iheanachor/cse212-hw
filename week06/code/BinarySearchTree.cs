using System;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree
{
    private Node? _root;

    // Insert (no duplicates)
    public void Insert(int value)
    {
        if (_root == null)
        {
            _root = new Node(value);
            return;
        }

        if (Contains(value))
            return;

        _root.Insert(value);
    }

    // Contains
    public bool Contains(int value)
{
    return _root?.Contains(value) ?? false;
}

    // Height
    public int GetHeight()
    {
        return _root?.GetHeight() ?? 0;
    }

    // Reverse traversal (largest -> smallest)
    public IEnumerable<int> Reverse()
{
    List<int> values = new();

    TraverseBackward(_root, values);

    return values;
}

    private void TraverseBackward(Node? node, List<int> values)
{
    if (node == null)
        return;

    TraverseBackward(node.Right, values);
    values.Add(node.Data);
    TraverseBackward(node.Left, values);
}

    // In-order traversal string
    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", InOrder(_root)) + "}";
    }

    private IEnumerable<int> InOrder(Node? node)
    {
        if (node == null)
            yield break;

        foreach (var value in InOrder(node.Left))
            yield return value;

        yield return node.Data;

        foreach (var value in InOrder(node.Right))
            yield return value;
    }
}