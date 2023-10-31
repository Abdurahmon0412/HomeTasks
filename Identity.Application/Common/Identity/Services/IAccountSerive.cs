using Identity.Domain.Entities;

namespace Identity.Application.Common.Identity.Services;

public interface IAccountSerive
{
    ValueTask<User> CreateAsync(User user);

    ValueTask<bool> VerificateAsync(string token);

    ValueTask<bool> MarkEmailAsVerified(Guid userId);

    ValueTask<User> GetUserByUserName (string userName);
}