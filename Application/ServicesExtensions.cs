using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServicesExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection Services)
        {
            Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            Services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
