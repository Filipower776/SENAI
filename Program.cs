using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria
{
    class Program
    {
        static int check = 0, i,s=1;
        static int[] sorteio = new int[6];
        static int[,] bilhetes = new int[5000000, 6];
        static Random gerador = new Random();

        static void gerabilhete(int[,]bilhetes)
        {
            for (int i = 0; i < 5000000; i++)
            {
                for (int z = 0; z < 6; z++)
                {
                    int fds = gerador.Next(59);
                    bilhetes[i, z] = fds+1;
                    for (int r = z - 1; r >= 0; r--)
                    {
                        if (bilhetes[i,z] == bilhetes[i,r])
                        { z--; }
                    }
                }
            }
        }

        static void loretia(int[] sorteio)
        {
            for (i = 0; i < 6; i++)
            {
                int fds = gerador.Next(59);
                sorteio[i] = fds+1;
                for (int r = i-1; r >= 0; r--)
                {
                    if (sorteio[i] == sorteio[r])
                    { i--; }
                }
            }
        }

        static void Main(string[] args)
        {
                gerabilhete(bilhetes);

            while (s == 1)
            {
                loretia(sorteio);
                for (i = 0; i < 5000000; i++)
                {
                    for (int z = 0; z < 6; z++)
                    {
                        for (int c = 0; c < 6; c++)
                        {
                            if (bilhetes[i, z] == sorteio[c])
                            {
                                check = check + 1;
                            }
                        }
                        if (check == 6)
                            break;
                    }
                    if (check == 6)
                        break;
                    check = 0;
                }

                Console.Write("Números sorteados: ");
                for (int a = 0; a < 6; a++)
                {
                    Console.Write(sorteio[a] + " ");
                }

                Console.WriteLine("\n");

                if (check == 6)
                {
                    Console.WriteLine("O ganhador é o bilhete " + (i + 1) + ".\n");
                    s = 0;
                    Console.Write("Pressione qualquer tecla para finalizar.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Não houve ganhador.\n");
                    s = 1;
                    Console.Write("Pressione qualquer tecla para refazer o sorteio.");
                    Console.ReadKey();
                    Console.Clear();
                }


            }
        }
    }
}
