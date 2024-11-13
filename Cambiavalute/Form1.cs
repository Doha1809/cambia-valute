namespace cambiaValute
{
    public partial class Form1 : Form
    {
        Cambia cambia = new Cambia("123", "lala", "129", 1, 2, 3);
        double valore;
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double quantità_denaro = Convert.ToDouble(textBox1.Text);
            cambia.Carica_denaro(quantità_denaro);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cambia.Valuta_originale = textBox3.Text;
            char carattere;
            string risul = "";

            for (int i = 0; i < cambia.Valuta_originale.Length; i++)
            {
                carattere = cambia.Valuta_originale[i];
                
                if (carattere >= 'A' && carattere<='Z')
                    {
                       carattere =(char)( carattere + 32);  
                    }
                
                
                risul+= carattere;
               
            }
            cambia.Valuta_originale = risul;
            cambia.Valuta_destinazione = textBox2.Text;
            risul = "";

            for (int i = 0; i < cambia.Valuta_destinazione.Length; i++)
            {
                carattere = cambia.Valuta_destinazione[i];

                if (carattere >= 'A' && carattere <= 'Z')
                {
                    carattere = (char)(carattere + 32);
                }


                risul += carattere;
                MessageBox.Show(risul);

            }
           cambia.Valuta_destinazione=risul;
            cambia.Imposta_denaro();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            valore = cambia.Converti();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cambia.stampa(valore);
        }
    }
}
class Cambia
{
    private string id_univoco;
    public string Id_univoco
    {
        get { return id_univoco; }
    }

    private string ditta_produtrice;
    private string Ditta_produtrice
    {
        get { return ditta_produtrice; }
    }
    private string data_ultimo_caricamento;
    public string Data_ultimo_caricamento
    {
        get { return data_ultimo_caricamento; }
    }
    private double euro_dollaro;
    public double Euro_dollaro
    {
        get { return euro_dollaro; }
        set { euro_dollaro = value; }
    }
    private double euro_sterlina;
    public double Euro_sterlina
    {
        get { return euro_sterlina; }
        set { euro_sterlina = value; }
    }
    private double dollaro_sterlina;
    public double Dollaro_sterlina
    {
        get { return dollaro_sterlina; }
        set { dollaro_sterlina = value; }
    }

    private int conta_erogazione;
    public int Conta_erogazione
    {
        get { return conta_erogazione; }

    }
    private double quantità_denaro;
    public double Quantità_denaro
    {
        get { return quantità_denaro; }
    }
    private string valuta_originale;
    public string Valuta_originale
    {
        get { return valuta_originale; }
        set { valuta_originale = value; }   
    }
    private string valuta_destinazione;
    public string Valuta_destinazione
    {
        get { return valuta_destinazione; }
        set { valuta_destinazione = value;}
    }
    public Cambia(string id_univoco, string ditta_produtrice, string data_ultimo_caricamento, double euro_dollaro, double euro_sterlina, double dollaro_sterlina)
    {
        this.id_univoco = id_univoco;
        this.ditta_produtrice = ditta_produtrice;
        this.data_ultimo_caricamento = data_ultimo_caricamento;
        this.euro_dollaro = euro_dollaro;
        this.euro_sterlina = euro_sterlina;
        this.dollaro_sterlina = dollaro_sterlina;

    }
    public void Carica_denaro(double quantità_denaro)
    {
        this.quantità_denaro = quantità_denaro;
        conta_erogazione = conta_erogazione + 1;
    }
    public void Imposta_denaro()
    {
       /* do
        {
           MessageBox.Show("inserisci il tipo di denaro");
           
        } while (valuta_originale != "euro" && valuta_originale != "dollaro" && valuta_originale != "sterline");
       */
        do
        {
            Console.WriteLine("inserisci il tipo di denaro");
            
        } while (valuta_destinazione != "euro" && valuta_destinazione != "dollaro" && valuta_destinazione != "sterline");
    }
    public double Converti()
    {
        if (valuta_originale == "euro" && valuta_destinazione == "dollaro")
        {
            return quantità_denaro * euro_dollaro;
        }
        if (valuta_originale == "dollaro" && valuta_destinazione == "euro")
        {
            return quantità_denaro / euro_dollaro;
        }
        if (valuta_originale == "euro" && valuta_destinazione == "sterline")
        {
            return quantità_denaro * euro_sterlina;
        }
        if (valuta_originale == "sterline" && valuta_destinazione == "euro")
        {
            return quantità_denaro / euro_sterlina;
        }
        if (valuta_originale == "dollaro" && valuta_destinazione == "sterline")
        {
            return quantità_denaro * dollaro_sterlina;
        }
        if (valuta_originale == "sterline" && valuta_destinazione == "dollaro")
        {
            return quantità_denaro / dollaro_sterlina;
        }
        else
            return 0;
    }
    public void stampa(double valore)
    {
        MessageBox.Show($"l'erogazione effetuata è:{valore}");
    }


}
