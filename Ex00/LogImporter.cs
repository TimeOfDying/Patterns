namespace Patterns.Ex00
{
    /// <summary>
    /// Этот файл нельзя менять по условиям задания
    /// Требуется именно расширить функциональность текущего класса, а не изменить ее
    /// </summary>
    public class LogImporter
    {
        private readonly ILogReader reader;

        public LogImporter(ILogReader reader)
        {
            this.reader = reader;
        }

        public void ImportLogs(string source)
        {
            var file = this.reader.ReadLogFile(source);
        }

    }
}