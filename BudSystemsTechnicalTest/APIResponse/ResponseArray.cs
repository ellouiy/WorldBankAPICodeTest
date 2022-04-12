namespace BudSystemsTechnicalTest
{
    public struct ResponseArray
    {
        public Paging Header;
        public Country[] Country;

        public static implicit operator ResponseArray(Paging header) => new ResponseArray
        {
            Header = header
        };

        public static implicit operator ResponseArray(Country[] country) => new ResponseArray
        {
            Country = country
        };
    }
}