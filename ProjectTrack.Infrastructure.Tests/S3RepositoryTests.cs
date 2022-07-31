using Amazon.S3;
using NSubstitute;
using ProjectTrack.Domain.Common;

namespace ProjectTrack.Infrastructure.Tests;

public class S3RepositoryTests
{
    private readonly IAmazonS3 _s3Client;
    private S3RepositoryOptions _options;
    private readonly JsonConverter _converter;
    private readonly S3Repository<Data> _repository;

    class Data : PersistentObject { };

    public S3RepositoryTests()
    {
        _converter = new JsonConverter();
        _s3Client = Substitute.For<IAmazonS3>();
        _options = new S3RepositoryOptions {BucketName = "Bucket1"};
        _repository = new S3Repository<Data>(_s3Client, _converter, _options);
    }

    [Fact]
    public async Task GivenGetRequest_WhenBucketDoesntExist_BucketIsCreated()
    {
        _s3Client.DoesS3BucketExistAsync(_options.BucketName).Returns(false);
        
        await _repository.GetAsync("1");
        await _s3Client.Received().PutBucketAsync(nameof(Data));
    }
    
    [Fact]
    public async Task GivenGetRequest_WhenBucketExists_BucketIsNotCreated()
    {
        _s3Client.DoesS3BucketExistAsync(_options.BucketName).Returns(true);
        
        await _repository.GetAsync("1");

        await _s3Client.Received().DoesS3BucketExistAsync(_options.BucketName);
        await _s3Client.DidNotReceive().PutBucketAsync(Arg.Any<string>(), Arg.Any<CancellationToken>());
    }
}