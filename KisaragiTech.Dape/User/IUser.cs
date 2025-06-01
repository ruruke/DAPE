using KisaragiTech.Dape.Base;

namespace KisaragiTech.Dape.User;

public interface IUser : IIdentifiable<UserID>
{
    string GetPreferredHandle();
}
