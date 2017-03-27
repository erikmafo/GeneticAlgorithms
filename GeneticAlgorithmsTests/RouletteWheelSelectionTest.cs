using System;
using System.Linq;
using GeneticAlgorithms;

namespace GeneticAlgorithmsTests
{
	using NUnit.Framework;
	using Moq;
	using System.Collections.Generic;

	[TestFixture]
	public class RouletteWheelSelectionTest
	{
		private readonly Mock<RandomNumberGenerator> randomNumberGeneratorMock = new Mock<RandomNumberGenerator>();
		private RouletteWheelSelection rouletteWheelSelection;

		[SetUp]
		public void setup()
		{
			rouletteWheelSelection = new RouletteWheelSelection(randomNumberGeneratorMock.Object);

		}


		private static BreedingCandidate CreateCandidateMock(double fitness)
		{
			var mock = new Mock<BreedingCandidate>();
		    mock.Name = "Breeding candidate with fitness equal to " + fitness.ToString();
			mock.Setup(m => m.GetFitness()).Returns(fitness);

			return mock.Object;
		}


	    private static Population<T> CreatePopulationMock<T>(IEnumerable<T> candidates) where T : BreedingCandidate
	    {
	        Mock<Population<T>> populationMock = new Mock<Population<T>>();

	        double sum = 0.0;

	        foreach (var candidate in candidates)
	        {
	            sum += candidate.GetFitness();
	        }

	        populationMock.Setup(pop => pop.Size).Returns(candidates.Count);
	        populationMock.Setup(pop => pop.TotalFitness).Returns(sum);
	        populationMock.Setup(pop => pop.GetCandidates()).Returns(candidates);

	        return populationMock.Object;
	    }


	    private static readonly object[] SelectionCases =
		{
			new object[] { 0.3, AsList(CreateCandidateMock(0.0)), 0},
			new object[] { 0.3, AsList(CreateCandidateMock(4.0), CreateCandidateMock(6.0)), 0},
			new object[] { 0.5, AsList(CreateCandidateMock(4.0), CreateCandidateMock(6.0)), 1},
			new object[] { 0.7, AsList(CreateCandidateMock(4.0), CreateCandidateMock(6.0)), 1}
		};


	    private static IList<T> AsList<T>(params T[] values)
	    {
	        return new List<T>(values);
	    }


		[Test, TestCaseSource(nameof(SelectionCases))]
		public void TheProbabilityOfSelectionShouldBeProportionalToFitness(double random, IList<BreedingCandidate> candidates, int indexOfWinner)
		{
		    BreedingCandidate winner = candidates[indexOfWinner];
		    var population = CreatePopulationMock(candidates);
		    randomNumberGeneratorMock.Setup(m => m.NextDouble()).Returns(random);

			var selected = rouletteWheelSelection.DoSelection(population);

		    Assert.AreSame(winner, selected);
		}


	    [Test]
	    public void ShouldThrowArgumentExceptionIfPopulationIsEmpty()
	    {
	        var population = CreatePopulationMock(Enumerable.Empty<BreedingCandidate>());

	        Assert.Throws(typeof(ArgumentException), () => rouletteWheelSelection.DoSelection(population));
	    }


	}
}
