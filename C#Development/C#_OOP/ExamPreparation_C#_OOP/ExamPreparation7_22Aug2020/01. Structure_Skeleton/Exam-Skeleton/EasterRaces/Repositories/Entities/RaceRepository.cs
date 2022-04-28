using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models = new List<IRace>();
        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return models.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }
    }
}
