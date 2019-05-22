using System;
using System.Collections.Generic;
using System.Text;
using Bluetracker.SDK.Reporting.Models;
using Bluetracker.SDK.Reporting.Wrapper;

namespace Bluetracker.SDK.Reporting.Clients
{
    public class PortCallClient
    {
        private PortCallWrapper _portCallWrapper;

        /// <summary>
        /// Creates a new PortCallClient instance.
        /// </summary>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key BlueCloud_ApiKey is used to specify the API token.
        /// </remarks>
        public PortCallClient(string authorization)
        {
            _portCallWrapper = new PortCallWrapper(authorization);
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
        public PortCallClient(string serverAddress, string authorization)
        {
            _portCallWrapper = new PortCallWrapper(serverAddress, authorization);
        }

        /// <summary>
        /// Get a specific PortCallDetails object.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <param name="callId">The Guid of the specific PortCall.</param>
        /// <returns>The portCall object.</returns>
        public PortCallDetails GetSpecific(int imoNumber, Guid callId)
        {
            return _portCallWrapper.GetSpecific(imoNumber, callId);
        }

        /// <summary>
        /// Returns a list of PortCalls.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <param name="startDate">The start DateTime</param>
        /// <param name="endDate">The end DateTime</param>
        /// <param name="includeDeleted">Include deleted?</param>
        /// <returns>
        /// A list of PortCall objects, which belong to the ship with the given IMO number
        /// </returns>
        public List<PortCall> GetAll(int imoNumber, DateTime? startDate = null, DateTime? endDate = null, bool includeDeleted = false)
        {
            return _portCallWrapper.GetAll(imoNumber, startDate, endDate, includeDeleted);
        }

        /// <summary>
        /// Returns a list of Agents.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <param name="callId">The Guid of the specific PortCall.</param>
        /// <returns>
        /// A list of Agent objects, which belong to the ship with the given IMO number and the PortCall uid
        /// </returns>
        public List<Agent> GetAgents(int imoNumber, Guid callId)
        {
            return _portCallWrapper.GetAgents(imoNumber, callId);
        }
    }
}
