using System;
namespace Erikmafo.GeneticAlgorithms
{
	public class Individual<T> : BreedingCandidate
	{
	    public Individual(Chromosone<T> chromosone, double fitness)
		{
			this.Chromosone = chromosone;
			this.Fitness = fitness;
		}


		public Chromosone<T> Chromosone { get; }

	    public double Fitness { get; }
	}
}
