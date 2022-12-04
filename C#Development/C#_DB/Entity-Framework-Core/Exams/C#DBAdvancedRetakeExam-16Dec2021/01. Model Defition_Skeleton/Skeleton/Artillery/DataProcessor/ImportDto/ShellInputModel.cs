using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{

    [XmlType("Shell")]
    public class ShellInputModel
    {
        [XmlElement("ShellWeight")]
        [Range(2, 1680)]
        public double ShellWeight { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        [XmlElement("Caliber")]
        public string Caliber { get; set; }
    }
}
