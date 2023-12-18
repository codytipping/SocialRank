using SocialRank.Models;

namespace SocialRank.Algorithms;

public class RankCalculator
{
    private const double DampingFactor = 0.85;

    public static List<UserRank> CalculateRank(List<UserRank> users, int iterations = 100)
    {
        int userCount = users.Count;
        double initialRank = 1.0 / userCount;
        foreach (var user in users) { user.Rank = initialRank; }
        for (int iteration = 0; iteration < iterations; iteration++)
        {
            foreach (var user in users)
            {
                double newRank = (1 - DampingFactor) / userCount;
                foreach (var link in user.Links!)
                {
                    newRank += DampingFactor * (link.Rank / link.Links!.Count);
                }
                user.Rank = newRank;
            }
        }
        users.Sort((x, y) => x.Rank.CompareTo(y.Rank));
        return users;
    }
}