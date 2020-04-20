﻿using System;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Venu.BuildingBlocks.Shared.Messaging;
using Venu.Ticketing.API.Commands;
using Venu.Ticketing.API.Commands.Dtos;

namespace Venu.Ticketing.API.IntegrationHandlers
{
    public class CustomerCreatedConsumer : IConsumer<UserCreated>
    {
        private readonly ILogger<CustomerCreatedConsumer> _logger;
        private readonly IMediator _mediator;

        public CustomerCreatedConsumer(ILogger<CustomerCreatedConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            _logger.LogInformation($"CustomerCreatedConsumer happened: Username: {context.Message.Username}");

            await _mediator.Send(new CreateCustomerCommand(new CustomerInput(context.Message.Id, context.Message.Username)));

            await Task.Delay(10);
            await Task.FromResult(0);
        }
    }
}