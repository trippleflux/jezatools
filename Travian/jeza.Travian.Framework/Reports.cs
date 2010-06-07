using System.Collections.Generic;

namespace jeza.Travian.Framework
{
    public class Reports
    {
        /// <summary>
        /// Adds new report to the collection.
        /// </summary>
        /// <param name="report">The report.</param>
        public void AddReport(Report report)
        {
            if (reportList.Contains(report))
            {
                return;
            }
            reportList.Add(report);
        }

        /// <summary>
        /// Gets the reports list.
        /// </summary>
        /// <value>The reports list.</value>
        public List<Report> ReportList
        {
            get { return reportList; }
        }

        private readonly List<Report> reportList = new List<Report>();
    }
}