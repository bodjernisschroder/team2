namespace RegionSyd.Model
{
    public class Assignment
    {
        public int RegionId { get; set; }
        public int RegionalId { get; set; }
        public int TypeId { get; set; }
        public int ComboId { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string ServiceGoal { get; set; }
    }
}