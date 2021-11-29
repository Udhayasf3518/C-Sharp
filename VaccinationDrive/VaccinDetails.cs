﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    class VaccinDetails
    {
        public DateTime Date { get; set; }
        public Vaccine Type { get; set; }

        public VaccinDetails(Vaccine type,DateTime date)
        {
            this.Date = date;
            this.Type = type;
        }
    }

    /// <summary>
    /// Enum for VaccinTypes
    /// </summary>
    public enum Vaccine
    {
        CovinShild = 1,
        Covaxin
    }
}
