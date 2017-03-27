using System;
using NUnit.Framework;
using Moq;
using Erikmafo.GeneticAlgorithms;


namespace Erikmafo.GeneticAlgorithmsTests
{
	[TestFixture]
	public class DefaultPopulationTest
	{

		private Population<BreedingCandidate> population;


		[SetUp]
		public void Setup()
		{
			population = new DefaultPopulation<BreedingCandidate>();
		}

		[Test]
		public void TestZeroCandidatesAdded()
		{
			Assert.AreEqual(0.0, population.TotalFitness);
			Assert.AreEqual(0, population.Size);
		}

		[Test]
		public void TestAddCandidate()
		{
			BreedingCandidate candidateA = BreedingCandidateMocks.CreateMock(0.4);
			BreedingCandidate candidateB = BreedingCandidateMocks.CreateMock(1.5);

			population.Add(candidateA);
			population.Add(candidateB);

			Assert.AreEqual(1.9, population.TotalFitness);
			Assert.AreEqual(2, population.Size);
		}

		[Test]
		public void TestRemoveCandidate()
		{
			BreedingCandidate candidateA = BreedingCandidateMocks.CreateMock(0.4);

			population.Add(candidateA);

			population.Remove(candidateA);

			Assert.AreEqual(0, population.Size);

			Assert.AreEqual(0.0, population.TotalFitness);
			
		}








	}
}
