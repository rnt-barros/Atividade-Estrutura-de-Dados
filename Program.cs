class No
{
    public int Valor { get; set; }

    public No? Proximo
    {
        get { return proximo; }
        set { proximo = value; }
    }

    private No? proximo = null;
}

class ListaEncadeada
{
    private No? primeiro = null;

    public No? Primeiro
    {
        get
        {
            return primeiro;
        }
    }

    public void AdicionarNoInicio(int valor)
    {
        No novo = new No { Valor = valor };
        if (primeiro == null)
        {
            primeiro = novo;
        }else{
            novo.Proximo = primeiro;
            primeiro = novo;
        }
    }

    public void AdicionarNoFinal(int valor)
    {
        No novo = new No { Valor = valor };
        if (primeiro == null)
        {
            primeiro = novo;
        }else{
            No? aux = primeiro;
            while (aux!.Proximo != null)
            {
                aux = aux.Proximo;
            }
            aux.Proximo = novo;
        }
    }

    public void RemoverInicio()
    {
        if (primeiro == null)
        {
            throw new Exception("Lista vazia!");
        }
        primeiro = primeiro.Proximo;
    }

    public void RemoverFinal()
    {
        if (primeiro == null)
        {
            throw new Exception("Lista vazia");
        }

        if (primeiro.Proximo == null)
        {
            primeiro = null;
        }else{
            No? aux = primeiro;

            while (aux!.Proximo!.Proximo != null)
            {
                aux = aux.Proximo;
            }

            aux.Proximo = null;
        }
    }

    public bool SaoIguais(ListaEncadeada outraLista)
    {
        No? atual1 = this.Primeiro;
        No? atual2 = outraLista.Primeiro;

        while (atual1 != null && atual2 != null)
        {
            if (atual1.Valor != atual2.Valor)
            {
                return false;
            }

            atual1 = atual1.Proximo;
            atual2 = atual2.Proximo;
        }

        return atual1 == null && atual2 == null;
    }
}