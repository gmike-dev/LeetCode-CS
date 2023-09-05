namespace LeetCode._138._Copy_List_with_Random_Pointer;

public class Node
{
  public int val;
  public Node next;
  public Node random;

  public Node(int _val)
  {
    val = _val;
    next = null;
    random = null;
  }
}