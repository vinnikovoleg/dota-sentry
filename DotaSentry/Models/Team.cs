namespace DotaSentry.Models
{
    public class Team
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public long Score { get; set; }
        public long Lead { get; set; }
    }
}