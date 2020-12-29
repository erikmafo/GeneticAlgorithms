using System;
using NUnit.Framework;
using Moq;

namespace GeneticAlgorithms.Tests
{
    [TestFixture]
    public class ChromosomeTest
    {
        private readonly Mock<ICrossoverMethod> _crossoverMethodMock = new();

        [Test]
        public void ConstructorShouldSetTheValueOfEachGenes()
        {
            int[] values = {1, 2, 3};

            var chromosome = new Chromosome<int>(values);

            Assert.AreEqual(values.Length, chromosome.Length);
            for (var i = 0; i < values.Length; i++)
                Assert.AreEqual(values[i], chromosome.GetGene(i));
        }

        [Test]
        public void ShouldCreateNewChromosoneWithGenesSelectedFromTheParents()
        {
            var mother = new Chromosome<string>(new[] {"A", "B", "C"});
            var father = new Chromosome<string>(new[] {"D", "E", "F"});
            _crossoverMethodMock.Setup(cm => cm.SelectGene(0, mother, father)).Returns("A");
            _crossoverMethodMock.Setup(cm => cm.SelectGene(1, mother, father)).Returns("E");
            _crossoverMethodMock.Setup(cm => cm.SelectGene(2, mother, father)).Returns("F");

            var child = mother.DoCrossover(_crossoverMethodMock.Object, father);

            Assert.AreEqual("A", child.GetGene(0));
            Assert.AreEqual("E", child.GetGene(1));
            Assert.AreEqual("F", child.GetGene(2));
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfAttemptToCrossoverChromosonesWithUnequalLength()
        {
            var mother = new Chromosome<string>(new[] {"A", "B", "C"});
            var father = new Chromosome<string>(new[] {"D", "E"});

            Assert.Throws(typeof(ArgumentException), () => mother.DoCrossover(_crossoverMethodMock.Object, father));
        }

        [Test]
        public void ShouldCreateExactCopy()
        {
            var chromosome = new Chromosome<string>(new[] {"H", "E", "L", "L", "O"});

            var copy = chromosome.CreateCopy();

            Assert.AreEqual("H", copy.GetGene(0));
            Assert.AreEqual("E", copy.GetGene(1));
            Assert.AreEqual("L", copy.GetGene(2));
            Assert.AreEqual("L", copy.GetGene(3));
            Assert.AreEqual("O", copy.GetGene(4));
        }

        [Test]
        public void ShouldApplyMutationOperatorToEachGene()
        {
            var chromosome = new Chromosome<int>(new[] {1, 2, 3});
            var mutationOperatorMock = new Mock<IMutationOperator>();
            mutationOperatorMock.Setup(mock => mock.MutateGene(0, chromosome)).Returns(1);
            mutationOperatorMock.Setup(mock => mock.MutateGene(1, chromosome)).Returns(0);
            mutationOperatorMock.Setup(mock => mock.MutateGene(2, chromosome)).Returns(3);

            chromosome.ApplyMutationOperator(mutationOperatorMock.Object);

            Assert.AreEqual(1, chromosome.GetGene(0));
            Assert.AreEqual(2, chromosome.GetGene(1));
            Assert.AreEqual(3, chromosome.GetGene(2));
        }
    }
}