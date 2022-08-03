using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Net.Http.Headers;

namespace AgileDevelopment.IntegrationTests;

public class MethodologiesControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
{
    private readonly HttpClient _client;

    public MethodologiesControllerIntegrationTests(TestingWebAppFactory<Program> factory)
        => _client = factory.CreateClient();

    [Fact]
    public async Task Index_WhenCalled_ReturnApplicationForm()
    {
        var response = await _client.GetAsync("/Methodologies");

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        Assert.Contains("DevOps", responseString);
        Assert.Contains("Rapid", responseString);
    }

    [Fact]
    public async Task Create_WhenCalled_ReturnCreateForm()
    {
        var response = await _client.GetAsync("/Methodologies/Create");

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        Assert.Contains("Create", responseString);
        Assert.Contains("Methodology", responseString);
        Assert.Contains("Back to List", responseString);
    }

    [Fact]
    public async Task Create_SentWrongModel_ReturnsViewWithErrorMessages()
    {
        // Arrange
        var initialRes = await _client.GetAsync("/Methodologies/Create");
        var antiForgeryVal = await AntiForgeryTokenExtractor.ExtractAntiForgeryValues(initialRes);

        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Methodologies/Create");
        postRequest.Headers.Add("Cookie", new CookieHeaderValue(AntiForgeryTokenExtractor.Cookie, antiForgeryVal.cookie).ToString());
        var formModel = new Dictionary<string, string>
            {
                { AntiForgeryTokenExtractor.Field, antiForgeryVal.field },
                { "Description", "Description without Title.." }
            };

        postRequest.Content = new FormUrlEncodedContent(formModel);

        // Act
        var response = await _client.SendAsync(postRequest);

        // Assert
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        Assert.Contains("The Title field is required.", responseString);
    }

    [Fact]
    public async Task Create_WhenPostExecuted_ReturnsToIndexViewWithCreatedMethodology()
    {
        var initialRes = await _client.GetAsync("/Methodologies/Create");
        var antiForgeryVal = await AntiForgeryTokenExtractor.ExtractAntiForgeryValues(initialRes);

        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Methodologies/Create");
        postRequest.Headers.Add("Cookie", new CookieHeaderValue(AntiForgeryTokenExtractor.Cookie, antiForgeryVal.cookie).ToString());
        var formModel = new Dictionary<string, string>
        {
            { AntiForgeryTokenExtractor.Field, antiForgeryVal.field },//new
            {"Title", "New Methodology" },
            {"Description", "Description ..." }
        };

        postRequest.Content = new FormUrlEncodedContent(formModel);

        var response = await _client.SendAsync(postRequest);

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        Assert.Contains("New Methodology", responseString);
        Assert.Contains("Description ...", responseString);
    }
}