using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //public Assignment(Region region, int regionalID, Type type, string description, DateTime scheduledDateTime, string fromAddress, string toAddress)
        //{
        //    this.Region = region;
        //    this.RegionalID = regionalID;
        //    this.Type = type;
        //    this.Description = description;
        //    this.ScheduledDateTime = scheduledDateTime;
        //    this.FromAddress = fromAddress;
        //    this.ToAddress = toAddress;
        //    //this.ServiceGoal = serviceGoal;
        //}
    }
}
