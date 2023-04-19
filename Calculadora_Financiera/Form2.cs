using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_Financiera
{
    public partial class Form2 : Form
    {
        //Inialización de variables globales
        int cantidadMeses = 0;
        double tasaInteres = 0;
        int opcionPrestamo = 0;
        int opcion_cantidadMeses = 0;
        double monto = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void button_Atrás_Click(object sender, EventArgs e)
        {
            this.Hide(); //Esconder esta ventana "Datos"
            Form1 Bienvenida = new Form1(); //Se crea una nueva ventana Bienvenida
            Bienvenida.Show(); //Se muestra
        }

        //Botón de SALIR, antes de programar no le cambié el nombre
        private void button1_Click(object sender, EventArgs e)
        {
            //Acá creamos un mensaje flotante para confirmar que queremos salir del app
            if (MessageBox.Show("¿Está seguro que desea salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void comboBox_TipoPréstamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (comboBox_TipoPréstamo.SelectedIndex != -1)
            {
                String opcionPrestamo = comboBox_TipoPréstamo.Text;
                {   // Establece la tasa de interés según la opción de préstamo seleccionada
                    switch (opcionPrestamo)
                    {
                        case "Personal Regular con Tasa de interés: 15%":
                            tasaInteres = (float)0.15;
                            break;
                        case "Personal Rápido con Tasa de interés: 18%":
                            tasaInteres = (float)0.18;
                            break;
                        case "Reparación y ampliación de vivienda con Tasa de interés: 12%":
                            tasaInteres = (float)0.12;
                            break;
                        case "Compra de Lote con Tasa de interés: 12%":
                            tasaInteres = (float)0.12;
                            break;
                        case "Compra de Vehículo Nuevo con Tasa de interés: 18%":
                            tasaInteres = (float)0.18;
                            break;
                    }
                }
            }
        }

        private void label_MontoT_Click(object sender, EventArgs e)
        {

        }

        private void label_CuotaMensual_Click(object sender, EventArgs e)
        {

        }
        private void textBox_MontoSolicitar_TextChanged(object sender, EventArgs e)
        {
            // Verifica si el monto del préstamo ingresado es válido y lo almacena en la variable
            if (double.TryParse(textBox_MontoSolicitar.Text, NumberStyles.Currency, CultureInfo.InvariantCulture, out monto))
            {
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido para el monto del préstamo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_PlazoMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si la cantidad de meses  ingresada es válida y la almacena en la variable
            if (int.TryParse(comboBox_PlazoMeses.Text, out cantidadMeses))
            {
                // usa el valor recibido en la conversión de String a int

                // Establece la tasa de interés según la opción de préstamo seleccionada
                String opcion_cantidadMeses = comboBox_PlazoMeses.Text;
                {
                    switch (opcion_cantidadMeses)
                    {
                        case "24 meses (2 años)":
                            cantidadMeses = (int)24;
                            break;
                        case "60 meses (5 años)":
                            cantidadMeses = (int)60;
                            break;
                        case "84 meses (7 años)":
                            cantidadMeses = (int)84;
                            break;
                        default:
                            MessageBox.Show("Opción de plazo de meses no es válida.", "Error");
                            return;
                    }
                }
            }
            else
            {
                // entrada no válida
            }
        }

        private void button_Calcular_Click(object sender, EventArgs e)
        {
            double monto, interesMensual, cuotaMensual, montoTotal;

            interesMensual = monto * tasaInteres / (100 * 12);
            cuotaMensual = (monto + interesMensual) / cantidadMeses;
            montoTotal = cuotaMensual * cantidadMeses;

            label_CuotaMensual.Text = cuotaMensual.ToString();
            label_MontoT.Text = montoTotal.ToString();
        }
    }
}
