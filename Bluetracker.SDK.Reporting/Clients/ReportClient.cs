using System;
using System.Collections.Generic;
using System.Text;
using Bluetracker.SDK.Reporting.Models;
using Bluetracker.SDK.Reporting.Wrapper;

namespace Bluetracker.SDK.Reporting.Clients
{
    public class ReportClient
    {
        private ReportWrapper _reportWrapper;

        /// <summary>
        /// Creates a new PortCallClient instance.
        /// </summary>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key BlueCloud_ApiKey is used to specify the API token.
        /// </remarks>
        public ReportClient(string authorization)
        {
            _reportWrapper = new ReportWrapper(authorization);
        }

        /// <summary>
        /// Creates a new PortCallClient instance.
        /// </summary>
        /// <param name="serverAddress">The server address.</param>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key BlueCloud_ApiKey is used to specify the API token, the key BlueCloud_ServerAddress is used to set the
        /// service address. If the service address is not specified as constructor parameter,
        /// the default service address will be used.
        /// </remarks>
        public ReportClient(string serverAddress, string authorization)
        {
            _reportWrapper = new ReportWrapper(serverAddress, authorization);
        }

        /// <summary>
        /// Returns a paged list of reports.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <param name="page">(optional, default: 0) number of the page to be returned</param>
        /// <param name="pageSize">(optional, default: 100) max. number of reports returned with a page</param>
        /// <returns>
        /// A paged list of report objects, which belong to the ship with the given IMO number
        /// </returns>
        public PageHeader GetAll(int imoNumber, int page = 0, int pageSize = 100)
        {
            return _reportWrapper.GetAll( imoNumber, page, pageSize);
        }

        /// <summary>
        /// Returns details of a specific report.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <param name="reportUid">The Guid of the specific Report.</param>
        /// <returns>
        /// A ReportDetails objects, with infos about the report with the given reportUid.
        /// </returns>
        public ReportDetails GetSpecific(int imoNumber, Guid reportUid)
        {
            return _reportWrapper.GetSpecific( imoNumber, reportUid);
        }

        /// <summary>
        /// Returns a list of report versions.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <param name="reportUid">The Guid of the specific Report.</param>
        /// <returns>
        /// A list of ReportVersion objects, with infos about all versions of the report with the given reportUid.
        /// </returns>
        public List<ReportVersion> GetReportVersions(int imoNumber, Guid reportUid)
        {
            return _reportWrapper.GetReportVersions( imoNumber, reportUid);
        }

        /// <summary>
        /// Returns a detailed information about a specific report version.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <param name="reportUid">The Guid of the specific Report.</param>
        /// <param name="versionUid">The Guid of a specific ReportVersion.</param>
        /// <returns>
        /// A ReportVersion object, with detailed information about the reportVersion with the given versionUid.
        /// </returns>
        public ReportVersionDetails GetSpecificReportVersion(int imoNumber, Guid reportUid, Guid versionUid)
        {
            return _reportWrapper.GetSpecificReportVersion( imoNumber, reportUid, versionUid);
        }
    }
}
