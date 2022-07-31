using Amazon.S3;
using Amazon.S3.Model;
using ProjectTrack.Application.Common;
using ProjectTrack.Domain.Common;

namespace ProjectTrack.Infrastructure;

public record S3RepositoryOptions
{
    public string BucketName { get; set; }
}

public class S3Repository<T> where T : PersistentObject
{
    private readonly IAmazonS3 _s3Client;
    private readonly IJsonConverter _converter;
    private readonly S3RepositoryOptions _options;

    public S3Repository(IAmazonS3 s3Client, IJsonConverter jsonConverter, S3RepositoryOptions options) 
        => (_s3Client, _converter, _options) 
            = (s3Client, jsonConverter, options);

    public async Task<Response<T>> InsertAsync(T model)
    {
        return null;
    }
    
    public async Task<Response<T>> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        await Instantiate(cancellationToken);

        var typeName = typeof(T).Name.ToLower();

        var objectResponse = await _s3Client.GetObjectAsync(new GetObjectRequest
        {
            BucketName = _options.BucketName,
            Key = $"{typeName}/{id}"
        }, cancellationToken);
        
        var wasSuccess = objectResponse.ContentLength == 0;
        
        return null;
    }

    public async Task<Response<T>> UpdateAsync(string id, T model)
    {
        
        return null;
    }

    public async Task<Response<T>> DeleteAsync(string id)
    {
        
        return null;
    }

    private async Task Instantiate(CancellationToken cancellationToken)
    {
        if (!await _s3Client.DoesS3BucketExistAsync(_options.BucketName))
            await _s3Client.PutBucketAsync(_options.BucketName, cancellationToken);
    }
}