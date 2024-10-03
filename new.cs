using System;
using System.Collections.Generic;

namespace AdminManagement
{
    public class Student
    {
        // Private fields
        private int studentId;
        private string name;
        // Protected field
        protected string contact;

        // Constructor
        public Student(int studentId, string name, string contact)
        {
            this.studentId = studentId;
            this.name = name;
            this.contact = contact;
        }

        // Public methods to access private fields
        public int GetStudentId()
        {
            return studentId;
        }

        public string GetName()
        {
            return name;
        }

        public void UpdateContact(string newContact)
        {
            contact = newContact;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"ID: {studentId}, Name: {name}, Contact: {contact}");
        }
    }

    public class Admin : Student
    {
        public Admin(int studentId, string name, string contact)
            : base(studentId, name, contact)
        {
        }
    }

    class Program
    {
        static void ClassifyById(List<Admin> adminList)
        {
            // Instead of using a dictionary, use arrays for the ID prefixes (19, 20, 21, 22)
            int[] prefixCount = new int[4];  // To store counts for prefixes 19, 20, 21, 22 respectively

            foreach (var admin in adminList)
            {
                int prefix = admin.GetStudentId() / 100000;
                switch (prefix)
                {
                    case 19:
                        prefixCount[0]++;
                        break;
                    case 20:
                        prefixCount[1]++;
                        break;
                    case 21:
                        prefixCount[2]++;
                        break;
                    case 22:
                        prefixCount[3]++;
                        break;
                }
            }

            Console.WriteLine("Classification by ID Prefix:");
            Console.WriteLine($"Prefix 19: {prefixCount[0]} admins");
            Console.WriteLine($"Prefix 20: {prefixCount[1]} admins");
            Console.WriteLine($"Prefix 21: {prefixCount[2]} admins");
            Console.WriteLine($"Prefix 22: {prefixCount[3]} admins");
        }

        static void ClassifyByDepartment(List<Admin> adminList)
        {
            // Instead of using a dictionary, use an array for department codes (CE, EEE, ME, CSE)
            int[] deptCount = new int[4];  // To store counts for CE, EEE, ME, CSE respectively

            foreach (var admin in adminList)
            {
                int deptCode = (admin.GetStudentId() % 100000) / 1000;
                switch (deptCode)
                {
                    case 1:
                        deptCount[0]++;
                        break;
                    case 2:
                        deptCount[1]++;
                        break;
                    case 3:
                        deptCount[2]++;
                        break;
                    case 4:
                        deptCount[3]++;
                        break;
                }
            }

            Console.WriteLine("Classification by Department:");
            Console.WriteLine($"CE: {deptCount[0]} admins");
            Console.WriteLine($"EEE: {deptCount[1]} admins");
            Console.WriteLine($"ME: {deptCount[2]} admins");
            Console.WriteLine($"CSE: {deptCount[3]} admins");
        }

        static void Main(string[] args)
        {
            List<Admin> adminList = new List<Admin>();

            while (true)
            {
                Console.WriteLine("\n1: Add Admin\n2: Show All Admins\n3: Search by ID\n4: Update Contact by ID\n5: Remove by ID\n6: Classify by ID\n7: Classify by Department\n8: Exit");
                Console.Write("Choose an option: ");
                if (!int.TryParse(Console.ReadLine(), out int nm))
                {
                    Console.WriteLine("Invalid option, please enter a number.");
                    continue;
                }

                switch (nm)
                {
                    case 1:  // Add Admin
                        Console.Write("Enter Admin ID (6 digits): ");
                        if (!int.TryParse(Console.ReadLine(), out int studentId))
                        {
                            Console.WriteLine("Invalid ID format.");
                            continue;
                        }
                        Console.Write("Enter Admin Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Admin Contact: ");
                        string contact = Console.ReadLine();
                        adminList.Add(new Admin(studentId, name, contact));
                        Console.WriteLine("Admin added successfully.");
                        break;

                    case 2:  // Show All Admins
                        if (adminList.Count > 0)
                        {
                            Console.WriteLine("Admin List:");
                            foreach (var admin in adminList)
                            {
                                admin.ShowDetails();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No admins in the list.");
                        }
                        break;

                    case 3:  // Search by ID
                        Console.Write("Enter Admin ID to search: ");
                        if (!int.TryParse(Console.ReadLine(), out int searchId))
                        {
                            Console.WriteLine("Invalid ID format.");
                            continue;
                        }
                        var foundAdmin = adminList.Find(admin => admin.GetStudentId() == searchId);
                        if (foundAdmin != null)
                        {
                            foundAdmin.ShowDetails();
                        }
                        else
                        {
                            Console.WriteLine("Admin not found.");
                        }
                        break;

                    case 4:  // Update Contact by ID
                        Console.Write("Enter Admin ID to update contact: ");
                        if (!int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.WriteLine("Invalid ID format.");
                            continue;
                        }
                        var adminToUpdate = adminList.Find(admin => admin.GetStudentId() == updateId);
                        if (adminToUpdate != null)
                        {
                            Console.Write("Enter new contact: ");
                            string newContact = Console.ReadLine();
                            adminToUpdate.UpdateContact(newContact);
                            Console.WriteLine("Contact updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Admin not found.");
                        }
                        break;

                    case 5:  // Remove by ID
                        Console.Write("Enter Admin ID to remove: ");
                        if (!int.TryParse(Console.ReadLine(), out int removeId))
                        {
                            Console.WriteLine("Invalid ID format.");
                            continue;
                        }
                        var adminToRemove = adminList.Find(admin => admin.GetStudentId() == removeId);
                        if (adminToRemove != null)
                        {
                            adminList.Remove(adminToRemove);
                            Console.WriteLine("Admin removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Admin not found.");
                        }
                        break;

                    case 6:  // Classify by ID Prefix
                        ClassifyById(adminList);
                        break;

                    case 7:  // Classify by Department
                        ClassifyByDepartment(adminList);
                        break;

                    case 8:  // Exit
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option, please choose a valid one.");
                        break;
                }
            }
        }
    }
}
