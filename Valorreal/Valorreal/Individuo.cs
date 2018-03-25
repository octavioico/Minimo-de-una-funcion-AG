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
    class Individuo
    {
        Cromosoma cromosoma; //declarar cromosoma 
        private double aptitud;//variable aptitud
        private double ve;//variable valor esperado
        public Individuo()
        {
            cromosoma = new Cromosoma(1); // crear cromosoma            
        }

        //Algoritmo cruza por 1 punto
        public Individuo[] Cross1P(Individuo madre)
        {
            Individuo[] hijos = new Individuo[2];//Arreglo cromosomas hijos
            hijos[0] = new Individuo();//Creamos cromosoma hijo 0
            int[] gen = new int[madre.cromosoma.gen[0].getBitsPG()]; ; //declaracion gen auxiliar hijo 0
            hijos[1] = new Individuo();//Crear cromosoma hijo 1
            int[] gen2 = new int[madre.cromosoma.gen[0].getBitsPG()]; ; //declaracion gen auxiliar hijo 1
            int crosspoint = new Random(Guid.NewGuid().GetHashCode()).Next(0, madre.cromosoma.gen[0].getBitsPG());//generamos punto aleatorio para cruza
            //Console.WriteLine("\nPunto de Cruza: " + crosspoint + "\n");//Mostramospunto cruza
            //Algoritmo que junta partes de cada padre en cada hijo
            for (int i = 0; i < madre.cromosoma.gen[0].getBitsPG(); i++)
            {
                //Si i es menor al punto de cruza metemos la primer parte del padre en hijo 0 y primer parte madre hijo 1
                if (i <= crosspoint)
                {
                    gen[i] = Int32.Parse(this.cromosoma.gen[0].getGene().ElementAt(i).ToString());
                    gen2[i] = Int32.Parse(madre.cromosoma.gen[0].getGene().ElementAt(i).ToString());
                }
                //Si i es mayor al punto de cruza metemos la segunda parte del padre en hijo 1 y segunda parte madre hijo 0
                else
                {
                    gen[i] = Int32.Parse(madre.cromosoma.gen[0].getGene().ElementAt(i).ToString());
                    gen2[i] = Int32.Parse(this.cromosoma.gen[0].getGene().ElementAt(i).ToString());
                }
            }
            //Ingresamos el gen mezclado en cada hijo
            hijos[0].cromosoma.gen[0].setGene(gen);
            hijos[1].cromosoma.gen[0].setGene(gen2);
            //retornamos los hijos creados
            return hijos;
        }
        //Mutacion
        public void mutacion() {
            int[] aux;
            aux=this.cromosoma.gen[0].getGeneBin();//obtenemos el cromosoma
            aux[new Random(Guid.NewGuid().GetHashCode()).Next(0, this.cromosoma.gen[0].getBitsPG())]=1;//un bit aleatorio lo colocamos a 1
            this.cromosoma.gen[0].setGene(aux);//Seteamos el gen mutado en el cromosoma
        }
        //Calcula aptitud
        public void calaptitud() {
            double x = this.cromosoma.gen[0].GetValue();//obtenemos el valor del cromosoma
            aptitud = Math.Cos(x/180) * Math.Pow(Math.E, ((-Math.PI * x) / 100));//funcion de aptitud
        }
        //devolver valor aptitud
        public double getaptitud() {
            return aptitud;
        }
        //Set ve
        public void setve(double ve) {
            this.ve = ve;
        }
        //get ve
        public double getve() {
            return ve;
        }
        //Metodo to String
        public override string ToString()
        {
            return string.Format(cromosoma.ToString());
        }
    }
}
