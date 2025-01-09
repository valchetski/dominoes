using System.Collections;

namespace Dominoes.Tests.TestsData;

public class DominoesInvalidTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [""];
        yield return ["2|1"];
        yield return ["2|1 4|3"];
        yield return ["2|1 1|3 3|2 4|5"]; // it has chain with 3 dominoes out of 4, but we assume that all the dominoes must be in circle
        yield return ["2|1 6|5 2|3 4|5 1|4"];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}