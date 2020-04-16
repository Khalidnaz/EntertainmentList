using System;
using EntertainmentList.Models;
using HotChocolate.Types;

namespace EntertainmentList.Types
{
	public class UserType : ObjectType<User>
	{
		protected override void Configure(IObjectTypeDescriptor<User> descriptor)
		{
			descriptor.Field(f => f.Id)
				.Type<IntType>();

			descriptor.Field(f => f.FirstName)
				.Type<StringType>();

			descriptor.Field(f => f.LastName)
				.Type<StringType>();

			descriptor.Field(f => f.Email)
				.Type<StringType>();

			// descriptor.Field(f => f.PasswordHash)
			// 	.Type<ListType<ByteType>>();

			// descriptor.Field(f => f.PasswordSalt)
			// .Type<ListType<ByteType>>();

			descriptor.Field(f => f.Created)
				.Type<DateType>();
		}
	}
}