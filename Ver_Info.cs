using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto
{
    class Ver_Info
    {
        private string cadena;
        public Ver_Info()
        {
            StreamReader lectura;
            lectura = File.OpenText("Archivos.txt");
            cadena = lectura.ReadLine();
            while (cadena != null)
            {
                Console.WriteLine(cadena);
                cadena = lectura.ReadLine();
            }

            lectura.Close();

        }
    }
}
