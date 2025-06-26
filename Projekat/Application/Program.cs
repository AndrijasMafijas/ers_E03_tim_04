using Presentation.GlavniMeni;
using Services.AuthServisi;

public class Program
{
    private static void Main(string[] args)
    {
        AuthMeni.Autentifikacija();
        int brojEntiteta = EntitetMeni.OdabirEntiteta();
        MapaMeni.OdabirMape(brojEntiteta);

    }
}
