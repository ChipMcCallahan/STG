using System;

namespace STG
{
    class RNG
    {
        private int seed;

        // Chooses as starting seed a non-negative random Int32, 
        // with random state derived from system clock.
        // See https://docs.microsoft.com/en-us/dotnet/api/system.random.
        internal RNG()
        {
            this.seed = new Random().Next();
        }

        internal RNG(int seed)
        {
            if (seed < 0) { throw new ArgumentException("Seed must be nonnegative."); }
            this.seed = seed;
        }

        // Do NOT rely on the low order bits of the LCG alone.
        // See https://en.wikipedia.org/wiki/Linear_congruential_generator.
        internal int Next()
        {
            this.seed = (this.seed * 1103515245 + 12345) & 0x7FFFFFFF;
            return this.seed ^ this.seed >> 13 ^ this.seed >> 7; // thanks pieguy
        }
    }
}
