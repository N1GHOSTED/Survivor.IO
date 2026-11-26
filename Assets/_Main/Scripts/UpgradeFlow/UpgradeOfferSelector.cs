using System;
using System.Collections.Generic;

namespace SurvivorIO.UpgradeFlow
{
    public sealed class OneShotGate
    {
        private bool acquired;

        public bool TryAcquire()
        {
            if (acquired)
            {
                return false;
            }

            acquired = true;
            return true;
        }
    }

    public static class UpgradeOfferSelector
    {
        public static List<int> SelectDistinct(IList<int> candidates, int count, Random random)
        {
            if (candidates == null)
            {
                throw new ArgumentNullException(nameof(candidates));
            }

            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            var available = new List<int>();
            foreach (int candidate in candidates)
            {
                if (!available.Contains(candidate))
                {
                    available.Add(candidate);
                }
            }

            var selected = new List<int>(Math.Min(count, available.Count));
            while (selected.Count < count && available.Count > 0)
            {
                int index = random.Next(available.Count);
                selected.Add(available[index]);
                available.RemoveAt(index);
            }

            return selected;
        }
    }
}
