﻿using SocialRank.Models;

namespace SocialRank.Algorithms;

public class RankCalculator
{
    private const double DampingFactor = 0.85;
    
    public void CalculateRank(List<Content> contents, int iterations = 100)
    {
        int contentCount = contents.Count;
        double initialRank = 1.0 / contentCount;
        foreach (var content in contents) { content.Rank = initialRank; }
        for (int iteration = 0; iteration < iterations; iteration++)
        {
            foreach (var content in contents)
            {
                double newRank = (1 - DampingFactor) / contentCount;
                foreach (var link in content.Links)
                {
                    newRank += DampingFactor * (link.Rank / link.Links.Count);
                }
                content.Rank = newRank;
            }
        }
    }
}