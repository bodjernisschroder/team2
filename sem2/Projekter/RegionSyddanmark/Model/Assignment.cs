using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Model
{
    public class Assignment
    {
        public Region Region { get; set; }
        public int RegionalID { get; set; }
        public Type Type { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        //public DateTime ServiceGoal { get; set; }

        public Assignment(Region region, int regionalID, Type type, string description, DateTime scheduledDateTime, string fromAddress, string toAddress)
        {
            this.Region = region;
            this.RegionalID = regionalID;
            this.Type = type;
            this.Description = description;
            this.ScheduledDateTime = scheduledDateTime;
            this.FromAddress = fromAddress;
            this.ToAddress = toAddress;
            //this.ServiceGoal = serviceGoal;
        }
    }
}
