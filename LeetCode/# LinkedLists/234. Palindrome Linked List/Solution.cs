namespace LeetCode.__LinkedLists._234._Palindrome_Linked_List;

public class Solution
{
  public bool IsPalindrome(ListNode head)
  {
    if (head?.next == null)
      return true;

    var slow = head;
    var fast = head;
    var reversed = (ListNode)null;
    while (fast?.next != null)
    {
      fast = fast.next?.next;
      (slow.next, reversed, slow) = (reversed, slow, slow.next);
    }
    if (fast != null)
      slow = slow.next;
    while (reversed != null && slow != null)
    {
      if (reversed.val != slow.val)
        return false;
      reversed = reversed.next;
      slow = slow.next;
    }
    return true;
  }
}