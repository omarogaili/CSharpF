using Newtonsoft.Json;
using System.Windows.Forms;

namespace Shapes_Omarogaili
{
    public partial class ShapesDrawForm : Form
    {
        public ShapesDrawForm()
        {
            InitializeComponent();
        }
        private bool drawSquare = false;
        private bool drawCircle = false;
        private bool drawTriangle = false;
        private Color selectTheColor = Color.Black;
        private Stack<Shape> draw = new Stack<Shape>();
        private Stack<Shape> redo = new Stack<Shape>();


        private void btn_Square_Click(object sender, EventArgs e)
        {
            drawSquare = true;
            ShowColorDialog();
        }
        private void btn_Circle_Click(object sender, EventArgs e)
        {
            drawCircle = true;
            ShowColorDialog();
        }
        private void btn_Triangle_Click(object sender, EventArgs e)
        {
            drawTriangle = true;
            ShowColorDialog();
        }
        /* jag t�nker anv�nda mig av Color Dialog som finns f�rst s� har jag skapat ett variabel som tar emot svart f�rg
         * o sedan s� anv�nder jag den variabeln f�r att �ndra f�rgen enligt ColorDialog, som du se i rad 50 i metoden nedan.
         * jag tyckte att det s�ttet va mer clean och b�ttre eftersom jag hade fixat en lista f�rst och sedan en metod f�r att retunera
         * det v�rdet som anv�ndaren valde (allts� f�rgen).s� d�rf�r vald jag det s�ttet.
         */
        private void ShowColorDialog()
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectTheColor = colorDialog.Color;
            }
        }
        /*definierar jag alla shape som vi har. allts� dessa shape f�r deras egeskaper i den metoden
         * och sedan so pushar vi de till draw listan som vi har skapat 
         */
        private void picBox_Click(object sender, EventArgs e)
        {
            if (drawSquare)
            {
                var mouse = (MouseEventArgs)e;
                Square square = new Square(
                    selectTheColor,
                    mouse.Location,
                    10
                    );
                draw.Push(square);
                redo.Clear();
                drawSquare = false;

            }
            else if (drawCircle)
            {
                var mouse = (MouseEventArgs)e;
                var circle = new Circle(
                    selectTheColor,
                    mouse.Location,
                    20
                    );
                draw.Push(circle);
                redo.Clear();
                drawCircle = false;
            }
            else if (drawTriangle)
            {
                var mouse = (MouseEventArgs)e;
                var triangle = new Triangle(
                    selectTheColor,
                    mouse.Location,
                    40,
                    50,
                    30
                    );
                draw.Push(triangle);
                redo.Clear();
                drawTriangle = false;
            }
            picBox.Refresh();
        }

        /*
         * i den metoden s� anropar vi Draw metoden 
         */
        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in draw)
            {
                shape.Draw(e.Graphics);
            }

        }
        /*
         * jag g�r en Clear() f�r att t�nma draw och sedan g�r jag en picBox refresh 
         * s� jag t�mmer Stacken, eftersom jag t�nker att jag vill ha den �terst�llt till sitt
         * ursprungliga tillst�nd. 
         */
        private void btn_Refresh_Click(object sender, EventArgs e)
        {

            draw.Clear();
            picBox.Refresh();
        }

        private void btn_Undo_Click(object sender, EventArgs e)
        {
            if (draw.Count > 0)
            {
                Shape undoneShape = draw.Pop();
                redo.Push(undoneShape);
            }
            picBox.Refresh();

        }
        /*jag t�nker fixa tv� metoder f�r att hantera spara filen en metod f�r att spara filen som en 
         * s� SaveAsFile �r metoden som haterar sparning av data i en fil d�r anv�nder jag mig av en object
         * lista och Cast f�r att spara alla shape som vi har till den listan och sedan s� g�r jag en 
         * convert f�r att och sedan spara jag de . 
         * jag anropar dessa metoder beroende p� vad anv�nder v�ljer att spara filen som . i btn_Save_Click metoden
         */
        private void SaveAsFile()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            var jsonSerializerOptions = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };
            saveFile.Filter = "Textfiler (*.txt)|*.txt";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFile.FileName = "ShapesData.txt";
            saveFile.DefaultExt = "txt";
            saveFile.InitialDirectory = path;
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFile.FileName;
                List<object> allObjects = new List<object>();
                allObjects.AddRange(draw.Cast<object>());
                string json = JsonConvert.SerializeObject(allObjects, Formatting.Indented, jsonSerializerOptions);
                File.WriteAllText(filename, json);

                MessageBox.Show("Data har sparats till filen.", "Sparad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveAsImage()
        {
            Bitmap bitmap = new Bitmap(picBox.Width, picBox.Height);// jag sparar picBoxen genom att anv�nda height och width av den 
            picBox.DrawToBitmap(bitmap, picBox.ClientRectangle);
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Bild";//namnet p� filen by defult
            savefile.DefaultExt = "Jpg";//formatet som filen ska ha 
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);// path som den ska sparas i
            savefile.InitialDirectory = path;
            if (savefile.ShowDialog() == DialogResult.OK) //och d�r om anv�ndaren trycker yes eller OK s� spara jag den som bild. 
            {
                string filename = savefile.FileName;
                bitmap.Save(savefile.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("filen har sparats.", "Sparad", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        /* i den metoden s� hanterar jag sparning av filerna h�r har vi olika  val som anv�ndaren ska kunna 
         * v�lja mellan du kan spara filen b�de som en bild eller som text om du bukar i b�de tv� checkboxes
         *  eller som en bild om du v�ljer bild eller som en fil d�. men v�ljer man inget s� f�r man ett
         *  felmeddelande om att du m�ste v�ljer n�got innan f�r att spara filen. 
         */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (saveAs_file.Checked && saveAs_photo.Checked)
            {
                SaveAsImage();
                SaveAsFile();
                MessageBox.Show("filen har sparats.", "Sparad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (saveAs_photo.Checked)
            {
                SaveAsImage();
            }
            else if (saveAs_file.Checked)
            {
                SaveAsFile();
            }

            else
            {
                MessageBox.Show("Du m�ste v�lja hur vill du spara filen som?", "Osparad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            var jsonSerializerOptions = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;

                try
                {
                    string json = File.ReadAllText(filename);
                    List<object> allObjects = JsonConvert.DeserializeObject<List<object>>(json, jsonSerializerOptions);

                    // Clear existing drawings
                    draw.Clear();
                    foreach (var obj in allObjects)
                    {
                        if (obj is Square square)
                        {
                            draw.Push(square);
                        }
                        else if (obj is Circle circle)
                        {
                            draw.Push(circle);
                        }
                        else if (obj is Triangle triangle)
                        {
                            draw.Push(triangle);
                        }
                    }

                    picBox.Refresh();

                    MessageBox.Show("Filen har laddats.", "Laddad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ett fel intr�ffade n�r filen l�stes in: {ex.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    }

