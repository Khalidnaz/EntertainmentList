using api.Models;
using HotChocolate.Types;

namespace api.Types
{
	public class UserType : ObjectType<User>
	{
		protected override void Configure(IObjectTypeDescriptor<User> descriptor)
		{
			descriptor.Field(f => f.Id)
				.Type<IdType>();

			descriptor.Field(f => f.FirstName)
				.Type<StringType>();

			descriptor.Field(f => f.LastName)
				.Type<StringType>();

			descriptor.Field(f => f.Email)
				.Type<StringType>();

			descriptor.Field(f => f.Password)
				.Type<StringType>();

			descriptor.Field(f => f.Created)
				.Type<DateType>();
		}
	}
}