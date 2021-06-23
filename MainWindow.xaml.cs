using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MCBE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("hola");
            playMcbe(entrada, salida);
        }

        // Ejecuta el código introducido en entradaTxt y muestra resultados en salidaTxt
        public void playMcbe(TextBox entradaTxt, TextBox salidaTxt)
        {
            byte PC = 00;               // Contador de programa, contiene un número que es la dirección
                                        // de la posición de memoria donde está almacenada la instrucción
                                        // que está por ejecutar el MCBE
            
            byte IR = 00;               // Registro de instrucción, Antes de ejecutar cada instrucción,
                                        // la CPU va a copiarla en el registro IR, o registro de instrucción;
                                        // y mientras está almacenada allí la instrucción, va a ser decodificada,
                                        // es decir, la CPU va a interpretar de qué instrucción se trata
                                        // y la va a ejecutar.

            byte AC = 00;               // Acumulador, que pertenece a la ALU, es un registro que interviene en
                                        // casi todas las operaciones del MCBE; sobre todo para las operaciones aritméticas.

            byte[] Mem = new byte[32];  // Memoria 0 a 29=>Memoria Principal
                                        // 30 comunicación dispositivos de entrada, solo lectura
                                        // y 31 solo escritura, muestra en pantalla

            string[] codeLine = entradaTxt.Text.Split(Environment.NewLine, // Guarda cada renglón en una posición distinta
                            StringSplitOptions.RemoveEmptyEntries);
            string[] code = new string[codeLine.Length];
            string[] dir = new string[codeLine.Length];

            for(int i = 0; i< codeLine.Length; i++)
            {
                code[i] = codeLine[i].Substring(0, 3);
                dir[i] = codeLine[i].Substring(3, 5);
            }



            salidaTxt.Text = code[1]+"  "+dir[1]; //codeLine[3];

        }

        private void Button_DecToBin_Click(object sender, RoutedEventArgs e)
        {
            salida.Text = Conversiones.decimalBinario(Int32.Parse(entrada.Text)).ToString();
        }

        private void Button_BinToDec_Click(object sender, RoutedEventArgs e)
        {
            salida.Text = Conversiones.binarioDecimal(Int32.Parse(entrada.Text)).ToString();
        }
    }


}
