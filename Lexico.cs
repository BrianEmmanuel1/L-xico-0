namespace Léxico_0
{
    public class Lexico : Token
    {
        StreamReader Archivo;
        StreamWriter Log;
        public Lexico()
        { 
            Archivo = new StreamReader("C:\\Users\\gatog\\OneDrive\\ITQ\\Cuarto Semestre\\Automatas I\\Léxico 0\\Prueba.cpp");
            Log     = new StreamWriter("C:\\Users\\gatog\\OneDrive\\ITQ\\Cuarto Semestre\\Automatas I\\Léxico 0\\Prueba.log");
            Log.AutoFlush = true;
        }

        public void Cerrar()
        {
            Archivo.Close();
            Log.Close();
        }

        public void NextToken()
        {
            char c;
            string Buffer = "";

            while(char.IsWhiteSpace(c = (char) Archivo.Read()));

            if(char.IsLetter(c))
            {
                Buffer += c;
                while(char.IsLetterOrDigit(c = (char) Archivo.Peek()))
                {
                    Buffer+=c;
                    Archivo.Read();
                }
                setClasificacion(Tipos.Identicador);
            }
            else if(char.IsDigit(c))
            {
                Buffer += c;
                while(char.IsDigit(c = (char) Archivo.Peek()))
                {
                    Buffer+=c;
                    Archivo.Read();
                }
                setClasificacion(Tipos.Numero);
            }
            else if(c == ';')
            {
                Buffer+=c;
                setClasificacion(Tipos.FinSentencia);
            } 
            else if(c == '=')
            {
                Buffer+=c;
                setClasificacion(Tipos.Asignacion);
            }
            else if(c == '*' || c=='%' || c=='/')
            {
                Buffer+=c;
                setClasificacion(Tipos.OperadorFactor);
            }
            else if(c == '+' || c=='-')
            {
                Buffer+=c;
                setClasificacion(Tipos.OperadorTermino);
            }
            else
            {
                Buffer+=c;
                setClasificacion(Tipos.Caracter);
            }
            setContenido(Buffer);
            Log.WriteLine(getContenido() + " | " + getClasificacion());
        }

        public bool FinArchivo()
        {
            return Archivo.EndOfStream;
        }
    }
}