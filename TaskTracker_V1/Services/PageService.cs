namespace TaskTracker_V1.Services
{
    // Interface to control navigation logic
    // Can implement logic to control navigation and ensure certain business rules are enforced
    public interface IPageService
    {
        Task PushAsync(Page page);

        Task<Page> PopAsync();

        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);

        Task DisplayAlert(string title, string message, string ok);
    }

    // CLass that extends the above to provide methods for navigation
    internal class PageService : IPageService
    {
        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        // Display an alert based on the parameters passed in
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        // Use to navigate from one Page view to another
        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        // Use to dismiss current page view
        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }
    }
}