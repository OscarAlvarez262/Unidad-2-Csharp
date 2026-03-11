using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Validaciones
{
    public bool ValidarNombre(string N)
    {
        int c = 0;
        // Counter for valid characters / Contador de caracteres válidos

        byte[] ascii = Encoding.ASCII.GetBytes(N);
        // Convert string to ASCII bytes / Convierte la cadena a bytes ASCII

        foreach (byte b in ascii)
        // Iterate each character byte / Recorre cada byte del texto
        {
            if ((b >= 97 && b <= 122) || (b >= 65 && b <= 90) || b == 32)
            // Check if lowercase, uppercase or space / Verifica si es minúscula, mayúscula o espacio
            {
                c++;
                // Increase counter if valid / Aumenta el contador si es válido
            }
        }

        if (c == N.Length)
        // If all characters are valid / Si todos los caracteres son válidos
        {
            return true;
            // Name is valid / Nombre válido
        }
        else
        {
            return false;
            // Name is invalid / Nombre inválido
        }
    }

    public bool ValidarEdad(string E)
    {
        int e = 0;
        // Variable to store converted age / Variable para guardar la edad convertida

        try
        {
            e = Convert.ToInt32(E);
            // Convert string to integer / Convierte la cadena a entero

            if ((e >= 18 && e <= 99))
            // Check if age is between 18 and 99 / Verifica si la edad está entre 18 y 99
            {
                return true;
                // Valid age / Edad válida
            }
            else
            {
                return false;
                // Age out of range / Edad fuera de rango
            }
        }
        catch
        {
            return false;
            // Return false if conversion fails / Retorna falso si falla la conversión
        }
    }

    public bool ValidarSalario(string S)
    {
        double s;
        // Variable to store salary / Variable para guardar el salario

        try
        {
            s = Convert.ToDouble(S);
            // Convert string to double / Convierte la cadena a decimal

            if (s < 0)
            // Check if salary is negative / Verifica si el salario es negativo
            {
                return false;
                // Invalid salary / Salario inválido
            }
            else
            {
                return true;
                // Valid salary / Salario válido
            }
        }
        catch
        {
            return false;
            // Return false if conversion fails / Retorna falso si falla la conversión
        }
    }

    public bool ValidarCorreo(string C)
    {
        bool bA = false;
        // Flag for '@' symbol / Bandera para símbolo '@'

        bool bB = false;
        // Flag for '.' symbol / Bandera para símbolo '.'

        byte[] ascii = Encoding.ASCII.GetBytes(C);
        // Convert string to ASCII bytes / Convierte la cadena a bytes ASCII

        foreach (byte b in ascii)
        // Iterate through each character / Recorre cada carácter
        {
            if (b == 64)
            // ASCII 64 = '@' / 64 es '@'
            {
                bA = true;
                // Mark that '@' exists / Marca que existe '@'
            }

            if (b == 46)
            // ASCII 46 = '.' / 46 es '.'
            {
                string[] partes = C.Split('.');
                // Split email by '.' / Divide el correo por '.'

                if (partes.Length >= 1)
                // Check if split generated parts / Verifica que haya partes
                {
                    bB = true;
                    // Mark that '.' exists / Marca que existe '.'
                }
            }
        }

        if (bA == true && bB == true)
        // Email must contain both '@' and '.' / Debe contener '@' y '.'
        {
            return true;
            // Valid email / Correo válido
        }
        else
        {
            return false;
            // Invalid email / Correo inválido
        }
    }

    public bool ValidarNumero(string Nu)
    {
        string N = Nu;
        // Copy input string / Copia la cadena recibida

        double aux = 0;
        // Auxiliary numeric variable / Variable auxiliar numérica

        try
        {
            aux = double.Parse(N);
            // Try converting to number / Intenta convertir a número

            if ((N.Length == 10))
            // Check if length is 10 digits / Verifica que tenga 10 dígitos
            {
                return true;
                // Valid phone number / Número válido
            }
            else
            {
                return false;
                // Invalid length / Longitud inválida
            }
        }
        catch
        {
            return false;
            // Return false if conversion fails / Retorna falso si falla la conversión
        }
    }

    public bool ValidarContraseña(string Co)
    {
        bool bA = false;
        // Flag for uppercase letter / Bandera para mayúscula

        bool bB = false;
        // Flag (repeated condition) / Bandera (condición repetida)

        bool bC = false;
        // Flag for number / Bandera para número

        byte[] ascii = Encoding.ASCII.GetBytes(Co);
        // Convert password to ASCII bytes / Convierte la contraseña a bytes ASCII

        foreach (byte b in ascii)
        // Iterate each character / Recorre cada carácter
        {
            if ((b >= 65) && (b <= 90))
            // Check if uppercase letter / Verifica si es mayúscula
            {
                bA = true;
                // Mark uppercase found / Marca mayúscula encontrada
            }

            if ((b >= 65) && (b <= 90))
            // Same condition repeated / Misma condición repetida
            {
                bB = true;
                // Mark flag / Marca bandera
            }

            if ((b >= 48) && (b <= 57))
            // Check if numeric digit / Verifica si es número
            {
                bC = true;
                // Mark number found / Marca número encontrado
            }
        }

        if (Co.Length >= 8 && bA && bB && bC)
        // Password must be at least 8 characters and meet conditions
        // La contraseña debe tener al menos 8 caracteres y cumplir condiciones
        {
            return true;
            // Valid password / Contraseña válida
        }
        else
        {
            return false;
            // Invalid password / Contraseña inválida
        }
    }