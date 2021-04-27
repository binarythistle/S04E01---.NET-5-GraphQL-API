using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Commands
{
    public class AddCommandInputType : InputObjectType<AddCommandInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddCommandInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a command.");

            descriptor
                .Field(c => c.HowTo)
                .Description("Represents the how-to for the command.");
            descriptor
                .Field(c => c.CommandLine)
                .Description("Represents the command line.");
            descriptor
                .Field(c => c.PlatformId)
                .Description("Represents the unique ID of the platform which the command belongs.");

            base.Configure(descriptor);
        }
    }
}
