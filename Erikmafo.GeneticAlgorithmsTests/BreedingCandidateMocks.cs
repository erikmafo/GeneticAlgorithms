using System;
using Moq;
using Erikmafo.GeneticAlgorithms;


namespace Erikmafo.GeneticAlgorithmsTests
{
	public class BreedingCandidateMocks
	{
		private BreedingCandidateMocks()
		{
		}


		public static BreedingCandidate CreateMock(double fitness)
		{
			var mock = new Mock<BreedingCandidate>();
			mock.Name = "Breeding candidate with fitness equal to " + fitness.ToString();
			mock.Setup(m => m.Fitness).Returns(fitness);

			return mock.Object;
		}

	}
}
