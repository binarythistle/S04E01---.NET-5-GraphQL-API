using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Commands
{
    public class AddCommandPayloadType : ObjectType<AddCommandPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddCommandPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added command.");

            descriptor
                .Field(c => c.command)
                .Description("Represents the added command.");

            base.Configure(descriptor);
        }
    }
}
