using Domain.Modeli;
using Domain.PomocneMetode;
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
    public class SimulacijaBitkeServis
    {
        public int GenerisiVremeTrajanjaBitke()
        {
            return GeneratorDuzineTrajanjaBitke.GenerisiDuzinuTrajanjaBitke();
        }
        public string SimulirajDogadjaj(float duzinaTB ,int IdProdavnice, string nazivMape)
        {
            Thread.Sleep(Convert.ToInt32(Math.Floor(duzinaTB / 5)) * 1000);
            string x = "";
            IHerojiRepository heroji = new HerojiRepository();
            ITimoviRepository timovi = new TimoviRepository();
            IProdavnicaRepository prodavnice = new ProdavnicaRepository();
            IMapeRepository mape = new MapeRepository();
            Igrac pobednik;
            int opcijaa = GeneratorOpcija.GenerisiOpciju();

            if(timovi.getPlaviTim().Count == 0)
            {
                x += "\n---------------Finished---------------\nRED TEAM WON THE MATCH!";
                return x;
            }
            if (timovi.getCrveniTim().Count == 0)
            {
                x += "\n---------------Finished---------------\nBLUE TEAM WON THE MATCH!";
                return x;
            }

            //ovde prvo da vidimo iz kog tima je pobednik
            if (opcijaa == 1)
            {
                pobednik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogIgraca(timovi.getPlaviTim());
            }
            else pobednik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogIgraca(timovi.getCrveniTim());

            int opcija = GeneratorOpcija.GenerisiOpciju();
            //ako je 1 onda je napao/ubio nekog iz suprotnog tima a ako je 2 ubio je entitet
            if (opcija == 1)
            {
                Igrac gubitnik;
                //ako je pobednik iz plavog tima , gubitnik je iz crvenog sigurno i obratno
                if (opcijaa == 1)
                {
                    gubitnik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogIgraca(timovi.getCrveniTim());
                }
                else gubitnik = GeneratorNasumicnogElementaListe.OdaberiNasumicnogIgraca(timovi.getPlaviTim());

                Heroj pobednikovHeroj = heroji.PronadjiPoId(pobednik.getIdHeroja());
                Heroj gubitnikovHeroj = heroji.PronadjiPoId(gubitnik.getIdHeroja());

                if(pobednikovHeroj.JacinaNapada > gubitnikovHeroj.ZivotniPoeni)
                {
                    x += pobednik.getIme() + " eliminated " + gubitnik.getIme() + " and earned 300 gold!\n";
                    heroji.UkloniHeroja(gubitnik.getIdHeroja());
                    timovi.UkloniIgraca(gubitnik.getIdHeroja());
                    pobednikovHeroj.TrenutnoNovcica += 300;
                    AutomatskaKupovinaServis aks = new AutomatskaKupovinaServis();
                    aks.ProveriNovac(pobednik, IdProdavnice);
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
                    Heroj pobednikovHeroj = heroji.PronadjiPoId(pobednik.getIdHeroja());
                    pobednikovHeroj.TrenutnoNovcica += brojka;
                    AutomatskaKupovinaServis aks = new AutomatskaKupovinaServis();
                    aks.ProveriNovac(pobednik, IdProdavnice);
                }
                else
                {
                    x += pobednik.getIme() + " lurked on the map but didn't find any entity.\n";
                }
            }


            
            return x;
        }
    }
}
