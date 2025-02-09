namespace segundaAnimacion
{
    public partial class Form1 : Form
    {
        //lista para manipulacion de imagenes
        private List<Image> imagenesP = new List<Image>();//imagenes personaje
        private List<Image> imagenesS = new List<Image>();//imagenes semaforo

        //variables para la animaicion del personaje
        private int indiceImagen = 0;
        int posicionX = 0;
        int desplazamientoX = 10;//el predeterminado es 5

        //varibles para el semaforo peatonal
        //cada 10 ticks es un segundo, el timer esta ajustado cada tick cada 100 milisec.
        int contando_ticks = 0;
        int rojo, amarillo, verde;

        //posicion de la caja de colision
        int colision_x;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.Shown += new EventHandler(Form1_Shown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lista de imagenes de semaforo
            imagenesS.Add(Properties.Resources.Semaforo);//rojo
            imagenesS.Add(Properties.Resources.Semaforo2);//amarillo
            imagenesS.Add(Properties.Resources.Semaforo3);//verde

            //lista de imagenes personaje
            imagenesP.Add(Properties.Resources.panel1);
            imagenesP.Add(Properties.Resources.panel2);
            imagenesP.Add(Properties.Resources.panel3);


        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Movimietno()
        {

            // Mover el PictureBox en el eje X
            posicionX += desplazamientoX;

            // Si el PictureBox llega al borde derecho del formulario, reiniciar posición
            if (posicionX + pictureBox2.Width > this.ClientSize.Width)
            {
                posicionX = 0;
            }

            // Actualizar la posición del PictureBox
            pictureBox2.Location = new Point(posicionX, pictureBox2.Location.Y);

            // Incrementamos el índice para la siguiente imagen
            indiceImagen++;

            // Si hemos llegado al final de la lista, reiniciamos el índice
            if (indiceImagen >= imagenesP.Count)
            {
                indiceImagen = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //estandar para que mayormente se detengana
            //verde 50, amarrillo 20, rojo 40
            verde = 50;
            amarillo = verde + 20;
            rojo = amarillo + 40;

            colision_x = pictureBox3.Location.X;
            pictureBox2.Image = imagenesP[indiceImagen];

            // Actualizar el Label con la posición del eje X
            label2.Text = $"Posición X: {posicionX}";

            label3.Text = colision_x.ToString();

            // CAMBIO DEL SEMAFORO
            contando_ticks++;

            if (contando_ticks < verde)
            {
                Movimietno();
                pictureBox1.Image = imagenesS[2];
            }
            else if (contando_ticks < amarillo)
            {
                Movimietno();
                pictureBox1.Image = imagenesS[1];
            }
            else if (contando_ticks < rojo)
            {
                if (posicionX > (colision_x - 15) && posicionX < (colision_x + 15))
                {
                    label1.Text = "no hay moviemiento";

                }
                else
                {
                    Movimietno();
                }
                pictureBox1.Image = imagenesS[0];
            }
            else { contando_ticks = 0; }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Si necesitas manejar eventos de clic en el semáforo
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Si necesitas manejar eventos de clic en el personaje
        }
    }
}
