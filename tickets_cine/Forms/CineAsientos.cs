using tickets_cine.Models;
using tickets_cine.Repos;

namespace tickets_cine.Forms
{
    public partial class CineAsientosForm : Form
    {
        string asientoDisponiblePath = Path.Combine(Application.StartupPath, "Resources", "seat-available.png");

        private readonly SalaRepo _salaRepo = new SalaRepo();
        private readonly AsientoRepo _asientoRepo = new AsientoRepo();

        private List<Sala> salas = [];
        private List<Asiento> asientos = [];

        public CineAsientosForm()
        {
            InitializeComponent();

            _ = CargarSalas();


        }

        private async Task CargarSalas()
        {
            salas = await _salaRepo.ListarAsync();

            CBxSalas.Items.Clear();

            foreach (Sala sala in salas)
            {
                CBxSalas.Items.Add($"Sala {sala.Id}");
            }

            if (CBxSalas.Items.Count > 0)
            {
                CBxSalas.SelectedIndex = 0;
            }
        }

        private async void CBxSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBxSalas.SelectedItem != null)
            {
                string selectedText = CBxSalas.SelectedItem.ToString()!;
                int selectedId = int.Parse(selectedText.Replace("Sala ", ""));
                Sala selectedSala = salas.FirstOrDefault(s => s.Id == selectedId)!;

                if (selectedSala != null)
                {
                    MessageBox.Show($"Selected Sala: Id={selectedSala.Id}, Filas={selectedSala.Filas}, Columnas={selectedSala.Columnas}");
                    asientos.Clear();
                    asientos = await _asientoRepo.ListarPorSalaAsync(selectedSala.Id);

                    DrawSeats(selectedSala.Filas, selectedSala.Columnas, selectedSala.Bloques);
                }
            }
        }

        private void DrawSeats(int rows, int columns, int bloques)
        {
            int seatSize = 24;
            int margin = 4;
            int blockSpacing = 10;
            int seatIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++, seatIndex++)
                {
                    //int adjustedCol = col;
                    //if (bloques > 1)
                    //{
                    //    int blockSize = (int)Math.Ceiling(columns / (double)bloques);
                    //    int extraSpace = (col / blockSize) * blockSpacing;
                    //    adjustedCol += extraSpace;
                    //}

                    PictureBox seatPicBox = new PictureBox
                    {
                        Size = new Size(seatSize, seatSize),
                        Location = new Point(
                            10 + col * (seatSize + margin),
                            10 + row * (seatSize + margin)
                        ),
                        BackColor = Color.DarkOliveGreen,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = new { Row = row+1, Column = col+1, AsientoIdx = seatIndex }
                    };

                    seatPicBox.Click += Asiento_Click;
                    //seatPicBox.MouseDoubleClick += Asiento_DoubleClick;
                    panelAsientos.Controls.Add(seatPicBox);
                }
            }
        }

        private void Asiento_Click(object sender, EventArgs e)
        {
            PictureBox? clickedSeat = sender as PictureBox;
            var seatInfo = (dynamic)clickedSeat!.Tag!;

            MessageBox.Show($"Seat clicked: Row {seatInfo!.Row + 1}, Column {seatInfo.Column + 1}, Cod. Asiento: {asientos[seatInfo.AsientoIdx].Codigo}",
                "Seat Info"
            );
            // Logic to open another form or execute further actions
        }

        //private void Asiento_DoubleClick(object sender, MouseEventArgs e)
        //{
        //    PictureBox? clickedSeat = sender as PictureBox;
        //    var seatInfo = (dynamic)clickedSeat!.Tag!;

        //    MessageBox.Show(
        //        $"Double-click: Row {seatInfo.Row + 1}, Column {seatInfo.Column + 1}",
        //        "Seat Info"
        //    );
        //}


    }
}
