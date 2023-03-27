using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ExportDto
{
    public class ExportJsonTeamDto
    {
        public string Name { get; set; }
        public List<ExportJsonFootballerDto> Footballers { get; set; }
    }
}
