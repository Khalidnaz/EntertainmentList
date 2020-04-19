using HotChocolate;

namespace api.Models.Users
{
  public class LoginUserInput
  {
    [GraphQLNonNullType]
    public string Email { get; set; }

    [GraphQLNonNullType]
    public string Password { get; set; }
  }
}