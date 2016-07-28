using System.Collections.Generic;
using exercism;
using NUnit.Framework;

[TestFixture]
public class NucleoTideCountTest
{
    [Test]
    public void Has_no_nucleotides()
    {
        var dna = new Dna("");
        var expected = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 0 } };
        Assert.That(dna.NucleotideCounts, Is.EqualTo(expected));
    }

    [Test]
    public void Has_no_adenosine()
    {
        var dna = new Dna("");
        Assert.That(dna.Count('A'), Is.EqualTo(0));
    }

    [Test]
    public void Repetitive_cytidine_gets_counts()
    {
        var dna = new Dna("CCCCC");
        Assert.That(dna.Count('C'), Is.EqualTo(5));
    }

    [Test]
    public void Repetitive_sequence_has_only_guanosine()
    {
        var dna = new Dna("GGGGGGGG");
        var expected = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 8 } };
        Assert.That(dna.NucleotideCounts, Is.EqualTo(expected));
    }

    [Test]
    public void Counts_only_thymidine()
    {
        var dna = new Dna("GGGGTAACCCGG"); 
        Assert.That(dna.Count('T'), Is.EqualTo(1));
    }

    [Test]
    public void Counts_a_nucleotide_only_once()
    {
        var dna = new Dna("GGTTGG");
        dna.Count('T');
        Assert.That(dna.Count('T'), Is.EqualTo(2));
    }

    [Test]
    public void Validates_nucleotides()
    {
        var dna = new Dna("GGTTGG");
        Assert.Throws<InvalidNucleotideException>(() => dna.Count('X'));
    }

    [Test]
    public void Counts_all_nucleotides()
    {
        var dna = new Dna("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC");
        var expected = new Dictionary<char, int> { { 'A', 20 }, { 'T', 21 }, { 'C', 12 }, { 'G', 17 } };
        Assert.That(dna.NucleotideCounts, Is.EqualTo(expected));
    }
}

