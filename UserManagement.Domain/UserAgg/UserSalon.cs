using PhoenixFramework.Domain;

namespace UserManagement.Domain.UserAgg;

public class UserSalon : EntityBase<long>
{
    public int UserId { get; private set; }
    public int SalonId { get; private set; }
    public User User { get; private set; }
    public UserSalon(int userId, int salonId)
    {
        UserId = userId;
        SalonId = salonId;
    }
}