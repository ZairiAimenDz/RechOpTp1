using System;

namespace Classes
{
    public class MatriceAdjacence
    {
        private TypeDeGraph TypeDeGraph { get; set; }
        private bool[,] Matrice { get; set; }
        public MatriceAdjacence(int nbrelt, TypeDeGraph typeDeGraph)
        {
            if (nbrelt > 1)
            {
                Matrice = new bool[nbrelt, nbrelt];
                TypeDeGraph = typeDeGraph;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void AddArc(int a, int b)
        {
            Matrice[a - 1, b - 1] = true;
            if (TypeDeGraph == TypeDeGraph.NonOriente)
            {
                Matrice[b - 1, a - 1] = true;
            }
        }
        public void AffichierMatrice()
        {
            Console.Write("\t ");
            for (int i = 1; i < Math.Sqrt(Matrice.Length) + 1; i++)
            {
                Console.Write($"\t {i} ");
            }
            Console.WriteLine("\n__________________________________");
            for (int i = 1; i < Math.Sqrt(Matrice.Length) + 1; i++)
            {
                Console.Write($"\t {i} | ");
                for (int j = 1; j < Math.Sqrt(Matrice.Length) + 1; j++)
                {
                    Console.Write($"\t {Matrice[i - 1, j - 1].GetHashCode()}");
                }
                Console.WriteLine();
            }
        }
    }
}
