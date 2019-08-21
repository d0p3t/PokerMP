namespace PokerMP.Interfaces
{
    public interface IDeepCloneable<out T>
    {
        T DeepClone();
    }
}
