//NOTA: la ruta de las imagenes puede cambiar
namespace primeraAnimacion
{
    public partial class Form1 : Form
    {
        // Declaramos una lista para almacenar las imágenes y una variable para el índice
        private List<Image> imagenes = new List<Image>();
        private int indiceImagen = 0;

        public Form1()
        {
            InitializeComponent();

            // Asociamos los eventos Load y Shown del formulario a sus respectivos métodos
            this.Load += new EventHandler(Form1_Load);
            this.Shown += new EventHandler(Form1_Shown);
        }

        // Evento que se ejecuta al cargar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            imagenes.Add(Image.FromFile(@"C:\Users\Luis Pach\Desktop\repoAnimaciones\primeraAnimacion\dino2.png"));
            imagenes.Add(Image.FromFile(@"C:\Users\Luis Pach\Desktop\repoAnimaciones\primeraAnimacion\dino3.png"));
            // Añade más imágenes según necesites
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
            // Actualizamos la imagen del PictureBox
            pictureBox1.Image = imagenes[indiceImagen];

            // Incrementamos el índice para la siguiente imagen
            indiceImagen++;

            // Si hemos llegado al final de la lista, reiniciamos el índice
            if (indiceImagen >= imagenes.Count)
            {
                indiceImagen = 0;
            }
        }
    }
}

