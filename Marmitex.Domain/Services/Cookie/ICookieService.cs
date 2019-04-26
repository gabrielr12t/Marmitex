using System.Collections.Generic;

namespace Marmitex.Domain.Services.Cookie
{
    public interface ICookieService
    {
        void SetCookie(string key, string value, int? expireTime);
        void Remove(string nome);
        void RemoveRange(List<string> names);
        string GetCookie(string name);
        string GetAllCookies( );
    }
}