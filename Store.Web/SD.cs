namespace Store.Web;

public static class SD
{
    public static string ProductApiBase { get; set; }
    public static string ShoppingApiBase { get; set; }

    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}