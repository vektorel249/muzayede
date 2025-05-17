using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Common.Helpers;
using Vektorel.Muzayede.Data;
using Vektorel.Muzayede.Entities.Identity;

namespace Vektorel.Muzayede.Modules.Users.Commands;
public class SignUpRequest : IRequest<Result<bool>>
{
    public string Mail { get; set; }
    public string Password { get; set; }
    public string DisplayName { get; set; }
}

internal class SignUpCommand : IRequestHandler<SignUpRequest, Result<bool>>
{
    private readonly MuzayedeContext context;

    public SignUpCommand(MuzayedeContext context)
    {
        this.context = context;
    }

    public async Task<Result<bool>> Handle(SignUpRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await context.Users.AnyAsync(f => f.Mail == request.Mail, cancellationToken);
        if (existingUser)
        {
            return Result<bool>.Fail("Zaten kayıtlı kullanıcı");
        }

        var code = Guid.NewGuid();
        var user = new User
        {
            DisplayName = request.DisplayName,
            UserType = Common.Enums.UserType.User,
            Mail = request.Mail,
            Code = code.ToString(),
            Password = AuthenticationHelper.CreateHash(code, request.Password),
            IsActive = true,
        };

        context.Users.Add(user);
        await context.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true);
    }
}