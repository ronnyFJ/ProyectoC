using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Seccion();
        }
        static void Seccion()
        {
            Console.WriteLine("1> Ingresar informacion");
            Console.WriteLine("2> Buscar informacion");
            Console.WriteLine("3> Archivo de informacion");
            Console.WriteLine("4> Salir");
            int opciones = 0;
            opciones = Convert.ToInt32(Console.ReadLine());
            switch (opciones)
            {
                case 1:
                    Persona();
                    Ver_Info visor = new Ver_Info();
                    Console.ReadKey();
                    Seccion();
                    break;
                case 2:
                    Console.WriteLine("Buscando info...");
                    Busqueda();
                    break;
                case 3:
                    informacion();
                    break;
                case 4:
                    Console.WriteLine("Adios...");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("opcion incorrecta");
                    Seccion();
                    break;

            }
        }
        static void Persona()
        {

            string Identificacion, Nombre, Apellidos, Fecha_De_Nacimiento, cadena;
            int Edad, ID = -2;
            char Sexo = ' ';
            StreamReader lectura;
            lectura = File.OpenText("Archivos.txt");
            cadena = lectura.ReadLine();
            while (cadena != null)
            {
                ID = ID + 1;
                cadena = lectura.ReadLine();
            }
            lectura.Close();
            Console.WriteLine("Introduzca datos de la persona");
            Console.WriteLine("Identificacion:");
            Identificacion = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Nombre:");
            Nombre = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Apellido:");
            Apellidos = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Sexo:");
            try
            {
                Sexo = Convert.ToChar(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR! " + e.Message + "\n");
                Persona();
            }
            Console.WriteLine("Fecha de Nacimiento:");
            Fecha_De_Nacimiento = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Edad:");
            Edad = Convert.ToInt32(Console.ReadLine());

            if (Nombre.Length > 15)
            {
                Console.WriteLine("El nombre debe ser de 25 espacios max.\n");
                Persona();
            }
            else if (Apellidos.Length > 15)
            {
                Console.WriteLine("El Apellido debe ser de 25 espacios max.\n");
                Persona();
            }
            else if (Identificacion.Length > 13 || Identificacion == "")
            {
                Console.WriteLine("La identificacion debe ingresarse y debe ser de 13 espacios max.\n");
                Persona();
            }
            else if (!(Sexo == 'M' || Sexo == 'F'))
            {
                Console.WriteLine("El Sexo debe ser F o M en MAYUSCULA.\n");
                Persona();
            }
            else if (Fecha_De_Nacimiento.Length > 10)
            {


                Console.WriteLine("La fecha de nacimiento debe ser de 10 espacios max.\n");
                Persona();
            }
            else if (Edad > 999)
            {
                Console.WriteLine("La edad debe ser de 3 espacios max:\n");
                Persona();
            }
            else
            {
                //var sb = new StringBuilder();
                //sb.Append(String.Format("{0,0}{1,20}{2,10}{3,15}{4,10}{5,25}{6,11}\n", "ID", "IDENTIFICACION", "NOMBRE", "APELLIDO", "SEXO",
                //"FECHA DE NACIMIENTO", "EDAD"));
                string s = String.Format("{0,5}{1,20}{2,10}{3,15}{4,9}{5,23}{6,14}", ID, Identificacion, Nombre, Apellidos, Sexo,
                 Fecha_De_Nacimiento, Edad);
                StreamWriter escribir = File.AppendText("Archivos.txt");
                escribir.WriteLine(s);
                escribir.Close();

            }

        }
        static void informacion()
        {
            Console.WriteLine(" Campo                   Longitud        Mascara         Posicion Inicial          Posicion Final");
            Console.WriteLine("");
            Console.WriteLine("ID                         10                                   1                        10      ");
            Console.WriteLine("Identificacion             13                                   11                       23      ");
            Console.WriteLine("Nombre                     25                                   24                       73      ");
            Console.WriteLine("Apellido                   25                                   74                       123     ");
            Console.WriteLine("Sexo                       1                                    124                      124     ");
            Console.WriteLine("Fecha de nacimiento        10           DD-MM-YYYY              125                      134     ");
            Console.WriteLine("Edad                       3                                    135                      137     \n");
            Seccion();
        }
        static void Busqueda()
        {
            string cadena, persona;
            bool encontrado = false;
            Console.Write("ingresa la identificacion de la persona que buscas: ");
            persona = Console.ReadLine();
            Console.WriteLine("");
            StreamReader lectura;
            lectura = File.OpenText("Archivos.txt");
            cadena = lectura.ReadLine();
            while (cadena != null && encontrado == false)
            {
                if (cadena.Contains(persona))
                {
                    Console.WriteLine(cadena);
                    encontrado = true;
                }
                else
                {
                    cadena = lectura.ReadLine();
                }
                
            }
            if (encontrado == false)
            {
                Console.WriteLine("Datos no encontrados");
            }
            lectura.Close();
            Console.ReadLine();
            Seccion();

        }
    }

}

