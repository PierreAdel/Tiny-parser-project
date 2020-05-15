using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectScanner
{
    class Parser
    {
        private String[,] Output;
        private int Token_Pointer = 0;
        private String[] Accepted_Tokens;
        private int Accepted_Token_Pointer = 0;
        public Parser(String[,] Output)
        {
            this.Output = Output;


        }

        String Get_Next_Token()
        {


            return Output[Token_Pointer++, 0];

        }

        String Get_Token_Value()
        {


            return Output[Token_Pointer, 1];

        }


        Boolean Match(String Expected_Token, String Token)
        {
            return Expected_Token.Equals(Token);


        }
        void Add_Accepted_Token(String Token)
        {

            Accepted_Tokens[Accepted_Token_Pointer++] = Token;

        }




        void Comparison_Op()
        {
            if (Output[Token_Pointer, 0] == "=" || Output[Token_Pointer, 0] == ">" || Output[Token_Pointer, 0] == "<")
            {
                Add_Accepted_Token(Output[Token_Pointer, 0]);
            }

            else
            {
                //print Expected_Comparison_Operator_But_Not_Found
            }



        }
        void Mul_Op()
        {
            if (Output[Token_Pointer, 0] == "*" || Output[Token_Pointer, 0] == "/")
            {
                Add_Accepted_Token(Output[Token_Pointer, 0]);
            }

            else
            {
                //print Expected_Mul_Op_Operator_But_Not_Found
            }

        }
        void Add_Op()
        {
            if (Output[Token_Pointer, 0] == "+" || Output[Token_Pointer, 0] == "-")
            {
                Add_Accepted_Token(Output[Token_Pointer, 0]);
            }

            else
            {
                //print Expected_Add_Op_Operator_But_Not_Found
            }

        }



    }
}
