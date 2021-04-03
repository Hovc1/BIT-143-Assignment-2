using System;
using System.Collections.Generic;
using System.Text;

// Christopher Hovsepian  BIT 143  2019 Fall  A2.0

namespace Helpdesk
{
    class History
    {

        protected class LLNode
        {
            public LLNode(string x)
            {
                data = x;
            }
            public LLNode(){}//def con.
            public string data;//web page name
            public LLNode next;
        }
        protected LLNode backbutton;
        protected LLNode fwdbutton;




        public void PrintAll()  //  This is O(N)  because we do not know how long the link list is
        {
            Console.WriteLine("History:");
            Console.WriteLine("Previously visited pages:");
            LLNode temp = backbutton;  //  this makes a temp that takes the backbutton data
            while (temp != null)
            {
                Console.WriteLine(temp.data);  //  this takes the copied backbutton data and prints it
                temp = temp.next;  //  this dumps the coppied data we just printed, and modes us to the next node in the chain
            }

            Console.WriteLine("Pages in your 'future':");
            temp = fwdbutton;
            while (temp != null)
            {
                Console.WriteLine(temp.data);
                temp = temp.next;
            }
        }

         
        //  this is O(1)
        public void MoveBackwards()
        {
            if (backbutton == null)
                return;
            else if (fwdbutton == null)
            {
                LLNode temp = new LLNode(backbutton.data);
                fwdbutton = temp;
                backbutton = backbutton.next; 
            } 
            else
            {
                LLNode temp = new LLNode(backbutton.data);  //   makes a temp node and copys backbutton's data
                temp.next = fwdbutton;  //  this links the new copy to the fwdbutton node chain
                fwdbutton = temp;  //  this links the fwdbutton directory to our new (coppied) node (now at the head of the chain)
                backbutton = backbutton.next;  //  this gets rid of the origional thing we coppied on line 69
            }
        }

        // this is O(1)
        public void MoveForwards()
        {
            
            if (fwdbutton == null)
                return;
            else
            {
                LLNode temp = new LLNode(fwdbutton.data);  //   makes a temp node and copys fwdbutton's data
                temp.next = backbutton;  //  this links the new copy to the backbutton node chain
                backbutton = temp;  //  this links the backbutton directory to our new node at the front
                fwdbutton = fwdbutton.next;  //  this dumps the origional thing we coppied on line 84
            }


        }

        // this is O(1)
        public void VisitPage(string desc)
        {
            if (backbutton == null)
            {
                LLNode currentWeb = new LLNode(desc);
                backbutton = currentWeb;
                fwdbutton = null;
            }  
            else
            {
                LLNode currentWeb = new LLNode(desc);  //  makes a temp node with the imputed data
                currentWeb.next = backbutton;  //  this links the new node to the backbutton chain
                backbutton = currentWeb;  //  this links our temp (currentweb) directory to backbutton
                fwdbutton = null;  //  this clears out fwdbutton
            }
        }
    }//////////////////////////
}//////////////////////////////
