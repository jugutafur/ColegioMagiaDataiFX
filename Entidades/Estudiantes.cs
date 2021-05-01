namespace coreEstudiantes.Entidades{
    class Estudiante{
        private string nombre;
        private string apellido;
        private int edad;
        private int identificacion;
        private string casa;

        public Estudiante(string nombre, string apellido, int edad, int identificacion, string casa ){
            this.nombre= nombre;
            this.apellido= apellido;
            this.edad= edad;
            this.identificacion= identificacion;
            this.casa= casa;
        }

        public void setNombre(string nombre){
            this.nombre= nombre;
        }
        public string getNombre(){
            return nombre;
        }
        public void setApellido(string apellido){
            this.apellido= apellido;
        }
        public string getApellido(){
            return apellido;
        }
        public void setEdad(int edad){
            this.edad= edad;
        }
        public int getEdad(){
            return edad;
        }
        public void setIdentificacion(int identificacion){
            this.identificacion= identificacion;
        }
        public int getIdentificacion(){
            return identificacion;
        }

        public override string ToString() => ($"Name: {nombre} \nLastName: {apellido} \nage: {edad} \nId: {identificacion} \nCasa correspondiente {casa} ");
    }
}