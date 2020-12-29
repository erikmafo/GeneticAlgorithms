using Moq;

namespace GeneticAlgorithms.Tests
{
    public static class BreedingCandidateMocks
    {
        public static IBreedingCandidate CreateMock(double fitness)
        {
            var mock = new Mock<IBreedingCandidate>
            {
                Name = "Breeding candidate with fitness equal to " + fitness
            };
            mock.Setup(m => m.Fitness).Returns(fitness);
            return mock.Object;
        }
    }
}