namespace Sandbox.Sorts.IComparable
{
    /// <summary>
    /// Class which has various properties about a country, and a means to sort it via its <see cref="Word"/> property
    /// implementing <see cref="IComparable"/>
    /// </summary>
    public class Country : IComparable<Country>
    {
        public string? Word { get; set; }
        public string? Language { get; set; }
        public int Population { get; set; }

        public int CompareTo(Country? other)
        {
            if (Word == null)
                return other?.Word == null ? 0 : 1;

            if (other?.Word == null)
                return -1; // a > b

            // We've now got something to compare
            int returnValue = Word.Length.CompareTo(other.Word.Length);

            if (returnValue != 0) return returnValue; // Lengths are not equal

            // Lengths are equal, so compare by normal alphabetical order instead
            return string.Compare(Word, other.Word, StringComparison.Ordinal);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Country other) return false;
            return Word?.Equals(other.Word) ?? false;
        }

        public static bool operator ==(Country left, Country right) => left.Population == right.Population;

        public static bool operator !=(Country left, Country right) => left.Population != right.Population;

        public static bool operator <(Country left, Country right) => left.Population < right.Population;

        public static bool operator >(Country left, Country right) => left.Population > right.Population;

        public override int GetHashCode() => Word?.GetHashCode() ^ Language?.GetHashCode() ?? 0;
    }
}
