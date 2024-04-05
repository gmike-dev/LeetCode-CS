namespace LeetCode._2353._Design_a_Food_Rating_System.PriorityQueue;

public class FoodRatings
{
  private readonly Dictionary<string, string> foodCuisine = new();
  private readonly Dictionary<string, int> foodRating = new();
  private readonly Dictionary<string, PriorityQueue<string, (int rating, string food)>> cuisineFoodRatings = new();

  public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
  {
    foreach (var (food, cuisine, rating) in foods.Zip(cuisines, ratings))
    {
      foodCuisine[food] = cuisine;
      foodRating[food] = rating;
      if (!cuisineFoodRatings.TryGetValue(cuisine, out var bestRatings))
        cuisineFoodRatings[cuisine] = bestRatings = new();
      bestRatings.Enqueue(food, (-rating, food));
    }
  }

  public void ChangeRating(string food, int newRating)
  {
    foodRating[food] = newRating;
    cuisineFoodRatings[foodCuisine[food]].Enqueue(food, (-newRating, food));
  }

  public string HighestRated(string cuisine)
  {
    var cuisineFoodRating = cuisineFoodRatings[cuisine];
    while (cuisineFoodRating.TryPeek(out var food, out var priority) && -priority.rating != foodRating[food])
      cuisineFoodRating.Dequeue();
    return cuisineFoodRating.Peek();
  }
}
