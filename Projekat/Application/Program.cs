using Presentation.GlavniMeni;
using Services.AuthServisi;

public class Program
{
    private static void Main(string[] args)
    {
        AuthMeni.Autentifikacija();
        int brojEntiteta = EntitetMeni.OdabirEntiteta();
        string nazivMape = "";
        int IdProdavnice = MapaMeni.OdabirMape(brojEntiteta,ref nazivMape);
        TimoviMeni.DodavanjeIgraca();
        SimulacijaBitkeMeni.PokreniSimulacijuBitke(IdProdavnice , nazivMape);
        StatistikaBitkeMeni.StatistikaBitke(IdProdavnice, nazivMape);
    }
}
