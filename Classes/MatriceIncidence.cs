using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class MatriceIncidence
    {
        private TypeDeGraph TypeDeGraph { get; set; }
        private int[,] Matrice { get; set; }
        public int nbrelts { get; set; }
        public int nbrarcs { get; set; }
        public MatriceIncidence(int nbrelt, int nbarc, TypeDeGraph typegraph)
        {
            if (nbrelt > 2 && nbarc > 2)
            {
                this.nbrarcs = nbarc;
                this.nbrelts = nbrelt;
                this.TypeDeGraph = typegraph;
                Matrice = new int[nbarc, nbrelt];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }
        public void AddArc(int a, int arc ,int b)
        {
            Matrice[arc - 1, a - 1] = 1;
            if (TypeDeGraph == TypeDeGraph.NonOriente)
                Matrice[arc - 1, b - 1] = 1;
            else
                Matrice[arc - 1, b - 1] = -1;
        }
        public void AffichierMatrice()
        {
            Console.Write("\t ");
            for (int i = 1; i < nbrarcs + 1; i++)
            {
                Console.Write($"\t a-{i} ");
            }
            Console.WriteLine("\n_________________________________________");
            for (int elt = 1; elt < nbrelts + 1; elt++)
            {
                Console.Write($"\t {elt }| ");
                for (int arc = 1; arc < nbrarcs + 1; arc++)
                {
                    Console.Write($"\t {Matrice[arc - 1, elt - 1]}");
                }
                Console.WriteLine();
            }
        }
    }
}
