using FarmersOnlyBudget.Models;
using FirebaseAdmin.Auth;

namespace FarmersOnlyBudget.Api.Services;

public interface IAuthenticatedUserService
{
    FirebaseToken FirebaseToken { get; }

    UserModel User { get; }
    
    Task Init(FirebaseToken token);

    Task<bool> Exists(string firebaseUid);
}