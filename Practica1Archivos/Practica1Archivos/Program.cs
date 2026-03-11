using static System.Runtime.InteropServices.JavaScript.JSType;

class program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hola mundo");
        // Print greeting message / Imprime mensaje de saludo

        string nombrearchivo = "Datos.txt";
        // File name variable / Variable con el nombre del archivo

        string nombre;
        // Variable to store name / Variable para guardar el nombre

        int edad;
        // Variable to store age / Variable para guardar la edad

        double estatura;
        // Variable to store height / Variable para guardar la estatura

        string datos;
        // Variable to store each line read from file / Variable para guardar cada línea leída del archivo

        StreamReader leerarchivo = null;
        // Reader object initialized as null / Objeto lector inicializado en null

        StreamWriter archivo = null;
        // Writer object initialized as null / Objeto escritor inicializado en null

        if (File.Exists(nombrearchivo))
        // Check if file exists / Verifica si el archivo existe
        {
            leerarchivo = File.OpenText(nombrearchivo);
            // Open file for reading / Abre el archivo para lectura

            do
            {
                datos = leerarchivo.ReadLine();
                // Read one line from file / Lee una línea del archivo

                string[] d = datos.Split(" _ ");
                // Split line using separator / Divide la línea usando el separador

                Console.WriteLine("El nombre es: " + d[0]);
                // Print name (first position) / Imprime el nombre (posición 0)

                Console.WriteLine("la edad es: " + d[1]);
                // Print age (second position) / Imprime la edad (posición 1)

                Console.WriteLine("la estatura es: " + d[2]);
                // Print height (third position) / Imprime la estatura (posición 2)

            } while (datos != null);
            // Repeat until line is null / Repite hasta que la línea sea null

            leerarchivo.Close();
            // Close reader / Cierra el lector
        }
        else
        {
            archivo = File.AppendText(nombrearchivo);
            // Create/open file for writing / Crea o abre el archivo para escritura

            for (int i = 1; i < 6; i++)
            // Loop 5 times / Ciclo que se ejecuta 5 veces
            {
                Console.WriteLine("Escribe el nombre");
                // Ask for name / Solicita el nombre

                nombre = Console.ReadLine();
                // Read name from console / Lee el nombre desde consola

                Console.WriteLine("Escribe la edad");
                // Ask for age / Solicita la edad

                edad = Convert.ToInt32(Console.ReadLine());
                // Convert input to int / Convierte la entrada a entero

                Console.WriteLine("Escribe la estatura");
                // Ask for height / Solicita la estatura

                estatura = Convert.ToDouble(Console.ReadLine());
                // Convert input to double / Convierte la entrada a decimal (double)

                archivo.WriteLine(nombre + "_" + edad + "_" + estatura);
                // Write data to file separated by "_" / Escribe los datos en el archivo separados por "_"

                i++;
                // Manually increment i (extra increment) / Incrementa manualmente i (incremento extra)
            }

            archivo.Close();
            // Close writer / Cierra el escritor
        }
    }
}