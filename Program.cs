using System;
using OSLite.Domain;
using OSLite.Domain.ValueObjects;

class Program
{
    static void Main()
    {
        var cliente = new Cliente("Ana", new Email("ana@teste.com"));
        var ordem = new OrdemDeServico();
        ordem.AdicionarItem(new ItemDeServico("Limpeza interna", new Money(80)));
        cliente.AdicionarOrdem(ordem);

        Console.WriteLine($"Cliente: {cliente.Nome}");
        Console.WriteLine($"Total OS: {ordem.Total}");
        Console.WriteLine($"Status: {ordem.Status}");
    }
}
