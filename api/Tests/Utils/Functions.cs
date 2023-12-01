using System.Globalization;

namespace Tests.Utils
{
    public class Functions
    {
        [Theory]
        [InlineData("10/10/2023 00:00:00")]
        public static void GetDateTimeString_Value(string date)
        {
            // Arrange
            var dateTime = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            
            // Act
            var result = Core.Utils.Functions.GetDateTimeString(dateTime);

            // Assert
            Assert.Equal(date, result);
        }
    }
}
