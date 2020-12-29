using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithms.Selection;
using Moq;
using NUnit.Framework;

namespace GeneticAlgorithms.Tests.Selection
{
    [TestFixture]
    public class RouletteWheelSelectionTest
    {
        private static readonly object[] SelectionCases =
        {
            new object[] {0.3, AsList(BreedingCandidateMocks.CreateMock(0.0)), 0},
            new object[] {0.3, AsList(BreedingCandidateMocks.CreateMock(4.0), BreedingCandidateMocks.CreateMock(6.0)), 0},
            new object[] {0.5, AsList(BreedingCandidateMocks.CreateMock(4.0), BreedingCandidateMocks.CreateMock(6.0)), 1},
            new object[] {0.7, AsList(BreedingCandidateMocks.CreateMock(4.0), BreedingCandidateMocks.CreateMock(6.0)), 1}
        };

        private readonly Mock<IRandomNumberGenerator> _randomNumberGeneratorMock = new();
        private RouletteWheelSelection _rouletteWheelSelection;

        [SetUp]
        public void Setup()
        {
            _rouletteWheelSelection = new RouletteWheelSelection(_randomNumberGeneratorMock.Object);
        }

        [Test, TestCaseSource(nameof(SelectionCases))]
        public void TheProbabilityOfSelectionShouldBeProportionalToFitness(
            double random,
            IList<IBreedingCandidate> candidates,
            int indexOfWinner)
        {
            var winner = candidates[indexOfWinner];
            var population = CreatePopulationMock(candidates);
            _randomNumberGeneratorMock.Setup(m => m.NextDouble()).Returns(random);

            var selected = _rouletteWheelSelection.Select(population);

            Assert.AreSame(winner, selected);
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfPopulationIsEmpty()
        {
            var population = CreatePopulationMock(Enumerable.Empty<IBreedingCandidate>());

            Assert.Throws(typeof(ArgumentException), () => _rouletteWheelSelection.Select(population));
        }

        private static IPopulation<T> CreatePopulationMock<T>(IEnumerable<T> candidates) where T : IBreedingCandidate
        {
            var populationMock = new Mock<IPopulation<T>>();

            var candidatesList = candidates.ToList();
            var sum = candidatesList.Sum(candidate => candidate.Fitness);

            populationMock.Setup(pop => pop.Size).Returns(candidatesList.Count);
            populationMock.Setup(pop => pop.TotalFitness).Returns(sum);
            populationMock.Setup(pop => pop.GetCandidates()).Returns(candidatesList);

            return populationMock.Object;
        }

        private static IList<T> AsList<T>(params T[] values) => new List<T>(values);
    }
}