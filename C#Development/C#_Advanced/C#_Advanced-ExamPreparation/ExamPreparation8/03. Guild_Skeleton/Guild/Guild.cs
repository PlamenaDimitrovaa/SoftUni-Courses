using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count();

        public void AddPlayer(Player player)
        {
            if (Capacity > roster.Count())
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (roster.Exists(x => x.Name == name))
            {
                roster.Remove(roster.FirstOrDefault(x => x.Name == name));
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PromotePlayer(string name)
        {
            if (roster.Exists(x => x.Name == name && x.Rank != "Member"))
            {
                roster.FirstOrDefault(x => x.Name == name).Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (roster.Exists(x => x.Name == name && x.Rank != "Trial"))
            {
                roster.FirstOrDefault(x => x.Name == name).Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> myListTemp = new List<Player>();
            foreach (var player in this.roster)
            {
                if (player.Class == @class)
                {
                    myListTemp.Add(player);
                }
            }

            Player[] myArrayToReturn = myListTemp.ToArray();

            this.roster = this.roster.Where(x => x.Class != @class).ToList();

            return myArrayToReturn;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
