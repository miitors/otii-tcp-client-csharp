using System.Linq;

namespace OtiiTcpClient {

    /// <summary>
    /// The Otii class provides methods at the application level of Otii.
    /// </summary>
    public partial class Otii {
        private readonly OtiiClient _client;

        /// <summary>
        /// Initializes a new instance of <see cref="Otii"/> with a <see cref="OtiiClient"/>.
        /// </summary>
        /// <param name="client">The Otii client.</param>
        internal Otii(OtiiClient client) {
            _client = client;
        }

        /// <summary>
        /// Create a new project.
        /// </summary>
        /// <returns>An object representing the newly created project.</returns>
        public Project CreateProject() {
            var request = new CreateProjectRequest();
            var response = _client.PostRequest<CreateProjectRequest, CreateProjectResponse>(request);
            return new Project(_client, response.Data.ProjectId);
        }

        /// <summary>
        /// Retrieves the active project.
        /// </summary>
        /// <returns>An object representing the current project if one exists, otherwise null</returns>
        public Project GetActiveProject() {
            var request = new GetActiveProjectRequest();
            var response = _client.PostRequest<GetActiveProjectRequest, GetActiveProjectResponse>(request);
            var projectId = response.Data.ProjectId;
            return projectId == -1 ? null : new Project(_client, projectId);
        }

        /// <summary>
        /// Retrieves the device id from the name of the id.
        /// </summary>
        /// <param name="deviceName">The name of the connected device.</param>
        /// <returns>The id of the named device.</returns>
        public string GetDeviceId(string deviceName) {
            var request = new GetDeviceIdRequest(deviceName);
            var response = _client.PostRequest<GetDeviceIdRequest, GetDeviceIdResponse>(request);
            return response.Data.DeviceId;
        }

        /// <summary>
        /// Retrieves a list of all connected devices.
        /// </summary>
        /// <param name="timeout">An optional timeout in seconds.</param>
        /// <returns>A list of all connected devices.</returns>
        public Arc[] GetDevices(int timeout = 0) {
            var request = new GetDevicesRequest(timeout);
            var response = _client.PostRequest<GetDevicesRequest, GetDevicesResponse>(request);
            var devices = response.Data.Devices.Select(device => new Arc(_client, device.DeviceId, device.Name, device.Type));
            return devices.ToArray();
        }

        /// <summary>
        /// Retrieves a list of all <see cref="License"/> for the logged in user.
        /// </summary>
        /// <returns>A list of all <see cref="License"/>.</returns>
        public License[] GetLicenses() {
            var request = new GetLicensesRequest();
            var response = _client.PostRequest<GetLicensesRequest, GetLicensesResponse>(request);
            var licenses = response.Data.Licenses.Select(license => new License(
                license.Id,
                license.Type,
                license.Available,
                license.ReservedTo,
                license.Hostname,
                license.Addons.Select(addon => addon.Id).ToArray()
            ));
            return licenses.ToArray();
        }

        /// <summary>
        /// Login to the license server.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public void Login(string username, string password) {
            var request = new LoginRequest(username, password);
            _client.PostRequest(request);
        }

        /// <summary>
        /// Logout from the license server.
        /// </summary>
        /// <returns></returns>
        public void Logout() {
            var request = new LogoutRequest();
            _client.PostRequest(request);
        }

        /// <summary>
        /// Opens an existing project.
        /// </summary>
        /// <param name="filename">The path to the project file.</param>
        /// <param name="force">Set to true to open the file even if the current project has unsaved data.</param>
        /// <param name="progress">Indicates whether to show progress, during the process.</param>
        /// <returns>The <see cref="Project"/> loaded from the specified <paramref name="filename"/>.</returns>
        public Project OpenProject(string filename, bool force = false, bool progress = false) {
            var request = new OpenProjectRequest(filename, force, progress);
            var response = _client.PostRequest<OpenProjectRequest, OpenProjectResponse>(request);
            var projectId = response.Data.ProjectId;
            return projectId == -1 ? null : new Project(_client, projectId);
        }

        /// <summary>
        /// Reserves the specified <paramref name="licenseId"/>.
        /// </summary>
        /// <param name="licenseId">License id to reserve.</param>
        /// <returns></returns>
        public void ReserveLicense(int licenseId) {
            var request = new ReserveLicenseRequest(licenseId);
            _client.PostRequest(request);
        }

        /// <summary>
        /// Retrieves license.
        /// </summary>
        /// <param name="licenseId">License id to return.</param>
        /// <returns></returns>
        public void ReturnLicense(int licenseId) {
            var request = new ReturnLicenseRequest(licenseId);
            _client.PostRequest(request);
        }

        /// <summary>
        /// Turns the main power on or off for all connected devices.
        /// </summary>
        /// <param name="enable">Set to true to turn on power, false to turn off power.</param>
        public void SetAllMain(bool enable) {
            var request = new SetAllMainRequest(enable);
            _client.PostRequest(request);
        }

        /// <summary>
        /// Shutdowns TCP server.
        /// </summary>
        public void Shutdown() {
            var request = new ShutdownRequest();
            try {
                _client.PostRequest(request);
            } catch (OtiiClient.DisconnectedException) {
            }
        }
    }
}