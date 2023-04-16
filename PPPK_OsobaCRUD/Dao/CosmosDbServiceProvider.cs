using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PPPK_OsobaCRUD.Dao
{
    public static class CosmosDbServiceProvider
    {
        private const string DatabaseName = "PeopleDB";
        private const string ContainerName = "Person";
        private const string Account = "https://osobe2022.documents.azure.com:443/";
        private const string Key = "x8ch9MPW3xbauGnoABmzk1qd36XlECIrjedOUlIVGcrPhBWHOk0SUxnF3eEd16wGlkHvoB8EbIVoACDbG68CuQ==";

        private static ICosmosDbService cosmosDbService;

        public static ICosmosDbService CosmosDbService { get => cosmosDbService; }

        public static async Task Init()
        {
            CosmosClient cosmosClient = new CosmosClient(Account, Key);
            cosmosDbService = new CosmosDbService(cosmosClient, DatabaseName, ContainerName);

            DatabaseResponse databaseResponse
                = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await databaseResponse.Database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
        }
    }
}