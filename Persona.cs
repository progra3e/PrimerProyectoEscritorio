using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PrimerProyectoEscritorio
{
    internal class Persona
    {
        //Propiedades: Variables
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }

        //Puede guardar uno o varios números de telefono
        public List<string> Telefonos { get; set; }
        public string DPI { get; set; }
        public string NIT {  get; set; }
        public string Direccion { get; set; }


        //Métodos o Eventos: Funciones
        public string Saludo()
        {
            string saludo = "Hola: " + Nombre + ", " + Apellido;
            return saludo;

        }

        public int Edad()
        {
            DateTime hoy = DateTime.Now;


            TimeSpan intervalo = hoy - FechaNacimiento;    
            
            return (intervalo.Days / 365);
        }

        public void SoloLetras()
        {
            string nombre2 = "";

            for (int i = 0; i < Nombre.Length; i++)
            {                
                if (char.IsLetter(Nombre[i]))
                {
                    nombre2 += Nombre[i];
                }
                if (char.IsWhiteSpace(Nombre[i]))
                {
                    nombre2 += Nombre[i];
                }
            }
           
            Nombre = nombre2;
        }

        public void PrimeraMayuscula()
        {
            Nombre = CultureInfo.InvariantCulture.
                      TextInfo.ToTitleCase(Nombre);                
        }

        public void Normalizar()
        {
            Nombre.Trim();
            SoloLetras();
            PrimeraMayuscula();
        }       
    }
}
