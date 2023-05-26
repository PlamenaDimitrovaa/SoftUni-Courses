﻿using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Entities;

namespace HouseRentingSystem.Services.Agents
{
    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext data;

        public AgentService(HouseRentingDbContext data)
       => this.data = data;

        public void Create(string userId, string phoneNumber)
        {
            var agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            this.data.Agents.Add(agent);
            this.data.SaveChanges();
        }

        public bool ExistsById(string userId)
        => this.data.Agents.Any(a => a.User.Id == userId);

        public bool UserHasRents(string userId)
        => this.data.Houses.Any(h => h.RenterId == userId);

        public bool UserWithPhoneNumberExists(string phoneNumber)
        => this.data.Agents.Any(a => a.PhoneNumber == phoneNumber);
    }
}
