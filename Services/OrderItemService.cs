using CustomerDatabaseApp.Models;
using CustomerDatabaseApp.Repositories.Interfaces;
using CustomerDatabaseApp.Services;
using System.Collections.Generic;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        _orderItemRepository.Add(orderItem);
    }

    public OrderItem GetOrderItem(int id)
    {
        return _orderItemRepository.GetById(id);
    }

    public void UpdateOrderItem(OrderItem orderItem)
    {
        _orderItemRepository.Update(orderItem);
    }

    public void DeleteOrderItem(int id)
    {
        _orderItemRepository.Delete(id);
    }

    public IEnumerable<OrderItem> GetAllOrderItems()
    {
        return _orderItemRepository.GetAll();
    }
}
