using System;
namespace Erikmafo.GeneticAlgorithms
{
	public class Individual<T> : BreedingCandidate
	{
	    private readonly double fitness;

		public Individual(Chromosone<T> chromosone, double fitness)
		{
			this.Chromosone = chromosone;
			this.fitness = fitness;
		}


		public Chromosone<T> Chromosone { get; }

	    public double GetFitness()
		{
			return fitness;
		}
	}
}
