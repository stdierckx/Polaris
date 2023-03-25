using Polaris.Api.Models;
using RestSharp;
using Xunit;

namespace Polaris.Api.Test.Api;

public class ExerciseTypeTests
{
    private readonly RestSharpClient _client;

    public ExerciseTypeTests()
    {
        _client = new RestSharpClient("http://localhost:8080/api/");
    }
    
    [Fact]
    public void PassingTest()
    {
        Assert.Equal(4, 2 + 2);
    }

    [Fact]
    public void Get_ReturnsExerciseTypes()
    {
        var request = new RestRequest("exerciseTypes", Method.Get);
        var exerciseTypes = _client.Execute<List<ExerciseType>>(request);

        Assert.NotNull(exerciseTypes);
        Assert.NotEmpty(exerciseTypes);
    }

    [Fact]
    public void Get_ReturnsExerciseTypeById()
    {
        var request = new RestRequest("exerciseTypes/1", Method.Get);
        var exerciseType = _client.Execute<ExerciseType>(request);

        Assert.NotNull(exerciseType);
        Assert.Equal(1, exerciseType.Id);
    }
    
    [Fact]
    public void CreateExerciseType_ShouldReturnCreatedStatus()
    {
        // Arrange
        var request = new RestRequest("/api/exercisetypes", Method.Post);
        var newExerciseType = new
        {
            Name = "Running",
            Description = "Jogging at a moderate pace"
        };
        request.AddJsonBody(newExerciseType);

        // Act
        var response = _client.Execute<RestResponse>(request);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
    }
}
