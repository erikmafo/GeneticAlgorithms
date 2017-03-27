namespace GeneticAlgorithms
{
	public interface RandomNumberGenerator
	{

	    /// <summary>
	    /// Returns a pseduo random double int the interval [0, 1]
	    /// </summary>
	    /// <returns> A double between 0 and 1</returns>
		double NextDouble();
	}
}
