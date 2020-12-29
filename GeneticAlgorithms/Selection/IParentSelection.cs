using System;
using System.Collections.Generic;

namespace GeneticAlgorithms.Selection
{
    public interface IParentSelection
    {
        /// <summary>
        /// Does the selection of parents to produce the next offspring.
        /// </summary>
        /// <returns>The candidate selected for breeding.</returns>
        /// <param name="candidates">The breeding candidates to select from.</param>
        T Select<T>(IPopulation<T> candidates) where T : IBreedingCandidate;
    }
}