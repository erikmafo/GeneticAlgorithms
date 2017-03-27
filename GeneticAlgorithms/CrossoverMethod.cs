namespace GeneticAlgorithms
{


	/// <summary>
	/// Crossover method.
	/// </summary>
	public interface CrossoverMethod
	{

		/// <summary>
		/// Selects the gene that should make up the ith gene of the offspring.
		/// </summary>
		/// <returns>The ith gene of the offstring.</returns>
		/// <param name="index">Index.</param>
		/// <param name="mother">Mother.</param>
		/// <param name="father">Father.</param>
		/// <typeparam name="T">The type of the Gene.</typeparam>
		T SelectGene<T>(int index, Chromosone<T> mother, Chromosone<T> father);

	}
}
