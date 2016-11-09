using System;
using System.Linq;

namespace DesignPatterns
{
    class StockOverivew
    {
        static Stock _stock;

        //private static void SwitchCommand(string input)
        //{
        //    string Input = input.Trim().ToLower().Split(' ').First();
        //    Products type;
        //    switch (Input)
        //    {
        //        case "stock":
        //            string[] allOrCategory = Input.Split(' ');
        //            if (allOrCategory.Length == 1)
        //            {
        //                _stock.PrintInventory();
        //            }
        //            else
        //            {
        //                _stock.PrintInventory(allOrCategory[1]);
        //            }
        //            break;
        //        case "add":
        //            string name = Input.Split(' ')[1];
        //            string price = Input.Split(' ')[2];
        //            string category = Input.Split(' ')[3];
        //            type = (Products)Enum.Parse(typeof(Products), Input.Split(' ')[4]);

        //            _stock.Add(name, price, type);
        //            break;
        //        case "delete":
        //            int id = int.Parse(Input.Split(' ')[1]);
        //            type = (Products)Enum.Parse(typeof(Products), Input.Split(' ')[2]);
        //            _stock.Delete(id, type);
        //            break;
        //        default:
        //            Console.WriteLine("Wrong input");
        //            break;

        //    }
        //}

        public static void Main(string[] args)
        {
            if (_stock == null)
            {
                _stock = new Stock("database.json");
            }
            string command = "";
            while (command.ToLower() != "exit")
            {
                command = Console.ReadLine();
                if (command == "add")
                {
                    _stock.Add("Banan", 20, 2, "Frugt");
                    _stock.PrintInventory();
                    //Console.WriteLine(_stock.CalculateStockWorth());
                }
                //SwitchCommand(command);

                //    if (command.ToLower().Contains("stock"))
                //    {
                //        string[] allOrCategory = command.Split(' ');
                //        if (allOrCategory.Length == 1)
                //        {
                //            _stock.PrintInventory();
                //        }
                //        else
                //        {
                //            _stock.PrintInventory(allOrCategory[1]);
                //        }
                //    }
                //    else if (command.ToLower().Contains("addhat"))
                //    {
                //        string name = command.Split(' ')[1];
                //        string price = command.Split(' ')[2];
                //        string category = command.Split(' ')[3];
                //        _stock.HatDatabase.Create(new Hat() {Name = name, Price = int.Parse(price), Category = category});
                //    }
                //    else if (command.ToLower().Contains("deleteHat"))
                //    {
                //        string id = command.Split(' ')[1];
                //        Hat toRemove = _stock.HatDatabase.Read(int.Parse(id));
                //        _stock.HatDatabase.Delete(toRemove);
                //    }
                //    else if (command.ToLower().Contains("addShoe"))
                //    {
                //        string name = command.Split(' ')[1];
                //        string price = command.Split(' ')[2];
                //        string category = command.Split(' ')[3];
                //        _stock.ShoeDatabase.Create(new Shoe() { Name = name, Price = int.Parse(price), Category = category });
                //    }
                //    else if (command.ToLower().Contains("deleteShoe"))
                //    {
                //        string id = command.Split(' ')[1];
                //        Shoe toRemove = _stock.ShoeDatabase.Read(int.Parse(id));
                //        _stock.ShoeDatabase.Delete(toRemove);
                //    }
                //    else if (command.ToLower().Contains("addBannana"))
                //    {
                //        string name = command.Split(' ')[1];
                //        string price = command.Split(' ')[2];
                //        string category = command.Split(' ')[3];
                //        _stock.BannnanaDatabase.Create(new Bannana() { Name = name, Price = int.Parse(price), Category = category });
                //    }
                //    else if (command.ToLower().Contains("deleteBanana"))
                //    {
                //        string id = command.Split(' ')[1];
                //        Bannana toRemove = _stock.BannnanaDatabase.Read(int.Parse(id));
                //        _stock.BannnanaDatabase.Delete(toRemove);
                //    }

                //    else
                //    {
                //        Console.WriteLine("Unknown command.");
                //    }
            }
        }
    }
}