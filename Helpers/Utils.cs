namespace Api.FCXLabs.AvaliacaoUsuario.Helpers
{
    public class Utils
    {
        public static string GerarCPF()
        {
            Random random = new Random();
            int[] cpf = new int[11]; // Ajuste para 11 elementos

            for (int i = 0; i < 9; i++)
            {
                cpf[i] = random.Next(0, 9);
            }

            int soma = 0;
            int resto;

            for (int i = 0; i < 9; i++)
            {
                soma += cpf[i] * (10 - i);
            }

            resto = soma % 11;

            if (resto < 2)
            {
                cpf[9] = 0;
            }
            else
            {
                cpf[9] = 11 - resto;
            }

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += cpf[i] * (11 - i);
            }

            resto = soma % 11;

            if (resto < 2)
            {
                cpf[10] = 0;
            }
            else
            {
                cpf[10] = 11 - resto;
            }

            string cpfString = string.Concat(cpf.Select(d => d.ToString()));

            return cpfString.Insert(9, "-").Insert(6, ".").Insert(3, ".");
        }

        public static string FormatarCPF(string cpf)
        {
            // Remove qualquer caractere não numérico do CPF
            string cpfNumerico = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF possui 11 dígitos
            if (cpfNumerico.Length != 11)
            {
                throw new ArgumentException("O CPF deve conter exatamente 11 dígitos.");
            }

            // Insere os separadores de pontuação no CPF formatado
            return Convert.ToUInt64(cpfNumerico).ToString(@"000\.000\.000\-00");
        }
    }
}
