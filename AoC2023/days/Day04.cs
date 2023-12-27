using System.Diagnostics;

namespace AoC2023;

public class Day04
{
    private readonly string[] input;
    private readonly Stopwatch timer;

    public Day04()
    {
        timer = new Stopwatch();
        input = File.ReadAllLines("inputs/day04.txt");
    }

    public void Solve()
    {
        timer.Start();
        var result1 = SolveProblem1();
        Console.WriteLine($"Day 4 result 1 is {result1}. Completed in {timer.Elapsed}");
        timer.Restart();
        var result2 = SolveProblem2();
        Console.WriteLine($"Day 4 result 2 is {result2}. Completed in {timer.Elapsed}");
    }

    private int SolveProblem1()
    {
        var sum = 0;
        foreach (var s in input)
        {
            var game = s[(s.IndexOf(':') + 1)..];
            var games = game.Split('|');
            var winning = games[0].Trim().Split(' ');
            var own = games[1].Trim().Split(' ');
            var points = 0;
            foreach (var number in own)
            {
                if (!string.IsNullOrEmpty(number) && winning.Contains(number))
                {
                    points = points == 0 ? 1 : points * 2;
                }
            }
            sum += points;
        }
        return sum;
    }



    private int SolveProblem2()
    {
        var points = GetPoints();

        var count = new Dictionary<int, int>();
        foreach (var item in points)
        {
            count[item.Key] = 1;
        }

        for (int i = 0; i < points.Count; i++)
        {
            for (int j = 1; j <= points[i] ; j++)
            {
                var nextIndex = i + j;
                count[nextIndex] += count[i];
            }
        }
        return count.Sum(s => s.Value);
    }

    private IDictionary<int, int> GetPoints()
    {
        var points = new Dictionary<int, int>();
        for (int i = 0; i < input.Length; i++)
        {
            points[i] = 0;
            var game = input[i][(input[i].IndexOf(':') + 1)..];
            var games = game.Split('|');
            var winning = games[0].Trim().Split(' ');
            var own = games[1].Trim().Split(' ');
            foreach (var number in own)
            {
                if (!string.IsNullOrEmpty(number) && winning.Contains(number))
                {
                    points[i] ++;
                }
            }
        }
        return points;
    }
}
