class Program
{

    // Instance of the validation class
    // Instancia de la clase de validaciones
    static Validaciones val = new Validaciones();

    static void Main(string[] args)
    {
        // Variable that stores the menu option selected by the user
        // Variable que guarda la opción seleccionada del menú
        int op = 0;

        // Loop that keeps the program running until the user selects option 5
        // Ciclo que mantiene el programa ejecutándose hasta que el usuario elija la opción 5
        do
        {

            op = Menus();
            switch (op)
            {
                case 1:
                    // Call method to add a new record to the file
                    // Llama al método para agregar un nuevo registro al archivo
                    Agregar();
                    break;
                case 2:
                    // Call method to delete the entire file
                    // Llama al método para eliminar todo el archivo
                    Eliminarachivo();
                    Console.WriteLine("Eliminar");
                    break;
                case 3:
                    // Call method to delete a specific element from the file
                    // Llama al método para eliminar un elemento específico del archivo
                    EliminarElementoArchivo();
                    Console.WriteLine("Eliminar dato");
                    break;
                case 4:
                    // Call method to display file content
                    // Llama al método para mostrar el contenido del archivo
                    Mostrar();
                    break;
                case 5:
                    // Exit option
                    // Opción para salir del programa
                    break;
            }
        } while (op != 5);

    }

    static void EliminarElementoArchivo()
    {
        // Variable to store the name to delete
        // Variable para guardar el nombre que se desea eliminar
        string nombre;

        // Show current data before deleting
        // Muestra los datos actuales antes de eliminar
        Mostrar();

        Console.WriteLine("Escribe el nombre a eliminar");
        nombre = Console.ReadLine();

        // Reader object to read the file
        // Objeto lector para leer el archivo
        StreamReader leerArchivo = null;

        // Variable that stores each line read
        // Variable que guarda cada línea leída
        string datos = null;

        // Check if file exists
        // Verifica si el archivo existe
        if (File.Exists("Datos.txt"))
        {
            // Open file for reading
            // Abre el archivo para lectura
            leerArchivo = File.OpenText("Datos.txt");

            do
            {
                // Read a line from the file
                // Lee una línea del archivo
                datos = leerArchivo.ReadLine();

                if (datos != null)
                {
                    // Split the line into parts (name, age, height)
                    // Divide la línea en partes (nombre, edad, estatura)
                    string[] d = datos.Split(" _ ");

                    // If the name matches the one to delete
                    // Si el nombre coincide con el que se quiere eliminar
                    if (nombre.Equals(d[0]))
                    {
                        Console.WriteLine("Si lo encontro");
                    }
                    else
                    {
                        // If it does not match, save the line into an auxiliary file
                        // Si no coincide, guarda la línea en un archivo auxiliar
                        StreamWriter archivo = null;
                        archivo = File.AppendText("DatosAux.txt");
                        archivo.WriteLine(datos);
                        archivo.Close();
                    }
                }
            } while (datos != null);

            // Close the reader
            // Cierra el lector
            leerArchivo.Close();

            // Delete original file
            // Elimina el archivo original
            File.Delete("Datos.txt");

            // Copy auxiliary file to replace the original
            // Copia el archivo auxiliar para reemplazar el original
            File.Copy("DatosAux.txt", "Datos.txt");

            // Delete auxiliary file
            // Elimina el archivo auxiliar
            if (File.Exists("DatosAux.txt"))
            {
                File.Delete("DatosAux.txt");
            }
        }
    }

    static void Eliminarachivo()
    {

        // Check if the file exists
        // Verifica si el archivo existe
        if (File.Exists("Datos.txt"))
        {
            // Delete the file
            // Elimina el archivo
            File.Delete("Datos.txt");
        }
        else
        {
            Console.WriteLine("El archivo no existe");
        }

    }

    static void Agregar()
    {
        // Variables to store user input
        // Variables para guardar datos del usuario
        string nombre, edad, estatura;

        // Writer object for the file
        // Objeto escritor del archivo
        StreamWriter archivo = null;

        // Loop until a valid name is entered
        // Ciclo hasta que se ingrese un nombre válido
        while (true)
        {
            Console.WriteLine("Escribe un nombre");
            nombre = Console.ReadLine();

            // Validate the name
            // Validar el nombre
            if (val.Validarnombre(nombre))
            {
                break;

            }
            else
            {
                Console.WriteLine("Error al introducir el nombre");
            }
        }

        Console.WriteLine("El nombre correcto es: " + nombre);

        // Loop until a valid age is entered
        // Ciclo hasta que se ingrese una edad válida
        while (true)
        {
            Console.WriteLine("Escribe la edad");
            edad = Console.ReadLine();

            if (val.Validaredad(edad))
            {
                break;

            }
            else
            {
                Console.WriteLine("Error al introducir la edad");
            }
        }

        Console.WriteLine("La edad correcta es: " + edad);

        // Loop until a valid height is entered
        // Ciclo hasta que se ingrese una estatura válida
        while (true)
        {
            Console.WriteLine("Escribe la estatura");
            estatura = Console.ReadLine();

            if (val.Validarestatura(estatura))
            {
                break;

            }
            else
            {
                Console.WriteLine("Error al introducir la estatura");
            }
        }

        Console.WriteLine("La estatura correcta es: " + estatura);

        // Open file to append data
        // Abre el archivo para agregar datos
        archivo = File.AppendText("Datos.txt");

        // Save data separated by "_"
        // Guarda los datos separados por "_"
        archivo.WriteLine(nombre + " _ " + edad + " _ " + estatura);

        // Close the file
        // Cierra el archivo
        archivo.Close();
    }

    static void Mostrar()
    {
        // Reader object
        // Objeto lector
        StreamReader leerarchivo = null;

        // Variable to store lines
        // Variable para guardar líneas
        string datos = null;

        // Check if file exists
        // Verifica si el archivo existe
        if (File.Exists("Datos.txt"))
        {
            leerarchivo = File.OpenText("Datos.txt");

            do
            {
                // Read line
                // Lee línea
                datos = leerarchivo.ReadLine();

                if (datos != null)
                {

                    // Split the line into data fields
                    // Divide la línea en campos de datos
                    string[] d = datos.Split(" _ ");

                    // Display stored data
                    // Muestra los datos almacenados
                    Console.WriteLine("El nombre es: " + d[0]);
                    Console.WriteLine("la edad es: " + d[1]);
                    Console.WriteLine("la estatura es: " + d[2]);
                }

            } while (datos != null);

            // Close file reader
            // Cierra el lector del archivo
            leerarchivo.Close();
        }
    }

    static int Menus()
    {
    // Label used for menu validation loop
    // Etiqueta usada para repetir el menú si hay error
    inicio:

        int opcion = 0;

        // Display menu options
        // Muestra las opciones del menú
        Console.WriteLine("**********************************");
        Console.WriteLine("1.- Agregar elementos al archivo");
        Console.WriteLine("2.- Eliminar archivo");
        Console.WriteLine("3.- Eliminar datos en el archivo");
        Console.WriteLine("4.- Mostrar contenido del archivo");
        Console.WriteLine("5.- Salir");
        Console.WriteLine("**********************************");

        Console.WriteLine("Escribe la opcion del menu");

        // Read user input
        // Lee la opción ingresada
        string op = Console.ReadLine();

        // Validate if the input is a valid number
        // Valida si la entrada es un número válido
        if (val.Validaredad(op))
        {
            opcion = int.Parse(op);
        }
        else
        {
            Console.WriteLine("Error en el menu");
            goto inicio; // Return to menu if validation fails
        }

        return opcion;
    }
}
