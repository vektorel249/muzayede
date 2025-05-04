using MediatR;
using System.ComponentModel.DataAnnotations;
using Vektorel.Muzayede.Data;

namespace Vektorel.Muzayede.Modules.Users.Queries;
public record SignInResult(string token, DateTime expiresAt);

public class SignInRequest : IRequest<SignInResult>
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}

internal class SignInQuery : IRequestHandler<SignInRequest, SignInResult>
{
    private readonly MuzayedeContext context;

    public SignInQuery(MuzayedeContext context)
    {
        this.context = context;
    }
    public async Task<SignInResult> Handle(SignInRequest request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new SignInResult("sdkfjsdfkj", DateTime.Now.AddMinutes(10));
    }
}