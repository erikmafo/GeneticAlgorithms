using System;
using System.Collections.Generic;

namespace Erikmafo.GeneticAlgorithms
{
	public class DefaultPopulation<T> : Population<T> where T : BreedingCandidate
	{

		private IList<T> candidates = new List<T>();

		private double totalFitness = 0.0;

		public DefaultPopulation()
		{
		}

		public int Size
		{
			get
			{
				return candidates.Count;
			}
		}

		public double TotalFitness
		{
			get
			{
				return totalFitness;
			}
		}

		public void Add(T candidate)
		{
			candidates.Add(candidate);

			totalFitness += candidate.GetFitness();
		}

		public IEnumerable<T> GetCandidates()
		{
			return candidates;
		}

		public bool Remove(T candidate)
		{
			totalFitness -= candidate.GetFitness();

			return candidates.Remove(candidate);
		}
	}
}
