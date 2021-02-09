using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Platforms
{
    public class AddPlatformInputType : InputObjectType<AddPlatformInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddPlatformInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a platform.");

            descriptor
                .Field(p => p.Name)
                .Description("Represents the name for the platform.");

            base.Configure(descriptor);
        }
    }
}
