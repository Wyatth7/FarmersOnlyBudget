using FirebaseAdmin.Auth;

namespace FarmersOnlyBudget.Api.Services;

public interface IAuthenticatedUserService
{
    Task Init(FirebaseToken token);

    Task<bool> Exists(string firebaseUid);
}