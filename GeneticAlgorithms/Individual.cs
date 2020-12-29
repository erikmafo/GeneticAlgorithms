namespace GeneticAlgorithms
{
    public class Individual<T> : IBreedingCandidate
    {
        public Individual(IChromosome<T> chromosome, double fitness)
        {
            Chromosome = chromosome;
            Fitness = fitness;
        }

        public IChromosome<T> Chromosome { get; }

        public double Fitness { get; }
    }
}