using System;
using Microsoft.IdentityModel.Tokens;

namespace api.Models
{
  public class AuthUser
  {
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Token { get; set; }
  }
}