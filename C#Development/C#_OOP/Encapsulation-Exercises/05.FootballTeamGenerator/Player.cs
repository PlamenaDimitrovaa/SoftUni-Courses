using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Endurance
        {
            get => this.endurance;
            private set
            {
                ValidateStats(nameof(Endurance), value);
                endurance = value; 
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set 
            {
                ValidateStats(nameof(Sprint), value);
                sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set 
            {
                ValidateStats(nameof(Dribble), value);
                dribble = value; 
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                ValidateStats(nameof(Passing), value);
                passing = value; 
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set 
            {
                ValidateStats(nameof(Shooting), value);
                shooting = value;
            }
        }

        private void ValidateStats(string statName, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }

        public double Stats => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
    }
}
