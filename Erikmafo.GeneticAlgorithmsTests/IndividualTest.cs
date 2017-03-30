using System;
using Erikmafo.GeneticAlgorithms;

namespace Erikmafo.GeneticAlgorithmsTests
{
	using NUnit.Framework;
	using Moq;

	[TestFixture]
	public class IndividualTest
	{

		[Test]
		public void ConstructorShouldSetTheFitness()
		{
			double fitness = 0.3;

			var individual = new Individual<Object>(new Mock<Chromosone<Object>>().Object, fitness);

			Assert.AreEqual(fitness, individual.Fitness);
		}

	}
}
