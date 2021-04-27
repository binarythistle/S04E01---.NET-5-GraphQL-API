using System.Threading;
using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.GraphQL.Commands;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace CommanderGQL.GraphQL
{
    /// <summary>
    /// Represents the mutations available.
    /// </summary>
    [GraphQLDescription("Represents the mutations available.")]
    public class Mutation
    {
        /// <summary>
        /// Adds a <see cref="Platform"/> based on <paramref name="input"/>.
        /// </summary>
        /// <param name="input">The <see cref="AddPlatformInput"/>.</param>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <param name="eventSender">The <see cref="ITopicEventSender"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The added <see cref="Platform"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Adds a platform.")]
        public async Task<AddPlatformPayload> AddPlatformAsync(
            AddPlatformInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
            ) 
            {
                var platform = new Platform{
                    Name = input.Name
                };

                context.Platforms.Add(platform);
                await context.SaveChangesAsync(cancellationToken);

                await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

                return new AddPlatformPayload(platform);
            }

        /// <summary>
        /// Adds a <see cref="Command"/> based on <paramref name="input"/>.
        /// </summary>
        /// <param name="input">The <see cref="AddCommandInput"/>.</param>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <returns>The added <see cref="Command"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Adds a command.")]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input,
            [ScopedService] AppDbContext context)
            {
                var command = new Command{
                    HowTo = input.HowTo,
                    CommandLine = input.CommandLine,
                    PlatformId = input.PlatformId
                };

                context.Commands.Add(command);
                await context.SaveChangesAsync();

                return new AddCommandPayload(command);
            }
    }
}