using System;
using System.Collections.Generic;
using System;

namespace projectScanner
{
    class Token
    {
        String tokenName;

        public string TokenName { get => tokenName; set => tokenName = value; }

        public Token( )
        {
            this.TokenName = null ;
        }

        public void printTokenName()
        {
            Console.WriteLine(TokenName);
        }



        public static Boolean Is_Single_Char(char c, ref Token token) {

            switch (c) {
                case ';':
                    token.TokenName = "SEMI";


                    return true;
                case ',':

                    token.TokenName = "T_COMMA";


                    return true;
                case '(':
                    token.TokenName = "T_LPAREN";


                    return true;
                case ')':
                    token.TokenName = "T_RPAREN";
                    return true;
                case '{':
                    token.TokenName = "T_LCURLYPAREN";

                    return true;
                case '}':
                    token.TokenName = "T_RCURLYPAREN";
                    return true;

                case '+':
                    token.TokenName = "T_PLUS";


                    return true;
                case '/':
                    token.TokenName = "T_DIV";


                    return true;
                case '-':
                    token.TokenName = "T_MINUS";


                    return true;
                case '*':
                    token.TokenName = "T_MULT";


                    return true;
                case '>':
                    token.TokenName = "T_GTHAN";

                    return true;
                case '<':
                    token.TokenName = "T_STHAN";

                    return true;

                case '=':
                    token.TokenName = "T_TESTEQ";


                    return true;
            }
            return false;
        }



        public static Boolean Is_Double_Char(String s,ref Token token)
        {

            switch (s)
            {
                case ":=":
                    token.TokenName = "T_ASSIGNMENT";


                    return true;
                
                case "<>":
                    token.TokenName = "T_TESTNOTEQ";


                    return true;
                case "&&":
                    token.TokenName = "AND";


                    return true;
                case "||":
                    token.TokenName = "OR";


                    return true;
            }
            return false;
        }
        public static Boolean Is_Identifier(String s, ref Token token) {
            if (!(Char.IsLetter(s[0]))) {
                return false;


            }
            for (int i = 1; i < s.Length; i++)
            {
                if (!(Char.IsLetterOrDigit(s[i])))
                {
                    return false;
                }
            }
            token.TokenName = "ID_"+s;
            return true;
        }
        public static Boolean Is_Number(String s, ref Token token)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (!(Char.IsDigit(s[i])))
                {
                    return false;
                }
            }
            token.TokenName = "T_NUMBER";
            return true;

        }
        public static Boolean Is_String(String s, ref Token token)
        {
            {

                if (s[0] == '\"')
                {
                    token.TokenName = "T_QUOTEDSTRING";
                    return true;
                }
                return false;
            }

        }

        public static Boolean Is_Comment(String s, ref Token token)
        {

            if (s.Length>1&&s[0].Equals('/') && s[1].Equals('*'))
            {
                token.TokenName = "T_COMMENT";
                return true;
            }

            return false;

        }
        public static int Get_Comment_End(String s,int pointer)
        {
            for (; pointer < s.Length; pointer++)
            {

            
            if (s.Length-pointer>1&& s[pointer].Equals('*') && s[pointer+1].Equals('/'))
            {
                    return pointer + 2;
            }
            }
            return s.Length;

        }
        public static int Get_Number_End(String s, int pointer)
        {
            for (; s.Length - pointer > 0 && char.IsDigit(s[pointer]); pointer++)
            {


               
            }

            return pointer;

        }
        public static int Get_String_End(String s, int pointer)
        {
            for (; pointer < s.Length; pointer++)
            {


                if ( s[pointer].Equals('\"'))
                {
                    return pointer + 1;
                }
            }
            return s.Length;

        }
        public static Boolean Is_Keyword(String s, ref Token token) {
            switch (s)
            {
                case "write" : token.TokenName = "T_WRITE";
                    return true;
                 case "repeat" : token.TokenName = "T_REPEAT";
            return true;


                case "if":
                    token.TokenName = "T_IF";
                    return true;
                case "read":
                    token.TokenName = "T_READ";
                    return true;
                case "else":
                    token.TokenName = "T_ELSE";
                    return true;
                case "end":
                    token.TokenName = "T_END";
                    return true;
                case "main":
                    token.TokenName = "T_MAIN";
                    return true;
                //case "begin":
                //    token.TokenName = "RESERVED";
                //    return true;
                case "string":
                    token.TokenName = "T_STRING";
                    return true;
                case "float":
                    token.TokenName = "T_FLOAT";
                    return true;
                case "int":
                    token.TokenName = "T_INT";
                    return true;

                case "return":
                    token.TokenName = "T_RETURN";
                    return true;
                case "until":
                    token.TokenName = "T_UNTIL";
                    return true;
                case "elseif":
                    token.TokenName = "T_ELSEIF";
                    return true;
                case "then":
                    token.TokenName = "T_THEN";
                    return true;
                case "endl":
                    token.TokenName = "T_ENDL";
                    return true;


            }

            return false;
        
        }






        }
}
