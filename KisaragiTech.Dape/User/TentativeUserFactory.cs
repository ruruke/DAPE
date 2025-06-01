namespace KisaragiTech.Dape.User;

public static class TentativeUserFactory
{
    public static LocalTentativeUser Create(string initialPreferredUsername)
    {
        return new LocalTentativeUser(UserIDGenerationService.Generate(), initialPreferredUsername);
    }
}