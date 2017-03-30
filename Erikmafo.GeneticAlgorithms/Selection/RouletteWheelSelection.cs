

using System;

namespace Erikmafo.GeneticAlgorithms.Selection
{
	public class RouletteWheelSelection : ParentSelection
	{
		private readonly RandomNumberGenerator randomNumberGenerator;

		public RouletteWheelSelection(RandomNumberGenerator randomNumberGenerator)
		{
			this.randomNumberGenerator = randomNumberGenerator;	
		}


		public T DoSelection<T>(Population<T> population) where T : BreedingCandidate
		{

		    if (population.Size <= 0)
		    {
		        throw new ArgumentException("The population cannot be empty");
		    }

		    T selected = default(T);

		    var spin = randomNumberGenerator.NextDouble() * population.TotalFitness;

			var currentFitness = 0.0;

		    foreach (T candidate in population.GetCandidates())
		    {
				currentFitness += candidate.Fitness;

				if (spin <= currentFitness)
				{
					selected = candidate;
					break;
				}
		    }

		    return selected;
		}
	}
}
