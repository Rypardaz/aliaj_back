using PhoenixFramework.Domain;

namespace AM.Domain.UserAgg;

public class UserSalon(int userId, int salonId) : EntityBase<long>
{
    public int UserId { get; private set; } = userId;
    public int SalonId { get; private set; } = salonId;
    public User User { get; private set; }
}