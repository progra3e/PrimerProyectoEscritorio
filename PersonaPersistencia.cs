using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PrimerProyectoEscritorio
{
    internal class PersonaPersistencia
    {
        public void GuardarTxt(string fileName, List<Persona> personas)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (Persona persona in personas)
            {
                writer.WriteLine(persona.Nombre);
                writer.WriteLine(persona.Apellido);
                writer.WriteLine(persona.DPI);
                writer.WriteLine(persona.FechaNacimiento);
            }
            writer.Close();
        }
        public List<Persona> LeerTxt(string fileName)
        {
            List<Persona> personas = new List<Persona>();
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                //Crear una persona
                Persona persona = new Persona();
                //Leer sus propiedades desde el archivo con el reader.Readline
                persona.Nombre = reader.ReadLine();
                persona.Apellido = reader.ReadLine();
                persona.DPI = reader.ReadLine();
                persona.FechaNacimiento = Convert.ToDateTime(reader.ReadLine());

                //Guardar la persona en la lista de personas
                personas.Add(persona);
            }
            reader.Close();
            return personas;
        }

        public void GuardarJson(string nombreArchivo, List<Persona> personas)
        {
            string json = JsonConvert.SerializeObject(personas);
            System.IO.File.WriteAllText(nombreArchivo, json);
        }

        public List<Persona> LeerJson(string nombreArchivo)
        {
            List<Persona> personas = new List<Persona>();
            StreamReader jsonStream = File.OpenText(nombreArchivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            personas = JsonConvert.DeserializeObject<List<Persona>>(json);
            return personas;
        }
    }
}
