namespace LeetCode._2353._Design_a_Food_Rating_System.SortedSet;

public class FoodRatings
{
  private readonly Dictionary<string, string> foodCuisine = new();
  private readonly Dictionary<string, int> foodRating = new();
  private readonly Dictionary<string, SortedSet<(int rating, string food)>> cuisineFoodRatings = new();

  public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
  {
    foreach (var (food, cuisine, rating) in foods.Zip(cuisines, ratings))
    {
      foodCuisine[food] = cuisine;
      foodRating[food] = rating;
      if (!cuisineFoodRatings.TryGetValue(cuisine, out var sortedFoodRating))
        cuisineFoodRatings[cuisine] = sortedFoodRating = new();
      sortedFoodRating.Add((-rating, food));
    }
  }

  public void ChangeRating(string food, int newRating)
  {
    var oldRating = foodRating[food];
    var cuisine = foodCuisine[food];
    foodRating[food] = newRating;
    var sortedFoodRating = cuisineFoodRatings[cuisine];
    sortedFoodRating.Remove((-oldRating, food));
    sortedFoodRating.Add((-newRating, food));
  }

  public string HighestRated(string cuisine)
  {
    return cuisineFoodRatings[cuisine].Min.food;
  }
}
