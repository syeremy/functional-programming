namespace Demo
{
    public interface IPriceCurve
    {
        Amount GetPrice(decimal atPoint);
    }
}
