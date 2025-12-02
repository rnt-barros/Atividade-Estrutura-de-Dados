class No
{
    public int Valor { get; set; }
    public No? Proximo { get; set; }
}

class ListaEncadeada
{
    private No? primeiro = null;
    private No? ultimo = null;
    private int quantidade = 0;

    public void Adicionar(int valor)
    {
        No novo = new No { Valor = valor };

        if (primeiro == null)
        {
            primeiro = novo;
            ultimo = novo;
        }
        else if (valor % 2 == 0)
        {
            ultimo!.Proximo = novo;
            ultimo = novo;
        }
        else
        {
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
        }
        else
        {
            if (primeiro.Proximo == null)
            {
                primeiro = null;
                ultimo = null;
            }
            else
            {
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

class Program
{
    static void Main(string[] args)
    {
        ListaEncadeada listaPrincipal = new ListaEncadeada();

        Console.WriteLine("Digite 50 números:");
        for (int i = 0; i < 50; i++)
        {
            Console.Write($"Número {i + 1}: ");
            int valor = int.Parse(Console.ReadLine()!);
            listaPrincipal.Adicionar(valor);
        }

        int removidos = 0;
        while (removidos < 25 && listaPrincipal.Quantidade > 0)
        {
            listaPrincipal.Remover();
            removidos++;
        }

        ExibirPercentuais(listaPrincipal);

        OrdenarLista(listaPrincipal);

        Console.WriteLine("\nLista ordenada:");
        ExibirLista(listaPrincipal);
    }

    static void ExibirPercentuais(ListaEncadeada lista)
    {
        int pares = 0, impares = 0;
        int total = lista.Quantidade;

        No? atual = lista.Primeiro;

        while (atual != null)
        {
            if (atual.Valor % 2 == 0) pares++;
            else impares++;

            atual = atual.Proximo;
        }

        Console.WriteLine($"Percentual pares: {((double)pares / total) * 100:0.00}%");
        Console.WriteLine($"Percentual ímpares: {((double)impares / total) * 100:0.00}%");
    }


    static void OrdenarLista(ListaEncadeada lista)
    {
        if (lista.Primeiro == null) return;

        bool trocou;

        do
        {
            trocou = false;
            No? atual = lista.Primeiro;

            while (atual != null && atual.Proximo != null)
            {
                if (atual.Valor > atual.Proximo.Valor)
                {
                    int temp = atual.Valor;
                    atual.Valor = atual.Proximo.Valor;
                    atual.Proximo.Valor = temp;
                    trocou = true;
                }

                atual = atual.Proximo;
            }
        } while (trocou);
    }

    static void ExibirLista(ListaEncadeada lista)
    {
        No? atual = lista.Primeiro;

        while (atual != null)
        {
            Console.Write(atual.Valor + " ");
            atual = atual.Proximo;
        }

        Console.WriteLine();
    }
}