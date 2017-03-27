using System.Collections.Generic;

namespace GeneticAlgorithms
{
    public interface Population<T> where T : BreedingCandidate
    {

        int Size { get;  }

        double TotalFitness { get; }

        IEnumerable<T> GetCandidates();

    }
}