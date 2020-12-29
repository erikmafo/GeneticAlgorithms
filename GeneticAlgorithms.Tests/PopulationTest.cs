using NUnit.Framework;

namespace GeneticAlgorithms.Tests
{
    [TestFixture]
    public class PopulationTest
    {
        private IPopulation<IBreedingCandidate> _population;

        [SetUp]
        public void Setup()
        {
            _population = new Population<IBreedingCandidate>();
        }

        [Test]
        public void TestZeroCandidatesAdded()
        {
            Assert.AreEqual(0.0, _population.TotalFitness);
            Assert.AreEqual(0, _population.Size);
        }

        [Test]
        public void TestAddCandidate()
        {
            var candidateA = BreedingCandidateMocks.CreateMock(0.4);
            var candidateB = BreedingCandidateMocks.CreateMock(1.5);

            _population.Add(candidateA);
            _population.Add(candidateB);

            Assert.AreEqual(1.9, _population.TotalFitness);
            Assert.AreEqual(2, _population.Size);
        }

        [Test]
        public void TestRemoveCandidate()
        {
            var candidateA = BreedingCandidateMocks.CreateMock(0.4);

            _population.Add(candidateA);
            _population.Remove(candidateA);

            Assert.AreEqual(0, _population.Size);
            Assert.AreEqual(0.0, _population.TotalFitness);
        }
    }
}