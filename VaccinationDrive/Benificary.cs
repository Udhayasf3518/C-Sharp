using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    class Benificary
    {
        private int RegisterNumber = 100;
        public int RegNumber;
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public Gen Gender { get; set; }

        
        public List<VaccinDetails> VaccinDetails { get; set; }

        public Benificary(string name,long phone,string city,int age,Gen gender)
        {
            this.Name = name;
            this.PhoneNumber = phone;
            this.City = city;
            this.Age = age;
            this.Gender = gender;
            this.RegNumber = RegisterNumber++;
        }

    }
    /// <summary>
    /// Enum for Gender
    /// </summary>
    public enum Gen
    {
        Male = 1,
        Female,
        Transgender,
        Others
    }
}
