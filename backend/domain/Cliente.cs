﻿namespace domain;

public class Cliente
{    
    public int CodigoCliente { get; set; }
    public string Nome { get; set; }

    public string Endereco { get; set; }

    public string Cidade { get; set; }

    public string UF { get; set; }

    public DateTime? DataInsercao { get; set; }
}
