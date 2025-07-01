using Domain.Modeli;
using Domain.PomocneMetode;
using Domain.Repositories.HerojiRepository;
using Domain.Repositories.ProdavnicaRepository;
using Domain.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProdavnicaServisi
{
    public class AutomatskaKupovinaServis : IAutomatskaKupovinaServis
    {
        IHerojiRepository heroji = new HerojiRepository();
        IProdavnicaRepository prodavnice = new ProdavnicaRepository();
        public string ProveriNovac(Igrac pobednik,int IdProdavnice)
        {
            string x = "";
            Heroj pobednikovHeroj = heroji.PronadjiPoId(pobednik.getIdHeroja());
            while(pobednikovHeroj.TrenutnoNovcica >= 500)
            {
                Prodavnica p = prodavnice.PronadjiProdavnicuPoIdu(IdProdavnice);
                //opet generisem da li ce da kupi oruzje ili napitak
                int opcija3 = GeneratorOpcija.GenerisiOpciju();
                if (opcija3 == 1)
                {
                    Oruzje o = GeneratorNasumicnogElementaListe.OdaberiNasumicnoOruzje(p.ListaOruzja);
                    if (prodavnice.prodajOruzje(o, IdProdavnice))
                    {
                        pobednikovHeroj.JacinaNapada += o.PojacanjeNapada;
                        x += "\n" + pobednik.getIme() + " has purchased " + o.NazivOruzja + " and his current attack power is " + pobednikovHeroj.JacinaNapada;
                        p.UkupnoProdato += o.Cena;
                        pobednikovHeroj.TrenutnoNovcica -= o.Cena;
                    }
                    else continue;
                }
                else
                {
                    Napitak n = GeneratorNasumicnogElementaListe.OdaberiNasumicniNapitak(p.ListaNapitaka);
                    if (prodavnice.prodajNapitak(n, IdProdavnice))
                    {
                        pobednikovHeroj.JacinaNapada += n.PojacanjeNapada;
                        x += "\n" + pobednik.getIme() + " has purchased " + n.NazivNapitka + " and his current attack power is " + pobednikovHeroj.JacinaNapada;
                        p.UkupnoProdato += n.Cena;
                        pobednikovHeroj.TrenutnoNovcica -= n.Cena;
                    }
                    else continue;
                }
            }
            return x;
        }
    }
}
