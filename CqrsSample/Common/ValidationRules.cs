namespace CqrsSample.Common
{
    public class ValidationRules
    {
        public static bool BeAValidGuid(string guid)
        {
            return Guid.TryParse(guid, out _);
        }
    }
}
