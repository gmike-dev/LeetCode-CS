using LeetCode.__BinaryTrees;

namespace LeetCode.__LinkedLists._109._Convert_Sorted_List_to_Binary_Search_Tree;

public class ListSolution
{
  public TreeNode SortedListToBST(ListNode head)
  {
    if (head is null)
      return null;
    var values = new List<int>();
    for (var node = head; node != null; node = node.next)
      values.Add(node.val);
    return BuildTree(0, values.Count - 1, values);
  }

  private static TreeNode BuildTree(int l, int r, List<int> values)
  {
    if (l > r)
      return null;
    var m = l + (r - l) / 2;
    return new TreeNode(values[m],
      BuildTree(l, m - 1, values),
      BuildTree(m + 1, r, values));
  }
}

[TestFixture]
public class ListSolutionTests
{
  [TestCase("[-10,-3,0,5,9]", "[0,-10,5,null,-3,null,9]")]
  [TestCase("[]", "[]")]
  public void Test(string list, string expected)
  {
    TreeNode.ToString(new ListSolution().SortedListToBST(ListNode.FromString(list))).Should().Be(expected);
  }
}
