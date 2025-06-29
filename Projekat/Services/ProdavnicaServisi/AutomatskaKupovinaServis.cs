using Domain.Modeli;
using Domain.PomocneMetode;
using Domain.Repositories.HerojiRepository;
using Domain.Repositories.ProdavnicaRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProdavnicaServisi
{
    public class AutomatskaKupovinaServis
    {
        public string ProveriNovac(Igrac pobednik,int IdProdavnice)
        {
            IHerojiRepository heroji = new HerojiRepository();
            IProdavnicaRepository prodavnice = new ProdavnicaRepository();
            string x = "";
            Heroj pobednikovHeroj = heroji.PronadjiPoId(pobednik.getIdHeroja());
            if (pobednikovHeroj.TrenutnoNovcica >= 500)
            {
                Prodavnica p = prodavnice.PronadjiProdavnicuPoIdu(IdProdavnice);
                //opet generisem da li ce da kupi oruzje ili napitak
                int opcija3 = GeneratorOpcija.GenerisiOpciju();
                if (opcija3 == 1)
                {
                    Oruzje o = GeneratorNasumicnogElementaListe.OdaberiNasumicnoOruzje(p.listaOruzja);
                    pobednikovHeroj.JacinaNapada += o.PojacanjeNapada;
                    x += "\n" + pobednik.getIme() + " has purchased " + o.nazivOruzja + " and his current attack power is " + pobednikovHeroj.JacinaNapada;
                }
                else
                {
                    Napitak n = GeneratorNasumicnogElementaListe.OdaberiNasumicniNapitak(p.listaNapitaka);
                    pobednikovHeroj.JacinaNapada += n.PojacanjeNapada;
                    x += "\n" + pobednik.getIme() + " has purchased " + n.NazivNapitka + " and his current attack power is " + pobednikovHeroj.JacinaNapada;
                }
            }
            return x;
        }
    }
}
