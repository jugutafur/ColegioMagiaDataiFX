using System;
using System.IO;
using System.Net;
using Metodos;
using coreEstudiantes.Entidades;


namespace dataiFX
{
    class Program
    {
        static void Main(string[] args)
        {
            metodos validacion= new metodos();

            GetItem(10);
            GetItems();
            GetItems("ABC");
            PostItem("NewItem");
            PutItem(4, "ReplaceItem");
            DeleteItem(5);

            Console.WriteLine("=========================================");
            Console.WriteLine("Programa realizado por Juan Guillermo Tafur\nWeb Development Software \n\n");

            Console.WriteLine("Bienvenido a El Colegio de Magia y Hechicería Hogwarts  \n\n\nEste es el software que le permitira ingresar solicitudes para ingresos de nuevos aspirantes\n\n");


// main programa 
            var regresar= true;
            do{

// validacion de nombre

                Console.WriteLine("Por favor ingrese el nombre del Aspirante:");
                string Nombre="";
                do{
                    try{
                        Nombre= Console.ReadLine();
                        regresar = validacion.validarNombre(Nombre);
                    }catch{
                        Console.WriteLine("ingreso un Nombre invalido");
                        Console.WriteLine("Por favor ingrese nuevamente el nombre del Aspirante:");
                    }
                }while(regresar==false);

// validacion de apellido

                Console.WriteLine("favor ingrese el Apellido:");
                string Apellido="";
                do{
                    try{
                        Apellido= Console.ReadLine();
                        regresar = validacion.validarApellido(Apellido);
                    }catch{
                        Console.WriteLine("ingreso un Apellido invalido");
                        Console.WriteLine("Por favor ingrese nuevamente el Apellido del Aspirante:");
                    }
                }while(regresar==false);

// validacion de edad

                Console.WriteLine("favor ingrese la Edad:");
                int Edad=0;
                do{                
                try{
                    Edad = Int32.Parse(Console.ReadLine());
                    regresar = validacion.validarDos(Edad);
                }catch{
                    Console.WriteLine("ingrese un valor invalido");
                    Console.WriteLine("favor ingrese nuevamente la Edad:");
                    regresar=false;
                }
                }while(regresar==false);

// validacion de identificacion

                Console.WriteLine("favor ingrese su identificación: ");
                int identificación=0;
                do{                
                try{
                    identificación = Int32.Parse(Console.ReadLine());
                    regresar = validacion.validarDiez(identificación);
                }catch{
                    Console.WriteLine("ingrese un valor invalido");
                    Console.WriteLine("favor ingrese nuevamente la identificación:");
                    regresar=false;
                }
                }while(regresar==false);

// seleccion de casaMagia

                var regresar1= false;
                string casaMagia= "";
                do{
                    Console.WriteLine("favor ingrese la escuela a la cual desea pertenecer:\n\n1. Gryffindor\n2. Hufflepuff\n3. Ravenclaw\n4. Slytherin");
                    int Opcion=0;
                    do{                
                    try{
                        Opcion = Int32.Parse(Console.ReadLine());  
                    switch (Opcion)
                    {
                        case 1:
                            Console.WriteLine("Ha seleccionado Gryffindor");
                            regresar1=false;
                            casaMagia= "Hufflepuff";
                            break;
                        case 2:
                            Console.WriteLine("Ha seleccionado Hufflepuff");
                            regresar1=false;
                            casaMagia= "Hufflepuff";
                            break;
                        case 3:
                            Console.WriteLine("Ha seleccionado Ravenclaw");
                            regresar1=false;
                            casaMagia= "Ravenclaw";
                            break;
                        case 4:
                            Console.WriteLine("Ha seleccionado Slytherin");
                            regresar1=false;
                            casaMagia= "Slytherin";
                            break;
                        default:
                            Console.WriteLine("Ha seleccionado una opcion invalida, favor ingresar valor valido\n\n");
                            Console.WriteLine("favor ingrese nuevamente la escuela a la cual desea pertenecer:\n\n1. Gryffindor\n2. Hufflepuff\n3. Ravenclaw\n4. Slytherin");
                            regresar1=true;
                            break;
                    }
                        regresar= true;
                    }catch{
                        Console.WriteLine("ingrese un valor invalido");
                        Console.WriteLine("favor ingrese nuevamente la Opcion:\n\n1. Gryffindor\n2. Hufflepuff\n3. Ravenclaw\n4. Slytherin");
                        
                        regresar=false;
                    }
                    }while(regresar==false);
                }while(regresar1==true);

// creacion de objeto estudiate o aspirante

                var NewEstudiante2 = new Estudiante( Nombre, Apellido, Edad, identificación, casaMagia);
                Console.WriteLine(NewEstudiante2);

                
// regresar al inicio??

                Console.WriteLine("desea ingresar ota Solicitud\n\n1. Si \n2. No");
                int continuar;
                continuar = Int32.Parse(Console.ReadLine());
                if(continuar==1){
                    Console.WriteLine("deseas continuar");
                    regresar=true;
                }else{
                    Console.WriteLine("salir");
                    regresar=false;
                }
            }while(regresar);
        }

// conetion
        public static void GetItem(int id){
        var url = $"https://bd-peliculas5-default-rtdb.firebaseio.com/{id}.json";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                    string responseBody = objReader.ReadToEnd();
                    // Do something with responseBody
                    Console.WriteLine(responseBody);
                    }
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error al conectar la API GetItem");
        }
        }

        public static void GetItems(){
        var url = $"https://bd-peliculas5-default-rtdb.firebaseio.com/2.json";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                if (strReader == null) return;
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd();
                    // Do something with responseBody
                    Console.WriteLine(responseBody);
                }
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error al conectar la API GetItems");
        }
    }

        public static void GetItems(string filter){
        var url = $"https://bd-peliculas5-default-rtdb.firebaseio.com/2.json?filter={filter}";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                if (strReader == null) return;
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd();
                    // Do something with responseBody
                    Console.WriteLine(responseBody);
                }
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error al conectar la API GetItems");
        }
    }

        public static void PostItem(string data){
        var url = $"https://bd-peliculas5-default-rtdb.firebaseio.com/2.json";
        var request = (HttpWebRequest)WebRequest.Create(url);
        string json = $"{{\"data\":\"{data}\"}}";
        request.Method = "POST";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }

        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                if (strReader == null) return;
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd();
                    // Do something with responseBody
                    Console.WriteLine(responseBody);
                }
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error al conectar la API PostItem");
        }
    }

        public static void PutItem(int id, string data){
        var url = $"https://bd-peliculas5-default-rtdb.firebaseio.com/2.json";
        var request = (HttpWebRequest)WebRequest.Create(url);
        string json = $"{{\"id\":\"{id}\",\"data\":\"{data}\"}}";
        request.Method = "PUT";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }

        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                if (strReader == null) return;
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd();
                    // Do something with responseBody
                    Console.WriteLine(responseBody);
                }
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error al conectar la API PutItem");
    }
    }

        public static void DeleteItem(int id){

        var url = $"https://bd-peliculas5-default-rtdb.firebaseio.com/{id}.json";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "DELETE";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                if (strReader == null) return;
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd();
                    // Do something with responseBody
                    Console.WriteLine(responseBody);
                }
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error al conectar la API DeleteItem");
        }
    }

    }
}
