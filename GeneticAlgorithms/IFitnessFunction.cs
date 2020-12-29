namespace GeneticAlgorithms
{
    public interface IFitnessFunction<T>
    {
        /// <summary>
        /// Evaluates the fitness of the specified IChromosome.
        /// </summary>
        /// <returns>The fitness.</returns>
        /// <param name="chromosome">IChromosome.</param>
        double EvaluateFitness(Chromosome<T> chromosome);
    }
}