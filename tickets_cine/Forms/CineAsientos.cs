//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tickets_cine.Forms
{
    public partial class CineAsientosForm : Form
    {
        string asientoDisponiblePath = Path.Combine(Application.StartupPath, "Resources", "seat-available.png");
        public CineAsientosForm()
        {
            InitializeComponent();

            DrawSeats(10, 15);
        }

        private void DrawSeats(int rows, int columns)
        {
            int seatSize = 40;
            int margin = 10;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Button seatButton = new Button
                    {
                        Size = new Size(seatSize, seatSize),
                        Location = new Point(10 + col * (seatSize + margin), 10 + row * (seatSize + margin)),
                        //BackgroundImage = Image.FromFile("seat-available.png"),
                        BackColor = Color.DarkOliveGreen,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        FlatStyle = FlatStyle.Flat,

                        Tag = new { Row = row, Column = col, Custom = 12 }
                    };
                    seatButton.FlatAppearance.BorderColor = Color.FromArgb(60, 70, 73);
                    seatButton.FlatAppearance.BorderSize = 3;

                    // Add click event
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
