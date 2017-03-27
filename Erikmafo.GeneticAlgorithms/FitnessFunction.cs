using System;
namespace Erikmafo.GeneticAlgorithms
{
	public interface FitnessFunction<T>
	{
		/// <summary>
		/// Evaluates the fitness of the specified Chromosone.
		/// </summary>
		/// <returns>The fitness.</returns>
		/// <param name="chromosone">Chromosone.</param>
		double EvaluateFitness(DefaultChromosone<T> chromosone);

	}
}
