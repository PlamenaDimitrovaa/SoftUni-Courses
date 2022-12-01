﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;
using System.Xml.Serialization;
using Theatre.Data.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class CastXmlInputModel
    {
        [XmlElement("FullName")]
        [Required]
        [StringLength(30, MinimumLength = 4 )]
        public string FullName { get; set; }

        [XmlElement("IsMainCharacter")]
        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression("^\\+44-[0-9]{2}-[0-9]{3}-[0-9]{4}$")]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}




