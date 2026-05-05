namespace LeetCode.__Design._715._Range_Module;

public class RangeModule
{
    private readonly SegmentTree t = new(0, (int)1e9);

    public void AddRange(int left, int right)
    {
        t.Add(left, right);
    }

    public bool QueryRange(int left, int right)
    {
        return t.Query(left, right);
    }

    public void RemoveRange(int left, int right)
    {
        t.Remove(left, right);
    }

    private class SegmentTree(int left, int right)
    {
        private int color; // 0 - empty, 1 - full, 2 - partial
        private bool pushDown;
        private SegmentTree leftTree;
        private SegmentTree rightTree;

        public bool Query(int l, int r)
        {
            if (l >= r)
            {
                return true;
            }
            if (color < 2 || l == left && r == right)
            {
                return color == 1;
            }
            int m = left + (right - left) / 2;
            CreateChild(m);
            PushDown();
            return leftTree.Query(l, Math.Min(r, m)) && rightTree.Query(Math.Max(l, m), r);
        }

        public void Add(int l, int r)
        {
            if (l >= r || color == 1)
            {
                return;
            }
            if (left == l && r == right)
            {
                color = 1;
                pushDown = true;
                return;
            }
            int m = left + (right - left) / 2;
            CreateChild(m);
            PushDown();
            leftTree.Add(l, Math.Min(r, m));
            rightTree.Add(Math.Max(l, m), r);
            UpdateColor();
        }

        public void Remove(int l, int r)
        {
            if (l >= r || color == 0)
            {
                return;
            }
            if (left == l && r == right)
            {
                color = 0;
                pushDown = true;
                return;
            }
            int m = left + (right - left) / 2;
            CreateChild(m);
            PushDown();
            leftTree.Remove(l, Math.Min(r, m));
            rightTree.Remove(Math.Max(l, m), r);
            UpdateColor();
        }

        private void CreateChild(int m)
        {
            if (leftTree == null)
            {
                leftTree = new SegmentTree(left, m);
                rightTree = new SegmentTree(m, right);
            }
        }

        private void PushDown()
        {
            if (pushDown)
            {
                leftTree.color = color;
                rightTree.color = color;
                leftTree.pushDown = true;
                rightTree.pushDown = true;
                pushDown = false;
            }
        }

        private void UpdateColor()
        {
            if (leftTree.color == 0 && rightTree.color == 0)
            {
                color = 0;
            }
            else if (leftTree.color == 1 && rightTree.color == 1)
            {
                color = 1;
            }
            else
            {
                color = 2;
            }
        }
    }
}

[TestFixture]
public class SolutionTests
{
    [Test]
    public void Test()
    {
        RangeModule rangeModule = new();
        rangeModule.AddRange(10, 20);
        rangeModule.RemoveRange(14, 16);
        rangeModule.QueryRange(10, 14).Should().BeTrue();
        rangeModule.QueryRange(13, 15).Should().BeFalse();
        rangeModule.QueryRange(16, 17).Should().BeTrue();
    }
}
