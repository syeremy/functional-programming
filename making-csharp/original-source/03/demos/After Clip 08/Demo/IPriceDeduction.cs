namespace Demo
{
    public interface IPriceDeduction
    {
        Amount ApplyTo(Amount price);
    }
}
