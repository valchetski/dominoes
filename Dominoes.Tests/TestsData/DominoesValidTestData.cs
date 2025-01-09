﻿using System.Collections;

namespace Dominoes.Tests.TestsData;

public class DominoesValidTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [
            "2|1 1|3 3|2",
            "2|1 1|3 3|2"];
        
        yield return [
            "2|1 2|3 1|3",
            "2|1 1|3 3|2"];

        yield return [
            "2|1 6|5 2|3 4|5 1|4 6|3",
            "2|1 1|4 4|5 5|6 6|3 3|2"];

        yield return [
            "4|2 6|1 2|6 4|5 2|3 6|3 1|4 3|1 2|6 1|5 6|3 5|2 4|2 3|6 5|4 3|1 3|6 1|5 2|3 5|4 6|1 4|2 1|4",
            "4|2 2|6 6|1 1|4 4|5 5|1 1|3 3|2 2|6 6|3 3|6 6|3 3|1 1|5 5|2 2|4 4|5 5|4 4|2 2|3 3|6 6|1 1|4"];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}