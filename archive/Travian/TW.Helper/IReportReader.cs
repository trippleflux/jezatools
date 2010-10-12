namespace TW.Helper
{
    public interface IReportReader
    {
        /// <summary>
        /// Find new reports.
        /// </summary>
        void Collect();

        /// <summary>
        /// Parse report data.
        /// </summary>
        void Parse();

        /// <summary>
        /// Save report do DB.
        /// </summary>
        void Save();
    }
}