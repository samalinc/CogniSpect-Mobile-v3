namespace CSMobile.Presentation.Views.AppContext
{
    internal class ApplicationContextBuilder
    {
        public ApplicationContext ApplicationContext { get; set; }

        public ApplicationContextBuilder()
        {
            ApplicationContext = new ApplicationContext();
        }

        public IApplicationContext Build()
        {
            return ApplicationContext;
        }
    }
}