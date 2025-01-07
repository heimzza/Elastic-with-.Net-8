using Elastic.Clients.Elasticsearch;
using ElasticWithNet8.Models;
using ElasticWithNet8.Configurations;

namespace ElasticWithNet8.Services;

public class ElasticService : IElasticService
{
    private readonly ElasticsearchClient _client;
    private readonly ElasticSettings _elasticSettings;

    public Task<bool> AddOrUpdate(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddOrUpdateBulk(IEnumerable<User> users, string indexName)
    {
        throw new NotImplementedException();
    }

    public Task CreateIndexIfNotExistsAsync(string indexName)
    {
        throw new NotImplementedException();
    }

    public Task<User> Get(string key)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Remove(string key)
    {
        throw new NotImplementedException();
    }

    public Task<long?> RemoveAll()
    {
        throw new NotImplementedException();
    }

}