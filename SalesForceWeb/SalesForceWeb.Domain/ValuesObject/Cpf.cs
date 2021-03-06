﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;

namespace SalesForceWeb.Domain.ValuesObject
{
    [ComplexType]

    public class Cpf
    {
        public string Codigo { get;  set; }

        public Cpf() { }


        public Cpf(string cpf)
        {
            try
            {
                if (!IsCpf(cpf))
                    throw new Exception();

                Codigo = Convert.ToString(cpf);
            }
            catch (Exception)
            {
                throw new Exception("Cpf inválido: " + cpf);
            }
        }

        
        public string GetCpfCompleto()
        {
            var cpf = Codigo.ToString();

            if (string.IsNullOrEmpty(cpf))
                return "";

            while (cpf.Length < 11)
                cpf = "0" + cpf;

            return cpf;
        }




        public static bool IsCpf(string cpf)
        {
            while (cpf.Length < 11)
                cpf = "0" + cpf;

            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto;
            return cpf.EndsWith(digito);
        }

        public string CodigoCPF(string v)
        {
            var resultado = v;
            JArray usuarioarrray = JArray.Parse(v);
            foreach (JObject obj in usuarioarrray.Children<JObject>())
            {
                foreach (JProperty prop in obj.Properties())
                {
                    switch (prop.Name)
                    {
                        case "codigo":
                            v = prop.Value.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
            return Codigo = v;
        }

        
    }
}
