using System.Collections.Generic;
using Bluetracker.SDK.Reporting.Wrapper;
using Bluetracker.SDK.Reporting.Models;

namespace Bluetracker.SDK.Reporting.Clients
{
    public class ShipClient
    {
        private ShipWrapper _shipWrapper;

        /// <summary>
        /// Creates a new ShipClient instance.
        /// </summary>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key BlueCloud_ApiKey is used to specify the API token.
        /// </remarks>
        public ShipClient(string authorization)
        {
            _shipWrapper = new ShipWrapper(authorization);
        }

        /// <summary>
        /// Creates a new ShipClient instance.
        /// </summary>
        /// <param name="serverAddress">The server address.</param>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key BlueCloud_ApiKey is used to specify the API token, the key BlueCloud_ServerAddress is used to set the
        /// service address. If the service address is not specified as constructor parameter,
        /// the default service address will be used.
        /// </remarks>
        public ShipClient(string serverAddress, string authorization)
        {
            _shipWrapper = new ShipWrapper(serverAddress, authorization);
        }

        /// <summary>
        /// Get a specific ship object.
        /// </summary>
        /// <param name="imoNumber">IMO number of the ship.</param>
        /// <returns>The ship object.</returns>
        public Ship GetSpecific(int imoNumber)
        {
            return _shipWrapper.GetSpecific( imoNumber);
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
            return _shipWrapper.GetAll();
        }
    }
}
