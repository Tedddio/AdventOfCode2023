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
            var firstDigit = GetFirstDigit(s);
            var lastDigit = GetFirstDigit(s.Reverse());
            sum += int.Parse($"{firstDigit}{lastDigit}");
        };
        return sum;
    }

    private char GetFirstDigit(IEnumerable<char> line)
    {
        foreach (var character in line)
        {
            if (char.IsDigit(character))
            {
                return character;
            }

        }
        throw new Exception($"Found no digit in {line}");
    }

}
