using MediatR;
using Microsoft.AspNetCore.Identity;
using Vektorel.Muzayede.Common;
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
    private readonly UserManager<User> userManager;

    public SignUpCommand(MuzayedeContext context, UserManager<User> userManager)
    {
        this.context = context;
        this.userManager = userManager;
    }

    public async Task<Result<bool>> Handle(SignUpRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await userManager.FindByEmailAsync(request.Mail.ToLower());
        //var existingUser = await context.Users.AnyAsync(f => f.Email == request.Mail, cancellationToken);
        if (existingUser is not null)
        {
            return Result<bool>.Fail("Zaten kayıtlı kullanıcı");
        }

        var user = new User
        {
            DisplayName = request.DisplayName,
            UserType = Common.Enums.UserType.User,
            EmailConfirmed = true,
            Email = request.Mail.ToLower(),
            NormalizedEmail = request.Mail.ToLower(),
            UserName = request.Mail.ToLower(),
            NormalizedUserName = request.Mail.ToLower()
        };

        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            return Result<bool>.Success(true);
        }

        return Result<bool>.Fail(string.Join(',', result.Errors.Select(s => s.Description)));
    }
}