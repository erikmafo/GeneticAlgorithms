using System.Collections.Generic;

namespace GeneticAlgorithms
{
    public class Population<T> : IPopulation<T> where T : IBreedingCandidate
    {
        private readonly IList<T> _candidates = new List<T>();

        public Population()
        {
        }

        public int Size => _candidates.Count;

        public double TotalFitness { get; private set; }

        public void Add(T candidate)
        {
            _candidates.Add(candidate);
            TotalFitness += candidate.Fitness;
        }

        public IEnumerable<T> GetCandidates() => _candidates;

        public bool Remove(T candidate)
        {
            TotalFitness -= candidate.Fitness;
            return _candidates.Remove(candidate);
        }
    }
}