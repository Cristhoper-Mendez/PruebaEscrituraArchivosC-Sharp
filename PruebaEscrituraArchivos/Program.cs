using System;
using System.Diagnostics;
using System.IO;

namespace PruebaEscrituraArchivos
{
    class Program
    {
        static StreamReader reader;
        static StreamWriter writer;
       
        struct Persona
        {
            public string nombre;
            public int edad;
            public string direccion;
        }
        static void Main(string[] args)
        {
            Console.Title = "Prueba 1";

            int opcion;
            Console.WriteLine("Digite 1 para acceder al menu 1.");
            Console.WriteLine("Digite 2 para acceder al menu 2.");
            opcion = int.Parse(Console.ReadLine());
            
            if(opcion == 1)
            {
                Console.Title = "Prueba escritura/lectura de archivos en C#";
                OpcionMenu1();
            } else
            {
                Console.Title = "Ejemplo de archivos con estructuras.";
                OpcionMenu2();
            }


            Console.ReadKey();
        }

        static void OpcionMenu1()
        {
            Console.Clear();

            string archivo = "archivo.txt";
            string text;
            int opcion;
            Console.WriteLine("Digite 1 para crear y escribir sobre un archivo.");
            Console.WriteLine("Digite 2 para leer un archivo.");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                writer = new StreamWriter(archivo, true);
                Console.WriteLine("Digite un mensaje de prueba.");
                text = Console.ReadLine();
                writer.WriteLine(text);
                Console.WriteLine("Escritura exitosa...");
                writer.Close();
            }
            else
            {
                reader = new StreamReader(archivo);
                text = reader.ReadToEnd();
                Console.WriteLine("\t lo leido en el archivo es: " + text);
                reader.Close();
            }
        }

        static void OpcionMenu2()
        {
            int i = 0, contador = 0;
            string opcion, linea;
            string archivo = "datos.txt";

            Persona persona = new Persona();

            do
            {
                Console.Clear();
                writer = new StreamWriter(archivo, true);
                Console.WriteLine("Persona con Id: [" + (i + 1) + "]");

                Console.WriteLine("Nombre: ");
                persona.nombre = Console.ReadLine();

                Console.WriteLine("Edad: ");
                persona.edad = int.Parse(Console.ReadLine());

                Console.WriteLine("Direccion: ");
                persona.direccion = Console.ReadLine();

                // Escribir en el archivo
                writer.WriteLine("Persona con ID: " + (i +1));
                writer.WriteLine("Persona con nombre: " + persona.nombre);
                writer.WriteLine("Persona con edad: " + persona.edad);
                writer.WriteLine("Persona con direccion: " + persona.direccion);
                writer.WriteLine("---------------------------------------------------------");
                i++;

                writer.Close();

                Console.WriteLine("Desea ingresar otro registro? S/N");
                opcion = Console.ReadLine();

                if(opcion == "N" || opcion == "n")
                {
                    Process.Start("datos.txt");
                }
            } while (opcion == "S" || opcion == "s");

            reader = new StreamReader(archivo);
            while ((linea = reader.ReadLine()) != null)
            {
                Console.WriteLine(linea);
                contador++;
            }

        }
    }
}
