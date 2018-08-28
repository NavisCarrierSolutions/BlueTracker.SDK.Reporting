using System;
using Bluetracker.SDK.Reporting.Core;
using Bluetracker.SDK.Reporting.Models;
using System.Collections.Generic;

namespace Bluetracker.SDK.Reporting.Wrapper

{
    /// <inheritdoc />
    /// <summary>
    /// Client for getting, creating and updating ship information.
    /// </summary>
    internal class ShipWrapper : ApiWrapper
    {
        /// <summary>
        /// Creates a new ShipWrapper instance.
        /// </summary>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key BlueCloud_ApiKey is used to specify the API token.
        /// </remarks>
        internal ShipWrapper(string authorization) :
            base(authorization)
        {
        }

        /// <summary>
        /// Creates a new ShipWrapper instance.
        /// </summary>
        /// <param name="serverAddress">The server address.</param>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key BlueCloud_ApiKey is used to specify the API token, the key BlueCloud_ServerAddress is used to set the
        /// service address. If the service address is not specified as constructor parameter,
        /// the default service address will be used.
        /// </remarks>
        internal ShipWrapper(string serverAddress, string authorization) :
            base(serverAddress, authorization)
        {
        }

        /// <summary>
        /// Get a specific ship object.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <returns>The ship object.</returns>
        public Ship GetSpecific(int imoNumber)
        {
            var route = $"/v1/ships/{imoNumber}";
            var ret = GetObject<Ship>(route);
            return ret;
        }

        /// <summary>
        /// Returns a pages list of ships.
        /// </summary>
        /// <returns>
        /// A paged list of ship object, which belong to the company associated with the
        /// used API key.
        /// </returns>
        public List<Ship> GetAll()
        {
            var route = $"/v1/ships";
            var ret = GetObject<List<Ship>>(route);
            return ret;
        }
    }
}
