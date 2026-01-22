using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1 - Finding Symmetric Pairs (O(n))
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var results = new List<string>();

        foreach (var word in words)
        {
            // Reverse the word
            string reversed = $"{word[1]}{word[0]}";

            // Skip words like "aa"
            if (word == reversed)
            {
                continue;
            }

            // If reverse already seen, we found a pair
            if (seen.Contains(reversed))
            {
                results.Add($"{reversed} & {word}");
            }

            seen.Add(word);
        }

        return results.ToArray();
    }

    /// <summary>
    /// Problem 2 - Degree Summary
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // Degree is in the 4th column (index 3)
            string degree = fields[3];

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3 - Anagrams
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize input (ignore spaces and case)
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
        {
            return false;
        }

        var letterCount = new Dictionary<char, int>();

        // Count letters in word1
        foreach (char c in word1)
        {
            if (letterCount.ContainsKey(c))
            {
                letterCount[c]++;
            }
            else
            {
                letterCount[c] = 1;
            }
        }

        // Subtract letters using word2
        foreach (char c in word2)
        {
            if (!letterCount.ContainsKey(c))
            {
                return false;
            }

            letterCount[c]--;

            if (letterCount[c] < 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Problem 5 - Earthquake JSON Data
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var response = client.GetStreamAsync(uri).Result;

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(response, options);

        var results = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties.Place;
            double? mag = feature.Properties.Mag;

            results.Add($"{place} - Magnitude {mag}");
        }

        return results.ToArray();
    }
}
