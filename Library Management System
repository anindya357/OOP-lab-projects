using System;
using System.Collections.Generic;


class Book {
   private string title;
   private string author;
   private int yearPublished;
   
   
    public Book(string title,string author, int yearPublished )
    {
        this.title=title;
        this.author= author;
        this.yearPublished=yearPublished;
    }
    public int set_year(int ny)
    {
        yearPublished=ny;
        return yearPublished;
    }
    public string GetTitle()
    {
       return title;
    }
    public string AuthorName()
    {
        return author;
    }
    public int Year()
    {
        return yearPublished;
    }

}

class Library:Book {

      private List<Book> list= new list<Book>();

      public void AddBook()
      {
        Console.WriteLine("Enter the Name of the Book:");
        string new_book= Console.ReadLine();
        Console.WriteLine("Enter the Name of Author:");
        string new_author= Console.ReadLine();
        Console.WriteLine("Enter the Published Year:");
        int year= int.Parse(Console.ReadLine());
        
        list.Add(new Book(new_book, new_author, year));
      }
        public void GetBooks()
        {
          for (int i=0; i<list.Count; i++)
          {
            Console.WriteLine(list[i].GetTitle()+"  "+ list[i].AuthorName()+"  "+list[i].Year())
          }
        }
      public int TotalBooks()
      {
          return list.Count();
      }

      public void delete_book()
      {
        Console.WriteLine("Enter the name of the book and the author name to be deleted : ");
        string to_delete= Console.ReadLine();
        string author_delete= Console.ReadLine();
        for(int i=0;i<list.Count;i++)
        {
            if((list[i].GetTitle()==to_delete)&&(list[i].AuthorName()==author_delete)) 
            {
                list.RemoveAt(i);
                break;
            }
        }
     }


     public void update_year()
     {
        Console.WriteLine("Enter the name of the book and the author name to be updated : ");
        string to_update= Console.ReadLine();
        string author_update= Console.ReadLine();
        int flag=1;
        for(int i=0;i<list.Count;i++)
        {
            if((list[i].GetTitle()==to_update)&&(list[i].AuthorName()==author_update)) 
            {
                Console.WriteLine("Enter New Year:");
                int ny= int.Parse(Console.ReadLine());
                Console.WriteLine("Year is Updated");
                flag=0;
                break;
            }
            
        }
        if(flag==1) Console.WriteLine("Book not found");
     }

}

class Program {

       static void Main(){

          Book book = new Book();
          Library library= new Library();

            
            while(true) 
        {
                
           Console.WriteLine("1. Add Book");
           Console.WriteLine("2. Delete Book");
           Console.WriteLine("3. Update Year Published");
           Console.WriteLine("4. Total Books ");
           Console.WriteLine("5. Exit ");
           Console.WriteLine("Enter an Option:");
           int option=int.Parse(Console.ReadLine());
           if(option==1)
           
           {
            library.AddBook();
           }
           else if(option==2) {
              library.delete_book();
           }
           else if (option==3)
           {
             library.update_year();
           }
           else if (option==4)
           {
            Console.WriteLine(library.TotalBooks());
           }
           else if (option ==5 )
           {
            Console.WriteLine("Exiting...");
            break;
           }

        }
    }


}

