using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace guia12E3
{
    class Ejercicio2 : Ejercicio1
    {
        public void ejer2()
        {
            Ejercicio1.Mascota mascota2;
            FileStream fs;
            BinaryFormatter formatter = new BinaryFormatter();
            const string nombreArchivo = "mascota.bin";
            if (File.Exists(nombreArchivo))
            {
                try
                {
                    fs = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                    mascota2 = (Ejercicio1.Mascota)formatter.Deserialize(fs);
                    fs.Close();
                    Console.WriteLine("Datos de la mascota\n");
                    Console.WriteLine($"Nombre: {mascota2.nombre}");
                    Console.WriteLine($"Especie: {mascota2.especie}");
                    Console.WriteLine($"Raza: {mascota2.raza}");
                    Console.WriteLine($"Sexo: {mascota2.sexo}");
                    Console.WriteLine($"Edad: {mascota2.getEdad()}");
                    Console.WriteLine("Presione <Enter> para salir.");

                }
                catch (Exception)
                {

                    throw;
                }
                Console.ReadKey();
            }
        }
    }
}
