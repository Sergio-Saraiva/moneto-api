namespace Moneto.Domain.Settings;

public class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; }
    public CorsSettings CORS { get; set; }
}