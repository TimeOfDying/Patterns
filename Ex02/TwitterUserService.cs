using Patterns.Ex01.ExternalLibs.Twitter;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Patterns.Ex02
{
    public class TwitterUserService : UserService<TwitterUser>
    {
        readonly TwitterClient client = new TwitterClient();

        protected override UserInfo[] ConvertToUserInfo(TwitterUser[] user)
        {
            return user.Select(c =>
            {
                var userInfo = new UserInfo
                {
                    UserId = c.UserId.ToString(),
                    Name = this.client.GetUserNameById(c.UserId)
                };
                return userInfo;
            }).ToArray();
        }

        protected override string GetName(string userId)
        {
            return "NAME";
        }

        protected override TwitterUser[] GetGetSubscribersById(string userId)
        {
            return this.client.GetSubscribers(Convert.ToInt64(userId)).ToArray();
        }

        protected override string ParseUrl(string pageUrl)
        {
            var regex = new Regex("twitter.com/(.*)");
            var userName = regex.Match(pageUrl).Groups[0].Value;
            var userId = GetUserId(userName).ToString();
            return userId;
        }

        /// <summary>
        /// Нет необходимости менять этот метод, достаточно просто переиспользовать
        /// Реализация его не важна, стоит полагаться только на его внешний интерфейс
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private long GetUserId(String userName)
        {
            //TODO: Return userId from userName
            return 0;
        }
    }
}