namespace LeetCode.__Design._355._Design_Twitter;

public class Twitter
{
    private int time;
    private readonly Dictionary<int, HashSet<int>> follows = new();
    private readonly Dictionary<int, List<(int time, int id)>> tweets = new();

    public void PostTweet(int userId, int tweetId)
    {
        var tweet = (time, tweetId);
        time++;
        if (tweets.TryGetValue(userId, out var list))
        {
            list.Add(tweet);
        }
        else
        {
            tweets.Add(userId, [tweet]);
        }
    }

    public IList<int> GetNewsFeed(int userId)
    {
        PriorityQueue<int, int> q = new();
        EnqueueTweetsFromUser(userId);
        if (follows.TryGetValue(userId, out var list))
        {
            foreach (int followee in list)
            {
                EnqueueTweetsFromUser(followee);
            }
        }
        List<int> result = [];
        while (q.Count > 0)
        {
            result.Add(q.Dequeue());
        }
        result.Reverse();
        return result;

        void EnqueueTweetsFromUser(int user)
        {
            if (!tweets.TryGetValue(user, out var userTweets))
            {
                return;
            }
            foreach (var t in userTweets.TakeLast(10))
            {
                if (q.Count == 10)
                {
                    q.EnqueueDequeue(t.id, t.time);
                }
                else
                {
                    q.Enqueue(t.id, t.time);
                }
            }
        }
    }

    public void Follow(int followerId, int followeeId)
    {
        if (follows.TryGetValue(followerId, out var list))
        {
            list.Add(followeeId);
        }
        else
        {
            follows.Add(followerId, [followeeId]);
        }
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (follows.TryGetValue(followerId, out var list))
        {
            list.Remove(followeeId);
        }
    }
}

[TestFixture]
public class SolutionTests
{
    [Test]
    public void Test1()
    {
        var twitter = new Twitter();

        twitter.PostTweet(1, 5);
        twitter.GetNewsFeed(1).Should().Equal(5);

        twitter.Follow(1, 2);
        twitter.PostTweet(2, 6);
        twitter.GetNewsFeed(1).Should().Equal(6, 5);

        twitter.Unfollow(1, 2);
        twitter.GetNewsFeed(1).Should().Equal(5);
    }
}
