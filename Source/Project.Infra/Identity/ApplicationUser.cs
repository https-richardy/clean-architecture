using Microsoft.AspNetCore.Identity;
using Project.Domain.Contracts.Entities;

namespace Project.Infra.Identity;

public class ApplicationUser : IdentityUser, IUser
{

}