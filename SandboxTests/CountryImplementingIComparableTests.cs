using Moq;
using Sandbox.Sorts;

namespace SandboxUnitTests
{
    /// <summary>
    /// Various tests for the <see cref="Country"></see> which implements <seealso cref="IComparable"/>
    /// </summary>
    public class CountryUnitTests
    {
        [Fact]
        public void TestComparisonOrderBetweenTwoWordsWhenBothNotNullAndWordLengthIsEqual()
        {
            // Arrange
            var mockCountry1 = new Mock<Country>();
            mockCountry1.Object.Word = "a";

            var mockCountry2 = new Mock<Country>();
            mockCountry2.Object.Word = "b";

            // Act
            var word = mockCountry1.Object.CompareTo(mockCountry2.Object);
            var otherWord = mockCountry2.Object.CompareTo(mockCountry1.Object);

            // Assert
            Assert.True(word == -1 && otherWord == 1);
        }

        [Fact]
        public void TestComparisonOrderBetweenTwoWordsWhenBothNotNullAndWordLengthIsNotEqual()
        {
            // Arrange
            var mockCountry1 = new Mock<Country>();
            mockCountry1.Object.Word = "a";

            var mockCountry2 = new Mock<Country>();
            mockCountry2.Object.Word = "bb";

            // Act
            var word = mockCountry1.Object.CompareTo(mockCountry2.Object);
            var otherWord = mockCountry2.Object.CompareTo(mockCountry1.Object);

            // Assert
            Assert.True(word == -1 && otherWord == 1);
        }

        [Fact]
        public void TestComparisonOrderWhenWordIsNull() 
        {
            // Arrange
            var mockCountry1 = new Mock<Country>();
            var mockCountry2 = new Mock<Country>();

            mockCountry2.Object.Word = "b";

            // Act
            var word = mockCountry1.Object.CompareTo(mockCountry2.Object);

            // Assert 
            Assert.True(word == 1);
        }

        [Fact]
        public void TestComparisonOrderWhenWordAndOtherIsNull()
        {
            // Arrange
            var mockCountry1 = new Mock<Country>();
            var mockCountry2 = new Mock<Country>();

            // Act
            var result = mockCountry1.Object.CompareTo(mockCountry2.Object);

            // Assert 
            Assert.True(result == 0);
        }

        [Fact]
        public void TestComparisonOrderWhenWordIsNotNullAndOtherIsNull()
        {
            // Arrange
            var mockCountry1 = new Mock<Country>();
            var mockCountry2 = new Mock<Country>();

            mockCountry1.Object.Word = "b";

            // Act
            var result = mockCountry1.Object.CompareTo(mockCountry2.Object);

            // Assert 
            Assert.True(result == -1);
        }

        [Fact]
        public void TestSortEnsureCorrectOrderOfElements()
        {
            // Arrange
            var mockCountryList = new Mock<List<Country>>();
            mockCountryList.Object.Add(new()
            {
                Word = "d",
            });
            mockCountryList.Object.Add(new()
            {
                Word = "c",
            });
            mockCountryList.Object.Add(new()
            {
                Word = "b",
            });
            mockCountryList.Object.Add(new()
            {
                Word = "a",
            });

            // Act
            mockCountryList.Object.Sort();

            // Assert
            Assert.True(mockCountryList.Object.Any());
            Assert.True(mockCountryList.Object[0].Word == "a");
            Assert.True(mockCountryList.Object[1].Word == "b");
            Assert.True(mockCountryList.Object[2].Word == "c");
            Assert.True(mockCountryList.Object[3].Word == "d");
        }

        [Fact]
        public void EnsureCorrectHashTableBehaviour()
        {
            // Arrange - Need to provide non-mock instances because Mock does not use overriden GetHashcode method
            var country = new Country();
            var countryHashSet = new HashSet<Country>();

            country.Word = "Bonjour";
            country.Language = "Français";

            // Act
            countryHashSet.Add(country);
            countryHashSet.Add(new()
            {
                Word = "Hello",
                Language = "English"
            });
            countryHashSet.Add(new()
            {
                Word = "Hello",
                Language = "English"
            });

            // Assert
            Assert.True(countryHashSet.Count == 2);
            Assert.True(countryHashSet.TryGetValue(country, out _));
        }

        [Fact]
        public void EnsureCorrectEqualsBehaviourForNonEmptyInstancesOfCountryWithSameSetWordProperty()
        {
            // Arrange - Need to provide non-mock instances because Mock does not use overriden Equals method
            var country1 = new Country();
            var country2 = new Country();

            country1.Word = "a";
            country2.Word = "a";

            // Assert
            Assert.True(country1.Equals(country2));
        }

        [Fact]
        public void EnsureCorrectEqualsBehaviourForNonEmptyInstancesOfCountryWithDifferentSetWordProperty()
        {
            // Arrange - Need to provide non-mock instances because Mock does not use overriden Equals method
            var country1 = new Country();
            var country2 = new Country();

            country1.Word = "a";
            country2.Word = "b";

            // Assert
            Assert.True(!country1.Equals(country2));
        }

        [Fact]
        public void EnsureCorrectEqualsBehaviourForNonEmptyInstancesOfCountryWithSameSetWordPropertyButDifferentKeySetLanguageProperties()
        {
            // Arrange - Need to provide non-mock instances because Mock does not use overriden Equals method
            var country1 = new Country();
            var country2 = new Country();

            country1.Word = "Bonjour";
            country1.Language = "Français";

            country2.Word = "Bonjour";
            country2.Language = "Français (but with an English accent)";

            // Assert
            Assert.True(country1.Equals(country2));
        }

        [Fact]
        public void PopulationsBetweenTwoCountriesAreEqual()
        {
            // Arrange
            var country1 = new Country();
            var country2 = new Country();

            country1.Population = 1;
            country2.Population = 1;

            // Assert
            Assert.True(country1 == country2);
        }

        [Fact]
        public void PopulationsBetweenTwoCountriesAreNotEqual()
        {
            // Arrange
            var country1 = new Country();
            var country2 = new Country();

            country1.Population = 1;
            country2.Population = 2;

            // Assert
            Assert.True(country1 != country2);
        }

        [Fact]
        public void PopulationBetweenFirstProvidedCountryIsLessThanSecondProvidedCountry()
        {
            // Arrange
            var mockCountry1 = new Country();
            var mockCountry2 = new Country();

            mockCountry1.Population = 1;
            mockCountry2.Population = 2;

            // Assert
            Assert.True(mockCountry1 < mockCountry2);
        }

        [Fact]
        public void PopulationBetweenFirstProvidedCountryIsGreaterThanSecondProvidedCountry()
        {
            // Arrange
            var mockCountry1 = new Country();
            var mockCountry2 = new Country();

            mockCountry1.Population = 2;
            mockCountry2.Population = 1;

            // Assert
            Assert.True(mockCountry1 > mockCountry2);
        }
    }
}