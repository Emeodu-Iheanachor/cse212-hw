public class Node
{
    public int Data;
    public Node? Left;
    public Node? Right;

    public Node(int value)
    {
        Data = value;
    }

 public void Insert(int value)
{
    if (value == Data)
        return;

    if (value < Data)
    {
        if (Left == null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    else
    {
        if (Right == null)
            Right = new Node(value);
        else
            Right.Insert(value);
    }
}

public bool Contains(int value)
{
    if (value == Data)
        return true;

    if (value < Data)
        return Left?.Contains(value) ?? false;

    return Right?.Contains(value) ?? false;
}

public int GetHeight()
{
    int leftHeight = Left?.GetHeight() ?? 0;
    int rightHeight = Right?.GetHeight() ?? 0;

    return 1 + Math.Max(leftHeight, rightHeight);
}

}