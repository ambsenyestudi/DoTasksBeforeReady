using StarwarsTheme.Domain.Characters;
using Xunit;

namespace StarwarsTheme.Test.Characters
{
    public class CharacterInfoShould
    {
        [Theory]
        [InlineData("", "blue")]
        [InlineData(null, "blue")]
        [InlineData("Luck", "")]
        [InlineData("Luck", null)]
        public void Throw_incomplete_when_info_missing(string name, string eyeColor) =>
            Assert.Throws<IncompleteCharacterInformationException>(() =>
            CharacterInfo.Create(name, eyeColor));
    }
}
