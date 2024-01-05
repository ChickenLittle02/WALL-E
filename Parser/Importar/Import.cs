using System.Data;
class Code{
    public string Name{get; private set;}
    public string Text{get; private set;}
    public Code(string name, string text)
    {
        Name = name;
        Text = text;
    }

}
class Import{
    
    public static Code GetDocuments(string path)
    {
        string textoCompleto = "";
         if (File.Exists(path)) // Verifica si el archivo existe
            {
                textoCompleto = File.ReadAllText(path); // Lee todo el texto del archivo y lo guarda en una variable

                Console.WriteLine(textoCompleto); // Muestra el texto completo en la consola
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
            Code Codigo = new Code(path,textoCompleto);
            return Codigo;
        
    }
}