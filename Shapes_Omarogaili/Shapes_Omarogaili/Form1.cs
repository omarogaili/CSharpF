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
        /* jag tänker använda mig av Color Dialog som finns först så har jag skapat ett variabel som tar emot svart färg
         * o sedan så använder jag den variabeln för att ändra färgen enligt ColorDialog, som du se i rad 50 i metoden nedan.
         * jag tyckte att det sättet va mer clean och bättre eftersom jag hade fixat en lista först och sedan en metod för att retunera
         * det värdet som användaren valde (alltså färgen).så därför vald jag det sättet.
         */
        private void ShowColorDialog()
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectTheColor = colorDialog.Color;
            }
        }
        /*definierar jag alla shape som vi har. alltså dessa shape får deras egeskaper i den metoden
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
         * i den metoden så anropar vi Draw metoden 
         */
        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in draw)
            {
                shape.Draw(e.Graphics);
            }

        }
        /*
         * jag gör en Clear() för att tönma draw och sedan gör jag en picBox refresh 
         * så jag tömmer Stacken, eftersom jag tänker att jag vill ha den återställt till sitt
         * ursprungliga tillstånd. 
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
        /*jag tänker fixa två metoder för att hantera spara filen en metod för att spara filen som en 
         * så SaveAsFile är metoden som haterar sparning av data i en fil där använder jag mig av en object
         * lista och Cast för att spara alla shape som vi har till den listan och sedan så gör jag en 
         * convert för att och sedan spara jag de . 
         * jag anropar dessa metoder beroende på vad använder väljer att spara filen som . i btn_Save_Click metoden
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
            Bitmap bitmap = new Bitmap(picBox.Width, picBox.Height);// jag sparar picBoxen genom att använda height och width av den 
            picBox.DrawToBitmap(bitmap, picBox.ClientRectangle);
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Bild";//namnet på filen by defult
            savefile.DefaultExt = "Jpg";//formatet som filen ska ha 
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);// path som den ska sparas i
            savefile.InitialDirectory = path;
            if (savefile.ShowDialog() == DialogResult.OK) //och där om användaren trycker yes eller OK så spara jag den som bild. 
            {
                string filename = savefile.FileName;
                bitmap.Save(savefile.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("filen har sparats.", "Sparad", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        /* i den metoden så hanterar jag sparning av filerna här har vi olika  val som användaren ska kunna 
         * välja mellan du kan spara filen både som en bild eller som text om du bukar i både två checkboxes
         *  eller som en bild om du väljer bild eller som en fil då. men väljer man inget så för man ett
         *  felmeddelande om att du måste väljer något innan för att spara filen. 
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
                MessageBox.Show("Du måste välja hur vill du spara filen som?", "Osparad", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($"Ett fel inträffade när filen lästes in: {ex.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    }

