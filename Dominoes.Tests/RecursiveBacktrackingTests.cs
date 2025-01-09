using Dominoes.Tests.TestsData;
using FluentAssertions;

namespace Dominoes.Tests;

public class RecursiveBacktrackingTests
{
    [Theory]
    [ClassData(typeof(DominoesValidTestData))]
    public void ShouldFindChain(string rawInput, string rawExpected)
    {
        // arrange
        var input = rawInput.ToDominoesList();
        
        // act
        var chain = RecursiveBacktracking.FindCircularDominoesChain(input);
        
        // assert
        chain.Should().NotBeNull();
        chain.ToDominoesRawString().Should().Be(rawExpected);
    }
    
    [Theory]
    [ClassData(typeof(DominoesInvalidTestData))]
    public void ShouldNotFindChainAsItDoesntExist(string rawInput)
    {
        // arrange
        var input = rawInput.ToDominoesList();
        
        // act
        var chain = RecursiveBacktracking.FindCircularDominoesChain(input);
        
        // assert
        chain.Should().BeNull();
    }
}