using Patterns.Ex00.ExternalLibs;

namespace Patterns.Ex00
{

    public class FtpImporter : LogImporter
    {
        private readonly FtpClient ftpClient;
        public FtpImporter(ILogReader reader, FtpClient ftpClient) : base(reader)
        {
            this.ftpClient = ftpClient;
        }
        public void ImportLogs(string login, string password, string path)
        {
            var file = this.ftpClient.ReadFile(login, password, path);
        }

    }
}