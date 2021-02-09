using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL
{
    /// <summary>
    /// Represents the subscriptions available.
    /// </summary>
    [GraphQLDescription("Represents the queries available.")]
    public class Subscription
    {
        /// <summary>
        /// The subscription for added <see cref="Platform"/>.
        /// </summary>
        /// <param name="platform">The <see cref="Platform"/>.</param>
        /// <returns>The added <see cref="Platform"/>.</returns>
        [Subscribe]
        [Topic]
        [GraphQLDescription("The subscription for added platform.")]
        public Platform OnPlatformAdded([EventMessage] Platform platform)
        {
            return platform;
        }
    }
}