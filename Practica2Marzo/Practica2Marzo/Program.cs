
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static Validaciones val = new Validaciones();
    // Create instance of validation class / Crea una instancia de la clase de validaciones

    static void Main(string[] args)
    {
        StreamReader leerarchivo = null;
        // Reader object initialized as null / Objeto lector inicializado en null

        StreamWriter archivo = null;
        // Writer object initialized as null / Objeto escritor inicializado en null

        string respuesta = null;
        // Variable to store user response / Variable para guardar la respuesta del usuario

        int op = 0;
        // Integer variable (not used) / Variable entera (no utilizada)

        archivo = File.AppendText("Datos.txt");
        // Open file in append mode / Abre el archivo en modo agregar

        do
        {
        inicio:
            // Label for goto / Etiqueta para usar con goto

            string nombre;
            // Variable for name / Variable para el nombre

            string edad;
            // Variable for age / Variable para la edad

            string salario;
            // Variable for salary / Variable para el salario

            string correo;
            // Variable for email / Variable para el correo

            string numero;
            // Variable for phone number / Variable para el número telefónico

            string contraseña;
            // Variable for password / Variable para la contraseña

            string aux;
            // Auxiliary variable / Variable auxiliar

            Console.WriteLine("Ingresa un nombre");
            // Ask for name / Solicita el nombre

            nombre = Console.ReadLine();
            // Read name from console / Lee el nombre desde consola

            if (!val.ValidarNombre(nombre))
            // Validate name / Valida el nombre
            {
                Console.WriteLine("Nombre incorrecto");
                // Show error if invalid / Muestra error si es inválido
            }
            else
            {
                Console.WriteLine("ingresa la edad");
                // Ask for age / Solicita la edad

                edad = Console.ReadLine();
                // Read age / Lee la edad

                if (!val.ValidarEdad(edad))
                // Validate age / Valida la edad
                {
                    Console.WriteLine("Edad incorrecta");
                    // Show error if invalid / Muestra error si es inválida
                }
                else
                {
                    Console.WriteLine("Ingresa el salario");
                    // Ask for salary / Solicita el salario

                    salario = Console.ReadLine();
                    // Read salary / Lee el salario

                    if (!val.ValidarSalario(salario))
                    // Validate salary / Valida el salario
                    {
                        Console.WriteLine("Salario incorrecta");
                        // Show error if invalid / Muestra error si es inválido
                    }
                    else
                    {
                        Console.WriteLine("Ingresa el correo electronico");
                        // Ask for email / Solicita el correo

                        correo = Console.ReadLine();
                        // Read email / Lee el correo

                        if (!val.ValidarCorreo(correo))
                        // Validate email / Valida el correo
                        {
                            Console.WriteLine("correo incorrecto");
                            // Show error if invalid / Muestra error si es inválido
                        }
                        else
                        {
                            Console.WriteLine("Ingresa el numero de telefono");
                            // Ask for phone number / Solicita el número telefónico

                            numero = Console.ReadLine();
                            // Read phone number / Lee el número

                            if (!val.ValidarNumero(numero))
                            // Validate phone number / Valida el número
                            {
                                Console.WriteLine("Numero incorrecto");
                                // Show error if invalid / Muestra error si es inválido
                            }
                            else
                            {
                                Console.WriteLine("Ingresa la contraseña");
                                // Ask for password / Solicita la contraseña

                                contraseña = Console.ReadLine();
                                // Read password / Lee la contraseña

                                if (!val.ValidarContraseña(contraseña))
                                // Validate password / Valida la contraseña
                                {
                                    Console.WriteLine("contraseña incorrecta");
                                    // Show error if invalid / Muestra error si es inválida
                                }
                                else
                                {
                                    Console.WriteLine("El nombre es: " + nombre.ToUpper());
                                    // Print name in uppercase / Imprime el nombre en mayúsculas

                                    Console.WriteLine("La edad es: " + edad);
                                    // Print age / Imprime la edad

                                    Console.WriteLine("El correo es: " + correo.ToLower());
                                    // Print email in lowercase / Imprime el correo en minúsculas

                                    Console.WriteLine("El salario es: " + salario);
                                    // Print salary / Imprime el salario

                                    aux = "(" + numero.Substring(0, 2) + ") " + numero.Substring(2, 4) + "-" + numero.Substring(6, 4);
                                    // Format phone number / Da formato al número telefónico

                                    Console.WriteLine("El numero es: " + aux);
                                    // Print formatted phone number / Imprime el número formateado

                                    Console.WriteLine("La longitud de la contraseña es: " + contraseña.Length);
                                    // Print password length / Imprime la longitud de la contraseña

                                    archivo.WriteLine(nombre + "_" + edad + "_" + salario + "_" + correo + "_" + numero + "_" + contraseña);
                                    // Write data to file separated by "_" / Escribe los datos en el archivo separados por "_"

                                    archivo.Close();
                                    // Close file / Cierra el archivo

                                    Console.WriteLine("¿Desea ingresar otra persona Y/N?");
                                    // Ask if user wants to continue / Pregunta si desea continuar

                                    respuesta = Console.ReadLine();
                                    // Read response / Lee la respuesta

                                    if ((respuesta == "Y") || (respuesta == "y"))
                                    // Check if user wants to continue / Verifica si el usuario quiere continuar
                                    {
                                        goto inicio;
                                        // Jump to label inicio / Salta a la etiqueta inicio
                                    }
                                    else
                                    {
                                        break;
                                        // Exit loop / Sale del ciclo
                                    }
                                }
                            }
                        }
                    }
                }
            }

        } while (true);
        // Infinite loop / Ciclo infinito
    }