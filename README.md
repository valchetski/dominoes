# Dominoes

## Challenge
Given a random set of dominos, compute a way to order the set in such a way that they form a correct circular domino chain. For every stone the dots on one half of a stone match the dots on the neighboring half of an adjacent stone.
For example given the stones [2|1], [2|3] and [1|3] you should compute something like [1|2] [2|3] [3|1] or [3|2] [2|1] [1|3] or [1|3] [3|2] [2|1] etc, where the first and last numbers are the same meaning they’re in a circle.
For stones [1|2], [4|1] and [2|3] the resulting chain is not valid: [4|1] [1|2] [2|3]'s first and last numbers are not the same so it’s not a circle.

Write a program in C# which computes the chain for a random set of dominos. If a circular chain is not possible the program should output this.

## Assumptions
- The code challenge implemented in a way to keep it simple and readable.
- In code challenge description wasn't mentioned if the program should be console app or web api. Decided to go with the simplest approach and just added Tests to Class Library project. Tests can be used to run and test algorithms.
- All dominoes should be part of the circular chain. For example, in `[2|1] [1|3] [3|2] [4|5]` sequence subset of `[2|1] [1|3] [3|2]` will form correct circular chain. However, with `[4|5]` domino chain is not possible. In that case, program will return a value indicating that circular chain is not possible.

## Solution description
I've chosen to use two algorithms to solve the task:
- Eulerian circuit
- Recursive backtracking

Created `Dominoes.Benchmarks` project and added benchmarks to test the performance of each method.

Results are below:

| Method                    | rawInput             | Mean        | Error     | StdDev    | Median      | Gen0   | Allocated |
|-------------------------- |--------------------- |------------:|----------:|----------:|------------:|-------:|----------:|
| EulerianCircuitTest       | 2\|1 1\|3 3\|2       |  1,952.0 ns | 100.12 ns | 290.45 ns |  1,826.6 ns | 0.2365 |    1504 B |
| RecursiveBacktrackingTest | 2\|1 1\|3 3\|2       |    755.1 ns |  15.65 ns |  44.14 ns |    751.0 ns | 0.1106 |     696 B |
| EulerianCircuitTest       | 2\|1 2\|3 1\|3       |  1,782.2 ns |  35.64 ns |  90.07 ns |  1,766.4 ns | 0.2384 |    1504 B |
| RecursiveBacktrackingTest | 2\|1 2\|3 1\|3       |    875.1 ns |  17.96 ns |  52.40 ns |    865.8 ns | 0.1144 |     720 B |
| EulerianCircuitTest       | 2\|1 6(...)4 6\|3 [23] |  3,264.8 ns |  64.54 ns |  81.62 ns |  3,253.5 ns | 0.4387 |    2752 B |
| RecursiveBacktrackingTest | 2\|1 6(...)4 6\|3 [23] |  1,949.6 ns |  38.34 ns |  47.08 ns |  1,936.7 ns | 0.2060 |    1312 B |
| EulerianCircuitTest       | 4\|2 6(...)2 1\|4 [91] | 26,943.9 ns | 522.29 ns | 641.42 ns | 26,828.4 ns | 1.9226 |   12144 B |
| RecursiveBacktrackingTest | 4\|2 6(...)2 1\|4 [91] |  7,667.3 ns | 147.72 ns | 181.42 ns |  7,668.7 ns | 0.7248 |    4584 B |

As we can see from the table backtracking algorithm was more performant and used less memory.