using CRM_AGD.Areas.Address.Models;
using Moq;
using Xunit;

namespace CRM_AGD_TEST.Areas.Address
{
  public class CityTest
  {
    [Fact]
    public void TestCityName()
    {
      var test = new Mock<ICity>();
      string cityName = "Nielepice";

      var cityTest = new City()
      {
        CityId = 1,
        Name = cityName
      };
      test.Setup(x => x.Name).Returns("Nielepice");

      Assert.Equal(cityTest.Name, test.Object.Name);
    }


    [Fact]
    public void TestCityId()
    {
      var test = new Mock<ICity>();
      string cityName = "Nielepice";

      var cityTest = new City()
      {
        CityId = 1,
        Name = cityName
      };
      test.Setup(x => x.CityId).Returns(1);

      Assert.Equal(cityTest.CityId, test.Object.CityId);
    }
  }
}
