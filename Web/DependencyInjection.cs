using Application.Repository;
using Application.UseCases.CancelOrder;
using Application.UseCases.CreateCustomer;
using Application.UseCases.CreateOrder;
using Application.UseCases.CreateProduct;
using Application.UseCases.GetAllOrders;
using Application.UseCases.GetOrderByNumber;
using Application.UseCases.GetOrderReport;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Web
{
    public static class DependencyInjection
    {
        public static void RegisterDirtyStoreModule(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddTransient<CancelOrderUseCase>();
            services.AddTransient<CreateCustomerUseCase>();
            services.AddTransient<CreateOrderUseCase>();
            services.AddTransient<CreateProductUseCase>();
            services.AddTransient<GetAllOrdersUseCase>();
            services.AddTransient<GetOrderByNumberUseCase>();
            services.AddTransient<GetOrderReportUseCase>();

            var connectionString =
                configuration.GetValue<string>("DIRTY_STORE_CONNECTION_STRING")
                ?? throw new Exception("Connection string not found");

            services.AddDbContext<DirtyStoreDbContext>(options =>
                options.UseSqlite(connectionString).UseSnakeCaseNamingConvention()
            );

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ISessionLogRepository, SessionLogRepository>();
        }
    }
}
