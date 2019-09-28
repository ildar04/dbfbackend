﻿namespace Volunteer.Api.ViewModels.Activity
{
    using System;
    using System.Collections.Generic;

    public class ActivityViewModel
    {
        public Guid Uid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public RatingViewModel Rating { get; set; }
        public DateTime AddDateTime { get; set; }
        public int CommentCount { get; set; }
        public int Mark { get; set; }
        public IEnumerable<UserViewModel> Organizers { get; set; }
        public IEnumerable<UserViewModel> Volunteers { get; set; }
    }
}