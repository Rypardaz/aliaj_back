namespace AM.Domain.UserAgg.Services;

public interface IUserValidatorService
{
    void CheckUserExistence(string username);
}