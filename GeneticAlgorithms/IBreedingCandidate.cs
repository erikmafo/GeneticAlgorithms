using System;

namespace GeneticAlgorithms
{
    public interface IBreedingCandidate
    {
        double Fitness { get; }
    }
}