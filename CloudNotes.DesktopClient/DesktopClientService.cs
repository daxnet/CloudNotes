namespace CloudNotes.DesktopClient
{
    using System;
    using System.Threading.Tasks;
    using Extensibility;
    using Infrastructure;
    using Newtonsoft.Json;
    using Settings;

    internal sealed class CheckUpdateResult
    {
        public static readonly CheckUpdateResult NoUpdate = new CheckUpdateResult {HasUpdate = false};
        public bool HasUpdate { get; set; }
        public dynamic UpdatePackage { get; set; }

    }

    internal sealed class DesktopClientService
    {
        private readonly DesktopClientSettings settings;

        public DesktopClientService(DesktopClientSettings settings)
        {
            this.settings = settings;
        }

        public async Task<CheckUpdateResult> CheckUpdateAsync()
        {
            try
            {
                var proxyCredential = new ClientCredential
                {
                    UserName = Constants.ProxyUserName,
                    Password = Constants.ProxyUserPassword,
                    ServerUri = this.settings.PackageServer
                };
                using (var proxyClient = new ServiceProxy(proxyCredential))
                {
                    var result = await proxyClient.GetAsync("api/packages/latest/DesktopClient");
                    result.EnsureSuccessStatusCode();
                    dynamic availablePackage = JsonConvert.DeserializeObject(await result.Content.ReadAsStringAsync());
                    var packageVersion = new Version(availablePackage.Version.ToString());
                    if (typeof (Program).Assembly.GetName().Version < packageVersion)
                    {
                        return new CheckUpdateResult
                        {
                            HasUpdate = true,
                            UpdatePackage = availablePackage
                        };
                    }
                    return CheckUpdateResult.NoUpdate;
                }
            }
            catch
            {
                return CheckUpdateResult.NoUpdate;
            }
        }
    }
}
