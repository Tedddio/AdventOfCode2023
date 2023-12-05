using System.Diagnostics;

namespace AoC2023;

public class Day02
{
   private readonly string[] input;
    private readonly Stopwatch timer;

    private IDictionary<int, string> maxItems;

    public Day02()
    {
        timer = new Stopwatch();
        input = File.ReadAllLines("inputs/day02.txt");
        maxItems = GetMaxItems();
    }

    public void Solve()
    {
        timer.Start();
        var result1 = SolveProblem1();
        Console.WriteLine($"Day 2 result 1 is {result1}. Completed in {timer.Elapsed}");
        timer.Restart();
        var result2 = SolveProblem2();
        Console.WriteLine($"Day 2 result 2 is {result2}. Completed in {timer.Elapsed}");
    }

    private int SolveProblem1()
    {
        var sum = 0;
        foreach (var s in input)
        {
            var isGameValid = true;
            var split = s.Split(':');
            var gameIdPart = split[0];
            var cubes = split[1].Split(',', ';');
            foreach (var cube in cubes)
            {
                var cubeSplit = cube.Trim().Split(' ');
                var number = int.Parse(cubeSplit[0]);
                var color = cubeSplit[1];
                var kvp = maxItems.First(c => c.Value == color);
                if (kvp.Key < number) {
                    isGameValid = false;
                    break;
                }
            }
            sum += isGameValid ? int.Parse(string.Concat(gameIdPart.Where(char.IsDigit))) : 0;
        }
        return sum;
    }

    private int SolveProblem2()
    {
        var sum = 0;
        foreach (var s in input)
        {
            var dict = InitializeGameDictionnary();
            var split = s.Split(':');
            var gameIdPart = split[0];
            var cubes = split[1].Split(',', ';');
            foreach (var cube in cubes)
            {
                var cubeSplit = cube.Trim().Split(' ');
                var number = int.Parse(cubeSplit[0]);
                var color = cubeSplit[1];
                var kvp = dict.First(c => c.Key == color);
                if (kvp.Value < number) {
                   dict[kvp.Key] = number;
                }
            }
            sum += dict.Values.Aggregate(1, (current, next) => current * next);
        }
        return sum;
    }

    private IDictionary<string, int> InitializeGameDictionnary()
    {
        return new Dictionary<string, int>() {
            {"red", 0},
            {"green", 0},
            {"blue", 0}, 
        };
    }

    private IDictionary<int, string> GetMaxItems()
    {
        return new Dictionary<int, string>() {
            {12, "red"},
            {13, "green"},
            {14, "blue"},
        };
    }
}
