using System;
namespace Erikmafo.GeneticAlgorithms
{

    /// <summary>
    /// Contains a set of genes.
    /// </summary>
	public class DefaultChromosone<T> : Chromosone<T>
    {
		/// <summary>
		/// The genes of this Chromosone.
		/// </summary>
		private readonly T[] genes;

		/// <summary>
		///  Length property
		/// </summary>
		/// <value>The number of genes.</value>
		public int Length => genes.Length;

	    /// <summary>
		/// Initializes a new instance of the <see cref="T:Erikmafo.GeneticAlgorithms.Chromosone`1"/> class 
		/// with the specified genes.
		/// </summary>
		/// <param name="genes">Genes.</param>
		public DefaultChromosone(T[] genes)
		{
			this.genes = genes;
		}

		/// <summary>
		/// Gets the gene at a specified index.
		/// </summary>
		/// <returns>The gene at the specied index.</returns>
		/// <param name="i">The index.</param>
		public T GetGene(int i)
		{
			return genes[i];
		}

		/// <summary>
		/// Dos a crossover between this Chromosone and another by applying the specified CrossoverMethod.
		/// </summary>
		/// <returns>The resulting offspring.</returns>
		/// <param name="crossoverMethod">Crossover method.</param>
		/// <param name="other">Other.</param>
		public Chromosone<T> DoCrossover(CrossoverMethod crossoverMethod, Chromosone<T> other)
		{

			if (Length != other.Length)
			{
				throw new ArgumentException("Chromosones must be of same length");
			}

			var childGenes = new T[Length];

			for (var i = 0; i < Length; i++)
			{
				childGenes[i] = crossoverMethod.SelectGene(i, this, other);
			}

			return new DefaultChromosone<T>(childGenes);
		}

		public Chromosone<T> ApplyMutationOperator(MutationOperator mutationOperator)
        {
			var newGenes = new T[Length];

            for (var i = 0; i < Length; i++)
            {
				newGenes[i] = mutationOperator.MutateGene(i, this);
            }

			return new DefaultChromosone<T>(newGenes);

        }

        public Chromosone<T> CreateCopy()
        {
            return new DefaultChromosone<T>(genes);
        }

    }

}
