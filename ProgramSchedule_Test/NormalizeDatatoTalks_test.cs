using Xunit;
using Program_Schedule.Handlers;



namespace ProgramSchedule_Test
{
    public class NormalizeDatatoTalks_test
    {
        [Fact]
        public void NormalizingData_EqualCount()
        {
            //Arrange
            var inputUnNormalizedTalk = MockTalkData.GetMockUnNormalizedTalkData();
            NormalizeDatatoTalks talks = new NormalizeDatatoTalks(inputUnNormalizedTalk);
            //ACT
            var outputNormalizedTalk = talks.GetTalks();

            //Assert
            Assert.Equal(inputUnNormalizedTalk.Count,outputNormalizedTalk.Count);
        }
        [Fact]
        public void NormalizingData_FirstItemDataMatch()
        {
            //Arrange
            var inputUnNormalizedTalk = MockTalkData.GetMockUnNormalizedTalkData();
            NormalizeDatatoTalks talks = new NormalizeDatatoTalks(inputUnNormalizedTalk);
            //ACT
            var outputNormalizedTalk = talks.GetTalks();

            //Assert
            Assert.Equal(MockTalkData.GetMockTalkData()[0].Duration, outputNormalizedTalk[0].Duration);
            Assert.Equal(MockTalkData.GetMockTalkData()[0].Title, outputNormalizedTalk[0].Title);
        }
        [Fact]
        public void NormalizingData_GetTotalTalksTimeInMin()
        {
            //Arrange
            var inputUnNormalizedTalk = MockTalkData.GetMockUnNormalizedTalkData();
            NormalizeDatatoTalks talks = new NormalizeDatatoTalks(inputUnNormalizedTalk);
            //ACT
            var outputNormalizedTalk = talks.GetTalks();

            //Assert
            Assert.Equal(785,talks.TotalEventTimeInMin);
        }
    }
}
