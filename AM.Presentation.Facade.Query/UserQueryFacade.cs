using AM.Application.Contracts.User;
using AM.Infrastructure.Query.Contract.User;
using AM.Presentation.Facade.Contract.User;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class UserQueryFacade(IQueryBus queryBus, IQueryBusAsync queryBusAsync) : IUserQueryFacade
{
    public EditUser GetBy(Guid guid) => queryBus.Dispatch<EditUser, Guid>(guid);

    public List<UserViewModel> GetList() => queryBus.Dispatch<List<UserViewModel>>();

    public List<UserComboModel> GetForCombo(Guid guid) => queryBus.Dispatch<List<UserComboModel>, Guid>(guid);

    public async Task<List<UserSessionViewModel>> GetUserSessionsLog(UserSessionSearchModel searchModel) =>
        await queryBusAsync.Dispatch<List<UserSessionViewModel>, UserSessionSearchModel>(searchModel);

    public async Task<UserActiveSessionViewModel> HasActiveSession() =>
        await queryBusAsync.Dispatch<UserActiveSessionViewModel>();

    public async Task<List<UserSessionViewModel>> GetCurrentUserLastSessions() =>
        await queryBusAsync.Dispatch<List<UserSessionViewModel>>();

    public async Task<UserInformationViewModel> GetUserInformation() =>
        await queryBusAsync.Dispatch<UserInformationViewModel>();
}