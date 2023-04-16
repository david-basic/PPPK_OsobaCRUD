using Microsoft.Azure.Cosmos;
using PPPK_OsobaCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace PPPK_OsobaCRUD.Dao
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly Container container;
        public CosmosDbService(CosmosClient cosmosClient, string dbName, string containerName)
        {
            container = cosmosClient.GetContainer(dbName, containerName);
        }

        public async Task AddPersonAsync(Osoba person)
        => await container.CreateItemAsync(person, new PartitionKey(person.Id));

        public async Task DeletePersonAsync(Osoba person)
        => await container.DeleteItemAsync<Osoba>(person.Id, new PartitionKey(person.Id));

        public async Task<IEnumerable<Osoba>> GetPeopleAsync(string queryString)
        {
            List<Osoba> people = new List<Osoba>();

            var query = container.GetItemQueryIterator<Osoba>(new QueryDefinition(queryString));
            while (query.HasMoreResults)
            {
                var result = await query.ReadNextAsync();
                people.AddRange(result.ToList());
            }

            return people;
        }

        public async Task<Osoba> GetPersonAsync(string id)
        {
            try
            {
                return await container.ReadItemAsync<Osoba>(id, new PartitionKey(id));
            }
            catch (CosmosException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task UpdatePersonAsync(Osoba person)
        => await container.UpsertItemAsync(person, new PartitionKey(person.Id));
    }
}