﻿namespace Volunteer.DirtyData
{
    public static class TempDataInitializer
    {
        public static void Initialize()
        {
            ActivitiesData.InitializeTempData();
            UserData.InitializeTempData();
            MarkData.InitializeTempData();
        }
    }
}
