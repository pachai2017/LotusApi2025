using System.Collections.Generic;

namespace LotusFive.Application.Authentication
{
    public interface IUserCredentialValidator
    {
        bool TryValidateCredentials(string username, string password, out IReadOnlyCollection<string> roles);
    }
}
