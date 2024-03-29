﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> internalItems;
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            internalItems = new List<Item>();
            this.Items = new ReadOnlyCollection<Item>(internalItems);
        }
        public int Capacity { get; set; }

        public int Load => Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items { get; }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            internalItems.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item resultItem = this.Items.FirstOrDefault(i => i.GetType().Name == name);
            if (resultItem == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.internalItems.Remove(resultItem);
            return resultItem;
        }
    }
}
