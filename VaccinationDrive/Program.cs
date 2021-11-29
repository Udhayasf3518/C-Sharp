using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            Program  userObj = new Program();
             userObj.UserDetails();
            string c;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("--->> Covid Vaccination System <<-----");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(" 1. Benificary details \n 2. Vaccination \n 3. Exit");
                Console.WriteLine("--------------------------------------");
                Console.Write("Enter Your Option : ");
                int o = int.Parse(Console.ReadLine());

                switch (o)
                {
                    case 1:
                         userObj.Details();
                        break;
                    case 2:
                         userObj.Vaccination();
                        break;
                    case 3:
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("------->> Invalid Option <<----------");
                        break;
                }
                Console.WriteLine("--------------------------------------");
                Console.Write("Do you want to continue ?(yes/no) : ");
                c = Console.ReadLine().ToLower();
            }
            while (c == "yes");


            Console.ReadKey();
        }

        private List<Benificary> benificaryList = new List<Benificary>();

        public void UserDetails()
        {
            var firstUser = new Benificary("Udhaya", 12345, "Karur", 23, (Gen)1);
            var seconduser = new Benificary("Kamala", 67890, "Chennai",35, (Gen)2);


            benificaryList.Add(firstUser);
            benificaryList.Add(seconduser);
        }

        /// <summary>
        /// user details
        /// </summary>
        public void Details()
        {
            string o;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.Write("Enter Your Name :");
                string name = Console.ReadLine();
                Console.Write("Enter Your Mobile Number : ");
                long phoneNumber = Int64.Parse(Console.ReadLine());
                Console.Write("Enter Your City : ");
                string city = Console.ReadLine();
                Console.Write("Benificary Age : ");
                int age = int.Parse(Console.ReadLine());
                Console.Write(" 1.Male\n 2.Female\n 3.Transgender\n 4.Others");
                Console.Write("Benificary Gender : ");
                Gen Gender = (Gen)int.Parse(Console.ReadLine());

                Console.WriteLine("--------------------------------------");

                var Details = new Benificary(name, phoneNumber, city, age, Gender);
                benificaryList.Add(Details);

                Console.WriteLine("--------Registration Success--------");
                Console.WriteLine($"Your Register Number : {Details.RegNumber}");
                Console.WriteLine("--------------------------------------");

                Console.Write("\nDo You Want to Continue ? ( yes / no ) : ");
                o = Console.ReadLine().ToLower();
            }
            while (o == "yes");
        }



        /// <summary>
        /// Vaccine details
        /// </summary>

        public void Vaccination()
        {
            string o;
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("------->> Vaccine Details <<----------");
            Console.WriteLine("--------------------------------------");
            Console.Write("Register Number : ");
            int RegNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("--------------------------------------");
            foreach (Benificary details in benificaryList)
            {
                if (details.RegNumber == RegNumber)
                {
                    Console.WriteLine($"Welcome Mr/Ms : {details.Name}");
                    Console.WriteLine("--------------------------------------");
                    do
                    {
                        Console.WriteLine(" 1. Take vaccination\n 2. Vaccination History\n 3. Next Due Date\n 4. Exit");
                        Console.WriteLine("--------------------------------------");
                        Console.Write("Enter Your Option : ");
                        int a = int.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("Which Vaccine Do you Want ? ");
                                Console.WriteLine(" 1. CovinShild\n 2. Covaxin\n 3. Sputnic");
                                Console.WriteLine("--------------------------------------");
                                Console.Write("Enter Your Option : ");
                                Vaccine type = (Vaccine)int.Parse(Console.ReadLine());
                                Console.WriteLine("--------------------------------------");
                                if (details.RegNumber == RegNumber)
                                {
                                    VaccinDetails user = new VaccinDetails(type, DateTime.Now);

                                    if (details.VaccinDetails == null)
                                    {
                                        details.VaccinDetails = new List<VaccinDetails>();
                                    }
                                    details.VaccinDetails.Add(user);
                                }
                                Console.WriteLine("----->> You Have Vaccinated Succesfully <<-----");
                                break;
                            case 2:
                                History(RegNumber);
                                break;
                            case 3:
                                DueDate(RegNumber);
                                break;
                            case 4:

                            default:
                                Console.WriteLine("Invalid Option");
                                break;

                        }
                        Console.WriteLine("--------------------------------------");
                        Console.Write("Do you want to continue ? ( yes / no ) : ");
                        o = Console.ReadLine().ToLower();
                    }
                    while (o == "yes");
                }
            }
        }
        /// <summary>
        /// Due date
        /// </summary>
        /// <param name="regno"></param>
        public void DueDate(int regno)
        {
            foreach (Benificary detail in benificaryList)
            {
                if (detail.RegNumber == regno)
                {
                    if (detail.VaccinDetails != null)
                    {
                        if (detail.VaccinDetails.Count == 1)
                        {
                            Console.WriteLine($"Next Vaccine Due :{0}", detail.VaccinDetails[0].Type);
                            Console.WriteLine($"Next Due date :{0}", detail.VaccinDetails[0].Date.AddDays(15));
                        }

                        else if (detail.VaccinDetails.Count == 2)
                        {
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("----->> You Have Completed The Vaccination Course <<------");

                        }
                    }
                }
            }
        }
        /// <summary>
        /// History
        /// </summary>
        /// <param name="RegNumber"></param>
        public void History(int RegNumber)
        {
            foreach (Benificary detail in benificaryList)
            {
                if (detail.RegNumber == RegNumber)
                {
                    if (detail.VaccinDetails != null)
                    {
                        Console.WriteLine($"Name : {detail.Name}\n" +$"Age : {detail.Age}\n" +$"Gender : {detail.Gender}\n" + $"Mobile Number : {detail.PhoneNumber} \n" + $"City : {detail.City}\n" + $"Vaccination : {detail.VaccinDetails[0].Type}");
                    }
                }
            }
        }
    }
}

