

namespace Erikmafo.GeneticAlgorithms
{
    public interface MutationOperator
    {

        /// <summary>
        /// Mutates the value of a gene with a certain probability.
        /// </summary>
        /// <param name="index">The index of the gene in the chromosone</param>
        /// <param name="original">The original chromosone</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>A new value of the gene, or the same value</returns>
		T MutateGene<T>(int index, Chromosone<T> original);
    }
}