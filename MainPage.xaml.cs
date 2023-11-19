
namespace ShareExpenseMaui
{
    public partial class MainPage : ContentPage
    {
        private decimal _valorConta;
        private int _percentualGorjeta;
        private int _quantidadePessoas = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void TxtConta_Completed(object sender, EventArgs e)
        {
            _valorConta = decimal.Parse(TxtConta.Text);
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal totalGorjeta = _valorConta * _percentualGorjeta / 100;

            decimal valorGorjetaPorPessoa = totalGorjeta / _quantidadePessoas;

            LblGorjetaPessoa.Text = $"{valorGorjetaPorPessoa:C}";

            decimal subtotal = _valorConta / _quantidadePessoas;
            LblSubtotal.Text = $"{subtotal:C}";

            decimal totalPorPessoa = (_valorConta + totalGorjeta) / _quantidadePessoas;
            LblTotal.Text = $"{totalPorPessoa:C}";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                int percentualGorjeta = int.Parse(button.Text.Replace("%", ""));
                SliderGorjeta.Value = percentualGorjeta;
            }
        }

        private void SliderGorjeta_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _percentualGorjeta = (int)SliderGorjeta.Value;
            LblGorjeta.Text = $"Gorjeta: {_percentualGorjeta}%";
            CalcularTotal();
        }

        private void BtnReiniciar_Clicked(object sender, EventArgs e)
        {
            _valorConta = 0m;
            _percentualGorjeta = 0;
            TxtConta.Text = "";
            SliderGorjeta.Value = 0;
            LblNumeroPessoas.Text = "1";
            _quantidadePessoas = 1;
            CalcularTotal();

        }

        private void BtnMais_Clicked(object sender, EventArgs e)
        {
            _quantidadePessoas++;
            LblNumeroPessoas.Text = _quantidadePessoas.ToString();
            CalcularTotal();
        }

        private void BtnMenos_Clicked(object sender, EventArgs e)
        {
            if (_quantidadePessoas > 1)
                _quantidadePessoas--;

            LblNumeroPessoas.Text = _quantidadePessoas.ToString();
            CalcularTotal();
        }
    }

}
