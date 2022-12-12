using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class AbstractController : Controller
    {
        public string RoleAdmin = @"eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImM5YTJmZDA5LTJhNjktNDQ4Yy1hNWJiLTA4ZGEyMmIxYzFm"; 
        public string RoleUser = @"ImF1ZCI6Ik5vdmFuZXQifQsImlhdCI6MTYiOiJIUzUxMiIsInR5cC2ODc2NjM0MiwiaXNzIjoiTm92YW5ldCIs";

        public User CheckRoleSession(int[] listrole,bool andor)// true: and, false: or
        {

            // get session
            string jsonStr = HttpContext.Session.GetString("useraccount");
            User user;
            if (jsonStr is null) user = null;
            else user = JsonConvert.DeserializeObject<User>(jsonStr);
            // check session null
            if (user==null)
            {
                Response.Redirect("/nguoidung/dangnhap");
                return null;
            }
            else
            {
                if (andor)
                {
                    // true check role and listrole
                    foreach (int role in listrole)
                    {
                        if (user.RoleId!=role)
                        {
                            Response.Redirect("/nguoidung/eror");
                        }
                        return user;
                    }
                }
                else
                {
                    // check role or listrole
                    foreach (var role in listrole)
                    {
                        if (user.RoleId == role)
                        {
                            return user;
                        }
                    }
                    Response.Redirect("/nguoidung/eror");
                    return null;
                }
            }
            return user;
        }
        
        public bool CheckRoleCookie(string[] listRoles, bool andor)// true: and, false: or
        {
            string jsonStr = Request.Cookies["userAccount"];

            if (string.IsNullOrEmpty(jsonStr))
            {
                return false;
            }
            else
            {
                if (andor)
                {
                    // true check role and listrole
                    foreach (var role in listRoles)
                    {
                        if (jsonStr!=role)
                        {
                            return false;
                        }
                        return true;
                    }
                }
                else
                {
                    // check role or listrole
                    foreach (var role in listRoles)
                    {
                        if (jsonStr == role)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return false;
        }
    }
}
