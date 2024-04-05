namespace LeetCode._138._Copy_List_with_Random_Pointer;

public class Solution
{
  public Node CopyRandomList(Node head)
  {
    if (head == null)
      return null;

    var copies = new Dictionary<Node, Node>();
    for (var node = head; node != null; node = node.next)
      copies[node] = new Node(node.val);
    for (var node = head; node != null; node = node.next)
    {
      if (node.next != null)
        copies[node].next = copies[node.next];
      if (node.random != null)
        copies[node].random = copies[node.random];
    }

    return copies[head];
  }
}
