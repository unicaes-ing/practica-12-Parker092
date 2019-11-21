using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace guia12E3
{
    class Ejercicio1
    {
        public void ejer1() 
        {
            Mascota mascota = new Mascota();
            const string nombreArchivo = "mascotas.bin";
            FileStream fs;
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                Console.WriteLine("Nombre: ");
                mascota.nombre = Console.ReadLine();
                Console.WriteLine("Especie: ");
                mascota.especie = Console.ReadLine();
                Console.WriteLine("Raza: ");
                mascota.raza = Console.ReadLine();
                Console.WriteLine("Sexo: ");
                mascota.sexo = Console.ReadLine();
                Console.WriteLine("Edad: ");
                mascota.setEdad(Convert.ToInt32(Console.ReadLine()));
                fs = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
                formatter.Serialize(fs, mascota);
                fs.Close();
                Console.WriteLine("La informacion de la mascota fue almacenada correctamente...");
            }
            catch (Exception)
            {

                throw;
            }
            Console.ReadKey();
        }
        [Serializable]
        public struct Mascota
        {
            public string nombre;
            public string especie;
            public string raza;
            public string sexo;
            public int edad;
            public void setEdad(int edad)
            {
                if (edad > 0)
                {
                    this.edad = edad;
                }
            }
            public int getEdad()
            {
                return edad;
            }
        }
    }
}
