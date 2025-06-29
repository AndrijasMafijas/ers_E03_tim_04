using Domain.Modeli;
using Services.BitkaServisi;
using Services.ProdavnicaServisi;

namespace Presentation.GlavniMeni
{
    public class MapaMeni
    {
        public MapaMeni() { }
        public static int OdabirMape(int brojEntiteta,ref string IdMape)
        {
            Console.WriteLine("Now you need to choose map specifications: ");
            int IdProdavnice = 0;
            bool dobarUnos = false;
            Prodavnica p;
            Mapa m;
            while (!dobarUnos)
            {
                Console.WriteLine("Enter map name: ");
                string nazivMape = Console.ReadLine();
                OdabirMapeServis mapaServis = new OdabirMapeServis();
                if (nazivMape == string.Empty) continue;
                m = mapaServis.PronadjiMapu(nazivMape);
                if (m.NazivMape == string.Empty)
                {
                    Console.WriteLine(nazivMape + " doesn't exist.");
                    continue;

                    //dodao sam jednu mapu u MapeRepository!
                }
                IdMape = m.NazivMape;
                dobarUnos = true;
            }
            dobarUnos = false;
            while (!dobarUnos)
            {
                Console.WriteLine("Enter market id: ");
                string idProdavnice = Console.ReadLine();
                OdabirMapeServis mapaServis = new OdabirMapeServis();
                OdabirProdavniceServis ops = new OdabirProdavniceServis();
                if (idProdavnice == string.Empty) continue;
                p = ops.PronadjiProdavnicu(Convert.ToInt32(idProdavnice));
                if (p.ID == 0)
                {
                    Console.WriteLine("Market with id " + idProdavnice + " doesn't exist.");
                    continue;
                }
                dobarUnos = true;
                //dodao sam zbog testiranja i jednu prodavnicu u ProdavnicaRepository
                IdProdavnice = p.ID;
            }
            return IdProdavnice;
        }

    }
}
