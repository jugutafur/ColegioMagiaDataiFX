using System;

namespace Metodos{
    class metodos{

// // validar nombre !=20 caracteres
        public bool validarNombre(string Nombre){
            if(Nombre.Length<20){
                Console.WriteLine( $"1) nombre valido {Nombre} is {Nombre.Length}");
                return true;
            }else {
                Console.WriteLine( $"2) invalido {Nombre} is {Nombre.Length} \nPor favor ingrese nuevamente el nombre del Aspirante:");
                return false;
            }
        } 
        
// // validar Apelllido !=20 caracteres
        public bool validarApellido(string Apellido){
            if(Apellido.Length<20){
                Console.WriteLine( $"1) Apellido valido {Apellido} is {Apellido.Length}");
                return true;
            }else {
                Console.WriteLine( $"2) invalido {Apellido} is {Apellido.Length} \nPor favor ingrese nuevamente el Apellido del Aspirante:");
                return false;
            }
        }

// // validar identificacin<=20 digitos
        public bool validarDiez(int Identificacion){
            string cantidad= Identificacion.ToString();
            if(cantidad.Length<10){
                return true;
            }else {
                Console.WriteLine("favor ingrese nuevamente la identificación:");
                return false;
            }
        }

// // validar edad<=2 digitos
        public bool validarDos(int Edad){
            if(Edad<=99){
                return true;
            }else {
                Console.WriteLine("favor ingrese nuevamente la Edad:");
                return false;
            }
        }
    }
}