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
        int desplazamientoX = 5;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = imagenesP[indiceImagen];

            // Mover el PictureBox en el eje X
            posicionX += desplazamientoX;

            // Si el PictureBox llega al borde derecho del formulario, reiniciar posición
            if (posicionX + pictureBox2.Width > this.ClientSize.Width)
            {
                posicionX = 0;
            }

            // Actualizar la posición del PictureBox
            pictureBox2.Location = new Point(posicionX, pictureBox2.Location.Y);

            // Actualizar el Label con la posición del eje X
            label1.Text = $"Posición X: {posicionX}";

            // Incrementamos el índice para la siguiente imagen
            indiceImagen++;

            // Si hemos llegado al final de la lista, reiniciamos el índice
            if (indiceImagen >= imagenesP.Count)
            {
                indiceImagen = 0;
            }



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
