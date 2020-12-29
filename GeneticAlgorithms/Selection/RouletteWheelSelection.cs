using System;

namespace GeneticAlgorithms.Selection
{
    public class RouletteWheelSelection : IParentSelection
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public RouletteWheelSelection(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public T Select<T>(IPopulation<T> population) where T : IBreedingCandidate
        {
            if (population.Size <= 0)
            {
                throw new ArgumentException("The population cannot be empty");
            }

            var selected = default(T);

            var spin = _randomNumberGenerator.NextDouble() * population.TotalFitness;

            var currentFitness = 0.0;

            foreach (var candidate in population.GetCandidates())
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