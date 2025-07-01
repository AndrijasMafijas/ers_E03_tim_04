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
        public string SimulirajDogadjaj(float duzinaTB ,int IdProdavnice, string nazivMape)
        {
            Thread.Sleep(Convert.ToInt32(Math.Floor(duzinaTB / 10)) * 1000);
            string x = "";
            Igrac pobednik;
            int opcijaa = GeneratorOpcija.GenerisiOpciju();
            //ovde prvo da vidimo iz kog tima je pobednik
            if (opcijaa == 1)
            {
                pobednik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogZivogIgraca(timovi.getPlaviTim());
            }
            else pobednik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogZivogIgraca(timovi.getCrveniTim());

            int opcija = GeneratorOpcija.GenerisiOpciju();
            //ako je 1 onda je napao/ubio nekog iz suprotnog tima a ako je 2 ubio je entitet
            if (opcija == 1)
            {
                Igrac gubitnik;
                //ako je pobednik iz plavog tima , gubitnik je iz crvenog sigurno i obratno
                if (opcijaa == 1)
                {
                    gubitnik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogZivogIgraca(timovi.getCrveniTim());
                }
                else gubitnik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogZivogIgraca(timovi.getPlaviTim());

                Heroj pobednikovHeroj = heroji.PronadjiPoId(pobednik.getIdHeroja());
                Heroj gubitnikovHeroj = heroji.PronadjiPoId(gubitnik.getIdHeroja());

                if(pobednikovHeroj.JacinaNapada >= gubitnikovHeroj.ZivotniPoeni)
                {
                    x += pobednik.getIme() + " eliminated " + gubitnik.getIme() + " and earned 300 gold!\n";
                    es.EliminacijaHeroja(pobednik.getIdHeroja(), gubitnik.getIdHeroja());
                    x += aks.ProveriNovac(pobednik, IdProdavnice);
                }
                else
                {
                    gubitnikovHeroj.ZivotniPoeni -= pobednikovHeroj.JacinaNapada;
                    x += pobednik.getIme() + " damaged " + gubitnik.getIme() + " for " + pobednikovHeroj.JacinaNapada + 
                        " HP ,\n " + gubitnik.getIme() + " now has only " + gubitnikovHeroj.ZivotniPoeni + " HP left!\n";
                }
            }
            else
            {
                Mapa m = mape.PronadjiMapuPoNazivu(nazivMape);
                if(m.BrojPomocnih > 0)
                {
                    m.BrojPomocnih--;
                    int brojka = GeneratorNovcica.EliminacijaEntiteta();
                    x += pobednik.getIme() + " has slained an entity and gained " + brojka + " gold.\n";
                    es.EliminacijaEntiteta(pobednik.getIdHeroja(), brojka);
                    x += aks.ProveriNovac(pobednik, IdProdavnice);
                }
                else
                {
                    x += pobednik.getIme() + " lurked on the map but didn't find any entity.\n";
                }
            }
            int rezultat = pkbs.ProveriKraj();
            if (rezultat == 1)
            {
                x += "\n---------------Match Finished----------------\nBLUE TEAM WON!!!\n";
                return x;
            }
            else if (rezultat == 2)
            {
                x += "\n---------------Match Finished----------------\nRED TEAM WON!!!\n";
                return x;
            }
            return x;
        }
    }
}
