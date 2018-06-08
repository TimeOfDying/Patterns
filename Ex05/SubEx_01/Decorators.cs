using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_01
{
    public class DatabaseSaverDecorator : IDatabaseSaver
    {
        protected IDatabaseSaver saver;

        public DatabaseSaverDecorator(IDatabaseSaver saver)
        {
            this.saver = saver;
        }

        public void SaveData(object data)
        {
            this.saver.SaveData(data);
        }
    }

    public class MailSenderDecorator : DatabaseSaverDecorator
    {
        private MailSender mailSender;
        private string email;

        public MailSenderDecorator(IDatabaseSaver saver, MailSender mailSender, string email) : base(saver)
        {
            this.mailSender = mailSender;
            this.email = email;
        }

        public new void SaveData(object data)
        {
            base.SaveData(data);
            this.mailSender.Send(email);
        }
    }

    public class CacheUpdaterDecorator : DatabaseSaverDecorator
    {
        private CacheUpdater cacheUpdater;
        public CacheUpdaterDecorator(IDatabaseSaver saver, CacheUpdater cacheUpdater) : base(saver)
        {
            this.cacheUpdater = cacheUpdater;
        }

        public new void SaveData(object data)
        {
            base.SaveData(data);
            this.cacheUpdater.UpdateCache();
        }
    }
}
