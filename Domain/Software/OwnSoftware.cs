namespace Region.Accounting.Domain.Software
{
    public class OwnSoftware : FreeSoftware
    {
        public OwnSoftware(string vendor, string name, SoftwareType type) : base(vendor, name, type)
        {
        }
    }
}