using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace guia12E3
{
    class Ejercicio3
    {
        [Serializable]
        #region structura
        public struct alumno
        {
            //carnet nombre carrera cum
            public string carnet;
            public string nombre;
            public string carrera;
            private decimal cum;
            public void serCum(decimal cum)
            {
                if (cum > 0)
                {
                    this.cum = cum;
                }
            }
            public decimal getCum()
            {
                return cum;
            }
        }
        #endregion
        #region Creacion Stram Bin
        private static Dictionary<string, alumno> dAlumnos = new Dictionary<string, alumno>();
        private static BinaryFormatter formatter = new BinaryFormatter();
        private const string N_ARCH = "alumnos.bin";
        #endregion
        #region saver
        public static bool gDiccionario(Dictionary<string, alumno> dAlumnos)
        {
            try
            {
                FileStream fs = new FileStream(N_ARCH, FileMode.Create, FileAccess.Write);
                formatter.Serialize(fs, dAlumnos);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region reader
        public static bool leerDiccionario()
        {
            try
            {
                FileStream fs = new FileStream(N_ARCH, FileMode.Open, FileAccess.Read);
                dAlumnos = (Dictionary<string, alumno>)formatter.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        public void ejer3()
        {
            if (File.Exists(N_ARCH))
            {
                leerDiccionario();
            }
            else
            {
                gDiccionario(dAlumnos);
            }
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("===== MENU =====");
                Console.WriteLine(" 1 - Agregar alumno.");
                Console.WriteLine(" 2 - Mostrar alumnos.");
                Console.WriteLine(" 3 - Buscar alumno.");
                Console.WriteLine(" 4 - Editar alumno.(P)");
                Console.WriteLine(" 5 - Eliminar alumno");
                Console.WriteLine(" 6 - Salir");
                op = Convert.ToInt32(Console.ReadLine());
                
                switch (op)
                {
                    case 1:
                        #region Opccion 1
                        Console.Clear();
                        Console.WriteLine("===== AGREGAR =====");
                        alumno alumn = new alumno();
                        do
                        {
                            Console.WriteLine("Carnet: ");
                            alumn.carnet = Console.ReadLine();
                            if (dAlumnos.ContainsKey(alumn.carnet))
                            {
                                Console.WriteLine("Carnet existente en el registro.");
                            }
                        } while (dAlumnos.ContainsKey(alumn.carnet));
                        Console.WriteLine("Nombre: ");
                        alumn.nombre = Console.ReadLine();
                        Console.WriteLine("Carrera: ");
                        alumn.carrera = Console.ReadLine();
                        Console.WriteLine("CUM: ");
                        alumn.serCum(Convert.ToDecimal(Console.ReadLine()));
                        dAlumnos.Add(alumn.carnet, alumn);
                        gDiccionario(dAlumnos);
                        Console.WriteLine("Datos almacenados Correctamente");
                        Console.WriteLine("\nPresione <ENTER> para continuar.");
                        Console.ReadKey();
                        #endregion
                        break;
                    case 2:
                        #region Opccion 2
                        try
                        {
                            Console.WriteLine("======================== LISTADO DE ALUMNOS =============================");
                            Console.WriteLine("{0, 10} {1,-25} {2,-30} {3,5}", "Carnet: ", "Nombre: ", "Carrera: ", "CUM: ");
                            Console.WriteLine("=========================================================================");
                            leerDiccionario();
                            foreach (KeyValuePair<string, alumno> alumnoG in dAlumnos)
                            {
                                alumno alumns = alumnoG.Value;
                                Console.WriteLine("{0,10} {1,-25} {2,-30} {3,5}",
                                alumns.carnet, alumns.nombre, alumns.carrera, alumns.getCum());
                            }
                            Console.WriteLine("=========================================================================");
                            Console.WriteLine("\nPresione <ENTER> para continuar.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        Console.ReadKey();
                        #endregion
                        break;
                    case 3:
                        #region Opccion 3
                        string carnetBusc;
                        Console.WriteLine("Ingrese carnet asignado al alumno que desea buscar:");
                        carnetBusc = Console.ReadLine();
                        if (dAlumnos.ContainsKey(carnetBusc))
                        {
                            Console.WriteLine("===== DATOS DE ALUMNO =====");
                            Console.WriteLine("{0, 10} {1,-25} {2,-30} {3,5}", "Carnet: ", "Nombre: ", "Carrera: ", "CUM: ");
                            Console.WriteLine("=========================================================================");
                            leerDiccionario();
                            Console.WriteLine("{0,10} {1,-25} {2,-30} {3,5}",
                                dAlumnos[carnetBusc].carnet, dAlumnos[carnetBusc].nombre, dAlumnos[carnetBusc].carrera, dAlumnos[carnetBusc].getCum());
                        }
                        else
                        {
                            Console.WriteLine("El carnet: " + carnetBusc + " NO esta registrado.");
                        }
                        Console.WriteLine("\nPresione <ENTER> para continuar.");
                        Console.ReadKey();
                        #endregion
                        break;
                    case 4:
                        #region Opccion 4
                        string cMod;
                        Console.WriteLine("Ingrese carnet asignado al alumno que desea modificar:");
                        cMod = Console.ReadLine();
                        if (dAlumnos.ContainsKey(cMod))
                        {
                            Console.WriteLine("===== MODIFICAR DATOS DE ALUMNO =====");
                            dAlumnos.Remove(cMod);
                            Console.WriteLine("===== MODIFICAR =====");
                            Console.WriteLine("INGRESE LOS NUEVOS DATOS DEL ALUMNO "+cMod+" :");
                            alumno alumnN = new alumno();
                            do
                            {
                                Console.WriteLine("Carnet: ");
                                alumnN.carnet = Console.ReadLine();
                                if (dAlumnos.ContainsKey(alumnN.carnet))
                                {
                                    Console.WriteLine("Carnet existente en el registro.");
                                }
                            } while (dAlumnos.ContainsKey(alumnN.carnet));
                            Console.WriteLine("Nombre: ");
                            alumnN.nombre = Console.ReadLine();
                            Console.WriteLine("Carrera: ");
                            alumnN.carrera = Console.ReadLine();
                            Console.WriteLine("CUM: ");
                            alumnN.serCum(Convert.ToDecimal(Console.ReadLine()));
                            dAlumnos.Add(alumnN.carnet, alumnN);
                            gDiccionario(dAlumnos);
                            Console.WriteLine("Datos almacenados Correctamente");
                            Console.WriteLine("\nPresione <ENTER> para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("El carnet: " + cMod + " NO esta registrado.");
                        }
                        #endregion
                        break;
                    case 5:
                        #region Opccion 5
                        string cElim;
                        Console.WriteLine("Ingrese carnet asignado al alumno que desea modificar:");
                        cElim = Console.ReadLine();
                        if (dAlumnos.ContainsKey(cElim))
                        {
                            dAlumnos.Remove(cElim);
                        }
                        gDiccionario(dAlumnos);
                            #endregion
                        break;
                }
            } while (op != 6);
        }
    }
}
