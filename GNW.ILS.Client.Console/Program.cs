using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using GNW.ILS.Entities.Service.Models;
using GNW.ILS.Service.WCF.Contract;

namespace GNW.ILS.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
             // Main method
            
            System.Console.WriteLine("Press Enter to start");
            System.Console.ReadLine();

            IAddressTypeService addressTypeService = new ChannelFactory<IAddressTypeService>("addressTypeService").CreateChannel();
            //IOrderService orderService = new ChannelFactory<IOrderService>("orderService").CreateChannel();

            using ((IDisposable)addressTypeService)
            //using ((IDisposable)orderService)
            {
                try
                {
                    // Get addressTypes
                    System.Console.WriteLine("AddressTypes:");
                    Task<IEnumerable<AddressType>> task = addressTypeService.GetAddressTypes();
                    task.Wait();
                    IEnumerable<AddressType> addressTypes = task.Result;
                    if (addressTypes == null) return;
                    foreach (var c in addressTypes)
                        PrintAddressType(c);

                    //// Get orders for a addressType
                    //Console.WriteLine("\nGet addressType orders {AddressTypeId}:");
                    //string addressTypeId = Console.ReadLine();
                    //if (!addressTypes.Any(c => int.Equals(c.Id, addressTypeId, StringComparison.OrdinalIgnoreCase)))
                    //{
                    //    Console.WriteLine("Invalid addressType id: {0}", addressTypeId.ToUpper());
                    //    return;
                    //}
                    //IEnumerable<Order> orders = orderService.GetAddressTypeOrdersAsync(addressTypeId).Result;
                    //foreach (var o in orders)
                    //    PrintOrder(o);

                    //// Get an order
                    //Console.WriteLine("\nGet an order {OrderId}:");
                    //int orderId = int.Parse(Console.ReadLine());
                    //if (!orders.Any(o => o.OrderId == orderId))
                    //{
                    //    Console.WriteLine("Invalid order id: {0}", orderId);
                    //    return;
                    //}
                    //Order order = orderService.GetOrderAsync(orderId).Result;
                    //PrintOrderWithDetails(order);

                    //// Create a new order
                    //Console.WriteLine("\nPress Enter to create a new order for {0}",
                    //    addressTypeId.ToUpper());
                    //Console.ReadLine();

                    //var newOrder = new Order
                    //{
                    //    AddressTypeId = addressTypeId,
                    //    OrderDate = DateTime.Today,
                    //    ShippedDate = DateTime.Today.AddDays(1),
                    //    OrderDetails = new ChangeTrackingCollection<OrderDetail>
                    //        {
                    //            new OrderDetail { ProductId = 1, Quantity = 5, UnitPrice = 10 },
                    //            new OrderDetail { ProductId = 2, Quantity = 10, UnitPrice = 20 },
                    //            new OrderDetail { ProductId = 4, Quantity = 40, UnitPrice = 40 }
                    //        }
                    //};
                    //var createdOrder = orderService.CreateOrderAsync(newOrder).Result;
                    //PrintOrderWithDetails(createdOrder);

                    //// Update the order
                    //Console.WriteLine("\nPress Enter to update order details");
                    //Console.ReadLine();

                    //// Start change-tracking the order
                    //var changeTracker = new ChangeTrackingCollection<Order>(createdOrder);

                    //// Modify order details
                    //createdOrder.OrderDetails[0].UnitPrice++;
                    //createdOrder.OrderDetails.RemoveAt(1);
                    //createdOrder.OrderDetails.Add(new OrderDetail
                    //{
                    //    OrderId = createdOrder.OrderId,
                    //    ProductId = 3,
                    //    Quantity = 15,
                    //    UnitPrice = 30
                    //});

                    //// Submit changes
                    //Order changedOrder = changeTracker.GetChanges().SingleOrDefault();
                    //Order updatedOrder = orderService.UpdateOrderAsync(changedOrder).Result;

                    //// Merge changes
                    //changeTracker.MergeChanges(updatedOrder);
                    //Console.WriteLine("Updated order:");
                    //PrintOrderWithDetails(createdOrder);

                    //// Delete the order
                    //Console.WriteLine("\nPress Enter to delete the order");
                    //Console.ReadLine();
                    //bool deleted = orderService.DeleteOrderAsync(createdOrder.OrderId).Result;

                    //// Verify order was deleted
                    //Order deletedOrder = orderService.GetOrderAsync(createdOrder.OrderId).Result;
                    //Console.WriteLine(deleted && deletedOrder == null
                    //    ? "Order was successfully deleted"
                    //    : "Order was not deleted");
                }
                catch (AggregateException aggEx)
                {
                    var baseEx = aggEx.Flatten().GetBaseException();
                    var innerExMsg = baseEx.InnerException != null ? "\r\n" + baseEx.InnerException.Message : "";
                    System.Console.WriteLine(baseEx.Message + innerExMsg);
                }
                finally
                {
                    var channel = addressTypeService as IClientChannel;
                    if (channel != null && channel.State == CommunicationState.Faulted)
                    {
                        channel.Abort();
                    }
                }

                // Keep console open
                System.Console.WriteLine("Press any key to exit");
                System.Console.ReadKey(true);
            }
       
        }

         // Helper methods

        private static void PrintAddressType(AddressType c)
        {
            System.Console.WriteLine("{0} {1}",
                c.AddressTypeId,
                c.Name
                );
        }

        //private static void PrintOrder(Order o)
        //{
        //    Console.WriteLine("{0} {1}",
        //        o.OrderId,
        //        o.OrderDate.GetValueOrDefault().ToShortDateString());
        //}

        //private static void PrintOrderWithDetails(Order o)
        //{
        //    Console.WriteLine("{0} {1}",
        //        o.OrderId,
        //        o.OrderDate.GetValueOrDefault().ToShortDateString());
        //    foreach (var od in o.OrderDetails)
        //    {
        //        Console.WriteLine("\t{0} {1} {2} {3}",
        //            od.OrderDetailId,
        //            od.Product.ProductName,
        //            od.Quantity,
        //            od.UnitPrice.ToString("c"));
        //    }
        //}
    
    }
}
