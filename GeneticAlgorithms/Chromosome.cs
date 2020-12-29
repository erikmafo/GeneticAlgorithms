using System;

namespace GeneticAlgorithms
{
    /// <summary>
    /// Contains a set of genes.
    /// </summary>
    public class Chromosome<T> : IChromosome<T>
    {
        /// <summary>
        /// The genes of this IChromosome.
        /// </summary>
        private readonly T[] _genes;

        /// <summary>
        ///  Length property
        /// </summary>
        /// <value>The number of genes.</value>
        public int Length => _genes.Length;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GeneticAlgorithms.IChromosome`1"/> class 
        /// with the specified genes.
        /// </summary>
        /// <param name="genes">Genes.</param>
        public Chromosome(T[] genes)
        {
            _genes = genes;
        }

        /// <summary>
        /// Gets the gene at a specified index.
        /// </summary>
        /// <returns>The gene at the specied index.</returns>
        /// <param name="i">The index.</param>
        public T GetGene(int i) => _genes[i];

        /// <summary>
        /// Dos a crossover between this IChromosome and another by applying the specified ICrossoverMethod.
        /// </summary>
        /// <returns>The resulting offspring.</returns>
        /// <param name="crossoverMethod">Crossover method.</param>
        /// <param name="other">Other.</param>
        public IChromosome<T> DoCrossover(ICrossoverMethod crossoverMethod, IChromosome<T> other)
        {
            if (Length != other.Length)
            {
                throw new ArgumentException("Chromosomes must be of same length");
            }

            var childGenes = new T[Length];

            for (var i = 0; i < Length; i++)
            {
                childGenes[i] = crossoverMethod.SelectGene(i, this, other);
            }

            return new Chromosome<T>(childGenes);
        }

        public IChromosome<T> ApplyMutationOperator(IMutationOperator mutationOperator)
        {
            var newGenes = new T[Length];

            for (var i = 0; i < Length; i++)
            {
                newGenes[i] = mutationOperator.MutateGene(i, this);
            }

            return new Chromosome<T>(newGenes);
        }

        public IChromosome<T> CreateCopy() => new Chromosome<T>(_genes);
    }
}