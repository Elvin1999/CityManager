namespace CityManager.Helpers
{
    public static class JwtExtention
    {
        public static void AddApplicationError(this HttpResponse response,string message)
        {
            response.Headers.Add("Application-Error",message);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Accept-Control-Expose-Header", "Application-Error");
        }
    }
}
