namespace Dominoes;

public class Domino(int left, int right)
{
    public int Left { get; private set; } = left;
    public int Right { get; private set; } = right;
    
    public void Reverse()
    {
        (Left, Right) = (Right, Left);
    }
}