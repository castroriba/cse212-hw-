using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1 - Find symmetric pairs using sets
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> seen = new();
        List<string> result = new();

        foreach (var word in words)
        {
            string reversed = new string(word.Reverse().ToArray());

            if (seen.Contains(reversed) && word != reversed)
            {
                result.Add($"{reversed} & {word}");
            }

            seen.Add(word);
        }

        return result.ToArray();
    }

    // Problem 2 - Summarize degrees
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim();
                if (!string.IsNullOrEmpty(degree))
                {
                    if (!degrees.ContainsKey(degree))
                        degrees[degree] = 0;
                    degrees[degree]++;
                }
            }
        }

        return degrees;
    }

    // Problem 3 - Anagrams
    public static bool IsAnagram(string word1, string word2)
    {
        string clean1 = new string(word1.ToLower().Where(c => c != ' ').ToArray());
        string clean2 = new string(word2.ToLower().Where(c => c != ' ').ToArray());

        if (clean1.Length != clean2.Length) return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in clean1)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;
            counts[c]++;
        }

        foreach (char c in clean2)
        {
            if (!counts.ContainsKey(c)) return false;
            counts[c]--;
            if (counts[c] < 0) return false;
        }

        return true;
    }

    // Problem 5 - Earthquake JSON Data
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        List<string> results = new();
        foreach (var feature in featureCollection.features)
        {
            string place = feature.properties.place;
            double mag = feature.properties.mag;
            results.Add($"{place} - Mag {mag}");
        }

        return results.ToArray();
    }
}

// Helper classes for JSON
public class FeatureCollection
{
    public List<Feature> features { get; set; }
}

public class Feature
{
    public Properties properties { get; set; }
}

public class Properties
{
    public string place { get; set; }
    public double mag { get; set; }
}
