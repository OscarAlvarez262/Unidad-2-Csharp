


using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{ // Main class of the program / Clase principal del programa

    static Validaciones val = new Validaciones(); // Create validation object / Crear objeto de validaciones

    static void Main(string[] args) // Program entry point / Punto de entrada del programa
    {
        int op = 0; // Variable to store menu option / Variable para almacenar opción del menú
        do // Loop until user chooses option 5 / Ciclo hasta que el usuario elija opción 5
        {
            op = Menu(); // Call menu method and store selected option / Llamar método menú y guardar opción elegida
            switch (op) // Evaluate selected option / Evaluar opción seleccionada
            {
                case 1: // Option 1 / Opción 1
                    Agregar(); // Call add method / Llamar método agregar
                    break; // Exit case / Salir del case
                case 2: // Option 2 / Opción 2
                    Console.WriteLine("Eliminar"); // Print message / Mostrar mensaje
                    break; // Exit case / Salir del case
                case 3: // Option 3 / Opción 3
                    Console.WriteLine("Eliminar Dato"); // Print message / Mostrar mensaje
                    break; // Exit case / Salir del case
                case 4: // Option 4 / Opción 4
                    Console.WriteLine("Mostar archivo"); // Print message / Mostrar mensaje
                    Mostrar(); // Call show method / Llamar método mostrar
                    break; // Exit case / Salir del case
                case 5: // Option 5 / Opción 5
                    Console.WriteLine("Salir"); // Print exit message / Mostrar mensaje de salida
                    break; // Exit case / Salir del case
            }
        } while (op != 5); // Repeat while option is not 5 / Repetir mientras la opción no sea 5
    }

    static void Mostrar()
    { // Method to display file content / Método para mostrar contenido del archivo
        StreamReader leerArchivo = null; // Reader object / Objeto lector
        string datos = null; // Variable to store each line / Variable para almacenar cada línea
        if (File.Exists("Datos.txt")) // Check if file exists / Verificar si el archivo existe
        {
            leerArchivo = File.OpenText("Datos.txt"); // Open file for reading / Abrir archivo para lectura
            do // Loop to read lines / Ciclo para leer líneas
            {
                datos = leerArchivo.ReadLine(); // Read one line / Leer una línea
                if (datos != null) // If line is not null / Si la línea no es nula
                {
                    string[] d = datos.Split(" _ "); // Split line by delimiter / Separar línea por delimitador
                    Console.WriteLine("El nombre es: " + d[0]); // Print name / Mostrar nombre
                    Console.WriteLine("La edad es: " + d[1]); // Print age / Mostrar edad
                    Console.WriteLine("La estatura es: " + d[2]); // Print height / Mostrar estatura
                }
            } while (datos != null); // Continue while there are lines / Continuar mientras haya líneas
            leerArchivo.Close(); // Close file / Cerrar archivo
        }
    }

    static void Agregar()
    { // Method to add new data / Método para agregar nuevos datos
        string nombre, edad, estatura; // Variables for data / Variables para datos
        StreamWriter archivo = null; // Writer object / Objeto escritor

        while (true) // Infinite loop until valid name / Ciclo infinito hasta nombre válido
        {
            Console.WriteLine("Escribe un nombre"); // Ask for name / Pedir nombre
            nombre = Console.ReadLine(); // Read input / Leer entrada
            if (val.ValidarNombre(nombre)) // Validate name / Validar nombre
            {
                break; // Exit loop if valid / Salir del ciclo si es válido
            }
            else
            {
                Console.WriteLine("Error al introducir el nombre"); // Show error / Mostrar error
            }
        }
        Console.WriteLine("El nombre correcto es:" + nombre); // Confirm valid name / Confirmar nombre válido

        while (true) // Loop until valid age / Ciclo hasta edad válida
        {
            Console.WriteLine("Escribe la edad"); // Ask for age / Pedir edad
            edad = Console.ReadLine(); // Read input / Leer entrada
            if (val.ValidarEdad(edad)) // Validate age / Validar edad
            {
                break; // Exit loop if valid / Salir del ciclo si es válido
            }
            else
            {
                Console.WriteLine("Error al introducir la edad"); // Show error / Mostrar error
            }
        }

        Console.WriteLine("La edad correcta es:" + edad); // Confirm valid age / Confirmar edad válida

        while (true) // Loop until valid height / Ciclo hasta estatura válida
        {
            Console.WriteLine("Escribe la estatura de la persona"); // Ask for height / Pedir estatura
            estatura = Console.ReadLine(); // Read input / Leer entrada
            if (val.ValidarEstatura(estatura)) // Validate height / Validar estatura
            {
                break; // Exit loop if valid / Salir del ciclo si es válido
            }
            else
            {
                Console.WriteLine("Error al introducir la estatura"); // Show error / Mostrar error
            }
        }
        Console.WriteLine("La estatura correcto es:" + estatura); // Confirm valid height / Confirmar estatura válida

        archivo = File.AppendText("Datos.txt"); // Open file in append mode / Abrir archivo en modo agregar
        archivo.WriteLine(nombre + " _ " + edad + " _ " + estatura); // Write formatted line / Escribir línea formateada
        archivo.Close(); // Close file / Cerrar archivo
    }

    static int Menu()
    { // Method to display menu and return option / Método para mostrar menú y retornar opción
    inicio: // Label for goto / Etiqueta para goto
        int opcion = 0; // Variable to store option / Variable para almacenar opción
        Console.WriteLine("1.- Agregar elementos al archivo"); // Menu option 1 / Opción 1
        Console.WriteLine("2.- Eliminar Archivo"); // Menu option 2 / Opción 2
        Console.WriteLine("3.- Eliminar Datos en el archivo"); // Menu option 3 / Opción 3
        Console.WriteLine("4.- Mostrar Contenido del archivo"); // Menu option 4 / Opción 4
        Console.WriteLine("5.- Salir"); // Menu option 5 / Opción 5
        Console.WriteLine("Escibe la opcion del menu"); // Ask for selection / Pedir selección
        string op = Console.ReadLine(); // Read input / Leer entrada

        if (val.ValidarEdad(op)) // Validate option using age validation / Validar opción usando validación de edad
        {
            opcion = int.Parse(op); // Convert to int / Convertir a entero
        }
        else
        {
            Console.WriteLine("Error en el menu"); // Show error / Mostrar error
            goto inicio; // Return to menu start / Regresar al inicio del menú
        }

        return opcion; // Return selected option / Retornar opción seleccionada
    }
}
