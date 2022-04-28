using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		// TODO: Implement the rest of the class.
		private readonly double baseHealth;
		private readonly double baseArmor;
		protected readonly double abilityPoints;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			Name = name;
			Health = health;
			baseArmor = armor;
			Armor = armor;
			this.abilityPoints = abilityPoints;
			this.Bag = bag;
        }

		private string name;
		private double health;
		private double armor;

        public double BaseArmor { get => baseArmor; }
		public double BaseHealth { get => baseHealth; }
		public double AbilityPoints { get => abilityPoints; }
        public string Name
		{
            get
            {
				return name;
            }
			private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

				name = value;
            } 
		}
        public double Health
		{
			get => health;
            set
            {
                if (value < 0)
                {
					health = 0;
                }
                else if (value > baseHealth)
                {
					health = baseHealth;
                }
                else
                {
					health = value;
                }
            }
		}
		public double Armor
		{
			get => armor;
			set
			{
				if (value < 0)
				{
					armor = 0;
				}
                else
                {
					armor = value;
                }
			}
		}

        public IBag Bag { get; }
        public bool IsAlive { get; set; } = true;

		public virtual void UseItem(Item item)
        {
			this.EnsureAlive();
			item.AffectCharacter(this);
        }

		public virtual void TakeDamage(double hitpoints)
        {
			this.EnsureAlive();
			double healthReduce = hitpoints - this.Armor;
			this.Armor -= hitpoints;
            if (healthReduce > 0)
            {
				this.Health -= healthReduce;
            }

            if (this.Health == 0)
            {
				this.IsAlive = false;
            }
        }

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}