﻿using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.decorations;

        public void Add(IDecoration model)
            => this.decorations.Add(model);

        public IDecoration FindByType(string type)
            => this.decorations.FirstOrDefault(m => m.GetType().Name == type);

        public bool Remove(IDecoration model)
            => this.decorations.Remove(model);
    }
}
