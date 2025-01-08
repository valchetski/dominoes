# dominoes

## Challenge:
Given a random set of dominos, compute a way to order the set in such a way that they form a correct circular domino chain. For every stone the dots on one half of a stone match the dots on the neighboring half of an adjacent stone.
For example given the stones [2|1], [2|3] and [1|3] you should compute something like [1|2] [2|3] [3|1] or [3|2] [2|1] [1|3] or [1|3] [3|2] [2|1] etc, where the first and last numbers are the same meaning they’re in a circle.
For stones [1|2], [4|1] and [2|3] the resulting chain is not valid: [4|1] [1|2] [2|3]'s first and last numbers are not the same so it’s not a circle.

Write a program in C# which computes the chain for a random set of dominos. If a circular chain is not possible the program should output this.
