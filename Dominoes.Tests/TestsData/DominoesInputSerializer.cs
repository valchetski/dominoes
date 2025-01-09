namespace Dominoes.Tests.TestsData;

/// <summary>
/// Set of helper methods that improve readability of input and output in tests.
/// That class could be part of the console app project. But for the simplicity I didn't create that project and have everything in tests.
/// </summary>
public static class DominoesInputSerializer
{
    /// <summary>
    /// Parses string input to list of objects.
    /// </summary>
    /// <param name="input">Input string.<example>2|1 2|3 1|3</example></param>
    /// <returns>List of objects.</returns>
    public static List<Domino> ToDominoesList(this string input)
    {
        return input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(item =>
            {
                var numbers = item.Split('|', StringSplitOptions.RemoveEmptyEntries);
                return new Domino(int.Parse(numbers[0]), int.Parse(numbers[1]));
            })
            .ToList();
    }

    public static string ToDominoesRawString(this List<Domino> dominoes)
    {
        return string.Join(' ', dominoes.Select(x => $"{x.Left}|{x.Right}"));
    }
}