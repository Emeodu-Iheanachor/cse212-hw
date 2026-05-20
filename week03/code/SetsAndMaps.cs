using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Find symmetric two-character pairs in O(n) time.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var results = new List<string>();

        foreach (var word in words)
        {
            string reversed = $"{word[1]}{word[0]}";

            if (word != reversed && seen.Contains(reversed))
            {
                string pair =
                    string.Compare(word, reversed) < 0
                    ? $"{word} & {reversed}"
                    : $"{reversed} & {word}";

                results.Add(pair);
            }

            seen.Add(word);
        }

        return results.ToArray();
    }

    /// <summary>
    /// Summarize education degrees from census file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var fields = line.Split(',');

            if (fields.Length < 4)
                continue;

            string degree = fields[3].Trim();

            degrees[degree] = degrees.GetValueOrDefault(degree) + 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determine if two words are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            counts[c] = counts.GetValueOrDefault(c) + 1;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Fetch and format earthquake daily summaries from USGS API.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        string json = client.GetStringAsync(uri).Result;

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var data = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var results = new List<string>();

        if (data?.Features == null)
            return results.ToArray();

        foreach (var f in data.Features)
        {
            if (f?.Properties == null)
                continue;

            string place = f.Properties.Place ?? "Unknown";
            double? mag = f.Properties.Mag;

            results.Add($"{place} - Mag {mag}");
        }

        return results.ToArray();
    }
}