using System;
using System.Collections.Generic;
using System;

namespace projectScanner
{
    class Token
    {
        String tokenName;
        public const String SEMI_COLON = "SEMI";
        public const String COMMA = "T_COMMA";
        public const String LPAREN = "T_LPAREN";
        public const String RPAREN = "T_RPAREN";
        public const String LCURLYPAREN = "T_LCURLYPAREN";
        public const String RCURLYPAREN = "T_RCURLYPAREN";
        public const String PLUS = "T_PLUS";
        public const String DIV = "T_DIV";
        public const String MINUS = "T_MINUS";
        public const String MULT = "T_MULT";
        public const String GTHAN = "T_GTHAN";
        public const String STHAN = "T_STHAN";
        public const String TESTEQ = "T_TESTEQ";
        public const String ASSIGNMENT = "T_ASSIGNMENT";
        public const String IF = "T_IF";
        public const String END = "T_END";
        public const String READ = "T_READ";
        public const String ELSE = "T_ELSE";
        public const String THEN = "T_THEN";
        public const String UNTIL = "T_UNTIL";
        public const String WRITE = "T_WRITE";
        public const String REPEAT = "T_REPEAT";
        public const String ID = "ID";
        public const String Number = "T_NUMBER";

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

                    token.TokenName = COMMA;


                    return true;
                case '(':
                    token.TokenName = LPAREN;


                    return true;
                case ')':
                    token.TokenName = RPAREN;
                    return true;
                case '{':
                    token.TokenName = LCURLYPAREN;

                    return true;
                case '}':
                    token.TokenName = RCURLYPAREN;
                    return true;

                case '+':
                    token.TokenName = PLUS;


                    return true;
                case '/':
                    token.TokenName = DIV;


                    return true;
                case '-':
                    token.TokenName =MINUS;


                    return true;
                case '*':
                    token.TokenName = MULT;


                    return true;
                case '>':
                    token.TokenName = GTHAN;

                    return true;
                case '<':
                    token.TokenName =STHAN;

                    return true;

                case '=':
                    token.TokenName =TESTEQ;


                    return true;
            }
            return false;
        }



        public static Boolean Is_Double_Char(String s,ref Token token)
        {

            switch (s)
            {
                case ":=":
                    token.TokenName = ASSIGNMENT;


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
            token.TokenName = ID;
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
            token.TokenName = Number;
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
                case "write" : token.TokenName = WRITE;
                    return true;
                 case "repeat" : token.TokenName = REPEAT;
            return true;


                case "if":
                    token.TokenName = IF;
                    return true;
                case "read":
                    token.TokenName = READ;
                    return true;
                case "else":
                    token.TokenName = ELSE;
                    return true;
                case "end":
                    token.TokenName = END;
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
                    token.TokenName = UNTIL;
                    return true;
                case "elseif":
                    token.TokenName = "T_ELSEIF";
                    return true;
                case "then":
                    token.TokenName = THEN;
                    return true;
                case "endl":
                    token.TokenName = "T_ENDL";
                    return true;


            }

            return false;
        
        }






        }
}
