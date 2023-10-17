// See https://aka.ms/new-console-template for more information
class Program{
    static void Main(){
        
        List<Elemento> elementos = new List<Elemento>();

        Console.WriteLine("Ingrese Cantidad de Elementos");
        string opcion = Console.ReadLine();
        bool opcion1 = int.TryParse(opcion, out int opcion2);

        int i = 1;
        while(i <= opcion2){
            Console.WriteLine("----------------------------");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Ingrese Nombre de elemento");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese Peso de elemento");
            string peso = Console.ReadLine();
            bool peso1 = int.TryParse(peso, out int peso2);

            Console.WriteLine("Ingrese Calorias de elemento");
            string caloria1 = Console.ReadLine();
            bool caloria2 = int.TryParse(caloria1, out int caloria3);

            Elemento elemento = new Elemento(nombre, peso2, caloria3);
            elementos.Add(elemento);
            i++;
        }
        // List<Elemento> elementos = new List<Elemento>{
        //     new Elemento("Cuerda",100,2),
        //     new Elemento("hilo",200,2),
        // };
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Ingrese el Peso maximo para llevar: ");
        string StrMaxiPeso = Console.ReadLine();
        bool isok = int.TryParse(StrMaxiPeso, out int MaxiPeso);

        Console.WriteLine("Ingrese las calorias minimas: ");
        string StrminCalorias = Console.ReadLine();
        bool isok2 = int.TryParse(StrminCalorias, out int minCalorias);

        List<Elemento> ElementosOptimos = EncontarElementosOptimos(elementos, minCalorias, MaxiPeso);

        Console.WriteLine("Elemetos Optimos: ");
        foreach (var elemento in ElementosOptimos)
        {
            Console.WriteLine($"{elemento.Nombre} - {elemento.Peso} - {elemento.Calorias}");  
        }
    }
    static List<Elemento> EncontarElementosOptimos(List<Elemento> elementos, int OptPeso, int OptCalorias){
        int n = elementos.Count;
        List<Elemento> ElementosOptimos = new List<Elemento>();
        int[,] num = new int[n + 1, OptPeso +1 ];

        for(int i = 1; i <= n; i++){
            for(int pesos = 1; pesos <= OptPeso; pesos++){
                Elemento elementoAhora = elementos[1 - 1];

                if ( elementoAhora.Peso > pesos){
                    num[i, pesos] = num[i - 1, pesos];
                }
                else{
                    num[i, pesos] = Math.Max(
                        num[i - 1, pesos],
                        num[i - 1, pesos - elementoAhora.Peso] + elementoAhora.Calorias
                    );
                }
            }
        }
        int k = OptPeso;
        
        for(int i = n; i > 0 && k > 0; i--){
            if(num[i, k] != num[i - 1, k]){
                ElementosOptimos.Add(elementos[i - 1]);
                k -= elementos[i- 1].Peso;
            }
        }

        ElementosOptimos.Reverse();
        return ElementosOptimos;

    }
}
