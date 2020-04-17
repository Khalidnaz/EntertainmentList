using api.Graphql;
using HotChocolate.Types;

namespace api.Types
{
	public class MutationType : ObjectType<Mutation>
	{
		protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
		{
			descriptor.Field(t => t.CreateUser(default))
				.Type<NonNullType<UserType>>()
				.Argument("user", a => a.Type<NonNullType<UserInputType>>());
		}
	}
}