namespace Patterns.Ex00.ExternalLibs
{
     public class LogImporterClient
    {
        /// <summary>
        /// TODO: Изменения нужно вносить в этом методе
        /// </summary>
        public void DoMethod()
        {

            var importer = new FtpImporter(new FileLogReader(), new FtpClient());

            importer.ImportLogs("name", "pass", "path");
        }
    }
}
