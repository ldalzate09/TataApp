﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TataApp.Models
{
    public class Time
    {
        public int TimeId { get; set; }

        public int EmployeeId { get; set; }

        public int ProjectId { get; set; }

        public int ActivityId { get; set; }

        public DateTime DateRegistered { get; set; }

        public DateTime DateReported { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string Remarks { get; set; }

        public Project Project { get; set; }

        public Activity Activity { get; set; }

        public string FromTo
        {
            get { return string.Format("{0:HH:mm} - {1:HH:mm}", From, To); }
        }

        public string ActivityTime
        {
            get { return string.Format("{0}, Hours: {1:N1}", Activity.Description, (To - From).TotalHours); }
        }
    }
}
