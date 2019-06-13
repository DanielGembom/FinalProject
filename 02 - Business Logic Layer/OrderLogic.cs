using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class OrderLogic : BaseLogic
    {
        public OrderModel GetOrderByID(int id)
        {
            return GetOrder()
                .Where(o => id == o.id)
                .SingleOrDefault();
        }

        public List<OrderModel> GetAllUserOrders(string username)
        {
            return GetOrder()
                .Where(o => username == o.user.userName)
                .ToList();
        }

        public List<OrderModel> GetAllOrders()
        {
            return GetOrder()
                .ToList();
        }

        public OrderModel AddNewOrder(OrderModel order)
        {
            Order newOrder = new Order
            {
                CarID = order.carID,
                UserID = order.userID,
                StartDate = order.startDate,
                EndDate = order.endDate,
                TotalPrice = order.totalPrice
            };
            DB.Orders.Add(newOrder);
            DB.SaveChanges();
            return GetOrder()
                .Where(o => newOrder.OrderID == o.id)
                .SingleOrDefault();
        }

        private IQueryable<OrderModel> GetOrder()
        {
            return DB.Orders
                .Select(o => new OrderModel
                {
                    id = o.OrderID,
                    carID = o.CarID,
                    userID = o.UserID,
                    user = DB.Users
                        .Where(u => u.UserID == o.UserID)
                        .Select(u => new UserModel
                        {
                            id = u.UserID,
                            firstName = u.FirstName,
                            lastName = u.LastName,
                            userName = u.UserName,
                            phone = u.Phone,
                            email = u.Email,
                            birthDay = u.Birthday,
                            role = u.Role
                        }).FirstOrDefault()
                }).AsQueryable();
        }
    }
}
