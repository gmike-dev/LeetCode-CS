using System.Collections.Generic;
using System.Linq;

namespace LeetCode._1361._Validate_Binary_Tree_Nodes;

public class Solution
{
  public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
  {
    var root = FindRoot(n, leftChild, rightChild);
    if (root == -1)
      return false;
    var q = new Queue<int>();
    q.Enqueue(root);
    var visited = new HashSet<int>();
    while (q.Count > 0)
    {
      var v = q.Dequeue();
      if (visited.Contains(v))
        return false;
      if (leftChild[v] != -1)
        q.Enqueue(leftChild[v]);
      if (rightChild[v] != -1)
        q.Enqueue(rightChild[v]);
      visited.Add(v);
    }
    return visited.Count == n;
  }

  private int FindRoot(int n, int[] leftChild, int[] rightChild)
  {
    var nodes = new HashSet<int>(Enumerable.Range(0, n));
    nodes.ExceptWith(leftChild);
    nodes.ExceptWith(rightChild);
    if (nodes.Count == 1)
      return nodes.First();
    return -1;
  }
}