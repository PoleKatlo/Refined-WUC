using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUC
{
    internal class Display : Decision_Menus                                                                                                           
    {

        public void processor()
        {
            Display displayBill = new Display();
            Calculator calculator = new Calculator();

            Customer customer = new Customer("", "", "", "", "", 9);
            int option;
            option = displayBill.menuoption();
            Console.Clear();

            var Date = DateTime.Now;

            if (option == 1)
            {

                Console.WriteLine("Input Customer Details>>");
                Console.WriteLine("" +
                     "");

                Console.WriteLine("Enter Customer Name");
                Console.Write(">>>");
                customer.Name = Console.ReadLine();
                Console.WriteLine("" +
                    "");
                Console.WriteLine("Enter Customer Surname");
                Console.Write(">>>");
                customer.surname = Console.ReadLine();
                Console.WriteLine("" +
                     "");
                Console.WriteLine("Enter Customer's Location");
                Console.Write(">>>");
                customer.Location = Console.ReadLine();
                Console.WriteLine("" +
                    "");
                Console.WriteLine("Enter Customers Residential Plot");
                Console.Write(">>>");
                customer.plotno = Console.ReadLine();
                Console.WriteLine("" +
                    "");
                Console.WriteLine("Choose Customer UserType");
                Console.WriteLine("" +
                    "");
                Console.WriteLine(">>1.Domestic User");
                Console.WriteLine(">>2.Commercial/ Industrial User");
                Console.WriteLine("" +
                     "");
                Console.Write("Enter Choice>>>");
                try
                {
                    int user_type = Convert.ToInt32(Console.ReadLine());

                    if (user_type == 1)
                    {
                        customer.usertype = "Domestic";
                    }
                    else if (user_type == 2)
                    {
                        customer.usertype = "Commercial";
                    }
                    else
                    {
                        customer.usertype = "Unspecified";
                    }
                }
                catch
                {


                    customer.usertype = "Unspecified";

                }

                Console.WriteLine("" +
                    "");
                Console.WriteLine("Enter Water Used");
                Console.Write(">>>");
                //catch error user does enter a double 
                try
                {
                    customer.Water_Used = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {

                    customer.Water_Used = 0;
                }
                Console.WriteLine(customer.usertype);


                Console.Clear();
          

                Console.WriteLine(displayBill.stars());
                Console.WriteLine("       Water Utilities Corporation      ");                
                Console.WriteLine("          Customer Water Bill       ");              
                Console.WriteLine("" +
                  "");              
                Console.WriteLine("CUSTOMER DETAILS");                           
                Console.WriteLine(displayBill.starz());
                Console.WriteLine("Date :" + Date);
                Console.WriteLine("Names:" + customer.Name + " " + customer.surname);            
                Console.WriteLine("Customer Location:" + customer.Location + " " + customer.plotno);              
                Console.WriteLine("Customer UserType:" + customer.usertype + " " + "User");
                Console.WriteLine("" +
                   "");             
                Console.WriteLine("WATER BILL");            
                Console.WriteLine(displayBill.starz());             
                        Console.WriteLine("Portable Water Used      :" + customer.Water_Used + "KL");
                        Console.WriteLine("Portable Water cost      :BWP" + calculator.PortableWaterCost(customer.Water_Used, customer.usertype));             
                        Console.WriteLine("Waste Water Used         :BWP" + calculator.wastewaterCost(customer.Water_Used, customer.usertype));                         
                        Console.WriteLine("Total Cost               :BWP" + calculator.getbill(customer.Water_Used, customer.usertype));                
                        Console.WriteLine("VAT                      :14%");               
                        Console.WriteLine(displayBill.stars());             
                        Console.WriteLine("" +
                          "");             
                        Console.WriteLine(">>>Press Enter To Go Back");
                        Console.ReadLine();

                        FileStream print = new FileStream("Customer Bill.txt", FileMode.OpenOrCreate);
                        StreamWriter writer = new StreamWriter(print);
                        writer.WriteLine(displayBill.stars());
                        writer.WriteLine("       Water Utilities Corporation      ");
                        writer.WriteLine("          Customer Water Bill       ");
                        writer.WriteLine("" +
                        "");
                        writer.WriteLine("CUSTOMER DETAILS");
                        writer.WriteLine(displayBill.starz());
                        writer.WriteLine("Date :" + Date);
                        writer.WriteLine("Names:" + customer.Name + " " + customer.surname);
                        writer.WriteLine("Customer Location:" + customer.Location + " " + customer.plotno);
                        writer.WriteLine("Customer UserType:" + customer.usertype+" "+"User");
                        writer.WriteLine("" +
                        "");
                        writer.WriteLine("WATER BILL");
                        writer.WriteLine(displayBill.starz());
                        writer.WriteLine("Portable Water Used      :" + customer.Water_Used + "KL");
                        writer.WriteLine("Portable Water cost      :" + calculator.PortableWaterCost(customer.Water_Used, customer.usertype));
                        writer.WriteLine("Waste Water Used         :" + calculator.wastewaterCost(customer.Water_Used, customer.usertype));
                    writer.WriteLine("Total Cost               :BWP" + calculator.getbill(customer.Water_Used, customer.usertype));
                    writer.WriteLine("VAT                      :14%");
                    writer.WriteLine(displayBill.stars());
                    writer.Close();
                    print.Close();












                    string date = ("Date:" + Date);
                    string writeText = date;

                    string space = ("" +
                     "");
                    string writespace = space;
                    string names = ("Names:" + customer.Name + " " + customer.surname);
                    string writenames = names;
                    string location=("Customer Location:" + customer.Location + " " + customer.plotno);
                    string writelocation=location;
                    string usertype = ("UserType:" + customer.usertype+"User");
                    string writeusername = usertype;
                    string waterused = ("Amount Of Water Used: " + customer.Water_Used);
                    string writewaterused = waterused;
                    string TotalCost = ("Total Cost          :BWP" + calculator.getbill(customer.Water_Used, customer.usertype));
                    string writemonthlybill = TotalCost;

                    string stars = (displayBill.starz());
                    string writestars = stars;
                    // write into record file 

                    File.AppendAllText("Bill Records.txt", date + Environment.NewLine);
                    File.AppendAllText("Bill Records.txt", names + Environment.NewLine);
                    File.AppendAllText("Bill Records.txt", location + Environment.NewLine);
                    File.AppendAllText("Bill Records.txt", usertype + Environment.NewLine);
                    File.AppendAllText("Bill Records.txt", waterused + Environment.NewLine);
                    File.AppendAllText("Bill Records.txt", TotalCost + Environment.NewLine);
                    File.AppendAllText("Bill Records.txt", writestars + Environment.NewLine);



                    Console.WriteLine("Added To Records");
                    Console.Clear();
                    processor();


                }


                else if (option == 2)
                {
                    try
                    {
                        {
                            string Report = File.ReadAllText("Bill Records.txt");
                            Console.WriteLine(Report);
                            Console.WriteLine("" +
                             "");
                        Console.WriteLine(">>>Press Enter To Go Back");
                        Console.ReadKey();
                        Console.Clear();
                        processor();


                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("No Records Yet");
                    Console.WriteLine("" +
                         "");
                    Console.WriteLine(">>>Press Enter To Go Back");
                    Console.Read();
                    Console.Clear();
                    processor();
                }
            }
            else if (option == 3)
            {

                string Report = File.ReadAllText("Login History.txt");
                Console.WriteLine(Report);
                Console.WriteLine("" +
                 "");
                Console.WriteLine(">>>Press Enter To Go Back");
                Console.ReadKey();
                Console.Clear();
                processor();

            }

            else if (option == 4)
            {
                Console.WriteLine("Exit Application");
                Console.WriteLine("1.YES");
                Console.WriteLine("2.NO");
                int choice = (Convert.ToInt32(Console.ReadLine()));
                if (choice == 1)
                {
                    Environment.Exit(0);
                }
                else if (choice == 2)
                {
                    processor();
                }

            }

            else
            {
                Console.Clear();
                processor();
            }
        }

       
    }
}























