using System;

namespace GeneticAlgorithms
{
    public interface IChromosome<T>
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
        /// Dos a crossover between this <see cref="IChromosome{T}"/> and another by applying the specified ICrossoverMethod.
        /// </summary>
        /// <returns>The resulting offspring.</returns>
        /// <param name="crossoverMethod">Crossover method.</param>
        /// <param name="other">Other.</param>
        IChromosome<T> DoCrossover(ICrossoverMethod crossoverMethod, IChromosome<T> other);


        IChromosome<T> ApplyMutationOperator(IMutationOperator mutationOperator);

        /// <summary>
        /// Creates a copy of this <see cref="IChromosome{T}"/>
        /// </summary>
        /// <returns></returns>
        IChromosome<T> CreateCopy();
    }
}