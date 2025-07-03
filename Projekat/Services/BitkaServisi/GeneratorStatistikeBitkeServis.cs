using Domain.Modeli;
using Domain.Repositories.HerojiRepository;
using Domain.Repositories.MapeRepository;
using Domain.Repositories.ProdavnicaRepository;
using Domain.Repositories.TimoviRepository;
using Domain.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BitkaServisi
{
    public class GeneratorStatistikeBitkeServis : IGeneratorStatistikeBitkeServis
    {
        IHerojiRepository heroji = new HerojiRepository();
        ITimoviRepository timovi = new TimoviRepository();
        IProdavnicaRepository prodavnice = new ProdavnicaRepository();
        IMapeRepository mape = new MapeRepository();

        public GeneratorStatistikeBitkeServis()
        {

        }
        // Novi konstruktor za dependency injection
        public GeneratorStatistikeBitkeServis(
            IHerojiRepository heroji,
            ITimoviRepository timovi,
            IProdavnicaRepository prodavnice,
            IMapeRepository mape)
        {
            this.heroji = heroji;
            this.timovi = timovi;
            this.prodavnice = prodavnice;
            this.mape = mape;
        }

        public string IspisiStatistikuBitke(int idProdavnice, string nazivMape)
        {
            var sb = new StringBuilder();

            sb.AppendLine("===== BATTLE STATISTICS =====\n");

            // RED TEAM
            sb.AppendLine(">>> RED TEAM:");
            sb.AppendLine(string.Format("{0,-20} {1,-30} {2,6} {3,6} {4,8}", "Player", "Hero", "HP", "ATK", "Gold"));
            sb.AppendLine(new string('-', 75));
            foreach (var player in timovi.getCrveniTim())
            {
                var hero = heroji.PronadjiPoId(player.getIdHeroja());
                sb.AppendLine(string.Format("{0,-20} {1,-30} {2,6} {3,6} {4,8}", player.getIme(), hero.NazivHeroja, hero.ZivotniPoeni, hero.JacinaNapada, hero.TrenutnoNovcica));
            }
            sb.AppendLine();

            // BLUE TEAM
            sb.AppendLine(">>> BLUE TEAM:");
            sb.AppendLine(string.Format("{0,-20} {1,-30} {2,6} {3,6} {4,8}", "Player", "Hero", "HP", "ATK", "Gold"));
            sb.AppendLine(new string('-', 75));
            foreach (var player in timovi.getPlaviTim())
            {
                var hero = heroji.PronadjiPoId(player.getIdHeroja());
                sb.AppendLine(string.Format("{0,-20} {1,-30} {2,6} {3,6} {4,8}", player.getIme(), hero.NazivHeroja, hero.ZivotniPoeni, hero.JacinaNapada, hero.TrenutnoNovcica));
            }
            sb.AppendLine();

            // MAP DETAILS
            var m = mape.PronadjiMapuPoNazivu(nazivMape);
            sb.AppendLine(">>> MAP:");
            sb.AppendLine(string.Format("{0,-15} {1,-12} {2,15}", "Name", "Type", "Max Players"));
            sb.AppendLine(new string('-', 45));
            sb.AppendLine(string.Format("{0,-15} {1,-12} {2,15}", m.NazivMape, m.Tip_Mape, m.MaksimalanBrojIgraca));
            sb.AppendLine();
            sb.AppendLine(string.Format("{0,-15} {1,-15} {2,15}", "Red Team", "Blue Team", "Support Entities"));
            sb.AppendLine(new string('-', 45));
            sb.AppendLine(string.Format("{0,-15} {1,-15} {2,15}", m.NazivCrvenih, m.NazivPlavih, m.BrojPomocnih));
            sb.AppendLine();

            // SHOP DETAILS
            sb.AppendLine(">>> SHOP:");
            sb.AppendLine(string.Format("{0,5}", "ID"));
            sb.AppendLine(new string('-', 30));
            var shop = prodavnice.PronadjiProdavnicuPoIdu(idProdavnice);
            sb.AppendLine(string.Format("{0,5}", shop.ID));
            sb.AppendLine(new string('-', 30));
            sb.AppendLine(string.Format("{0,-15} {1}", "TOTAL REVENUE:", shop.UkupnoProdato));

            return sb.ToString();
        }
    }
}
