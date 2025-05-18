using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Common.Helpers;
using Vektorel.Muzayede.Common.Options;
using Vektorel.Muzayede.Data;
using Vektorel.Muzayede.Entities.Identity;

namespace Vektorel.Muzayede.Modules.Users.Queries;
public record SignInResult(string Token, DateTime ExpiresAt, string Id, string DisplayName);

public class SignInRequest : IRequest<Result<SignInResult>>
{
    [Required]
    public string Mail { get; set; }
    [Required]
    public string Password { get; set; }
}

internal class SignInQuery : IRequestHandler<SignInRequest, Result<SignInResult>>
{
    private readonly MuzayedeContext context;
    private readonly UserManager<User> userManager;
    private readonly JwtOptions options;

    public SignInQuery(MuzayedeContext context, UserManager<User> userManager, IOptions<JwtOptions> options)
    {
        this.context = context;
        this.userManager = userManager;
        this.options = options.Value;
    }

    public async Task<Result<SignInResult>> Handle(SignInRequest request, CancellationToken cancellationToken)
    {
        #region Reflection
        //var c1 = new Car("Honda");
        //c1.Go(5);
        //c1.GoStepByStep(1, 2, 5, 12, 5, 6);

        //var t = typeof(Car);
        //var ctors = t.GetConstructors();
        //var parameters = new object[] { "Honda" };
        //ctors[0].Invoke(parameters);

        //var c2 = (Car)Activator.CreateInstance(t);

        //var a = Activator.CreateInstance<A>(); 
        #endregion

        var user = await userManager.FindByEmailAsync(request.Mail.ToLower());
        if (user is null)
        {
            return Result<SignInResult>.Fail("Kullanıcı Bulunamadı");
        }

        if (!user.EmailConfirmed)
        {
            return Result<SignInResult>.Fail("Hesabınız henüz onaylanmadı");
        }

        var accessed = await userManager.CheckPasswordAsync(user, request.Password);

        if (!accessed)
        {
            return Result<SignInResult>.Fail("Kullanıcı Bulunamadı");
        }

        var (Token, ExpiresAt) = AuthenticationHelper.GenerateToken(user.Id, user.Email, user.UserType, options);
        var result = new SignInResult(Token, ExpiresAt, user.Id, user.DisplayName);
        return Result<SignInResult>.Success(result);
    }

    
}

//public class Car
//{
//    public Car(string name)
//    {

//    }

//    public void Go(int distance)
//    {

//    }

//    public void GoStepByStep(params int[] steps)
//    {

//    }
//}