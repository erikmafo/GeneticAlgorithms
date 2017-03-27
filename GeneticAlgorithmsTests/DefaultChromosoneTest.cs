using System;


namespace GeneticAlgorithmsTests
{
	using NUnit.Framework;
	using Moq;
    using GeneticAlgorithms;

	[TestFixture]
	public class DefaultChromosoneTest
	{
		private DefaultChromosone<int> chromosone;
		private Mock<CrossoverMethod> crossoverMethodMock = new Mock<CrossoverMethod>();

		[Test]
		public void ConstructorShouldSetTheValueOfEachGenes()
		{
			int[] values = { 1, 2, 3 };

			chromosone = new DefaultChromosone<int>(values);

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





	}
}
