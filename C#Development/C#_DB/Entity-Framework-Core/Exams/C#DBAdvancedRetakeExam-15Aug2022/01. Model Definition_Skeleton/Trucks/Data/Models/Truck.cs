using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Trucks.Data.Models.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }
        public int Id { get; set; }

        [StringLength(8)]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(17)]
        public string VinNumber { get; set; }
        public int TankCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public CategoryType CategoryType { get; set; }
        public MakeType MakeType { get; set; }
        public int DespatcherId { get; set; }
        public Despatcher Despatcher { get; set; }
        public ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}

