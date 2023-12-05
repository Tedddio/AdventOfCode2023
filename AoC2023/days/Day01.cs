using System.Diagnostics;

namespace AoC2023;

public class Day01
{
    private readonly string[] input;
    private readonly Stopwatch timer;
    private readonly IDictionary<int, string> stringifiedDigits;

    public Day01()
    {
        timer = new Stopwatch();
        input = File.ReadAllLines("inputs/day01.txt");
        stringifiedDigits = GetStringifiedDigits();
    }

    public void Solve()
    {
        timer.Start();
        var result1 = SolveProblem1();
        Console.WriteLine($"Day 1 result 1 is {result1}. Completed in {timer.Elapsed}");
        timer.Restart();
        var result2 = SolveProblem2();
        Console.WriteLine($"Day 1 result 2 is {result2}. Completed in {timer.Elapsed}");
    }

    private int SolveProblem1()
    {
        var sum = 0;
        foreach (var s in input)
        {
            var firstDigit = s.First(char.IsDigit);
            var lastDigit = s.Last(char.IsDigit);
            sum += int.Parse($"{firstDigit}{lastDigit}");
        };
        return sum;
    }


    private int SolveProblem2()
    {
        var sum = 0;
        foreach (var s in input)
        {
            var firstDigit = FindFirstDigitIncludingStringified(s);
            var lastDigit = FindFirstDigitIncludingStringified(s, true);
            sum += int.Parse($"{firstDigit}{lastDigit}");
        };
        return sum;
    }

    private string FindFirstDigitIncludingStringified(string line, bool fromEnd = false) 
    {
        var firstDigit = fromEnd ? line.LastOrDefault(char.IsDigit)
            : line.FirstOrDefault(char.IsDigit);

        var occurences = stringifiedDigits
            .Select(s => new KeyValuePair<int, string>(line.GetIndex(s.Value, fromEnd), s.Key.ToString()))
            .Where(result => result.Key != -1)
            .OrderBy(x => x.Key);
        
        var firstStringOccurence =  fromEnd ? occurences.LastOrDefault()
            : occurences.FirstOrDefault();

        if (firstStringOccurence.Equals(default(KeyValuePair<int, string>)))
        {
            return firstDigit.ToString();
        }

        if ((fromEnd && line.LastIndexOf(firstDigit) > firstStringOccurence.Key )
            || (!fromEnd && line.IndexOf(firstDigit) < firstStringOccurence.Key))
        {
            return firstDigit.ToString();
        } 
        return firstStringOccurence.Value;
    }

    private IDictionary<int, string> GetStringifiedDigits()
    {
        return new Dictionary<int, string>()
        {
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
        };
    }
}
