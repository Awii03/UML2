using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UML2
{
    public class UserDialog
    {
        MenuCatalog _menuCatalog;
        public UserDialog(MenuCatalog menuCatalog)
        {
            _menuCatalog = menuCatalog;
        }

        Pizza Updatepizza()
        {
            {
                Pizza pizzaItem = new Pizza();
                Console.Clear();
                Console.WriteLine("----------------------");
                Console.WriteLine("| Update  Pizza     |");
                Console.WriteLine("-----------------------");
                _menuCatalog.PrintMenu();
                Console.Write("Enter new pizza number: ");
                pizzaItem.Number = Int32.Parse(Console.ReadLine());


                string input = "";
                Console.WriteLine("enter new name");
                try
                {
                    input = Console.ReadLine();
                    pizzaItem.Name = (input);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                    throw;
                }

                input = "";
                Console.Write("Enter new pizza price: ");
                try
                {
                    input = Console.ReadLine();
                    pizzaItem.Price = Int32.Parse(input);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                    throw;
                }

                return pizzaItem;
            }


        }

        Pizza Deletepizza() 
        { 
        Pizza pizzaItem = new Pizza(); 
        Console.Clear();
            Console.WriteLine("----------------------");
        Console.WriteLine("| Delete Pizza     |");
        Console.WriteLine("-----------------------");
            _menuCatalog.PrintMenu();
        Console.Write("Enter pizza number: ");
        

        string input = "";
            
            try
            {
                input = Console.ReadLine();
                pizzaItem.Number = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            //input = "";
            //Console.Write("Enter pizza number: ");
            //try
            //{
            //    input = Console.ReadLine();
            //    pizzaItem.Number = Int32.Parse(input);
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
            //    throw;
            //}

            return pizzaItem;
        }


    

        Pizza GetNewPizza()
        {
            Pizza pizzaItem = new Pizza();
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("| Creating Pizza      |");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.Write("Enter name: ");
            pizzaItem.Name = Console.ReadLine();

            string input = "";
            Console.Write("Enter price: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("Enter pizza number: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Number = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            return pizzaItem;
        }
        int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("| KILLER PIZZAMENU |");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("Options:");
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }

            Console.Write("Enter option#: ");
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }
            return -1;
        }
        public void Run()
        {
            bool proceed = true;
            List<string> mainMenulist = new List<string>()
            {
                "0. Quit",
                "1. Create new pizza",
                "2. Print menu",
                "3. Update pizza",
                "4. Delete pizza"
            };

            while (proceed)
            {
                int MenuChoice = MainMenuChoice(mainMenulist);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 0:
                        proceed = false;
                        Console.WriteLine("Quitting");
                        break;
                    case 1:
                        try
                        {
                            Pizza pizza = GetNewPizza();
                            _menuCatalog.Create(pizza);
                            Console.WriteLine($"You created: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"No pizza created");
                        }
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        _menuCatalog.PrintMenu();
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 3:
                        //Console.WriteLine($"You selected: {mainMenulist[MenuChoice]}");
                        //Console.Write("Hit any key to continue");
                        //Console.ReadKey();
                        try
                        {
                            Pizza pizza = Updatepizza();
                            _menuCatalog.Update(pizza);
                            Console.WriteLine($"you have updated: {pizza}");
                        }
                        catch(Exception) 
                        {
                            Console.WriteLine("no pizza to update");
                        }
                        Console.WriteLine("hit any key to continue");
                        Console.ReadKey();
                        break;
                        case 4:
                        try
                        {
                            Pizza pizza = Deletepizza();
                            _menuCatalog.Delete(pizza);
                            Console.Write($"U have deleted: { pizza}");

                        }
                        catch(Exception)
                        {
                            Console.WriteLine("No pizza to delete");
                        }
                        Console.WriteLine("hit any key to continue");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("hit any ket to continue");
                        Console.ReadKey(); 
                        break;
                       
                        
                    
                }
            }

        }
    }
}
