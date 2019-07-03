namespace CSMobile.Domain.Services.WebApiIntegration
{
    public static class ApiEndpoints
    {
        public static readonly string Authentication = "auth/login";
        public static readonly string GetStudentSessions = "testSession/getStudentTests";
        public static readonly string GetTestVariantTemplate = "testVariant?testSessionId={0}";
        public static readonly string FinishTestVariantTemplate = "testVariant/finish/{0}";
    }
}