using Footballers.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ExportDto
{
    public class TeamJsonOutputModel
    {
        public string Name { get; set; }
        public List<FootballerJsonOutputModel> Footballers { get; set; }
    }
}
