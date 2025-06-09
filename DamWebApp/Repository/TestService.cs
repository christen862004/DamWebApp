namespace DamWebApp.Repository
{
    public class TestService : ITestService
    {
        public TestService()
        {
            Id =Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
    }
}
