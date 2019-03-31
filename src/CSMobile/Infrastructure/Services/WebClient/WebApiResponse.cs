namespace CSMobile.Infrastructure.Services.WebClient
{
    public class WebApiResponse
    {
        public WebApiResponse(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public bool Succeeded { get; }
    }
    
    public class WebApiResponse<TData> : WebApiResponse
    {
        public WebApiResponse(bool succeeded, TData data) : base(succeeded)
        {
            Data = data;
        }

        public TData Data { get; set; }
    }
}