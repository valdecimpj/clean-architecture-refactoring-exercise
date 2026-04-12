using Application.Repository;
using Domain.Enum;

namespace Application.UseCases.GetOrderReport;

public class GetOrderReportUseCase(IOrderRepository orderRepository)
{
    public async Task<GetOrderReportResponse> Execute()
    {
        var orders = await orderRepository.GetAll();
        int totalOrders = 0;
        int totalCancelledOrders = 0;
        decimal totalRevenue = 0;
        decimal totalCancelledRevenue = 0;

        foreach (var order in orders)
        {
            totalOrders++;
            if (order.Status == OrderStatusEnum.Cancelled)
            {
                totalCancelledOrders++;
                totalCancelledRevenue += order.TotalValue;
            }
            else
                totalRevenue += order.TotalValue;
        }

        return new(totalOrders, totalCancelledOrders, totalRevenue, totalCancelledRevenue);
    }
}
