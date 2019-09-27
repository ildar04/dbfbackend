﻿using System;
using System.Collections.Generic;
using System.Linq;
using Volunteer.BLModels.Entities;
using Volunteer.MainModule.Managers.DataManagers;

namespace TempDAL
{
    public class UserDataManager : IDataManager<User>
    {
        private static List<User> tempStore = new List<User>();

        public IEnumerable<User> GetAll(Predicate<User> filterPredicate = null)
        {
            if (filterPredicate == null)
            {
                return tempStore;
            }

            return tempStore.Where(i => filterPredicate.Invoke(i));
        }

        public bool Save(User enitity)
        {
            var exists = tempStore.FirstOrDefault(i => i.Uid == enitity.Uid);
            if (exists == null)
            {
                tempStore.Add(enitity);
            }
            else
            {
                tempStore.Remove(exists);
                tempStore.Add(enitity);
            }
            return true;
        }
    }
}
