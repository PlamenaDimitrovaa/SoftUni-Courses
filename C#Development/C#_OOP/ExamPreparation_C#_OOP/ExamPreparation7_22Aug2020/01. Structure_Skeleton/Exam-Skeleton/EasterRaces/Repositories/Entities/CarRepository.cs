using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models = new List<ICar>();
        public void Add(ICar model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return models.AsReadOnly();
        }

        public ICar GetByName(string name)
        {
            return models.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }
    }
}
