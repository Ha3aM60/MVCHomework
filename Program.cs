//Model for Note 
public class Note
{
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime CreationDate { get; set; }
    public List<string> Tags { get; set; }
    public Note()
    {

    }

    public Note(string title, string text, List<string> tags)
    {
        Title = title;
        Text = text;
        CreationDate = DateTime.Now;
        Tags = tags;
    }

    public override string ToString()
    {
        string tags = string.Join(", ", Tags);
        return $"Title: {Title}\nText: {Text}\nCreation date: {CreationDate}\nTags: {tags}";
    }
}

//Controller for Note
public class NotesController
{
    private List<Note> notes;

    public NotesController()
    {
        notes = new List<Note>();
    }

    public void AddNote()
    {
        Console.WriteLine("Enter note title:");
        string title = Console.ReadLine();
        Console.WriteLine("Enter note text:");
        string text = Console.ReadLine();
        Console.WriteLine("Enter tags separated by comma:");
        string tagsStr = Console.ReadLine();
        List<string> tags = tagsStr.Split(',').Select(t => t.Trim()).ToList();

        Note note = new Note
        {
            Title = title,
            Text = text,
            Tags = tags,
            CreationDate = DateTime.Now
        };

        notes.Add(note);
    }

    public void ShowNotes()
    {
        Console.WriteLine("Notes:");
        foreach (Note note in notes)
        {
            Console.WriteLine(note.ToString());
        }
    }

    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Note note in notes)
            {
                writer.WriteLine(note.Title);
                writer.WriteLine(note.Text);
                writer.WriteLine(note.CreationDate.ToString());
                writer.WriteLine(string.Join(",", note.Tags));
            }
        }
    }

    public void LoadFromFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                Note note = new Note();
                note.Title = reader.ReadLine();
                note.Text = reader.ReadLine();
                note.CreationDate = DateTime.Parse(reader.ReadLine());
                string tagsStr = reader.ReadLine();
                note.Tags = tagsStr.Split(',').Select(t => t.Trim()).ToList();

                notes.Add(note);
            }
        }
    }
}

//Model for Contact
public class Contact
{
    public string NameOfContact { get; set; }
    public string PhoneNumber { get; set; }
    public string AlternativePhone { get; set; }
    public string Email { get; set; }
    public string OtherInfo { get; set; }
    public Contact()
    {

    }

    public Contact(string name, string phone, string phone2, string email, string info)
    {
        NameOfContact = name;
        PhoneNumber = phone;
        AlternativePhone = phone2;
        Email = email;
        OtherInfo = info;
    }

    public override string ToString()
    {
        
        return $"Name: {NameOfContact}\nNumber of phone: {PhoneNumber}\nSecond number of phone: {AlternativePhone}\nEmail: {Email}\n Description: {OtherInfo}";
    }
}

//Controller for Contact
public class ContactController
{
    private List<Contact> contacts;

    public ContactController()
    {
        contacts = new List<Contact>();
    }

    public void AddContact()
    {
        Console.WriteLine("Enter name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter phone number:");
        string phoneN = Console.ReadLine();
        Console.WriteLine("Enter second phone number:");
        string phoneN1 = Console.ReadLine();
        Console.WriteLine("Enter email:");
        string email = Console.ReadLine();
        Console.WriteLine("Enter other info:");
        string otherInfo = Console.ReadLine();


        Contact contact = new Contact
        {
            NameOfContact = name,
            PhoneNumber = phoneN,
            AlternativePhone = phoneN1,
            Email = email,
            OtherInfo = otherInfo,
        };

        contacts.Add(contact);
    }

    public void ShowContacts()
    {
        Console.WriteLine("Contacts:");
        foreach (Contact item in contacts)
        {
            Console.WriteLine(item.ToString());
        }
    }

    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Contact item in contacts)
            {
                writer.WriteLine(item.NameOfContact);
                writer.WriteLine(item.PhoneNumber);
                writer.WriteLine(item.AlternativePhone);
                writer.WriteLine(item.Email);
                writer.WriteLine(item.OtherInfo);
            }
        }
    }

    public void LoadFromFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                Contact contact = new Contact();
                contact.NameOfContact = reader.ReadLine();
                contact.PhoneNumber = reader.ReadLine();
                contact.AlternativePhone = reader.ReadLine();
                contact.Email = reader.ReadLine();
                contact.OtherInfo = reader.ReadLine();


                contacts.Add(contact);
            }
        }
    }
}

//Main
internal partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть завдання:");
        Console.WriteLine("1. 1-2 завдання");
        Console.WriteLine("2: 3-4 завдання");
        string tmp = Console.ReadLine();
        if(tmp == "1")
        {
            NotesController controller = new NotesController();

            while (true)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Add note");
                Console.WriteLine("2. Show");
                Console.WriteLine("3. Save to file");
                Console.WriteLine("4. Read from file");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        controller.AddNote();
                        break;
                    case "2":
                        controller.ShowNotes();
                        break;
                    case "3":
                        controller.SaveToFile("notes.txt");
                        break;
                    case "4":
                        controller.LoadFromFile("notes.txt");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choise. try again.");
                        break;
                }
                Console.WriteLine();
            }
        }
        else if (tmp == "2")
        {
            ContactController controller = new ContactController();

            while (true)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Add contact");
                Console.WriteLine("2. Show");
                Console.WriteLine("3. Save to file");
                Console.WriteLine("4. Read from file");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        controller.AddContact();
                        break;
                    case "2":
                        controller.ShowContacts();
                        break;
                    case "3":
                        controller.SaveToFile("contacts.txt");
                        break;
                    case "4":
                        controller.LoadFromFile("contacts.txt");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choise. try again.");
                        break;
                }
                Console.WriteLine();
            }
        }



    }
}


