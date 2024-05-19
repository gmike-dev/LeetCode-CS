namespace LeetCode._857._Minimum_Cost_to_Hire_K_Workers;

public class Solution
 {
   public double MincostToHireWorkers(int[] quality, int[] wage, int k)
   {
     var n = quality.Length;
     var ratio = new List<(double rate, int quality)>();
     for (var i = 0; i < n; i++)
       ratio.Add(((double)wage[i] / quality[i], quality[i]));
     ratio.Sort();
     var topKMaxQualified = new PriorityQueue<int, int>();
     var qualitySum = 0;
     for (var i = 0; i < k; ++i)
     {
       var q = ratio[i].quality;
       qualitySum += q;
       topKMaxQualified.Enqueue(q, -q);
     }
     var result = ratio[k - 1].rate * qualitySum;
     for (var i = k; i < n; i++)
     {
       var q = ratio[i].quality;
       qualitySum += q - topKMaxQualified.Dequeue();
       topKMaxQualified.Enqueue(q, -q);
       result = Math.Min(result, ratio[i].rate * qualitySum);
     }
     return result;
   }
 }
