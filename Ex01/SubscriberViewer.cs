using Patterns.Ex01.ExternalLibs.Instagram;
using Patterns.Ex01.ExternalLibs.Twitter;
using System;
using System.Collections.Generic;

namespace Patterns.Ex01
{
    public class SubscriberViewer
    {
        /// <summary>
        /// Возвращает список подписчиков пользователя из соц.сети.
        /// TODO: необходимо изменить этот метод по условиям задачи
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="networkType"></param>
        /// <returns></returns>
        public SocialNetworkUser[] GetSubscribers(String userName, SocialNetwork networkType)
        {
           return Context.DoAlgorithm(networkType, userName);

        }
    }

    public interface ISocialNetworkTitleStrategy
    {
        SocialNetworkUser[] DoAlgorithm(String userName);
    }

    public class TwitterStrategy : ISocialNetworkTitleStrategy
    {

        public SocialNetworkUser[] DoAlgorithm(String userName)

        {
            List<SocialNetworkUser> users = new List<SocialNetworkUser>();
            TwitterUser[] twitterSubscribers = new TwitterClient().GetSubscribers(new TwitterClient().GetUserIdByName(userName));
            for (int i = 0; i < twitterSubscribers.Length; i++)
            {
                var user = new SocialNetworkUser();
                user.UserName = new TwitterClient().GetUserNameById(twitterSubscribers[i].UserId);
                users.Add(user);

            }
            return users.ToArray();
        }

    }

    public class InstagramStrategy : ISocialNetworkTitleStrategy
    {

        public SocialNetworkUser[] DoAlgorithm(String userName)

        {
            List<SocialNetworkUser> users = new List<SocialNetworkUser>();
            InstagramUser[] instSubscribers = new InstagramClient().GetSubscribers(userName);
            for (int i = 0; i < instSubscribers.Length; i++)
            {
                var user = new SocialNetworkUser();
                user.UserName = instSubscribers[i].UserName;
                users.Add(user);
            }
            return users.ToArray();
        }

    }

    public class Context

    {

        private static Dictionary<SocialNetwork, ISocialNetworkTitleStrategy> _strategies = new Dictionary<SocialNetwork, ISocialNetworkTitleStrategy>();

        static Context()

        {

            _strategies.Add(SocialNetwork.Instagram, new InstagramStrategy());
            _strategies.Add(SocialNetwork.Twitter, new TwitterStrategy());

        }


        public static SocialNetworkUser[] DoAlgorithm(SocialNetwork title, String username)

        {

            return _strategies[title].DoAlgorithm(username);

        }


    }

}