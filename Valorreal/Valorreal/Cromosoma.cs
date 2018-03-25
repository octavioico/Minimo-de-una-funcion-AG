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
    class Cromosoma
    {


        
        public Gen[] gen;
        //-------------------------
        //creamos el gene a partir de los bits obtenidos por el paso del parametro en el constructor
        public Cromosoma(int nGen)
        {
            gen = new Gen[nGen];//Constructor gen
            double min = -10;//Minimo funcion
            double max = 10;//maximo funcion
            int P = 300;//numero de partes
            for (int i = 0; i < nGen; i++)
            {
                crearGen(i,min,max,P);
            }
        }
        //-------------------------
        //inicializacion aleatoria del cromosoma

        public void crearGen(int ngen,double min, double max,int P)
        {
            gen[ngen] = new Gen(min,max,P);//Declaramos el gen
            gen[ngen].inicializa(new Random(Guid.NewGuid().GetHashCode())); // inicializar gen
        }

        //Metodo to string
        public override string ToString()
        {
            string s = "Cromosoma [";
            for (int i = 0; i < gen.Length; i++)
            {
                s += gen[i].getGene();
            }
            s += "] ";
            for (int i = 0; i < gen.Length; i++)
            {
                s += gen[i].GetValue();
                s += ", ";
            }
            return string.Format(s);
        }
        
    }
}
