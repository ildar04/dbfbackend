﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DobrfDownloadModule.DobrfModels
{
    public class @event
    {
        public photo image { get; set; }
        public author author { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }
}
