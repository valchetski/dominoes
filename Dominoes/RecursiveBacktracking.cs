namespace Dominoes;

public static class RecursiveBacktracking
{
    public static List<Domino>? FindCircularDominoesChain(List<Domino> dominoes)
    {
        if (dominoes.Count == 0)
        {
            return null;
        }
        
        var chain = new List<Domino>();
        return Backtrack(dominoes, chain) ? chain : null;
    }

    private static bool Backtrack(List<Domino> dominoes, List<Domino> chain)
    {
        if (dominoes.Count == 0)
        {
            return chain.First().Left == chain.Last().Right;
        }

        for (var i = 0; i < dominoes.Count; i++)
        {
            var current = dominoes[i];
            dominoes.RemoveAt(i);

            if (chain.Count == 0 || chain.Last().Right == current.Left)
            {
                chain.Add(current);
                if (Backtrack(dominoes, chain))
                {
                    return true;
                }
                chain.RemoveAt(chain.Count - 1);
            }

            if (chain.Count == 0 || chain.Last().Right == current.Right)
            {
                chain.Add(new Domino(current.Right, current.Left));
                if (Backtrack(dominoes, chain))
                {
                    return true;
                }
                chain.RemoveAt(chain.Count - 1);
            }

            dominoes.Insert(i, current);
        }

        return false;
    }
}