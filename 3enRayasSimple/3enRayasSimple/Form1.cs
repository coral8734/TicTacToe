using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3enRayaForm
{
    public partial class Form1 : Form
    {
        string playerX = "";
        string playerO = "";
        bool cambiar = true;
        int empate = 0;
        int ganadasX = 0;
        int ganadasO = 0;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Método para que cuando cargue el formulario el botón se desactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            OnOffBtn(false);
        }
       /// <summary>
       /// El siguiente método es para activar la casilla y poder introducir detro O o X
       /// </summary>
       /// <param name="OnOff"></param>
        private void OnOffBtn(bool OnOff)
        {
            a1.Enabled = OnOff;
            a2.Enabled = OnOff;
            a3.Enabled = OnOff;

            b1.Enabled = OnOff;
            b2.Enabled = OnOff;
            b3.Enabled = OnOff;

            c1.Enabled = OnOff;
            c2.Enabled = OnOff;
            c3.Enabled = OnOff;
        }

        private void INICIO_Click(object sender, EventArgs e)
        {
            iniciar();
        }
        /// <summary>
        /// Método para que cuando le demos a iniciar compruebe los datos introducidos y si se seleccionó la X o la O
        /// </summary>
        private void iniciar()
        {   //Este if dice que si se queda vacia la cajita del nombre de jugador 1 y tamabién la de jugador 2 salta un error
            if (NombreUser1.Text == "" && NombreUser2.Text == "")
            {
                MessageBox.Show("***ERROR*** Nombre no válido, el nombre no puede estar vacio");
            }
            //Aqui es por si un jugador o el otro está vacio  salte un error u otro
            else
            {
                if (NombreUser1.Text == "")
                {
                    MessageBox.Show("***ERROR*** El nombre del jugador 1 no debe estar vacio");
                }
                if (NombreUser2.Text == "")
                {
                    MessageBox.Show("***ERROR*** El nombre del jugador 2 no debe estar vacio");
                }
            }
            //Una vez han ingresado los datos los usuarios pasamos a validar las opciones X o O
            if (NombreUser1.Text != "" && NombreUser2.Text != "")
            {
                //Si el jugador 1 escoge la x y el jugador 2 escoge la o Se desabilite la otra opción 
                if (radioButton1.Checked && radioButton3.Checked)
                {
                    playerX = NombreUser1.Text;
                    playerO = NombreUser2.Text;
                    radioButton2.Enabled = false;
                    radioButton4.Enabled = false;
                    IniciarJuego();
                }
                //En este if hace lo mismo pero al contrario
                if (radioButton2.Checked && radioButton4.Checked)
                {
                    playerX = NombreUser2.Text;
                    playerO = NombreUser1.Text;
                    radioButton3.Enabled = false;
                    radioButton1.Enabled = false;
                    IniciarJuego();//llamada al método iniciar juego
                }
                //Si los dos usuarios eligen la x salta un error
                if (radioButton1.Checked && radioButton4.Checked)
                {
                    MessageBox.Show("***ERROR*** Solo un jugador puede seleccionar la opción x, Vuelva a elegir una de las dos opciones");
                }
                //Si los dos usuarios eligen la o salta un error
                if (radioButton2.Checked && radioButton3.Checked)
                {
                    MessageBox.Show("***ERROR*** Solo un jugador puede seleccionar la opción o,  Vuelva a elegir una de las dos opciones");
                }
                //Si ningun jugador elige letra se genera un error
                if (radioButton1.Checked == false && radioButton2.Checked == false|| radioButton4.Checked == false && radioButton3.Checked == false)
                {
                    MessageBox.Show("***ERROR*** Cada jugador debe seleccionar una Letra, Vuelva a elegir una de las dos opciones");
                }
            }
        }
        //Este método es para que cuando los jugadores hayan introducido todos los datos se inicie el juego
        private void IniciarJuego()
        {
            //para vincular el label con su respectivo textbox
            labelUser1.Text = NombreUser1.Text;
            labelUser2.Text = NombreUser2.Text;

            Clear.Visible = true;
            Reiniciar.Visible = true;

            Inicio.Visible = false;
            NombreUser1.Visible = false;
            NombreUser2.Visible = false;                                                                                                                                             

            MessageBox.Show("Empieza " + playerX, "Información ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OnOffBtn(true);//Para activar los  botones antes
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;//Creamos el objeto botón que representa a todos los  botones
           //Este if es para que cada vez que pongamos la x o la o cambie
            if (cambiar)
            {
                boton.Text = "x";
            }
            else
            {
                boton.Text = "o";
            }
            cambiar = !cambiar;
            boton.Enabled = false;
            Partida();
        }

        private void Partida()
        {
            //vertical
            if ((a1.Text == a2.Text) & (a2.Text == a3.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((b1.Text == b2.Text) & (b2.Text == b3.Text) && (!b1.Enabled))
            {
                Validacion(b1);
            }
            else if ((c1.Text == c2.Text) & (c2.Text == c3.Text) && (!c1.Enabled))
            {
                Validacion(c1);
            }


            //horizontal
            if ((a1.Text == b1.Text) & (b1.Text == c1.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((a2.Text == b2.Text) & (b2.Text == c2.Text) && (!a2.Enabled))
            {
                Validacion(a2);
            }
            else if ((a3.Text == b3.Text) & (b3.Text == c3.Text) && (!a3.Enabled))
            {
                Validacion(a3);
            }


            //diagonal
            if ((a1.Text == b2.Text) & (b2.Text == c3.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((a3.Text == b2.Text) & (b2.Text == c1.Text) && (!a3.Enabled))
            {
                Validacion(a3);
            }

            empate++;

            if (empate == 9)
            {
                MessageBox.Show("Hubo un empate" + playerX, "Empate ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                OnOffBtn(true);
                empate = 0;
            }


        }
        //Este método es para que saga un mensaje diciendo que jugador ha ganado
        public void Validacion(Button boton) 
        {
            empate = -1; //Para que el valor vuelva a 0

            if (boton.Text == "x")
            {
                MessageBox.Show("Gana" + playerX, "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasX ++;
            }
            else if (boton.Text == "o")
            {
                MessageBox.Show("Gana" + playerO, "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasO ++;

            }
            //Con este if se guarda la información de las paratidas que gana un jugador o el otro
            if (radioButton1.Checked && radioButton3.Checked)
            {
                PartidasGanadasJugador1.Text = ganadasX.ToString();
                PartidasGanadasJugador2.Text = ganadasO.ToString();
            }
            if (radioButton2.Checked && radioButton4.Checked)
            {
                PartidasGanadasJugador2.Text = ganadasX.ToString();
                PartidasGanadasJugador1.Text = ganadasO.ToString();
            }

            Limpiar();
            OnOffBtn(true);

        }
        private void Limpiar()
        {
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";

            b1.Text = "";
            b2.Text = "";
            b3.Text = "";

            c1.Text = "";
            c2.Text = "";
            c3.Text = "";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Limpiar();
            OnOffBtn(true);
            empate = 0;
        }

        /// <summary>
        /// En éste método pondremos todos los datos como al principio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Reiniciar_Click(object sender, EventArgs e)
        {
            Limpiar();
            OnOffBtn(false);//Para que los botones se desactiven porque al darle a reiniciar los usuarios deben volver a introducir los datos
            Clear.Visible = false;
            Reiniciar.Visible = false;

            Inicio.Visible = true;
            NombreUser1.Visible = true;
            NombreUser2.Visible = true;

            playerX = "";
            playerO = "";
            ganadasO = 0;
            ganadasX = 0;

            cambiar = true;
            PartidasGanadasJugador1.Text = 0.ToString();
            PartidasGanadasJugador2.Text = 0.ToString();

            labelUser1.Text = "Jugador 1";
            labelUser2.Text = "Jugador 2";

            radioButton2.Enabled = true;
            radioButton4.Enabled = true;
            radioButton3.Enabled = true;
            radioButton1.Enabled = true;

            radioButton3.Checked = false;
            radioButton2.Checked = false;
            radioButton4.Checked = false;
            radioButton1.Checked = false;
        }
    }
}
