namespace Demo.Finance
{
    public class NonSpecificEmpty : Money
    {
        private NonSpecificEmpty() { }

        public static NonSpecificEmpty Zero => new NonSpecificEmpty();
    }
}
