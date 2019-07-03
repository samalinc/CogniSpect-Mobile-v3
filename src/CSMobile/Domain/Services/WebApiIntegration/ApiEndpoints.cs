using CSMobile.Domain.Services.WebApiIntegration.Dtos;

namespace CSMobile.Domain.Services.WebApiIntegration
{
    public static class ApiEndpoints
    {
        /// <summary>
        /// POST
        /// Body: <see cref="LoginModelDto"/>
        /// </summary>
        public static readonly string Authentication = "auth/login";
        
        /// <summary>
        /// GET
        /// </summary>
        public static readonly string GetStudentSessions = "testSession/student";
        
        /// <summary>
        /// GET
        /// </summary>
        public static readonly string GetTestVariantUrlTemplate = "testVariant/student?testSessionId={0}";

        /// <summary>
        /// PUT
        /// Body: <see cref="UserAnswerModelDto"/>
        /// </summary>
        public static readonly string SubmitAnswerForQuestion = "answer/submit";
        
        /// <summary>
        /// PUT
        /// {0} - id of test variant
        /// </summary>
        public static readonly string FinishTestVariantUrlTemplate = "testVariant/finish/{0}";
    }
}