using Presentation.GlavniMeni;
using Services.AuthServisi;

public class Program
{
    private static void Main(string[] args)
    {
        AuthMeni.Autentifikacija();
        int brojEntiteta = EntitetMeni.OdabirEntiteta();
        string IdMape = "";
        int IdProdavnice = MapaMeni.OdabirMape(brojEntiteta,ref IdMape);
        TimoviMeni.DodavanjeIgraca();
        SimulacijaBitkeMeni.PokreniSimulacijuBitke(IdProdavnice , IdMape);
        StatistikaBitkeMeni.StatistikaBitke();
    }
}
