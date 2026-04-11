using Application.UseCases.CancelOrder;
using Application.UseCases.CreateOrder;
using Application.UseCases.GetAllOrders;
using Application.UseCases.GetOrderByNumber;
using Application.UseCases.GetOrderReport;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> Create(
        [FromBody] CreateOrderRequest createOrderRequest,
        [FromServices] CreateOrderUseCase createOrderUseCase
    ) => Ok(await createOrderUseCase.Execute(createOrderRequest));

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<OrderEntity>>> GetAll(
        [FromServices] GetAllOrdersUseCase getAllOrdersUseCase
    ) => Ok(await getAllOrdersUseCase.Execute());

    [HttpGet("by-number/{number:int}")]
    public async Task<ActionResult<OrderEntity>> GetByNumber(
        [FromRoute] int number,
        [FromServices] GetOrderByNumberUseCase getOrderByNumberUseCase
    ) => Ok(await getOrderByNumberUseCase.Execute(number));

    [HttpDelete("cancel/{number:int}")]
    public async Task<CancelOrderResponse> Cancel(
        [FromRoute] int number,
        [FromServices] CancelOrderUseCase cancelOrderUseCase
    ) => await cancelOrderUseCase.Execute(number);

    [HttpGet("report")]
    public async Task<ActionResult<GetOrderReportResponse>> GetReport(
        [FromServices] GetOrderReportUseCase getOrderReportUseCase
    ) => Ok(await getOrderReportUseCase.Execute());
}
