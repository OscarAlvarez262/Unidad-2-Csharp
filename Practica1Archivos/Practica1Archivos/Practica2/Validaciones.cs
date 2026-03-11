using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Validaciones{

    public bool ValidarNombre(String n)
    {
        int c = 0; // Counter for valid characters / Contador de caracteres válidos

        byte[] ascii = Encoding.ASCII.GetBytes(n);
        // Convert string to ASCII byte array / Convierte la cadena a arreglo de bytes ASCII

        foreach (byte b in ascii)
        // Iterate through each character byte / Recorrer cada byte del texto
        {
            if ((b >= 97 && b <= 122) || (b >= 65 && b <= 90) || b == 32)
            {
                // Check if character is lowercase letter, uppercase letter, or space
                // Verifica si el carácter es letra minúscula, mayúscula o espacio
                c++; // Increase counter if valid / Aumenta el contador si es válido
            }
        }

        if (c == n.Length)
        // If all characters were valid / Si todos los caracteres fueron válidos
        {
            return true; // Name is valid / Nombre válido
        }
        else
        {
            return false; // Name is invalid / Nombre inválido
        }
    }

    public bool ValidarEdad(String e)
    {
        bool r = (Regex.IsMatch(e, @"^[0-9]+$"));
        // Validate that the string contains only digits / Valida que la cadena contenga solo números

        return r;  // Return validation result / Retornar resultado de la validación
    }

    public bool ValidarEstatura(String e)
    {
        bool r = false; // Initialize result as false / Inicializa resultado en falso

        try
        {
            float estatura = float.Parse(e);
            // Try converting input to float / Intentar convertir la entrada a número decimal (float)

            r = true; // If conversion succeeds, set true / Si la conversión funciona, asigna verdadero
        }
        catch
        {
            r = false; // If conversion fails, keep false / Si falla la conversión, permanece falso
        }

        return r;  // Return validation result / Retornar resultado de la validación
    }
