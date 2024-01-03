namespace Syntax_Analizer
{
    partial class Syntax
    {
        public void BuildPunto(Scope actualScope)
        {
            Eat(TokenType.Keyword,"");
            if(IsNext(TokenType.SequenceKeyword))
            {//Es point sequence prueba aqui prueba es un tipo secuencia de puntos

            }else{
                //TIene que ser un identificador point p1;
                string name = actual_token.Value.ToString();
                Eat(TokenType.Identifier,"Se esperaba un identificador");
            }

        }
    }
}