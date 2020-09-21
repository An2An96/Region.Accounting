using System;
using Microsoft.Extensions.DependencyInjection;
using Region.Mediator.Query;

namespace Region.Mediator.MicrosoftContainerImplementation
{
    public class QueryBus : IQueryBus
    {
        private readonly IServiceProvider _provider;

        public QueryBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public TResult Handle<TResult>(IQuery<TResult> query)
        {
            using var scope = _provider.CreateScope();

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            var handler = scope.ServiceProvider.GetRequiredService(handlerType);
            return ((dynamic) handler).Handle((dynamic) query);
        }
    }
}