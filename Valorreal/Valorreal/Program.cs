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

    class Program
    {
        static void Main(string[] args)
        {
            Individuo[] ind = new Individuo[100]; //creacion individuos
            Individuo[] ng = new Individuo[100]; //creacion individuos para nuevas generaciones
            Individuo[] aux = new Individuo[2];//individuos auxiliares para agregar hijos
            double r;//variable para r
            double sapt2, sapt;//variables para suma de aptitud
            int j;//variable j para iterador
            //Creamos los 100 individuos iniciales
            for (int i = 0; i < 100; i++)
            {
                ind[i] = new Individuo();
            }
            //mostramos la primer generación
            Console.WriteLine("Primer Generación:\n");
            for (int i = 0; i < 100; i++)
            {
                ind[i].calaptitud();
                Console.WriteLine("Individuo:  " + ind[i].ToString() + " Aptitud: " + ind[i].getaptitud());
            }
            //Iterator de 500 generaciones
            for (int it = 0; it < 500; it++) {
                sapt = 0;
                //Calculamos la suma de aptitudes
                for (int i = 0; i < 100; i++)
                {
                    ind[i].calaptitud();
                    sapt += ind[i].getaptitud();
                }
                //Elegimos los mejores candidatos para cruza
                for (int i = 0; i < 100; i++)
                {
                    sapt2 = 0;
                    j = -1;
                    r = new Random(Guid.NewGuid().GetHashCode()).NextDouble() * (sapt);
                    //Console.WriteLine(r + "\n");
                    while (sapt2 < r)
                    {
                        j++;
                        //Console.WriteLine(sapt2 + " " + ind[j].getaptitud());
                        sapt2 += ind[j].getaptitud();
                    }
                    ng[i] = ind[j];
                }

                j = 0;
                //Si hay algun individuo que sea optimo pasa a la siguiente generacion 
                for (int i = 0; i < 100; i++) {
                    ng[i].calaptitud();
                    if (ng[i].getaptitud() <=1 && ng[i].getaptitud() >=-1) {
                        //Console.WriteLine("Elitismo"+ ng[i].getaptitud());
                        ind[j] = ng[i];
                        j++;
                    }
                }
                //Llenamos la generacion con la cruza de los individuos seleccionados 
                //Esta cruza se lleva aleatoriamente
                while (j <99) {
                    aux = ng[new Random(Guid.NewGuid().GetHashCode()).Next(0, 100)].Cross1P(ng[new Random(Guid.NewGuid().GetHashCode()).Next(0, 100)]);
                    //Los hijos almacenados en la variable auxiliar pasan a la siguiente generacion
                    ind[j] = aux[0];
                    j++;
                    ind[j] = aux[1];
                    j++;
                }
                //Mutamos al 10 por ciento de la población
                for (int i = 0; i < 10; i++)
                {
                    ind[new Random(Guid.NewGuid().GetHashCode()).Next(0, 100)].mutacion();
                }
            }
            //Calculamos las aptitudes finales
            for (int i = 0; i < 100; i++)
            {
                ind[i].calaptitud();
            }
            //Mostramos los individuos y aptitudes finales
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Individuo:  "+ind[i].ToString()+" Aptitud: "+ind[i].getaptitud()); //mostrar individuo
            }
            for (int i = 0; true;) { }
        }
    }
}
