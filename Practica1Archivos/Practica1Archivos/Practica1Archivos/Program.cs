



using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program { 
     
    static void Main(string[] args)
    {
        string nombrearchivo = "datos.txt";
        string nombre;
        int edad;
        double estatura;
        string datos;
        StreamWriter archivo = null;
        StreamReader leerArchivo = null;
        
        if(File.Exists(nombrearchivo)) {
            leerArchivo = File.OpenText(nombrearchivo);
            do
            {
                datos = leerArchivo.ReadLine();
                string[] d = datos.Split(" _ ");
                Console.WriteLine("El nombre es: " + d[0]);
                Console.WriteLine("La edad es: " + d[1]);
                Console.WriteLine("La estatura es: " + d[2]);
            } while (datos != null);
            leerArchivo.Close();
        }
        else
        {
            archivo = File.AppendText(nombrearchivo);
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("Escribe el nombre");
                nombre = Console.ReadLine();
                Console.WriteLine("Escribe la edad");
                edad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Escribe la estatura");
                estatura = Convert.ToDouble(Console.ReadLine());
                archivo.WriteLine(nombre + " _ " + edad + " _ " + estatura);
            }
            archivo.Close();
        } 
    }

}
