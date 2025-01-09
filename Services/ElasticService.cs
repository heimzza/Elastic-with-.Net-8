using Elastic.Clients.Elasticsearch;
using ElasticWithNet8.Models;
using ElasticWithNet8.Configurations;
using Microsoft.Extensions.Options;

namespace ElasticWithNet8.Services;

public class ElasticService : IElasticService
{
    private readonly ElasticsearchClient _client;
    private readonly ElasticSettings _elasticSettings;

    public ElasticService(IOptions<ElasticSettings> optionsMonitor)
    {
        _elasticSettings = optionsMonitor.Value;

        var settings = new ElasticsearchClientSettings(new Uri(_elasticSettings.Url))
            // .Authentication()
            .DefaultIndex(_elasticSettings.DefaultIndex);

        _client = new ElasticsearchClient(settings);
    }

    public Task<bool> AddOrUpdate(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddOrUpdateBulk(IEnumerable<User> users, string indexName)
    {
        throw new NotImplementedException();
    }

    public async Task CreateIndexIfNotExistsAsync(string indexName)
    {
        var isExists = _client.Indices.ExistsAsync(indexName)?.Result?.Exists == true;
        if (!isExists)
        {
            await _client.Indices.CreateAsync(indexName);
        }
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