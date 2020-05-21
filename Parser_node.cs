using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectScanner
{
    class Parser_Node
    {
        private string Node_Name;
        private string Node_Value;
        //       private Parser_node[] Childs;
        static private int Number_Seq=0;
         private int Number;
        private List<Parser_Node> Childs;

        public Parser_Node(string node_Name, string node_Value, List<Parser_Node> childs)
        {
            Number = Number_Seq;
            Number_Seq ++;
            Node_Name = node_Name;
            Node_Value = node_Value;
            Childs = childs;
        }

        public void Change_Name(String Name) {
            Node_Name = Name;
        
        }
        public String  Get_Name()
        {
            return Node_Name ;

        }
        public void Print_Childs(Parser_Node Parent=null)
        {
            if (Parent == null)
                Console.WriteLine("Node Number:" + Number + " Node Name:" + Node_Name + " This Node Has No Parent");
            else Console.WriteLine("Node Number:" + Number + " Node Name:" + Node_Name + " Node Parent Name:" + Parent.Node_Name
                + " Node Parent Number:" + Parent.Number);
            for (int i = 0; i < Childs.Count(); i++)
            {
             
                    Childs[i].Print_Childs(this);

            }

        }
        public void Populate_Treeview(TreeNode Parent)
        {
           
            TreeNode My_Tree_Node = new TreeNode();
          
            My_Tree_Node.Text = this.Node_Name;
            for (int i = 0; i < Childs.Count(); i++)
            {

                Childs[i].Populate_Treeview(My_Tree_Node);

            }
            Parent.Nodes.Add(My_Tree_Node);
        }

            public void Remove_Child(Parser_Node Node)
        {
            Childs.Remove(Node);

        }
        public int Get_Number_Of_Childs()
        {
           return Childs.Count();

        }
        public void Add_Child(Parser_Node node) {
            Childs.Add(node);
        
        }
        public Parser_Node Get_Last_Child()
        {
            return Childs[Childs.Count()-1];

        }
        public Parser_Node Get_Second_Last_Child()
        {
            return Childs[Childs.Count() - 2];

        }


        
    }
}
