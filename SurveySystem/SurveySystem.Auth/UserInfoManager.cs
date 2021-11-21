using SurveySystem.DBsource;
using SurveySystem.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SurveySystem.Auth
{
    public class UserInfoManager
    {
        public static bool TryLogin(string account, string pwd, out string errorMsg)
        {
            // 檢查空白
            if (string.IsNullOrWhiteSpace(account) ||
                string.IsNullOrWhiteSpace(pwd))
            {
                errorMsg = "<span style='color:red'>請輸入帳號/密碼</span>";
                return false;
            }

            // 讀取和檢查資料庫
            var userInfo = UserInfoManager.GetUserInfoByAccount(account);

            // 檢查 Null
            if (userInfo == null)
            {
                errorMsg = $"<span style='color:red'>帳號: {account} 輸入錯誤</span>";
                return false;
            }

            //檢查帳號是否黑名單
            if (userInfo.AccStatus == 1)
            {
                errorMsg = "<span style='color:red'>此帳號已被停用</span>";
                return false;
            }

            // 檢查帳號/密碼
            if (string.Compare(userInfo.Account, account, true) == 0 &&
                string.Compare(userInfo.Password, pwd, false) == 0)
            {
                //HttpContext.Current.Session["UserLoginInfo"] = userInfo.Account;
                errorMsg = string.Empty;
                return true;
            }
            else
            {
                errorMsg = "<span style='color:red'>登入失敗，請重新確認帳號/密碼</span>";
                return false;
            }
        }

        public static AcInfo GetUserInfoByAccount(string account)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.AcInfo
                         where item.Account == account
                         select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
