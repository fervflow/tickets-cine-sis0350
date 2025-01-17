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



            //DrawSeats(10, 15);
        }

        private async Task CargarSalas()
        {
            salas = await _salaRepo.ListarAsync();

            CBxSalas.Items.Clear();

            foreach (Sala sala in salas)
            {
                CBxSalas.Items.Add($"Sala {sala.Id}");
                //MessageBox.Show($"Cargado Sala: {sala.Id}");
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

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Button seatButton = new Button
                    {
                        Size = new Size(seatSize, seatSize),
                        Location = new Point(
                            10 + col * (seatSize + margin),
                            10 + row * (seatSize + margin)
                        ),
                        //BackgroundImage = Image.FromFile("seat-available.png"),
                        BackColor = Color.DarkOliveGreen,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        FlatStyle = FlatStyle.Flat,

                        Tag = new { Row = row, Column = col, Custom = 12 }
                    };
                    seatButton.FlatAppearance.BorderColor = Color.FromArgb(60, 70, 73);
                    seatButton.FlatAppearance.BorderSize = 3;

                    seatButton.Click += AsientoButton_Click;
                    panelAsientos.Controls.Add(seatButton);
                }
            }
        }

        private void AsientoButton_Click(object sender, EventArgs e)
        {
            Button? clickedSeat = sender as Button;
            var seatInfo = (dynamic)clickedSeat!.Tag!;

            MessageBox.Show($"Seat clicked: Row {seatInfo!.Row + 1}, Column {seatInfo.Column + 1}", "Seat Info");
            // Logic to open another form or execute further actions
        }

        
    }
}
