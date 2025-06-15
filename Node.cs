namespace Practice;

public class Node
{
    public SportsEquipment Data;
    public Node Prev;
    public Node Next;

    public Node(SportsEquipment Data)
    {
        this.Data = Data;
        Prev = null;
        Next = null;
    }
}