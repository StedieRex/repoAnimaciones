//NOTA: la ruta de las imagenes puede cambiar
namespace primeraAnimacion
{
    public partial class Form1 : Form
    {
        // Declaramos una lista para almacenar las im�genes y una variable para el �ndice
        private List<Image> imagenes = new List<Image>();
        private int indiceImagen = 0;
        int posicionX = 0; // Posici�n inicial en el eje X
        int desplazamientoX = 5; // Cantidad de p�xeles a mover en cada tick

        public Form1()
        {
            InitializeComponent();

            // Asociamos los eventos Load y Shown del formulario a sus respectivos m�todos
            this.Load += new EventHandler(Form1_Load);
            this.Shown += new EventHandler(Form1_Shown);
        }

        // Evento que se ejecuta al cargar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            imagenes.Add(Image.FromFile(@"C:\Users\Luis Pach\Desktop\repoAnimaciones\primeraAnimacion\dino2.png"));
            imagenes.Add(Image.FromFile(@"C:\Users\Luis Pach\Desktop\repoAnimaciones\primeraAnimacion\dino3.png"));
            // A�ade m�s im�genes seg�n necesites
        }


        // Evento que se ejecuta cuando el formulario se muestra por primera vez
        private void Form1_Shown(object sender, EventArgs e)
        {
            // Iniciamos el Timer
            timer1.Start();
        }

        // Evento que se ejecuta en cada tick del Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = imagenes[indiceImagen];

            // Mover el PictureBox en el eje X
            posicionX += desplazamientoX;

            // Si el PictureBox llega al borde derecho del formulario, reiniciar posici�n
            if (posicionX + pictureBox1.Width > this.ClientSize.Width)
            {
                posicionX = 0;
            }

            // Actualizar la posici�n del PictureBox
            pictureBox1.Location = new Point(posicionX, pictureBox1.Location.Y);

            // Actualizar el Label con la posici�n del eje X
            label1.Text = $"Posici�n X: {posicionX}";

            // Incrementamos el �ndice para la siguiente imagen
            indiceImagen++;

            // Si hemos llegado al final de la lista, reiniciamos el �ndice
            if (indiceImagen >= imagenes.Count)
            {
                indiceImagen = 0;
            }
        }
    }
}

