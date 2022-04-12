namespace BudSystemsTechnicalTest
{
    public class Country
    {
        public string Id { get; set; }

        public string Iso2Code { get; set; }

        public string Name { get; set; }

        public Region Region { get; set; }

        public AdminRegion AdminRegion { get; set; }

        public IncomeLevel IncomeLevel { get; set; }

        public LendingType LendingType { get; set; }

        public string CapitalCity { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}
