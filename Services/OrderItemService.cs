using CustomerDatabaseApp.Entities;
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

    public void AddOrderItem(OrderItemEntity orderItem)
    {
        _orderItemRepository.Add(orderItem);
    }

    public OrderItemEntity GetOrderItem(int id)
    {
        return _orderItemRepository.GetById(id);
    }

    public void UpdateOrderItem(OrderItemEntity orderItem)
    {
        _orderItemRepository.Update(orderItem);
    }

    public void DeleteOrderItem(int id)
    {
        _orderItemRepository.Delete(id);
    }

    public IEnumerable<OrderItemEntity> GetAllOrderItems()
    {
        return _orderItemRepository.GetAll();
    }
}
