using System;
using System.Collections.Generic;

namespace GeneticAlgorithms
{
	public interface ParentSelection
	{
		/// <summary>
		/// Does the selection of parents to produce the next offspring.
		/// </summary>
		/// <returns>The candidate selected for breeding.</returns>
		/// <param name="candidates">The breeding candidates to select from.</param>
		T DoSelection<T>(Population<T> candidates) where T : BreedingCandidate;

	}
}
