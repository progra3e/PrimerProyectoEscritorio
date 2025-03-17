using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PrimerProyectoEscritorio
{
    public partial class Form1 : Form
    {
       

        //Constructor
        // Funcion que se llama igual que la clase
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Limpiar()
        {
            textBoxApellido.Text = "";
            textBoxNombre.Text = "";
            textBoxDpi.Text = "";
            textBoxNombre.Focus();
        }

        //Lista para guardar varias personas (global)
        List<Persona> personas = new List<Persona>();
        private void button1_Click(object sender, EventArgs e)
        {
            //Crea una persona
            Persona persona = new Persona();
            persona.Nombre = textBoxNombre.Text;
            persona.Apellido = textBoxApellido.Text;
            persona.DPI = textBoxDpi.Text;
            persona.FechaNacimiento = monthCalendarFechaNacimiento.SelectionStart;

            //Agrega a la persona a la lista de personas
            personas.Add(persona);

            button2.Enabled = true;    
            Limpiar();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelNombre.Text = "";
            labelApellido.Text = "";
            labelDpi.Text = "";
            labelFechaNacimiento.Text = "";

            button2.Enabled = false;

            
            PersonaPersistencia personaPersistencia = new PersonaPersistencia();
            //personas = personaPersistencia.LeerTxt("../../Personas.txt");
            personas = personaPersistencia.LeerJson("../../Personas.json");
            
            Mostrar();
        }

        private void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = personas;
        }
        private void button2_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource = null;
           dataGridView1.DataSource = personas;

           comboBox1.ValueMember = "Apellido";
           comboBox1.SelectedValue = "DPI";
           comboBox1.DataSource = personas;                     
        }

        private void buttonOrdenar_Click(object sender, EventArgs e)
        {
            //Expresiones Lambda (a => a.Apellido)            
            personas = personas
                       .OrderBy(a => a.Apellido)
                       .ToList();
            Mostrar();
        }

       
       
       

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            PersonaPersistencia personaPersistencia = new PersonaPersistencia();
            //persona.Guardar(@"../../Personas.txt", personas);
           personaPersistencia.GuardarJson(@"../../Personas.json", personas);

        }
    }
}
