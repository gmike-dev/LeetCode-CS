using LeetCode.Common;

namespace LeetCode.LinkedLists._21._Merge_Two_Sorted_Lists;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    var list1 = new ListNode(1, new(2, new(4)));
    var list2 = new ListNode(1, new(3, new(4)));
    var expected = new ListNode(1, new(1, new(2, new(3, new(4, new(4))))));
    sln.MergeTwoLists(list1, list2)
      .Should()
      .BeEquivalentTo(expected);
  }
}
