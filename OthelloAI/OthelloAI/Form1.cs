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

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            //change button4 background to white and text to black
            button4.BackColor = Color.White;
            button4.ForeColor = Color.Black;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            //change button4 background to black and text to white
            button4.BackColor = Color.Black;
            button4.ForeColor = Color.White;
            //hide the current form
        }
        private void button1_Click(object sender, EventArgs e)
        {
            formatSelectedButton(button1);
            //hide label1 and label2
            label1.Hide();
            label2.Hide();
            //hide trackbar1 and trackbar2
            trackBar1.Hide();
            trackBar2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formatSelectedButton(button2);
            //show label1 and trackbar1
            label1.Show();
            trackBar1.Show();
            //hide label2 and trackbar2
            label2.Hide();
            trackBar2.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formatSelectedButton(button3);
            //show label2 and trackbar2
            label2.Show();
            trackBar2.Show();
        }

        private void formatSelectedButton(Button button)
        {
            //make only the passed in parameter button background white and text black and the rest of the buttons background black and text white
            button.BackColor = Color.White;
            button.ForeColor = Color.Black;
            if (button != button1)
            {
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
            }
            if (button != button2)
            {
                button2.BackColor = Color.Black;
                button2.ForeColor = Color.White;
            }
            if (button != button3)
            {
                button3.BackColor = Color.Black;
                button3.ForeColor = Color.White;
            }
        }
    }
}