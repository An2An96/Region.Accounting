namespace Region.Accounting.Controllers.Dto
{
    public class CreateSoftwareDto
    {
        public string Vendor { get; set; }
        public string Name { get; set; }
        public SoftwareKindDto Kind { get; set; }
        public SoftwareTypeDto Type { get; set; }
    }
}