using Domain.Modeli;
using Services.BitkaServisi;

namespace Presentation.GlavniMeni
{
    public class MapaMeni
    {
        public MapaMeni() { }
        public static void OdabirMape(int brojEntiteta)
        {
            Console.WriteLine("Now you need to choose map specifications: ");
            bool dobarUnos = false;
            Prodavnica p;
            Mapa m;
            while (!dobarUnos)
            {
                Console.WriteLine("Enter map name: ");
                string nazivMape = Console.ReadLine();
                MapaIProdavnicaServis mapaServis = new MapaIProdavnicaServis();
                if (nazivMape == string.Empty) continue;
                m = mapaServis.PronadjiMapu(nazivMape);
                if (m.NazivMape == string.Empty)
                {
                    Console.WriteLine(nazivMape + " doesn't exist.");
                    continue;

                    //dodao sam jednu mapu u MapeRepository!
                }
            }
            dobarUnos = false;
            while (!dobarUnos)
            {
                Console.WriteLine("Enter market id: ");
                string idProdavnice = Console.ReadLine();
                MapaIProdavnicaServis mapaServis = new MapaIProdavnicaServis();
                if (idProdavnice == string.Empty) continue;
                p = mapaServis.PronadjiProdavnicu(Convert.ToInt32(idProdavnice));
                if (p.ID == 0)
                {
                    Console.WriteLine("Market with id " + idProdavnice + " doesn't exist.");
                    continue;
                }
                dobarUnos = true;
                //dodao sam zbog testiranja i jednu prodavnicu u ProdavnicaRepository
            }
        }

    }
}
