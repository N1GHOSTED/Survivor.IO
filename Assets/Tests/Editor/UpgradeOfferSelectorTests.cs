using System;
using System.Collections.Generic;
using NUnit.Framework;
using SurvivorIO.UpgradeFlow;

public class UpgradeOfferSelectorTests
{
    [Test]
    public void SelectDistinctReturnsUniqueCandidatesUpToRequestedCount()
    {
        var candidates = new List<int> { 1, 2, 2, 3 };

        List<int> selected = UpgradeOfferSelector.SelectDistinct(candidates, 3, new Random(1));

        Assert.That(selected, Has.Count.EqualTo(3));
        Assert.That(selected, Is.Unique);
        Assert.That(selected, Is.SubsetOf(new[] { 1, 2, 3 }));
    }

    [Test]
    public void SelectDistinctReturnsAvailableOptionsWhenThereAreFewerThanRequested()
    {
        List<int> selected = UpgradeOfferSelector.SelectDistinct(
            new List<int> { 7, 7 },
            3,
            new Random(1));

        Assert.That(selected, Is.EqualTo(new[] { 7 }));
    }

    [Test]
    public void SelectDistinctReturnsEmptyForNoCandidates()
    {
        List<int> selected = UpgradeOfferSelector.SelectDistinct(
            new List<int>(),
            3,
            new Random(1));

        Assert.That(selected, Is.Empty);
    }
}
