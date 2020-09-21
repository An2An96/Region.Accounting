using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Region.Mediator.Command;
using Region.Mediator.Events;
using Region.Mediator.Query;

namespace Region.Mediator.MicrosoftContainerImplementation
{
    public static class ServiceCollectionExtensions
    {
        private static IEnumerable<Type> FindCommandHandlers(params Assembly[] assemblies) =>
            GetImplementationsOfGenericInterface(typeof(ICommandHandler<>), assemblies);

        private static IEnumerable<Type> FindQueryHandlers(params Assembly[] assemblies) =>
            GetImplementationsOfGenericInterface(typeof(IQueryHandler<,>), assemblies);

        private static IEnumerable<Type> FindEventHandlers(params Assembly[] assemblies) =>
            GetImplementationsOfGenericInterface(typeof(IEventHandler<>), assemblies);

        public static void AddMediator(this IServiceCollection collection, params Assembly[] assemblies)
        {
            #region Register Command Bus and Handlers

            collection.AddSingleton<ICommandBus, CommandBus>();

            foreach (var commandHandlerType in FindCommandHandlers(assemblies))
            {
                var interfaceType = GetSpecificTypeInterfaceByGeneric(commandHandlerType, typeof(ICommandHandler<>));

                if (collection.Any(x => interfaceType.Any(i => x.ServiceType == i)))
                    throw new Exception("ICommand cannot have more than one ICommandHandler");

                foreach (var type in interfaceType)
                {
                    collection.AddScoped(type, commandHandlerType);
                }
            }

            #endregion


            #region Register Query Bus and Handlers

            collection.AddSingleton<IQueryBus, QueryBus>();
            
            foreach (var queryHandlerType in FindQueryHandlers())
            {
                var interfaceType = GetSpecificTypeInterfaceByGeneric(queryHandlerType, typeof(IQueryHandler<,>));

                if (collection.Any(x => interfaceType.Any(i => x.ServiceType == i)))
                    throw new Exception("IQuery cannot have more than one IQueryHandler");

                foreach (var type in interfaceType)
                {
                    collection.AddScoped(type, queryHandlerType);
                }
            }

            #endregion


            #region Register Event Bus and Handlers

            collection.AddSingleton<IEventBus, EventBus>();

            foreach (var eventHandlerType in FindEventHandlers())
            {
                var interfaceType = GetSpecificTypeInterfaceByGeneric(eventHandlerType, typeof(IEventHandler<>));

                foreach (var type in interfaceType)
                {
                    collection.AddScoped(type, eventHandlerType);
                }
            }

            #endregion
        }

        private static IEnumerable<Type> GetSpecificTypeInterfaceByGeneric(Type type, Type genericInterface)
        {
            return type
                .GetInterfaces()
                .Where(x =>
                    x.IsGenericType && x.GetGenericTypeDefinition() == genericInterface);
        }

        private static IEnumerable<Type> GetImplementationsOfGenericInterface(Type type, params Assembly[] assembly)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => t
                    .GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == type));
        }
    }
}