namespace Application.UseCases.GetOrderReport;

public record GetOrderReportResponse(
    int TotalOrders,
    int TotalCancelledOrders,
    decimal TotalRevenue,
    decimal TotalCancelledRevenue
);
