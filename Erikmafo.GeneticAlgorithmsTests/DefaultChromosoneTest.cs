using System;
using Erikmafo.GeneticAlgorithms;
using NUnit.Framework;
using Moq;

namespace Erikmafo.GeneticAlgorithmsTests
{
	[TestFixture]
	public class DefaultChromosoneTest
	{
		private Mock<CrossoverMethod> crossoverMethodMock = new Mock<CrossoverMethod>();

		[Test]
		public void ConstructorShouldSetTheValueOfEachGenes()
		{
			int[] values = { 1, 2, 3 };

		    Chromosone<int> chromosone = new DefaultChromosone<int>(values);

			Assert.AreEqual(values.Length, chromosone.Length);

			for (int i = 0; i < values.Length; i++)
			{
				Assert.AreEqual(values[i], chromosone.GetGene(i));
			}

		}


		[Test]
		public void ShouldCreateNewChromosoneWithGenesSelectedFromTheParents()
		{
			// arrange
			var mother = new DefaultChromosone<String>(new String[] { "A", "B", "C" });
			var father = new DefaultChromosone<String>(new String[] { "D", "E", "F" });
			crossoverMethodMock.Setup(cm => cm.SelectGene(0, mother, father)).Returns("A");
			crossoverMethodMock.Setup(cm => cm.SelectGene(1, mother, father)).Returns("E");
			crossoverMethodMock.Setup(cm => cm.SelectGene(2, mother, father)).Returns("F");

			// act
			var child = mother.DoCrossover(crossoverMethodMock.Object, father);

			// assert
			Assert.AreEqual("A", child.GetGene(0));
			Assert.AreEqual("E", child.GetGene(1));
			Assert.AreEqual("F", child.GetGene(2));
		}


		[Test]
		public void ShouldThrowArgumentExceptionIfAttemptToCrossoverChromosonesWithUnequalLength()
		{ 
			
			var mother = new DefaultChromosone<String>(new String[] { "A", "B", "C" });
			var father = new DefaultChromosone<String>(new String[] { "D", "E"});

			Assert.Throws(typeof(ArgumentException), () => mother.DoCrossover(crossoverMethodMock.Object, father));
		
		}



	    [Test]
	    public void ShouldCreateExactCopy()
	    {

	        var chromosone = new DefaultChromosone<string>(new string[] {"H", "E", "L", "L", "O"});

	        var copy = chromosone.CreateCopy();

	        Assert.AreEqual("H", copy.GetGene(0));
	        Assert.AreEqual("E", copy.GetGene(1));
	        Assert.AreEqual("L", copy.GetGene(2));
	        Assert.AreEqual("L", copy.GetGene(3));
	        Assert.AreEqual("O", copy.GetGene(4));

	    }



	    [Test]
	    public void ShouldApplyMutationOperatorToEachGene()
	    {
			var chromosone = new DefaultChromosone<int>(new[] { 1, 2, 3 });

	        var mutationOperatorMock = new Mock<MutationOperator>();

			mutationOperatorMock.Setup(mock => mock.MutateGene(0, chromosone)).Returns(1);
			mutationOperatorMock.Setup(mock => mock.MutateGene(1, chromosone)).Returns(0);
			mutationOperatorMock.Setup(mock => mock.MutateGene(2, chromosone)).Returns(3);

	        chromosone.ApplyMutationOperator(mutationOperatorMock.Object);

	        Assert.AreEqual(1, chromosone.GetGene(0));
	        Assert.AreEqual(2, chromosone.GetGene(1));
	        Assert.AreEqual(3, chromosone.GetGene(2));

	    }



	}
}
