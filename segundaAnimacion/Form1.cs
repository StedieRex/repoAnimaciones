namespace segundaAnimacion
{
    public partial class Form1 : Form
    {
        enum EstadoSemaforo
        {
            Rojo,
            Amarillo,
            Verde
        }

        EstadoSemaforo estadoActual = EstadoSemaforo.Rojo;
        int posicionPersonajeX = 0;
        int velocidadPersonaje = 10;
        Point posicionSemaforo = new Point(200, 100); // Ajusta según tus necesidades

        int duracionVerde = 10000;   // 10 segundos
        int duracionAmarillo = 3000; // 3 segundos
        int duracionRojo = 4000;     // 4 segundos
        int contadorTiempo = 0;      // Contador para el tiempo transcurrido

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 100; // Intervalo de 100 ms para el Timer
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Location = posicionSemaforo;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contadorTiempo += timer1.Interval;
            label1.Text = contadorTiempo.ToString();
            if ((estadoActual == EstadoSemaforo.Verde && contadorTiempo >= duracionVerde) ||
                (estadoActual == EstadoSemaforo.Amarillo && contadorTiempo >= duracionAmarillo) ||
                (estadoActual == EstadoSemaforo.Rojo && contadorTiempo >= duracionRojo))
            {
                CambiarEstadoSemaforo();
                contadorTiempo = 0; // Reiniciar el contador al cambiar de estado
            }

            // Mover el personaje
            MoverPersonaje();
        }

        private void CambiarEstadoSemaforo()
        {
            switch (estadoActual)
            {
                case EstadoSemaforo.Rojo:
                    estadoActual = EstadoSemaforo.Amarillo;
                    pictureBox1.Image = Properties.Resources.Semaforo2;
                    break;
                case EstadoSemaforo.Amarillo:
                    estadoActual = EstadoSemaforo.Verde;
                    pictureBox1.Image = Properties.Resources.Semaforo3;
                    break;
                case EstadoSemaforo.Verde:
                    estadoActual = EstadoSemaforo.Rojo;
                    pictureBox1.Image = Properties.Resources.Semaforo;
                    break;
            }
        }

        private void MoverPersonaje()
        {
            // Mover el personaje solo cuando el semáforo está en rojo o amarillo
            if (estadoActual == EstadoSemaforo.Verde)
            {
                return;
            }

            posicionPersonajeX += velocidadPersonaje;

            // Actualizar la posición del PictureBox del personaje
            pictureBox2.Location = new Point(posicionPersonajeX, pictureBox2.Location.Y);
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
