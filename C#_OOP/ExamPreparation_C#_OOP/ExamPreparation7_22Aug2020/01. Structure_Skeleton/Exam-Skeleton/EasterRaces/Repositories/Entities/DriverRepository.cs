﻿using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> models = new List<IDriver>();

        public void Add(IDriver model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return models.AsReadOnly();
        }

        public IDriver GetByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDriver model)
        {
            return models.Remove(model);
        }
    }
}
