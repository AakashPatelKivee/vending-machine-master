namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.Reflection.Metadata;
    using System.Text;
    using System.Xml;

    public class SubMenu
    {
        public VendingMachine vm;

        public SubMenu(VendingMachine vm)
        {
            this.vm = vm;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press any key to move back");
                Console.WriteLine();
                Console.WriteLine("Please choose from the following options:");
                Console.WriteLine("1] >> Feed Money");
                Console.WriteLine("2] >> Select Product");
                Console.WriteLine("3] >> Finish Transaction");
                Console.WriteLine("Q] >> Return to Main Menu");
                Console.WriteLine($"Money in Machine: {this.vm.MoneyInMachine.ToString("C")}");
                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine(">>>>>> How much do you want to insert?");
                    while (true)
                    {
                        Console.Write("1, 2, 5, 10 dollars($)? ");
                        string amountToSubmit = Console.ReadLine();
                        if (amountToSubmit == "1"
                            || amountToSubmit == "2"
                            || amountToSubmit == "5"
                            || amountToSubmit == "10")
                        {
                            if (!this.vm.Money.AddMoney(amountToSubmit))
                            {
                                Console.WriteLine("Insert a valid amount.");
                            }
                            else
                            {
                                Console.WriteLine($"Money in Machine $: {this.vm.Money.MoneyInMachine.ToString("C")}");
                                break;
                            }
                        }
                    }

                }
                else if (input == "2")
                {
                    while (true)
                    {
                        this.vm.DisplayAllItems();
                        Console.Write(">>> What item do you want? ");
                        string choice = Console.ReadLine();
                        if (this.vm.ItemExists(choice) && this.vm.RetreiveItem(choice))
                        {
                            decimal Qut;
                            decimal mult;
                            Console.WriteLine($"Your item {this.vm.VendingMachineItems[choice].ProductName}\n  Price is {this.vm.VendingMachineItems[choice].Price}");
                            Console.WriteLine("how many items you wont (Enter Quantity)");
                            Qut = Convert.ToDecimal(Console.ReadLine());
                            mult = Qut * this.vm.VendingMachineItems[choice].Price;
                            Console.WriteLine("This is your Total={0}", mult);
                            Console.WriteLine($"This is your change $: {this.vm.Money.MoneyInMachine.ToString("C")}");
                            Console.WriteLine("Your order is successfull");
                            Console.WriteLine($"Enjoy Your {this.vm.VendingMachineItems[choice].ProductName}\n{this.vm.VendingMachineItems[choice].MessageWhenVended}");

                            while (true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Gave feedback\n");
                                Console.WriteLine("1 For Machine related\n");
                                Console.WriteLine("2 For Money related\n");
                                Console.WriteLine("3 For Items Related\n");
                                string v = Console.ReadLine();
                                if (v == "1")
                                {
                                    Console.WriteLine("Machine not a bed working" );
                                    Console.WriteLine("Good is  Working Machine");
                                }
                                else if (v == "2")
                                {
                                    Console.WriteLine("Money can not back or coine is not back");
                                    Console.WriteLine("All Works are succsses");
                                }
                                else if (v == "3")
                                {
                                    Console.WriteLine("items are not avalable");
                                    Console.WriteLine("items are Expiare date");
                                }
                                else
                                {
                                    Console.WriteLine("Please try again");
                                }

                                Console.WriteLine("Thank you for gaven FeedBack.");
                                Console.WriteLine("if back to rebuy any item press any key two time to move back");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            break;
                        }
                        if (!this.vm.ItemExists(choice))
                        {
                            Console.Clear();
                            Console.WriteLine("**INVALID ITEM**");
                            Console.WriteLine("Not regestred any item on this number(if back to re enter the system press any key two times)");
                            break;
                        }
                       else if (this.vm.ItemExists(choice) && this.vm.Money.MoneyInMachine > this.vm.VendingMachineItems[choice].Price)
                        {
                            Console.WriteLine(this.vm.VendingMachineItems[choice].MessageWhenSoldOut);
                            Console.WriteLine("You do not have money so you not buy items so First You feed a money balance");
                        }
                        else if (this.vm.Money.MoneyInMachine < this.vm.VendingMachineItems[choice].Price)
                        {
                            Console.WriteLine(this.vm.NotEnoughMoneyError);
                            Console.WriteLine("Sorry Machine is not working. Machine is working Mood"); 
                            break;
                        }
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("Finishing Transaction");
                    Console.WriteLine(this.vm);
                }
                else if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Returning to main menu");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
            }

        }
    }
}
