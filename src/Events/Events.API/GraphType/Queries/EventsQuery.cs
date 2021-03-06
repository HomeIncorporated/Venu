﻿using GraphQL.Types;
using MediatR;
using Venu.Events.API.GraphType.Types;

namespace Venu.Events.API.GraphType.Queries
{
    public class EventsQuery : ObjectGraphType
    {
        private readonly Query _query;

        public EventsQuery(IMediator mediator)
        {
            _query = new Query(mediator);
            
            Field<EventType>(
                "event",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return _query.GetEventById(id);
                }
            );
            Field<ListGraphType<EventType>>(
                "events",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "name" },
                    new QueryArgument<StringGraphType> { Name = "category" }
                ),
                resolve: context =>
                {
                    // If query has no search params return all events
                    if (context.Arguments.Count == 0) return _query.GetEvents();
                    
                    var name = context.GetArgument<string>("name");
                    var category = context.GetArgument<string>("category");
                    
                    return _query.GetEventsBySearch(name, category);
                }
            );
        }
    }
}