using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Validaciones
{
    public bool Validarnombre(string n) {
        int c = 0;
        byte[] ascii =Encoding.ASCII.GetBytes(n);
        foreach (byte b in ascii)
        {
            if ((b >=97 && b <=122 )||(b >=65&&b <=90)|| b ==32)
            {
                c ++;
            }
        }
        if (c == n.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Validaredad(string e) {
        bool r = (Regex.IsMatch(e, @"^[0-9]+$"));
        return r;
    }
    public bool Validarestatura(string e) { 
        bool r = false;
        try {
            float estatura = float.Parse(e);
            r = true;
        } catch
        {
            r = false;
        }
        return r;
    }

}

