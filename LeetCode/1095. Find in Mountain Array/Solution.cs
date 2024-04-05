namespace LeetCode._1095._Find_in_Mountain_Array;

public class MountainArray
{
  private readonly int[] array;

  public MountainArray(int[] array)
  {
    this.array = array;
  }

  public int Get(int index) => array[index];

  public int Length() => array.Length;
}

class Solution
{
  public int FindInMountainArray(int target, MountainArray mountainArr)
  {
    var peakIndex = GetPeakIndex(mountainArr);
    var index = BinarySearch(mountainArr, target, 0, peakIndex, (x, y) => x.CompareTo(y));
    return index != -1 ? index : BinarySearch(mountainArr, target, peakIndex + 1, mountainArr.Length() - 1, (x, y) => y.CompareTo(x));
  }

  private static int BinarySearch(MountainArray a, int target, int start, int end, Comparison<int> comparer)
  {
    var l = start;
    var r = end;
    while (l <= r)
    {
      var m = l + (r - l) / 2;
      var cmp = comparer(target, a.Get(m));
      if (cmp == 0)
        return m;
      if (cmp < 0)
        r = m - 1;
      else
        l = m + 1;
    }
    return -1;
  }


  private static int GetPeakIndex(MountainArray a)
  {
    var n = a.Length();
    var l = 0;
    var r = n - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (a.Get(m) < a.Get(m + 1))
        l = m + 1;
      else
        r = m;
    }
    return l;
  }
}
