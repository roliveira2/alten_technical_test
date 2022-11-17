using AltenTest.BLL;
using AltenTest.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;



namespace AltenTest.Infrastructure
{
    public static class ServicesInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            #region Custom
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingBLL, BookingBLL>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
        }
    }
}
