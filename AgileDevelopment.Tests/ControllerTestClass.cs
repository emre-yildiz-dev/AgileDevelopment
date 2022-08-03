using AgileDevelopment.Controllers;
using AgileDevelopment.Data;
using AgileDevelopment.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgileDevelopment.Tests;

[TestFixture]
public class ControllerTestClass
{
    private readonly ApplicationContext _context;
    private MethodologiesController _methodologiesController;
    [SetUp]
    public void Setup()
    {
        _methodologiesController = new MethodologiesController(_context);
    }

    [Test]
    public void TestMethodologiesIndex()
    {
        var actResult = _methodologiesController.Index();
        Assert.That(actResult, Is.Not.Null);
    }

    [Test]
    public void TestMethodologiesCreateRedirect()
    {
        var result = _methodologiesController.Create(new Methodology()
        {
            MethodologyID = 5,
            Title = "DevOps",
            Description = "DevOps Methodology"
        });

        Assert.That(result, Is.Not.Null);
    }
}