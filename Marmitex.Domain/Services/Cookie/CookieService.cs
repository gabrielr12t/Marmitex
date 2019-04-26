using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Marmitex.Domain.Services.Cookie
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _context;
        public CookieService(IHttpContextAccessor context)
        {
            _context = context;
        }
        public void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            _context.HttpContext.Response.Cookies.Append(key, value, option);
        }
        public string GetAllCookies()
        {
            return _context.HttpContext.Request.Cookies.ToString();
        }

        public string GetCookie(string name)
        {
            return _context.HttpContext.Request.Cookies[name];
        }

        public void Remove(string nome)
        {
            _context.HttpContext.Response.Cookies.Delete(nome);
        }

        public void RemoveRange(List<string> names)
        {
            foreach (var item in names) _context.HttpContext.Response.Cookies.Delete(item);
        }
    }
}