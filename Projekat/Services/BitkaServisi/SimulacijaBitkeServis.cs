using Domain.Modeli;
using Domain.PomocneMetode;
using Domain.Servisi;
using Domain.Repositories.HerojiRepository;
using Domain.Repositories.MapeRepository;
using Domain.Repositories.ProdavnicaRepository;
using Domain.Repositories.TimoviRepository;
using Services.ProdavnicaServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BitkaServisi
{
    public class SimulacijaBitkeServis : ISimulacijaBitkeServis
    {
        IHerojiRepository heroji = new HerojiRepository();
        ITimoviRepository timovi = new TimoviRepository();
        IMapeRepository mape = new MapeRepository();
        IAutomatskaKupovinaServis aks;
        IEliminacijaServis es;
        IProveraKrajaBitkeServis pkbs;

        public SimulacijaBitkeServis()
        {
        }

        public SimulacijaBitkeServis(IAutomatskaKupovinaServis aks, IEliminacijaServis es, IProveraKrajaBitkeServis pkbs)
        {
            this.aks = aks;
            this.es = es;
            this.pkbs = pkbs;
        }

        public int GenerisiVremeTrajanjaBitke()
        {
            return GeneratorDuzineTrajanjaBitke.GenerisiDuzinuTrajanjaBitke();
        }
        public string SimulirajDogadjaj(float duzinaTB, int IdProdavnice, string nazivMape)
        {
            Thread.Sleep(Convert.ToInt32(Math.Floor(duzinaTB / 20)) * 1000);

            StringBuilder sb = new StringBuilder();
            Igrac pobednik;
            int opcijaa = GeneratorOpcija.GenerisiOpciju();

            // Odredimo iz kog tima je pobednik
            if (opcijaa == 1)
            {
                pobednik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogZivogIgraca(timovi.getPlaviTim());
            }
            else
            {
                pobednik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogZivogIgraca(timovi.getCrveniTim());
            }

            int opcija = GeneratorOpcija.GenerisiOpciju();

            // Opcija 1 = napad na igrača iz protivničkog tima, opcija 2 = ubistvo entiteta
            if (opcija == 1)
            {
                Igrac gubitnik;
                if (opcijaa == 1)
                {
                    gubitnik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogZivogIgraca(timovi.getCrveniTim());
                }
                else
                {
                    gubitnik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogZivogIgraca(timovi.getPlaviTim());
                }

                Heroj pobednikovHeroj = heroji.PronadjiPoId(pobednik.getIdHeroja());
                Heroj gubitnikovHeroj = heroji.PronadjiPoId(gubitnik.getIdHeroja());

                if (pobednikovHeroj.JacinaNapada >= gubitnikovHeroj.ZivotniPoeni)
                {
                    sb.AppendLine($"[ELIMINATION] {pobednik.getIme()} eliminated {gubitnik.getIme()} and earned 300 gold!");
                    es.EliminacijaHeroja(pobednik.getIdHeroja(), gubitnik.getIdHeroja());
                    sb.Append(aks.ProveriNovac(pobednik, IdProdavnice));
                }
                else
                {
                    gubitnikovHeroj.ZivotniPoeni -= pobednikovHeroj.JacinaNapada;
                    sb.AppendLine($"[ATTACK] {pobednik.getIme()} damaged {gubitnik.getIme()} for {pobednikovHeroj.JacinaNapada} HP.");
                    sb.AppendLine($"[STATUS] {gubitnik.getIme()} now has {gubitnikovHeroj.ZivotniPoeni} HP left.");
                }
            }
            else
            {
                Mapa m = mape.PronadjiMapuPoNazivu(nazivMape);

                if (m.BrojPomocnih > 0)
                {
                    m.BrojPomocnih--;
                    int goldEarned = GeneratorNovcica.EliminacijaEntiteta();
                    sb.AppendLine($"[ENTITY] {pobednik.getIme()} has slain an entity and gained {goldEarned} gold.");
                    es.EliminacijaEntiteta(pobednik.getIdHeroja(), goldEarned);
                    sb.Append(aks.ProveriNovac(pobednik, IdProdavnice));
                }
                else
                {
                    sb.AppendLine($"[ENTITY] {pobednik.getIme()} lurked on the map but didn't find any entity.");
                }
            }

            int rezultat = pkbs.ProveriKraj();

            if (rezultat == 1)
            {
                sb.AppendLine("\n=============== MATCH FINISHED ===============");
                sb.AppendLine("                BLUE TEAM WON!!!              ");
                return sb.ToString();
            }
            else if (rezultat == 2)
            {
                sb.AppendLine("\n=============== MATCH FINISHED ===============");
                sb.AppendLine("                RED TEAM WON!!!               ");
                return sb.ToString();
            }

            return sb.ToString();
        }

    }
}
