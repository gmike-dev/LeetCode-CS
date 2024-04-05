namespace LeetCode._2353._Design_a_Food_Rating_System;

[TestFixture]
public class FoodRatingsTests
{
  [Test]
  public void SortedSetTest()
  {
    var foodRatings = new SortedSet.FoodRatings(
      new[] { "kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi" },
      new[] { "korean", "japanese", "japanese", "greek", "japanese", "korean" },
      new[] { 9, 12, 8, 15, 14, 7 });
    foodRatings.HighestRated("korean").Should().Be("kimchi"); // return "kimchi"
    // "kimchi" is the highest rated korean food with a rating of 9.
    foodRatings.HighestRated("japanese").Should().Be("ramen"); // return "ramen"
    // "ramen" is the highest rated japanese food with a rating of 14.
    foodRatings.ChangeRating("sushi", 16); // "sushi" now has a rating of 16.
    foodRatings.HighestRated("japanese").Should().Be("sushi"); // return "sushi"
    // "sushi" is the highest rated japanese food with a rating of 16.
    foodRatings.ChangeRating("ramen", 16); // "ramen" now has a rating of 16.
    foodRatings.HighestRated("japanese").Should().Be("ramen"); // return "ramen"
    // Both "sushi" and "ramen" have a rating of 16.
    // However, "ramen" is lexicographically smaller than "sushi".
  }

  [Test]
  public void PriorityQueueTest()
  {
    var foodRatings = new PriorityQueue.FoodRatings(
      new[] { "kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi" },
      new[] { "korean", "japanese", "japanese", "greek", "japanese", "korean" },
      new[] { 9, 12, 8, 15, 14, 7 });
    foodRatings.HighestRated("korean").Should().Be("kimchi"); // return "kimchi"
    // "kimchi" is the highest rated korean food with a rating of 9.
    foodRatings.HighestRated("japanese").Should().Be("ramen"); // return "ramen"
    // "ramen" is the highest rated japanese food with a rating of 14.
    foodRatings.ChangeRating("sushi", 16); // "sushi" now has a rating of 16.
    foodRatings.HighestRated("japanese").Should().Be("sushi"); // return "sushi"
    // "sushi" is the highest rated japanese food with a rating of 16.
    foodRatings.ChangeRating("ramen", 16); // "ramen" now has a rating of 16.
    foodRatings.HighestRated("japanese").Should().Be("ramen"); // return "ramen"
    // Both "sushi" and "ramen" have a rating of 16.
    // However, "ramen" is lexicographically smaller than "sushi".
  }
}
