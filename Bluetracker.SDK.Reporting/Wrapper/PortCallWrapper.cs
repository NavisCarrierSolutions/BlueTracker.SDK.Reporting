using System;
using System.Collections.Generic;
using System.Text;
using Bluetracker.SDK.Reporting.Models;
using Bluetracker.SDK.Reporting.Core;

namespace Bluetracker.SDK.Reporting.Wrapper
{
    /// <inheritdoc />
    /// <summary>
    /// Client for getting, creating and updating portcall information.
    /// </summary>
    internal class PortCallWrapper : ApiWrapper
    {
        /// <summary>
        /// Creates a new PortCallWrapper instance.
        /// </summary>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key BlueCloud_ApiKey is used to specify the API token.
        /// </remarks>
        internal PortCallWrapper(string authorization) : base(authorization)
        {
        }

        /// <summary>
        /// Creates a new PortCallWrapper instance.
        /// </summary>
        /// <param name="serverAddress">The server address.</param>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key BlueCloud_ApiKey is used to specify the API token, the key BlueCloud_ServerAddress is used to set the
        /// service address. If the service address is not specified as constructor parameter,
        /// the default service address will be used.
        /// </remarks>
        internal PortCallWrapper(string serverAddress, string authorization) : base(serverAddress, authorization)
        {
        }

        /// <summary>
        /// Get a specific PortCall object.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <param name="callUid">The Guid of the specific PortCall.</param>
        /// <returns>The PortCall object.</returns>
        public PortCallDetails GetSpecific(int imoNumber, Guid callUid)
        {
            var route = $"/v1/ships/{imoNumber}/portcalls/{callUid}";
            var ret = GetObject<PortCallDetails>(route);
            return ret;
        }

        /// <summary>
        /// Returns a list of PortCalls.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <param name="start">(optional, default: 01.01.0001 ) start date of a timely range of portcalls</param>
        /// <param name="end">(optional, default: 31.12.9999) end date of a timely range of portcalls</param>
        /// <param name="includeDeleted">(optional, default: false) if true, all PortCalls are listed, including the deleted calls!</param>
        /// <returns>
        /// A list of portcall object, which belong to the ship with the given IMO number!
        /// </returns>
        public List<PortCall> GetAll(int imoNumber, DateTime? start = null, DateTime? end = null, bool includeDeleted = false)
        {
            if (start == null)
                start = DateTime.MinValue;

            if (end == null)
                end = DateTime.MaxValue;

            var route = $"/v1/ships/{imoNumber}/portcalls?start={start:yyyy-MM-ddTHH:mm}&end={end:yyyy-MM-ddTHH:mm}&includeDeleted={includeDeleted.ToString().ToLower()}";

            var ret = GetObject<List<PortCall>>(route);
            return ret;
        }

        /// <summary>
        /// Returns a pages list of ships.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <param name="callUid">The Guid of the specific PortCall.</param>
        /// <returns>
        /// A list of Agent object, which belong to the PortCall with the given callUid.
        /// </returns>
        public List<Agent> GetAgents(int imoNumber, Guid callUid)
        {
            var route = $"/v1/ships/{imoNumber}/portcalls/{callUid}/agents";

            var ret = GetObject<List<Agent>>(route);
            return ret;
        }
    }
}
