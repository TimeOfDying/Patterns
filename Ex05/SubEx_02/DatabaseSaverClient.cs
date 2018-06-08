using System;
using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_02
{
    public class DatabaseSaverClient
    {
        public void Main(bool b)
        {

            var databaseSaver = new DatabaseSaverListener(new DatabaseSaver());

            databaseSaver.DataSaved += (sender, args) =>
            {
                var mailSender = new MailSender();
                var cacheUpdated = new CacheUpdater();
                mailSender.Send("");
                cacheUpdated.UpdateCache();
            };
            DoSmth(databaseSaver);
        }

        private void DoSmth(IDatabaseSaver saver)
        {
            saver.SaveData(null);
        }
    }

}