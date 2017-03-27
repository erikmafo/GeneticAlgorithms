using System.Collections.Generic;

namespace Erikmafo.GeneticAlgorithms
{
    public interface Population<T> where T : BreedingCandidate
    {
		/// <summary>
		/// Gets the number of BreedingCandidates in this population.
		/// </summary>
		/// <value>The size of the population.</value>
        int Size { get;  }

		/// <summary>
		/// Gets the sum of the fitness of all BreedingCandidates in this population.
		/// </summary>
		/// <value>The total fitness in the population.</value>
        double TotalFitness { get; }

		/// <summary>
		/// Gets the candidates in this population.
		/// </summary>
		/// <returns>The candidates.</returns>
        IEnumerable<T> GetCandidates();


		/// <summary>
		/// Add the specified candidate.
		/// </summary>
		/// <param name="candidate">Candidate.</param>
		void Add(T candidate);

		/// <summary>
		/// Remove the specified candidate.
		/// </summary>
		/// <returns>True if the candidate was present in the population before removal, and false otherwise.</returns>
		/// <param name="candidate">Candidate.</param>
		bool Remove(T candidate);

    }
}