using System;
class Program
{
    static void Main()
    {
        //KEVIN ROOSEVELT GUZMAN GUEVARA #083023
        bool salir = false;
        int capacidadBiblioteca = 100;
        string[] codigosLibros = new string[capacidadBiblioteca];
        string[] titulosLibros = new string[capacidadBiblioteca];
        string[] isbnsLibros = new string[capacidadBiblioteca];
        int[] edicionesLibros = new int[capacidadBiblioteca];
        string[] autoresLibros = new string[capacidadBiblioteca];
        int numLibros = 0;

        Console.WriteLine("BIENVENIDO AL SISTEMA....");
        Console.WriteLine("Si no eres un robot preciona enter:");
        Console.ReadKey();

        while (!salir)
        {

            //---------------------------------------MENU-------------------------
            Console.Clear();
            Console.WriteLine("---MENU---");
            Console.WriteLine("1. Llamadas Telefonicas");
            Console.WriteLine("2. Biblioteca");
            Console.WriteLine("3. Salir");

            Console.Write("Ingrese la opcion -> ");
            string opcion = Console.ReadLine();
            //---------------------------------------MENU-------------------------


            switch (opcion)
            {
                //-------------------------------------OPCION1------------------------
                case "1":
                    Console.Clear();
                    Console.WriteLine("LLAMADAS INTERESTELARES .");
                    Console.WriteLine("Ingrese la clave de la zona ");
                    Console.WriteLine("America del Norte [12]");
                    Console.WriteLine("America Central   [15]");
                    Console.WriteLine("America del Sur   [18]");
                    Console.WriteLine("Europa            [19]");
                    Console.WriteLine("Asia              [23]");
                    Console.Write("Ingrese la clave luego precione enter ->");

                    string claveZona = Console.ReadLine();

                    double costoPorMinuto = 0.0;

                    switch (claveZona)
                    {
                        case "12":
                            costoPorMinuto = 2.0;
                            break;
                        case "15":
                            costoPorMinuto = 2.2;
                            break;
                        case "18":
                            costoPorMinuto = 4.5;
                            break;
                        case "19":
                            costoPorMinuto = 3.5;
                            break;
                        case "23":
                            costoPorMinuto = 6.0;
                            break;
                        default:
                            Console.WriteLine("Clave de zona no valda.");
                            break;
                    }

                    if (costoPorMinuto > 0)
                    {
                        Console.Clear();
                        Console.Write("Ingrese el número de minutos hablados: ");
                        if (double.TryParse(Console.ReadLine(), out double minutos))
                        {
                            double costoTotal = costoPorMinuto * minutos;
                            Console.WriteLine($"El costo total de la llamada es: {costoTotal:C}");
                        }
                        else
                        {
                            Console.WriteLine("Numero de minutos no valido.ERRORCAPA#8 intente nuevamente. ");
                        }
                    }

                    Console.WriteLine("Presiona enter para regresar al menu principal.");
                    Console.ReadKey();
                    break;
                //--------------------------------------FINAL - OPCION1------------------------
                //-------------------------------OPCION2----------------------------------
                case "2":
                    Console.Clear();

                    Console.WriteLine("Estás en la opción de Biblioteca.");
                    Console.WriteLine("1. Agregar un libro");
                    Console.WriteLine("2. Mostrar listado de libros");
                    Console.WriteLine("3. Buscar libro por codigo");
                    Console.WriteLine("4. Editar la información de un libro por codigo");
                    Console.WriteLine("5. Regresar al Menu Principal");

                    Console.Write("Ingrese su eleccion: ");
                    string bibliotecaOpcion = Console.ReadLine();

                    switch (bibliotecaOpcion)
                    {
                        case "1":
                            Console.Clear();
                            // Agregar un libro
                            if (numLibros < capacidadBiblioteca)
                            {
                                Console.Write("Ingrese el codigo del libro: ");
                                string codigoLibro = Console.ReadLine();
                                Console.Write("Ingrese el titulo del libro: ");
                                string tituloLibro = Console.ReadLine();
                                Console.Write("Ingrese el ISBN del libro: ");
                                string isbnLibro = Console.ReadLine();
                                Console.Write("Ingrese la edición del libro (solo numero): ");
                                if (int.TryParse(Console.ReadLine(), out int edicionLibro))
                                {
                                    Console.Write("Ingrese el autor del libro: ");
                                    string autorLibro = Console.ReadLine();

                                    codigosLibros[numLibros] = codigoLibro;
                                    titulosLibros[numLibros] = tituloLibro;
                                    isbnsLibros[numLibros] = isbnLibro;
                                    edicionesLibros[numLibros] = edicionLibro;
                                    autoresLibros[numLibros] = autorLibro;

                                    numLibros++;

                                    Console.WriteLine("Libro agregado con exito.");
                                    Console.WriteLine("Precione enter para continuar. ");
                                }
                                else
                                {
                                    Console.WriteLine("Edicion no valida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Biblioteca al limite no se puden agregar mas.");
                            }

                            Console.ReadKey();
                            break;
                        case "2":
                            Console.Clear();
                            // Mostrar listado de libros
                            Console.WriteLine("Listado de Libros:");
                            MostrarLibros(codigosLibros, titulosLibros, isbnsLibros, edicionesLibros, autoresLibros, numLibros);
                            Console.ReadKey();
                            break;
                        case "3":
                            // Buscar libro por código
                            Console.Write("Ingrese el codigo del libro a buscar: ");
                            string codigoBusqueda = Console.ReadLine();
                            int indiceLibroEncontrado = BuscarLibroPorCodigo(codigosLibros, codigoBusqueda, numLibros);

                            if (indiceLibroEncontrado != -1)//VALIDACION ****
                            {
                                Console.WriteLine("Libro encontrado:");
                                MostrarLibro(codigosLibros[indiceLibroEncontrado], titulosLibros[indiceLibroEncontrado], isbnsLibros[indiceLibroEncontrado], edicionesLibros[indiceLibroEncontrado], autoresLibros[indiceLibroEncontrado]);
                            }
                            else
                            {
                                Console.WriteLine("Libro no encontrado.");
                            }

                            Console.ReadKey();
                            break;
                        case "4":
                            // Editar la información de un libro por código
                            Console.Write("Ingrese el codigo del libro a editar: ");
                            string codigoEdicion = Console.ReadLine();
                            int indiceLibroAEditar = BuscarLibroPorCodigo(codigosLibros, codigoEdicion, numLibros);

                            if (indiceLibroAEditar != -1) //validacion ***********
                            {
                                Console.WriteLine("Libro encontrado:");
                                MostrarLibro(codigosLibros[indiceLibroAEditar], titulosLibros[indiceLibroAEditar], isbnsLibros[indiceLibroAEditar], edicionesLibros[indiceLibroAEditar], autoresLibros[indiceLibroAEditar]);

                                Console.WriteLine("Ingrese la nueva información del libro:");
                                Console.Write("Título: ");
                                titulosLibros[indiceLibroAEditar] = Console.ReadLine();
                                Console.Write("ISBN: ");
                                isbnsLibros[indiceLibroAEditar] = Console.ReadLine();
                                Console.Write("Edición: ");
                                if (int.TryParse(Console.ReadLine(), out int nuevaEdicion))
                                {
                                    edicionesLibros[indiceLibroAEditar] = nuevaEdicion;
                                }
                                else
                                {
                                    Console.WriteLine("Edicion no valida.");
                                }
                                Console.Write("Autor: ");
                                autoresLibros[indiceLibroAEditar] = Console.ReadLine();

                                Console.WriteLine("Libro editado con exito! :).");
                            }
                            else
                            {
                                Console.WriteLine("Libro no encontrado. :c Vuelva mañana :D");
                            }

                            Console.ReadKey();
                            break;
                        case "5":
                            // Regresar al Menú Principal
                            break;
                        default:
                            Console.WriteLine("Opcion no valida precione enter para intentar de nuevo.");
                            Console.WriteLine("codigoderror_CAPA#8");
                            Console.ReadKey();
                            break;
                    }
                    break;
                //---------------------------------FINAL - OPCION2 ----------------
                case "3":
                    //OPCION SALIR
                    Console.Clear();
                    Console.WriteLine("Gracias por usar el sistema. Precione Enter para finalizar.");
                    Console.ReadKey();
                    salir = true;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opcion no valida precione enter para intentar de nuevo. ");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void MostrarLibros(string[] codigos, string[] titulos, string[] isbns, int[] ediciones, string[] autores, int numLibros)
    {
        Console.WriteLine("Cdigo\tTitulo\tISBN\tEdicion\tAutor");
        for (int i = 0; i < numLibros; i++)
        {
            Console.WriteLine($"{codigos[i]}\t{titulos[i]}\t{isbns[i]}\t{ediciones[i]}\t{autores[i]}");
        }
    }

    //-------------------------FUNCIONES

    //------------FUNCION BUSCAR LIBRO
    static int BuscarLibroPorCodigo(string[] codigos, string codigo, int numLibros)
    {
        for (int i = 0; i < numLibros; i++)
        {
            if (codigos[i] == codigo)
            {
                return i;
            }
        }
        return -1;
    }

    //-----------------------FUNCION MOSTRAR LIBRO
    static void MostrarLibro(string codigo, string titulo, string isbn, int edicion, string autor)
    {
        Console.WriteLine($"Codigo: {codigo}");
        Console.WriteLine($"Titulo: {titulo}");
        Console.WriteLine($"ISBN: {isbn}");
        Console.WriteLine($"Edicion: {edicion}");
        Console.WriteLine($"Autor: {autor}");
    }
}