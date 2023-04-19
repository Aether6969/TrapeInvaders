using TrapeInvaders;
using static System.Net.WebRequestMethods;

namespace GDD_Eksamen
{
    public partial class Form1 : Form
    {
        WFDrawImage renderTarget;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Form1()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(500, 1000);
            this.BackgroundImageLayout = ImageLayout.None;
            this.BackgroundImage = bitmap;
            this.DoubleBuffered = true;

            Graphics graphics = Graphics.FromImage(bitmap);

            renderTarget = new WFDrawImage(50, 100, graphics, 
                () => 
                {
                    try
                    {
                        this.Invoke(() =>
                        {
                            this.Invalidate();
                        });
                    }
                    catch { }
                });
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            Thread thread = new Thread(() =>
            {
                WFInputController controller = new WFInputController();

                Game game = new SpaceInvaders(controller, renderTarget);
                game.Run();
            });

            thread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}