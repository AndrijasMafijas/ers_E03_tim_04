using Domain.Servisi;
using Presentation.GlavniMeni;
using Services.AuthServisi;
using Services.BitkaServisi;
using Services.ProdavnicaServisi;

public class Program
{
    //IAuthServis auth = new AuthServis();
    //IAutomatskaKupovinaServis automatska = new AutomatskaKupovinaServis();
    //IEliminacijaServis el = new EliminacijaServis();
    //IHerojiServis herojiServis = new HerojiServis();
    //INapitakServis napitakServis = new NapitakServis();
    //IOdabirMapeServis odabirMape = new OdabirMapeServis();
    //IOdabirProdavniceServis ops = new OdabirProdavniceServis();
    //IOruzjeServis os = new OruzjeServis();
    //IProveraKrajaBitkeServis pkbs = new ProveraKrajaBitkeServis();
    //ISimulacijaBitkeServis sbs = new SimulacijaBitkeServis();
    //IStatistikaBitkeServis sbss = new StatistikaBitkeServis();
    //ITimoviServis ts = new TimoviServis();
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
