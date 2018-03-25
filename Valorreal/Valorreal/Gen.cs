/*
UNIVERSIDAD AUTONOMA DEL ESTADO DE MEXICO
CENTRO UNIVERSITARIO UAEM ZUMPANGO
INGENIERIA EN COMPUTACION
ALGORITMOS GENETICOS
ASDRUBAL LOPEZ CHAU
OCTAVIO HERNANDEZ HERNANDEZ
25/03/2018
Mínimo de una función
Encuentra el mínimo de la función f(x)=cos(x)*e^{-pi*x/100} en el intervalo de x [-10 a 10]
Usa la representación real con codificación Gray.
Implementa todo en C#.
Parámetros del AG:
N = 100, Total de generaciones = 500, Mecanismo de selección: Ruleta, Mutación 10%, Elitismo.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorreal
{
    
    class Gen
    {
        private int[] gene; //declaracion gen
        private int BITS_PER_GENE; //variable para saber cuantos bits constara nuestro gen
        private double min, max;//variable para maximo y minimo funcion
        private int P;//variable para numero de partes
        //Constructor del gen
        public Gen(double min, double max,int P)
        {
            this.P = P;
            this.min = min;
            this.max = max;
            BITS_PER_GENE = (int)(Math.Log10(P) / Math.Log10(2));//Declaracion del numero de bits por gen
            gene = new int[BITS_PER_GENE];
        }
        //Inicializamos el gen
        public void inicializa(Random rnd)
        {
            for (int i = 0; i < BITS_PER_GENE; i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    gene[i] = 1;
                }
            }
        }
        //algoritmo para obtencion del valor decimal (genotipo)
        public double GetValue()
        {
            double value = 0;
            int[] g = new int[BITS_PER_GENE];
            g = getGeneBin();
            double dx = Math.Abs((double)(min - max) / P);
            for (int j = 0; j < BITS_PER_GENE; j++)
            {
                value += g[BITS_PER_GENE - j - 1] * Math.Pow(2.0, j);
            }
            value = min + (dx * value);
            return value;
        }
        //----------------------------
        //algoritmo para mostrar el fenotipo
        public string getGene()
        {
            string g = "";
            for (int i = 0; i < BITS_PER_GENE; i++)
            {
                g += gene[i].ToString();
            }
            return g;
        }
        //-------------------------------
        //algoritmo para obtener gen en binario
        public int[] getGeneBin()
        {
            int[] g = new int[BITS_PER_GENE];
            g[0] = gene[0];
            g[1] = gene[1];
            for (int i = 1; i < BITS_PER_GENE - 1; i++)
            {
                if (g[i] != gene[i + 1])
                    g[i+1] = 1;
                else
                    g[i+1]= 0;
            }
            return g;
        }
        //getBitspor gene
        public int getBitsPG()
        {
            return BITS_PER_GENE;
        }
        //set Gene
        public void setGene(int[] gen)
        {
            gene = gen;
        }
    }
}
