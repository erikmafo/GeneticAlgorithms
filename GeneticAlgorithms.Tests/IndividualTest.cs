using NUnit.Framework;
using Moq;

namespace GeneticAlgorithms.Tests
{
    [TestFixture]
    public class IndividualTest
    {
        [Test]
        public void ConstructorShouldSetTheFitness()
        {
            const double fitness = 0.3;

            var individual = new Individual<object>(new Mock<IChromosome<object>>().Object, fitness);

            Assert.AreEqual(fitness, individual.Fitness);
        }
    }
}