namespace GeneticAlgorithms
{
    /// <summary>
    /// Crossover method.
    /// </summary>
    public interface ICrossoverMethod
    {
        /// <summary>
        /// Selects the gene that should make up the ith gene of the offspring.
        /// </summary>
        /// <returns>The ith gene of the offspring.</returns>
        /// <param name="index">Index.</param>
        /// <param name="mother">Mother.</param>
        /// <param name="father">Father.</param>
        /// <typeparam name="T">The type of the Gene.</typeparam>
        T SelectGene<T>(int index, IChromosome<T> mother, IChromosome<T> father);
    }
}