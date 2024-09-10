using System.Drawing.Printing;

namespace WinFormsApp6
{

    public partial class Form1 : Form
    {
        PrintDocument document = new PrintDocument();
        PrintDialog dialog = new PrintDialog();



        public static class Global
        {
            public static string res = "";
            private static string _globalVar = "";

            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }
      
        public Form1()
        {
            InitializeComponent();
            document.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);


        }
        public static void UNB(string[] words)
        {
            string t = "";
            t += "-Emetteur : " + words[2] + "\n" + "-Destinataire : " + words[3] + "\n";
            t += "-La date d'envoi : ";
            string w = words[4].Split(":")[0].Substring(0, 4);
            string v = words[4].Split(":")[0].Substring(4, 2);
            string u = words[4].Split(":")[0].Substring(6, 2);
            string q = words[4].Split(":")[1].Substring(0, 2);
            string z = words[4].Split(":")[1].Substring(2, 2);
            t += w + "-" + v + "-" + u + " à " + q + "h" + z + "min" + "\n";
            Global.res = t;
        }

        public static void DTM(string[] words)
        {
            Global.res += "-Date de delivrance de mainlevee : ";
            string w = words[1].Split(":")[1].Split("T")[0].Substring(0,4);
            string u = words[1].Split(":")[1].Split("T")[0].Substring(4,2);
            string i = words[1].Split(":")[1].Split("T")[0].Substring(6,2);
            string q = words[1].Split(":")[1].Split("T")[1].Substring(0,2);
            string j = words[1].Split(":")[1].Split("T")[1].Substring(2,2);
            Global.res += w + "-" + u + "-" + i + " à " + q + "h" + j + "min" + "\n";


        }
        public static void MOA(string[] words)
        {
            string w = words[1].Split(":")[1];
            Global.res += "-Prix total de la marchandise : " + w +" DH"+ "\n";
           
        }
        public static void GEI(string[] words)
        {
            if(words[2] == "4")
            {
                Global.res += "-Choix de pesage : " + "oui" + "\n";
            }
            else if (words[2] == "AP")
            {
                Global.res += "-Choix de pesage : " + "oui" + "\n";
            }
            else if (words[2] == "5")
            {
                Global.res += "-Choix de pesage : " + "non" + "\n";
            }
            else if (words[2] == "SP")
            {
                Global.res += "-Choix de pesage : " + "non" + "\n";
            }



        }
        public static void RFF(string[] words)
        {
            string[] arr = words[1].Split(":");
            string w = "";
            if (arr.Length > 1)
            {
                 w = arr[1];
            }
            else
            {
                 w = arr[0];
            }
            Global.res += "-Numero de la DUM : " + w + "\n";
           
        }
        public static void LIN(string[] words)
        {
            Global.res += "-Numero de Connaissement  : " + words[3] + "\n";
           
        }
        public static void NAD(string[] words)
        {
            string h = words[1];
            if(h == "DT")
            {
                int start = words[2].IndexOf("/");
                string w = words[2].Substring(start + 1);
                Global.res += "-ICE Declarant : " + w + "\n";
            }
            else if(h == "CN")
            {
                int start = words[2].IndexOf("/");
                string w = words[2].Substring(start + 1);
                Global.res += "-ICE Soumissionnaire : " + w + "\n";
            }
            else if (h == "CZ")
            { 
                Global.res += "-Id douane : " + words[2] + "\n";
            }


        }
        public static void PCI(string[] words)
        {
            Global.res += "-Numero de Conteneur : " + words[2] + "\n";
            
        }
        public static void GIR(string[] words)
        {
            Global.res += "-Numero d'escale : " + words[2] + "\n";
           
        }
        public static void CST(string[] words)
        {
            Global.res += "-Code NGP de l'article : " + words[2] + "\n";

        }
        public static void MEA(string[] words)
        {
            string w = words[3].Split(":")[1];
            Global.res += "-Poids de la marchandise : " + w +" KG" + "\n";

        }
        public static void BGM(string[] words)
        {
            if(words[3] == "9")
            {
                Global.res += "-Type de message : Transmission initiale" + "\n";
            }
            else if(words[3] == "4")
            {
                Global.res += "-Type de message : Modification" + "\n";
            }
           

        }
        private void button1_Click(object sender, EventArgs e)
        {

            string[] lines = Global.GlobalVar.Split("\n");
            Console.WriteLine("Contents of .txt = ");
            foreach (string line in lines)
            {

                string text = line;
                string[] lignes = text.Split('\'');

                foreach (var ligne in lignes)
                {
                    if (ligne.Length > 0)
                    {

                        string[] words = ligne.Split('+');
                        if (words[0] == "UNB")
                        {
                            UNB(words);
                        }
                        else if (words[0] == "DTM")
                        {
                            DTM(words);
                        }
                        else if (words[0] == "MOA")
                        {
                            MOA(words);
                        }
                        else if (words[0] == "GEI")
                        {
                            GEI(words);
                        }
                        else if (words[0] == "RFF")
                        {
                            RFF(words);
                        }
                        else if (words[0] == "LIN")
                        {
                            LIN(words);
                        }
                        else if (words[0] == "NAD")
                        {
                            NAD(words);
                        }
                        else if (words[0] == "PCI")
                        {
                            PCI(words);
                        }
                        else if (words[0] == "GIR")
                        {
                            GIR(words);
                        }
                        else if(words[0] == "CST")
                        {
                            CST(words);
                        }
                        else if (words[0] == "MEA")
                        {
                            MEA(words);
                        }
                        else if (words[0] == "BGM")
                        {
                            BGM(words);
                        }
                    }
                }
                
            }
          
            textBox1.Text = Global.res.Replace("\n", Environment.NewLine);

            panel5.Height = button1.Height;
            panel5.Top = button1.Top;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            string fileContent = File.ReadAllText(fileName);
            Global.GlobalVar = fileContent;
            string[] k = fileName.Split("\\");
            label3.Text = "Fichier : "+k[k.Length - 1];
            panel5.Height = button2.Height;
            panel5.Top = button2.Top;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dialog.Document = document;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
            panel5.Height = button3.Height;
            panel5.Top = button3.Top;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox1.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, 20, 20);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel5.Height = button4.Height;
            panel5.Top = button4.Top;
            textBox1.Text = string.Empty;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}