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
        private Parser_Node Node ;
         private Parser_Node Current_Node ;
        private bool If_Flag, Until_Flag;
        private TreeNode Tree_Node;
        private Form1 form1;
        private string Error;
        private int Number_Of_Errors;
        
        public Parser(String[,] Output, Form1 form1)
        { this.form1 = form1;
            this.Output = Output;
            this.Node = new Parser_Node("Program", "", new List<Parser_Node>());
            Number_Of_Errors = 0;
            Tree_Node = new TreeNode();
           
            If_Flag = false;
            Until_Flag = false;
            Current_Node = Node;
            Error = "";
            Stmt_Sequence();
            // Console.WriteLine(Get_Current_Token()=="-");
           
            Node.Print_Childs();
            Node.Populate_Treeview(Tree_Node);
          //  form1.Populate_Tree(Tree_Node);
            Form2 form2 = new Form2();
            form2.Text = "Syntax Tree";
            
            form2.Populate_Tree(Tree_Node);
           
            if (Number_Of_Errors > 0)
            {
                Form3 form3 = new Form3(Number_Of_Errors + " Errors Founds\n" + Error+"Please Note That This Errors May Lead To Wrong Syntax Tree");
                form3.Text = "Output";
                form3.Show();
            }
            else
            {
                Form3 form3 = new Form3("Compiled Successfully With No Errors");
                form3.Text = "Output";
                form2.Show();
                form3.Show();
               
            }
            // Output.
            //     Console.WriteLine(Parser_Node.Number_Seq);
            //for (int i = 0; i < Output.Length/2; i++)
            //{ 


            //    if (Get_Next_Token() == null) break;
            //    Console.WriteLine(Get_Current_Token());
            //}


        }
       
        // constructor  
      //  public Parser(String[,] Output) => this.Output = Output;

        String Get_Next_Token()
        {
            return Output[Token_Pointer+1, 0];
        }
        void Go_To_Next_Token()
        {
            Token_Pointer++;
        }

        String Get_Current_Token()
        {
            return Output[Token_Pointer, 0];
        }

        String Get_Current_Token_Value() 
        {
            return Output[Token_Pointer, 1];
        }


        Boolean Match(String Expected_Token, String Token)
        {
            if (Expected_Token == Token)
            {
              Current_Node.Add_Child( new Parser_Node(Get_Current_Token(),Get_Current_Token_Value(), new List<Parser_Node>()));
                return true;
            }
            return false;
            //if(!Expected_Token.Equals(Token)) // check this method // does it compare object location or String 
            //    throw new ParserException("Expected_"+Expected_Token+"_But_Not_Found");
        }


      


        void Stmt_Sequence() {
            Statement();

                while ((Get_Current_Token() == ";" && Get_Next_Token() != null )|| (If_Flag==true&&Get_Current_Token()!=null)|| (Until_Flag == true && Get_Current_Token() != null))
            {
                if ((Until_Flag == true && Get_Current_Token() != null)|| (If_Flag == true && Get_Current_Token() != null))
                {
                    If_Flag = false;
                    Until_Flag = false;
                    Token_Pointer--;

                }
                //if () 
                //{
                //    If_Flag = false;
                //}
              
                Go_To_Next_Token();
               
                if (Statement())
                {
                   
                   
                    Console.WriteLine("Right Statment");
                }
                else
                {
                    if (Get_Current_Token_Value()!=Token.UNTIL&& Get_Current_Token_Value() != Token.END)
                    {
                          Console.WriteLine("Error");
                       
                     //   break;
                    }

                }
            }
        
        }
        bool Statement() {

            if (If_Stmt()) return true;
            if (Repeat_Stmt()) return true;
           
            if (Read_Stmt()) return true;
           if (Write_Stmt()) return true;
            if (Assign_Stmt()) return true;
          
            return false;

        }
       
        

        // if exp then stmt-sequence [else stmt-sequence] end
        bool If_Stmt()
        {
            //treeView1.n
            Parser_Node Previous_Node = Current_Node;

            if (!Match(Token.IF, Get_Current_Token_Value())) return false;

                Current_Node = Current_Node.Get_Last_Child();
            Go_To_Next_Token();
            if (!Exp()) { Current_Node = Previous_Node; Number_Of_Errors++; Error += "The Condition Of The If Statement Is Missing\n";  }


            if (Match(Token.THEN, Get_Current_Token_Value())) { Current_Node.Remove_Child(Current_Node.Get_Last_Child()); }
            else
            { Current_Node = Previous_Node;
                Number_Of_Errors++;
                Error += "Missing Then In The If Statement\n";
                
                 }
            Go_To_Next_Token();
            Stmt_Sequence();

            if (Get_Current_Token_Value() == Token.ELSE)
            {
                Match(Token.ELSE, Get_Current_Token_Value());
                Go_To_Next_Token();
                Stmt_Sequence();
            }
            if (Match(Token.END, Get_Current_Token_Value())) { Current_Node.Remove_Child(Current_Node.Get_Last_Child()); } else { Current_Node = Previous_Node;
                Number_Of_Errors++; Error += "The End Of The If Statement Is Missing\n";
            }
            Go_To_Next_Token();
            Current_Node = Previous_Node;
            If_Flag = true;
            return true;
            // accept if no errors occured
        }
            
       
        bool Repeat_Stmt()
        {
           
            Parser_Node Previous_Node = Current_Node;
          if(  !Match(Token.REPEAT, Get_Current_Token_Value()))return false;
            Go_To_Next_Token();

            Current_Node = Current_Node.Get_Last_Child();

           
            Stmt_Sequence();
           if(Match(Token.UNTIL, Get_Current_Token_Value())) { Current_Node.Remove_Child(Current_Node.Get_Last_Child()); }
            else
            {
                Current_Node = Previous_Node;
                Number_Of_Errors++;
                Error += "Missing Until In The Repeat Statement\n";

            }
            Go_To_Next_Token();
            if(!Exp()){ Current_Node = Previous_Node; Number_Of_Errors++;
                Error += "Repeat Condition Is Missing\n";
            }

            Current_Node = Previous_Node;
            Until_Flag = true;
                return true;

            
            
        }

        bool Assign_Stmt()
        {
            Parser_Node Previous_Node = Current_Node;
            Parser_Node ASS = new Parser_Node("Assignment_Statement("+Get_Current_Token()+")", "", new List<Parser_Node>());
            Current_Node.Add_Child(ASS);
            Current_Node = ASS;
            if (!Match(Token.ID, Get_Current_Token_Value())) {Current_Node=Previous_Node; Current_Node.Remove_Child(ASS); return false; }
            Current_Node.Remove_Child(Current_Node.Get_Last_Child());
            Go_To_Next_Token();
           // Current_Node = Current_Node.Get_Last_Child();
            if (Match(Token.ASSIGNMENT, Get_Current_Token_Value()))// { Current_Node = Previous_Node; Current_Node.Remove_Child(ASS); return false; }
            { Current_Node.Remove_Child(Current_Node.Get_Last_Child()); }
            else
            {
                Current_Node = Previous_Node;
                Number_Of_Errors++;
                Error += "Missing Assignment Operator In The Assignment Statement\n";

            }
          //  Current_Node.Remove_Child(Current_Node.Get_Last_Child());
            Go_To_Next_Token();
            if(!Exp()){ Current_Node = Previous_Node; Current_Node.Remove_Child(ASS);  Number_Of_Errors++;
                Error += "Missing Identifier After The Assignment Statement\n";
            }
            Current_Node = Previous_Node;
          
                return true;

           
        }

        bool Read_Stmt()
        {
            Parser_Node Previous_Node = Current_Node;
          if( ! Match(Token.READ, Get_Current_Token_Value()))return false;
            Go_To_Next_Token();
            Current_Node = Current_Node.Get_Last_Child();

            if (!Match(Token.ID, Get_Current_Token_Value())) { Current_Node = Previous_Node; Number_Of_Errors++;
                Error += "Missing Identifier After The Read Statement\n";
            }
            Go_To_Next_Token();

            Current_Node = Previous_Node;
            
                return true;

           
        }

        //  write exp //done
        bool Write_Stmt()
        {
            Parser_Node Previous_Node = Current_Node;
            if(!Match(Token.WRITE, Get_Current_Token_Value()))return false;
            Go_To_Next_Token();
            Current_Node = Current_Node.Get_Last_Child();
            if(!Exp()){ Current_Node = Previous_Node; Number_Of_Errors++;
                Error += "Missing Identifier After The Write Statement\n";
            }
            Current_Node = Previous_Node;
           
                return true;

           
        }

        bool Exp()
        {
            if (SimpleExp())
            {
                if (Get_Current_Token() == "=" || Get_Current_Token() == ">" || Get_Current_Token() == "<")
                {
                    Parser_Node Before_Entering_Comparison = Current_Node;
                    if (Comparison_Op()&& SimpleExp())
                    {
                        Current_Node = Before_Entering_Comparison;
                        return true;
                    }
                    else
                    {
                        Number_Of_Errors++;
                        Error += "Missing Identifier After Comparison Operation\n";
                       // return false;
                    }
                  
                }
                return true;
            }
            return false;
        }

        bool SimpleExp()
        {
            if (Term())
            {
             //   string test = Get_Current_Token();
                if (Get_Current_Token() == "+" || Get_Current_Token() == "-")
                {
                    Parser_Node Before_Entering_Op = Current_Node;

                    if (Add_Op()&&SimpleExp())
                    {
                        Current_Node = Before_Entering_Op;
                        return true;
                        
                    }
                    else
                    {
                        Number_Of_Errors++;
                        Error += "Missing Identifier After Arithmatic Operation\n";
                       // return false;
                    }
                   
                }
                return true;
            }
            return false;
        }

        bool Term()
        {
            if (Factor())
            {
                if (Get_Current_Token() == "*" || Get_Current_Token() == "/")
                {
                    Parser_Node Before_Entering_Op = Current_Node;
                    if (Mul_Op()&&Term())
                    {
                        Current_Node = Before_Entering_Op;
                        return true;
                    }
                    else
                    {
                        Number_Of_Errors++;
                        Error += "Missing Identifier After Arithmatic Operation\n";
                     //   return false;
                    }
                   
                }
                return true;
            }
            return false;

        }
        bool Factor()
        {

            if (Match(Token.Number,Get_Current_Token_Value()))
            {
                Go_To_Next_Token();
                return true;
            }
            else if (Match(Token.ID, Get_Current_Token_Value()))
            {
                Go_To_Next_Token();
                return true;

            }
            else if (Match("(",Get_Current_Token()))
            {
                Go_To_Next_Token();
                if (Exp())
                {
                    if (!Match(")", Get_Current_Token()))
                    {
                        Number_Of_Errors++;
                        Error += "Missing Closing ) After opening it\n";
                    }
                    else
                    {
                        Go_To_Next_Token();
                    }
                    
                    return true;
                }
                

            }
         
            return false;
        }

        bool Mul_Op()
        {
            
            if (Match("*", Get_Current_Token())  || Match("/", Get_Current_Token()))
            {
                Parser_Node Before_Operation = Current_Node.Get_Second_Last_Child();
                Current_Node.Remove_Child(Before_Operation);
                Current_Node.Get_Last_Child().Change_Name("Arithmatic Operation(" + Current_Node.Get_Last_Child().Get_Name() + ")");
                Current_Node = Current_Node.Get_Last_Child();
                Current_Node.Add_Child(Before_Operation);
                Go_To_Next_Token();
                return true;
            }
            
            return false;



        }

        bool Add_Op()
        {
            if (Match("+", Get_Current_Token()) || Match("-", Get_Current_Token()))
            {
                Parser_Node Before_Operation= Current_Node.Get_Second_Last_Child();
                Current_Node.Remove_Child(Before_Operation);
                Current_Node.Get_Last_Child().Change_Name("Arithmatic Operation(" + Current_Node.Get_Last_Child().Get_Name() + ")");
                Current_Node = Current_Node.Get_Last_Child();
                Current_Node.Add_Child(Before_Operation);
                Go_To_Next_Token();
                return true;
            }
            return false;

        }

        bool Comparison_Op()
        {
            if (Match(">", Get_Current_Token()) || Match("<", Get_Current_Token()) || Match("=", Get_Current_Token()))
            {
                Parser_Node Before_Comparison = Current_Node.Get_Second_Last_Child();
                Current_Node.Remove_Child(Before_Comparison);
                Current_Node.Get_Last_Child().Change_Name("Comparison Operation(" + Current_Node.Get_Last_Child().Get_Name() + ")");
                Current_Node = Current_Node.Get_Last_Child();
                Current_Node.Add_Child(Before_Comparison);
                Go_To_Next_Token();
                return true;
            }
            return false;



        }
        // start node at the start of the function
        // child after every match
        // when new method is called start a new node   
        // when a function ends makes new tree node
    }
}
