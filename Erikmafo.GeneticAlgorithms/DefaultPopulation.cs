using System;
using System.Collections.Generic;

namespace Erikmafo.GeneticAlgorithms
{
	public class DefaultPopulation<T> : Population<T> where T : BreedingCandidate
	{

		private readonly IList<T> candidates = new List<T>();

	    public DefaultPopulation()
		{
		}

		public int Size => candidates.Count;

	    public double TotalFitness { get; private set; }

	    public void Add(T candidate)
		{
			candidates.Add(candidate);

			TotalFitness += candidate.Fitness;
		}

		public IEnumerable<T> GetCandidates()
		{
			return candidates;
		}

		public bool Remove(T candidate)
		{
			TotalFitness -= candidate.Fitness;

			return candidates.Remove(candidate);
		}
	}
}
