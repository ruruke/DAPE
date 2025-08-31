using KisaragiTech.Dape.User.Interface;
using KisaragiTech.Dape.User.Service;

namespace KisaragiTech.Dape.User.Model;

/// <summary>
/// 仮登録したローカルユーザー。仮ユーザーができることは本登録を完了させること、時間切れでキューから削除されること。
/// </summary>
public sealed class LocalTentativeUser : ILocalUser
{
    private readonly UserID _identifier;
    private readonly string _preferredHandle;

    /// <see cref="TentativeUserFactory.Create"/> を使うこと。
    /// 
    /// <param name="identifier"></param>
    /// <param name="preferredHandle"></param>
    internal LocalTentativeUser(UserID identifier, string preferredHandle)
    {
        this._identifier = identifier;
        this._preferredHandle = preferredHandle;
    }

    public UserID GetIdentifier() => this._identifier;

    public string GetPreferredHandle() => this._preferredHandle;

    public LocalRegisteredUser ToRegisteredUser(HashedPassword hashedPassword) => new(this._identifier, this._preferredHandle, hashedPassword);
}
