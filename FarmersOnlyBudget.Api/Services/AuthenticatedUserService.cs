using System.Data;
using FarmersOnlyBudget.Models;
using FirebaseAdmin.Auth;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace FarmersOnlyBudget.Api.Services;

public class AuthenticatedUserService(BudgetDbContext dbContext) : IAuthenticatedUserService
{
    public FirebaseToken FirebaseToken { get; private set; }

    public UserModel User { get; private set; }
    
    public async Task Init(FirebaseToken token)
    {
        FirebaseToken = token;

        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.FirebaseId == token.Uid);

        if (user is null) throw new InvalidOperationException("The user does not exist.");

        User = user.Adapt<UserModel>();
    }

    public async Task<bool> Exists(string firebaseUid)
        => await dbContext.Users.AnyAsync(u => u.FirebaseId.Equals(firebaseUid));
    
}