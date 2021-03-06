﻿using GraphQL.Types;
using Venu.Events.API.ViewModel;

namespace Venu.Events.API.GraphType.Types
{
    public class EventType : ObjectGraphType<Event>
    {
        public EventType()
        {
            Name = "event";
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.Summary).Description("Description of the event");
            Field(e => e.Url);
            Field(e => e.TicketsUrl);
            Field(e => e.PrimaryOrganizerId);
            Field(e => e.Date);
            Field(e => e.CreatedOn);
            Field(e => e.VenueId);
            Field(e => e.Category);
            Field(e => e.Tags);
            Field(e => e.Language);
            Field(e => e.Likes);
            Field(e => e.Shares);
            
            // TODO: Add associated types such as event organizer, venue, etc
        }
    }
}