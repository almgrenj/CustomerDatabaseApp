using CustomerDatabaseApp.Models;
using CustomerDatabaseApp.Services;
using CustomerDatabaseApp.Repositories.Interfaces;

namespace CustomerDatabaseApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void AddOrder(Order order) => _orderRepository.Add(order);
    public Order GetOrder(int id) => _orderRepository.GetById(id);
    public void UpdateOrder(Order order) => _orderRepository.Update(order);
    public void DeleteOrder(int id) => _orderRepository.Delete(id);
    public IEnumerable<Order> GetAllOrders() => _orderRepository.GetAll();
}
}
