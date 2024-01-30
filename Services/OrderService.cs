using CustomerDatabaseApp.Services;
using CustomerDatabaseApp.Repositories.Interfaces;
using CustomerDatabaseApp.Entities;

namespace CustomerDatabaseApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void AddOrder(OrderEntity order) => _orderRepository.Add(order);
    public OrderEntity GetOrder(int id) => _orderRepository.GetById(id);
    public void UpdateOrder(OrderEntity order) => _orderRepository.Update(order);
    public void DeleteOrder(int id) => _orderRepository.Delete(id);
    public IEnumerable<OrderEntity> GetAllOrders() => _orderRepository.GetAll();
}
}
