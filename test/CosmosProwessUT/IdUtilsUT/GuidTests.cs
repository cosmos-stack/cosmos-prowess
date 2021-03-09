using Cosmos.IdUtils;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosProwessUT.IdUtilsUT
{
    [Trait("IdUtilsUT", "GuidTests")]
    public class GuidTests
    {
        [Fact]
        public void RandomGuidTest()
        {
            GuidProvider.CreateRandom().CastToString().ShouldNotBeEmpty();
        }

        [Fact]
        public void GuidCreateTest()
        {
            GuidProvider.Create().CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.NormalStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.UnixStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.SqlStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.LegacySqlStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.PostgreSqlStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.BasicStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.TimeStampStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.UnixTimeStampStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SqlTimeStampStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.LegacySqlTimeStampStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.PostgreSqlTimeStampStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.CombStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SequentialAsStringStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SequentialAsBinaryStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SequentialAsEndStyle).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.EquifaxStyle).CastToString().ShouldNotBeEmpty();
        }

        [Fact]
        public void GuidCreateWithRepeatModeTest()
        {
            GuidProvider.Create(CombStyle.NormalStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.UnixStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.SqlStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.LegacySqlStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.PostgreSqlStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.BasicStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.TimeStampStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.UnixTimeStampStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SqlTimeStampStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.LegacySqlTimeStampStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.PostgreSqlTimeStampStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.CombStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SequentialAsStringStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SequentialAsBinaryStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SequentialAsEndStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.EquifaxStyle, NoRepeatMode.On).CastToString().ShouldNotBeEmpty();

            GuidProvider.Create(CombStyle.NormalStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.UnixStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.SqlStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.LegacySqlStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(CombStyle.PostgreSqlStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.BasicStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.TimeStampStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.UnixTimeStampStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SqlTimeStampStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.LegacySqlTimeStampStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.PostgreSqlTimeStampStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.CombStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SequentialAsStringStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SequentialAsBinaryStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.SequentialAsEndStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
            GuidProvider.Create(GuidStyle.EquifaxStyle, NoRepeatMode.Off).CastToString().ShouldNotBeEmpty();
        }
    }
}