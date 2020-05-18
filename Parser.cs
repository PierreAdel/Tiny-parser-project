using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace projectScanner
{
    class Parser
    {
        private System.Windows.Forms.TreeView treeView1;
        private String[,] Output;
        private int Token_Pointer = 0;
        private String[] Accepted_Tokens;
        private int Accepted_Token_Pointer = 0;

        // constructor  
        public Parser(String[,] Output) => this.Output = Output;

        String Get_Next_Token()
        {
            return Output[Token_Pointer++, 0];
        }

        String Get_Current_Token()
        {
            return Output[Token_Pointer, 0];
        }

        String Get_Token_Value() 
        {
            return Output[Token_Pointer, 1];
        }


        void Match(String Expected_Token, String Token)
        {
            if (Expected_Token == projectScanner.Token.ID)
            {
                Token = Token.Substring(0, 2);
            }
            if(!Expected_Token.Equals(Token)) // check this method // does it compare object location or String 
                throw new ParserException("Expected_"+Expected_Token+"_But_Not_Found");
        }


        void Add_Accepted_Token(String Token)
        {
            Accepted_Tokens[Accepted_Token_Pointer++] = Token;
        }




        void Comparison_Op()
        {
            String Current_Token = Get_Current_Token();
            if (Current_Token == "=" || Current_Token == ">" || Current_Token  == "<")
                Add_Accepted_Token(Output[Token_Pointer, 0]);

            else
                throw new ParserException("Expected_Comparison_Operator_But_Not_Found");



        }
        void Mul_Op()
        {
            String Current_Token = Get_Current_Token();
            if (Current_Token == "*" || Current_Token == "/")
            {
                Add_Accepted_Token(Output[Token_Pointer, 0]);
            }

            else
                throw new ParserException("Expected_Mul_Op_Operator_But_Not_Found");
            

        }
    
        void Add_Op()
        {
            String Current_Token = Get_Current_Token();
            if (Current_Token == "+" || Current_Token == "-")
            {
                Add_Accepted_Token(Output[Token_Pointer, 0]);
            }

            else
                throw new ParserException("Expected_Add_Op_Operator_But_Not_Found");
            

        }

        // if exp then stmt-sequence [else stmt-sequence] end
        void If_Stmt()
        {
            //treeView1.n
            String current = Get_Current_Token();
            Match(Token.IF,current);
            exp();
            Match(Token.THEN, Get_Next_Token());
            Stmt_Sequence();

            if (Get_Next_Token() == Token.ELSE)
            {
                Match(Token.ELSE, Get_Current_Token());
                Stmt_Sequence();
            }

            // accept if no errors occured
        }
            
       
        void Repeat_Stmt()
        {
            String current = Get_Current_Token();
            Match(Token.REPEAT, current);
            Stmt_Sequence();
            Match(Token.UNTIL, Get_Next_Token());
            exp();
 

        }

        void Assign_Stmt()
        {
            String current = Get_Current_Token();
            // match(TOKEN.ID);
            Match(Token.ASSIGNMENT, Get_Next_Token());
            exp();
                
        }

        void Read_Stmt()
        {

            Match(Token.READ, Get_Current_Token());
           // match(TOKEN.ID);
        }

        //  write exp //done
        void Write_Stmt()
        {
            Match(Token.WRITE, Get_Current_Token());
            exp();
        }
        
        void exp() { }
        void Stmt_Sequence() { }

        // start node at the start of the function
        // child after every match
        // when new method is called start a new node   
        // when a function ends makes new tree node
    }
}
