using System;
using System.Collections.Generic;
using NUnit.Framework;
using SurvivorIO.UpgradeFlow;

public class UpgradeOfferSelectorTests
{
    [Test]
    public void CombatCooldownAllowsHitsAtConfiguredInterval()
    {
        var cooldown = new CombatCooldown();

        Assert.That(cooldown.TryHit(1f, 0.5f), Is.True);
        Assert.That(cooldown.TryHit(1.25f, 0.5f), Is.False);
        Assert.That(cooldown.TryHit(1.5f, 0.5f), Is.True);
    }

    [Test]
    public void DifficultyProfileIncreasesCountAndHealthOverTime()
    {
        Assert.That(DifficultyProfile.GetEnemyCount(0f), Is.EqualTo(2));
        Assert.That(DifficultyProfile.GetEnemyCount(30f), Is.EqualTo(3));
        Assert.That(DifficultyProfile.GetEnemyHealth(30f), Is.EqualTo(2f));
        Assert.That(DifficultyProfile.GetEnemyCount(300f), Is.EqualTo(8));
    }

    [Test]
    public void SpawnCapacityDoesNotExceedEnemyLimit()
    {
        Assert.That(SpawnCapacity.GetSpawnCount(148, 5, 150), Is.EqualTo(2));
        Assert.That(SpawnCapacity.GetSpawnCount(150, 5, 150), Is.Zero);
        Assert.That(SpawnCapacity.GetSpawnCount(151, 5, 150), Is.Zero);
    }

    [Test]
    public void OneShotGateAllowsOnlyOneAcquisition()
    {
        var gate = new OneShotGate();

        Assert.That(gate.TryAcquire(), Is.True);
        Assert.That(gate.TryAcquire(), Is.False);
        Assert.That(gate.TryAcquire(), Is.False);
    }

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
