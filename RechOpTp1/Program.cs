using Classes;
using System;

namespace RechOpTp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Ecrire Le Type De Matrice : \n1 - Adjacence \n2 - Incidence");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case '1':
                        MatriceAdjacence();
                        break;
                    case '2':
                        MatriceIncidence();
                        break;
                    default: continue;
                }
                break;
            }
            Console.WriteLine("Fin !");
        }

        public static void MatriceIncidence()
        {
            MatriceIncidence matrice;
            TypeDeGraph typegraph;
            int nbrelt;
            int nbrarcs;
            while (true)
            {
                Console.WriteLine("Ecrire Le Type De Graph : \n1 - Graph Oriente\n2 - Graph Non Oriente");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case '1':
                        typegraph = TypeDeGraph.Oriente;
                        break;
                    case '2':
                        typegraph = TypeDeGraph.NonOriente;
                        break;
                    default: continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("Ecrire Le Nombre Des Noeuds");
                try
                {
                    nbrelt = int.Parse(Console.ReadLine());
                    if (nbrelt < 1)
                        continue;
                }
                catch
                {
                    Console.WriteLine("Re-Ecrire Le Nombre Des Noeuds");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("Ecrire Le Nombre D'Arc");
                try
                {
                    nbrarcs = int.Parse(Console.ReadLine());
                    if (nbrarcs < 1)
                        continue;
                }
                catch
                {
                    Console.WriteLine("Re-Ecrire Le Nombre D'Arc");
                    continue;
                }
                break;
            }
            matrice = new MatriceIncidence(nbrelt,nbrarcs, typegraph);
            Console.WriteLine("Ecrire Les Arcs / Aretes De Formes : x,arc,y ou x,y ⊂ [1..nbr de noeuds] et x sommet de depart - y sommet d arrivee , Pour Finir Ecrire \"fin\"");
            while (true)
            {
                Console.Write("Arc : ");
                var sommets = Console.ReadLine();
                var lstsommets = sommets.Split(',');
                if (sommets == "fin")
                    break;
                try
                {
                    int a = int.Parse(lstsommets[0]);
                    int arc = int.Parse(lstsommets[1]);
                    int b = int.Parse(lstsommets[2]);
                    if (a < 1 || b < 1)
                        continue;
                    matrice.AddArc(a,arc, b);
                }
                catch
                {
                    Console.WriteLine("Erreur");
                    continue;
                }
            }
            matrice.AffichierMatrice();
        }

        public static void MatriceAdjacence()
        {
            MatriceAdjacence matrice;
            TypeDeGraph typegraph;
            int nbrelt;
            while (true)
            {
                Console.WriteLine("Ecrire Le Type De Graph : \n1 - Graph Oriente\n2 - Graph Non Oriente");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case '1':
                        typegraph = TypeDeGraph.Oriente;
                        break;
                    case '2':
                        typegraph = TypeDeGraph.NonOriente;
                        break;
                    default: continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("Ecrire Le Nombre Des Noeuds");
                try
                {
                    nbrelt = int.Parse(Console.ReadLine());
                    if (nbrelt < 1)
                        continue;
                }
                catch
                {
                    Console.WriteLine("Re-Ecrire Le Nombre Des Noeuds");
                    continue;
                }
                break;
            }
            matrice = new MatriceAdjacence(nbrelt, typegraph);
            Console.WriteLine("Ecrire Les Arcs / Aretes De Formes : x,y ou x,y ⊂ [1..nbr de noeuds] et x sommet de depart - y sommet d arrivee , Pour Finir Ecrire \"fin\"");
            while (true)
            {
                Console.Write("Arc : ");
                var sommets = Console.ReadLine();
                var lstsommets = sommets.Split(',');
                if (sommets == "fin")
                    break;
                try
                {
                    int a = int.Parse(lstsommets[0]);
                    int b = int.Parse(lstsommets[1]);
                    if (a < 1 || b < 1)
                        continue;
                    matrice.AddArc(a, b);
                }
                catch
                {
                    Console.WriteLine("Erreur");
                    continue;
                }
            }
            matrice.AffichierMatrice();
        }
    }
}
