namespace OthelloAI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //give button1 a blue border with 2px width
            button1.FlatAppearance.BorderColor = Color.Blue;
            button1.FlatAppearance.BorderSize = 2;

            //hide label1 and label2
            label1.Hide();
            label2.Hide();
            //hide trackbar1 and trackbar2
            trackBar1.Hide();
            trackBar2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //show label1 and trackbar1
            label1.Show();
            trackBar1.Show();
            //hide label2 and trackbar2
            label2.Hide();
            trackBar2.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //show label2 and trackbar2
            label2.Show();
            trackBar2.Show();
        }
    }
}