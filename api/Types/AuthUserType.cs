using api.Models;
using api.Models.Users;
using HotChocolate.Types;

namespace api.Types
{
  public class AuthUserType : ObjectType<AuthUser>
  {
    protected override void Configure(IObjectTypeDescriptor<AuthUser> descriptor)
    {
      descriptor.Field(f => f.Id)
        .Type<IdType>();

      descriptor.Field(f => f.FirstName)
        .Type<StringType>();

      descriptor.Field(f => f.LastName)
        .Type<StringType>();

      descriptor.Field(f => f.Email)
        .Type<StringType>();

      descriptor.Field(f => f.Token)
        .Type<StringType>();
    }
  }
}