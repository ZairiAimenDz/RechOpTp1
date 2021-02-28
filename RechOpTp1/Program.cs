using Classes;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RechOpTp1
{
    /// <summary>
    /// Allows Us To Use The Console With A GUI Interface
    /// </summary>
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern Boolean AllocConsole();
    }


    class Program
    {
        /// <summary>
        /// Graph Drawing Requirements
        /// </summary>
       
        static Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
        static Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
        [STAThread]
        static void Main(string[] args)
        {

            while (true)
            {
                NativeMethods.AllocConsole();
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



                /// Code From The Graph Drawing Library
                Form form= new Form();
                viewer.Graph = graph;
                //associate the viewer with the form 
                form.SuspendLayout();
                viewer.Dock = System.Windows.Forms.DockStyle.Fill;
                form.Controls.Add(viewer);
                form.ResumeLayout();
                //show the form 
                Application.EnableVisualStyles();
                Application.Run(form);

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
                        graph.Directed = false;
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
                    graph.AddEdge(a.ToString(), arc.ToString(), b.ToString());
                }
                catch
                {
                    Console.WriteLine("Erreur");
                    continue;
                }
            }
            matrice.AffichierMatrice();
            Console.Read();
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
                        graph.Directed = false;
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
            Console.WriteLine("Ecrire Les Arcs / Aretes De Formes : x,y  / ou y,x inclut dans [1..nbr de noeuds] et x sommet de depart - y sommet d arrivee , Pour Finir Ecrire \"fin\"");
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
                    graph.AddEdge(a.ToString(), b.ToString());
                    
                }
                catch
                {
                    Console.WriteLine("Erreur");
                    continue;
                }
            }
            matrice.AffichierMatrice();

            Console.Read();
        }
    }
}
