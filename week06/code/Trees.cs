using System;
using System.Collections.Generic;

public static class Trees
{
    public static BinarySearchTree CreateTreeFromSortedList(int[] values)
{
    BinarySearchTree tree = new();

    BuildBalanced(tree, values, 0, values.Length - 1);

    return tree;
}

private static void BuildBalanced(
    BinarySearchTree tree,
    int[] values,
    int left,
    int right)
{
    if (left > right)
        return;

    int mid = (left + right) / 2;

    tree.Insert(values[mid]);

    BuildBalanced(tree, values, left, mid - 1);
    BuildBalanced(tree, values, mid + 1, right);
}
}