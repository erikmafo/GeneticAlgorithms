using System;

namespace Erikmafo.GeneticAlgorithms
{
    public interface Chromosone<T>
    {
        /// <summary>
        ///  Length property
        /// </summary>
        /// <value>The number of genes.</value>
        int Length { get; }

        /// <summary>
        /// Gets the gene at a specified index.
        /// </summary>
        /// <returns>The gene at the specied index.</returns>
        /// <param name="i">The index.</param>
        T GetGene(int i);

        /// <summary>
        /// Dos a crossover between this Chromosone and another by applying the specified CrossoverMethod.
        /// </summary>
        /// <returns>The resulting offspring.</returns>
        /// <param name="crossoverMethod">Crossover method.</param>
        /// <param name="other">Other.</param>
        Chromosone<T> DoCrossover(CrossoverMethod crossoverMethod, Chromosone<T> other);


        /// <summary>
        /// Creates a copy of this Chromosone
        /// </summary>
        /// <returns></returns>
        Chromosone<T> CreateCopy();

    }
}