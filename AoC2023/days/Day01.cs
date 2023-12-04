using System.Diagnostics;

namespace AoC2023;

public class Day01
{
    private readonly string[] input;
    private readonly Stopwatch timer;

    public Day01()
    {
        timer = new Stopwatch();
        input = File.ReadAllLines("inputs/day01.txt");
    }

    public void Solve()
    {
        timer.Start();
        var result1 = SolveProblem1();
        Console.WriteLine($"Day 1 result 1 is {result1}. Completed in {timer.Elapsed}");
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
}
