using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    public class Order
    {
        public int Id;
        OrderDetails Details;
        public Order(int Id, string Commodity, string Customer, int OrderPrice)
        {
            this.Id = Id;
            this.Details = new OrderDetails(Commodity, Customer, OrderPrice);
        }
        bool Equals(Order o1)
        {
            return (this.Id == o1.Id) && this.Details.Equals(o1.Details);
        }
        public override string ToString()
        {
            return "Order ID: " + Convert.ToString(this.Id) + Details.ToString();
        }
        class OrderDetails
        {
            public string Commodity;
            public string Customer;
            public int OrderPrice;
            public OrderDetails(string Commodity, string Customer, int OrderPrice)
            {
                this.Commodity = Commodity;
                this.Customer = Customer;
                this.OrderPrice = OrderPrice;
            }
            bool Equals(OrderDetails d1)
            {
                return (this.Commodity == d1.Commodity) &&
                    (this.Customer == d1.Customer) && (this.OrderPrice == d1.OrderPrice);
            }
            public override string ToString()
            {
                return "\nCommodity: " + this.Commodity + "\nCustomer: "
                       + this.Customer + "\nOrderPrice: " + Convert.ToString(this.OrderPrice);
            }
        }
        class Custom
        {
            public string custom;
            public Custom(string custom) 
            {
                this.custom = custom;
            }
            public override string ToString() 
            {
                return this.custom;
            }
        }
        class Commo
        {
            public string commo;
            public Commo(string commo) 
            {
                this.commo = commo;
            }
            public override string ToString() 
            {
                return this.commo;
            }
        }
        public class OrderService
        {
            public static List<Order> orders = new List<Order>();
            public static void Add() 
            {
                try
                {
                    int Id, oprice;
                    string com, cust;
                    Console.WriteLine("Please input an Order ID: ");
                    Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please input the Commodity: ");
                    com = Console.ReadLine();
                    Console.WriteLine("Please input the Customer: ");
                    cust = Console.ReadLine();
                    Console.WriteLine("Please input the OrderPrice: ");
                    oprice = Convert.ToInt32(Console.ReadLine());
                    Order newOrder = new Order(Id, com, cust, oprice);
                    foreach (Order order in orders)
                    {
                        if (order.Equals(newOrder) || order.Id == Id)
                            throw new Exception("Order is already existed. ");
                    }
                    orders.Add(newOrder);
                    Console.WriteLine("Which attribute do you want to use as key of sorting?(" +
                                "1 represents Commodity, " +
                                "2 represents Customer, 3 represents OrderPrice. " +
                                "Press 4 to use ID as tacit key)? ");
                    int stype = Convert.ToInt32(Console.ReadLine());
                    if (stype == 4)
                        orders.OrderBy(a => a.Id);
                    switch (stype)
                    {
                        case 1:
                            orders.OrderBy(a => a.Details.Commodity);
                            break;
                        case 2:
                            orders.OrderBy(a => a.Details.Customer);
                            break;
                        case 3:
                            orders.OrderBy(a => a.Details.OrderPrice);
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("There is something wrong with your input. " +
                        "Please try again.");
                }
            }
            public static void Remove()
            {
                try
                {
                    int removeId, flag = 0;
                    Console.WriteLine("Please input the Id you want to remove: ");
                    removeId = Convert.ToInt32(Console.ReadLine());
                    foreach (Order order in orders)
                    {
                        if (order.Id == removeId)
                        {
                            flag = 1;
                            orders.Remove(order);
                            break;
                        }
                    }
                    if (flag == 0)
                        throw new Exception();
                }
                catch
                {
                    Console.WriteLine("There is something wrong with your input" +
                        "(Nonexistent ID). Please try again.");
                }
            }
            public static void Alter() 
            {
                try
                {
                    int alterId, flag = 0;
                    Console.WriteLine("Please input the Id you want to alter: ");
                    alterId = Convert.ToInt32(Console.ReadLine());
                    foreach (Order order in orders)
                    {
                        if (order.Id == alterId)
                        {
                            int type, alterprice, alterid;
                            string altercom, altercust;
                            Console.WriteLine("What do you want to alter(" +
                                "1 represents ID, 2 represents Commodity, " +
                                "3 represents Customer, 4 represents OrderPrice)? ");
                            type = Convert.ToInt32(Console.ReadLine());
                            switch (type)
                            {
                                case 1:
                                    Console.WriteLine("Please input the new ID: ");
                                    alterid = Convert.ToInt32(Console.ReadLine());
                                    order.Id = alterid;
                                    break;
                                case 2:
                                    Console.WriteLine("Please input the new Commodity: ");
                                    altercom = Console.ReadLine();
                                    order.Details.Commodity = altercom;
                                    break;
                                case 3:
                                    Console.WriteLine("Please input the new Customer: ");
                                    altercust = Console.ReadLine();
                                    order.Details.Customer = altercust;
                                    break;
                                case 4:
                                    Console.WriteLine("Please input the new OrderPrice: ");
                                    alterprice = Convert.ToInt32(Console.ReadLine());
                                    order.Details.OrderPrice = alterprice;
                                    break;
                            }
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0)
                        throw new Exception();
                }
                catch
                {
                    Console.WriteLine("There is something wrong with your input" +
                        "(Nonexistent ID). Please try again.");
                }
            }
            public static void Query()
            {
                try
                {
                    List<Order> qorders = new List<Order>();
                    Console.WriteLine("What do you want to query(" +
                                "1 represents ID, 2 represents Commodity, " +
                                "3 represents Customer, 4 represents OrderPrice, 5 represents all orders)? ");
                    int qtype = Convert.ToInt32(Console.ReadLine());
                    switch (qtype)
                    {
                        case 1:
                            qorders.Clear();
                            Console.WriteLine("Please in put ID you want to query: ");
                            int qId = Convert.ToInt32(Console.ReadLine());
                            foreach (Order order1 in OrderService.orders)
                            {
                                if (qId == order1.Id)
                                {
                                    qorders.Add(order1);
                                }
                            }
                            var res1 = from n in qorders
                                       orderby n.Details.OrderPrice
                                       select n;
                            Console.WriteLine("*****************");
                            Console.WriteLine();
                            foreach (var item in res1)
                            {
                                Console.WriteLine(item.ToString());
                                Console.WriteLine();
                            }
                            Console.WriteLine("*****************");
                            break;
                        case 2:
                            qorders.Clear();
                            Console.WriteLine("Please in put Commodity you want to query: ");
                            string qcom = Console.ReadLine();
                            foreach (Order order1 in orders)
                            {
                                if (qcom == order1.Details.Commodity)
                                {
                                    qorders.Add(order1);
                                }
                            }
                            var res2 = from n in qorders
                                       orderby n.Details.OrderPrice
                                       select n;
                            Console.WriteLine("*****************");
                            Console.WriteLine();
                            foreach (var item in res2)
                            {
                                Console.WriteLine(item.ToString());
                                Console.WriteLine();
                            }
                            Console.WriteLine("*****************");
                            break;
                        case 3:
                            qorders.Clear();
                            Console.WriteLine("Please in put Customer you want to query: ");
                            string qcust = Console.ReadLine();
                            foreach (Order order1 in orders)
                            {
                                if (qcust == order1.Details.Customer)
                                {
                                    qorders.Add(order1);
                                }
                            }
                            var res3 = from n in qorders
                                       orderby n.Details.OrderPrice
                                       select n;
                            Console.WriteLine("*****************");
                            Console.WriteLine();
                            foreach (var item in res3)
                            {
                                Console.WriteLine(item.ToString());
                                Console.WriteLine();
                            }
                            Console.WriteLine("*****************");
                            break;
                        case 4:
                            qorders.Clear();
                            Console.WriteLine("Please in put ID you want to query: ");
                            int qoprice = Convert.ToInt32(Console.ReadLine());
                            foreach (Order order1 in orders)
                            {
                                if (qoprice == order1.Details.OrderPrice)
                                {
                                    qorders.Add(order1);
                                }
                            }
                            var res4 = from n in qorders
                                       orderby n.Details.OrderPrice
                                       select n;
                            Console.WriteLine("*****************");
                            Console.WriteLine();
                            foreach (var item in res4)
                            {
                                Console.WriteLine(item.ToString());
                                Console.WriteLine();
                            }
                            Console.WriteLine("*****************");
                            break;
                        case 5:
                            Console.WriteLine("*****************");
                            Console.WriteLine();
                            foreach (Order order1 in orders)
                            {
                                Console.WriteLine(order1.ToString());
                                Console.WriteLine();
                            }
                            Console.WriteLine("*****************");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("There is something wrong with your input" +
                        ". Please try again.");
                }
            }
        }
        class MainClass
        {
            static void Main(string[] args)
            {
                int opcode;
                while (true)
                {
                    Console.WriteLine("Please input an Operation(1 represents add, 2 represents remove, " +
                        "3 represents alter, 4 represents query, 5 represent qiut(NO Result will be saved !) ): ");
                    opcode = Convert.ToInt32(Console.ReadLine());
                    switch (opcode)
                    {
                        case 1:
                            OrderService.Add();
                            break;
                        case 2:
                            OrderService.Remove();
                            break;
                        case 3:
                            OrderService.Alter();
                            break;
                        case 4:
                            OrderService.Query();
                            break;
                        case 5:
                            Console.WriteLine("Do you really want to quit? (y/n)");
                            string quit;
                            quit = Console.ReadLine();
                            if (quit == "y") Environment.Exit(0);
                            break;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}