using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Raven.Embedded;

namespace VilligerElectronics.BudgetPlanner.DataStore
{
    public class DocumentStoreProvider
    {
        private readonly DbSettings settings;
        private readonly ILogger<DocumentStoreProvider> logger;

        public DocumentStoreProvider(IOptions<DbSettings> settingsAccessor, ILogger<DocumentStoreProvider> logger)
        {
            this.settings = settingsAccessor.Value;
            this.logger = logger;
        }

        public IDocumentStore Create()
        {
            var serverOptions = new ServerOptions()
            {
                ServerUrl = settings.ServerUrl,
                DataDirectory = settings.DataDirectory,
                FrameworkVersion = "6.0.0"
            };

            
            EmbeddedServer.Instance.StartServer(serverOptions);
            
            return EmbeddedServer.Instance.GetDocumentStore("BudgetPlanner");
        }
    }
}
