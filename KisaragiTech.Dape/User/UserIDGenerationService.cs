using System;

namespace KisaragiTech.Dape.User;

public static class UserIDGenerationService
{
    public static UserID Generate()
    {
        return new UserID(Guid.NewGuid());
    }
}
