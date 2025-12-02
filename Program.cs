class No
{
    public int Valor {get; set;}
    public No? Proximo {get; set;}
}

class ListaEncadeada
{
    private No? primeiro = null;
    private No? ultimo = null;
    private int quantidade = 0;

    public void Adicionar(int valor)
    {
        No novo = new No {Valor = valor};

        if(primeiro == null)
        {
            primeiro = novo;
            ultimo = novo;
        }else if (valor%2==0){
            ultimo!.Proximo = novo;
            ultimo = novo;
        }else{
            novo.Proximo = primeiro;
            primeiro = novo;
        }

        quantidade++;
    }

    public void Remover()
    {
        if (primeiro == null)
            throw new Exception("Lista vazia!");

        if (primeiro.Valor % 2 == 0)
        {
            primeiro = primeiro.Proximo;

            if (primeiro == null)
            {
                ultimo = null;
            }
        }else{
            if (primeiro.Proximo == null)
            {
                primeiro = null;
                ultimo = null;
            }else{
                No aux = primeiro;

                while (aux.Proximo!.Proximo != null)
                {
                    aux = aux.Proximo;
                }

                aux.Proximo = null;
                ultimo = aux;
            }
        }

        quantidade--;
    }

    public int Quantidade
    {
        get { return quantidade; }
    }

    public No? Ultimo
    {
        get { return ultimo; }
    }

    public No? Primeiro
    {
        get { return primeiro; }
    }

}