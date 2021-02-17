using System;
					
public class clientServerApplication
{
	// Writes user's information to .txt file. Displays status of writing operation.
	public void writeToTxt(string[] userInput)
	{
		Console.WriteLine("User Input Saving.");
		Console.WriteLine("Printing user's information.");
		for(int i = 0; i < userInput.Length; i++)
		{
			Console.WriteLine(userInput[i]);
		}
		
		try
		{
			// Write user info to .txt file and saved to "FILE_PATH"
			System.IO.File.WriteAllLines("FILE_PATH", userInput);
		} catch (Exception e) {
			// Failed status of save to file operation
			Console.WriteLine("Saving Failed.");
		}
		Console.WriteLine("Saving Success.");
	}
	
	// Accepts user's input and validates with user if inputted info is correct.
	public void userInput()
	{
		Console.WriteLine("Enter first name: ");
		string firstName = Console.ReadLine();
		Console.WriteLine("Enter last name: ");
		string lastName = Console.ReadLine();
		Console.WriteLine("Enter date of birth: ");
		string dateOfBirth = Console.ReadLine();
		Console.WriteLine("Enter email address: ");
		string emailAddress = Console.ReadLine();
		Console.WriteLine("Enter phone number: ");
		string phoneNumber = Console.ReadLine();
		
		
		Console.WriteLine("Your first name is: " + firstName);
		Console.WriteLine("Your last name is: " + lastName);
		Console.WriteLine("Your date of birth is: " + dateOfBirth);
		Console.WriteLine("Your email address is: " + emailAddress);
		Console.WriteLine("Your phone number is: " + phoneNumber);
		
		// Validate user input
		do
		{
			Console.WriteLine("Is the entered information correct? (Y/N): ");
			string userCorrectInput = Console.ReadLine();
			
			if(userCorrectInput == "Y")
			{				
				string[] lines = 
				{
					firstName, lastName, dateOfBirth, emailAddress, phoneNumber
				};
				
				// Save user info to file or a SQL server database based on configuration
				writeToTxt(lines);
				break;
			}
			else if(userCorrectInput == "N")
			{
				userInput();
				break;
			}
		}while(true);
	}
	
	// Retrieve data from a file. Display data to user.
	public void read()
	{
		string[] lines = System.IO.File.ReadAllLines(@"FILE_PATH");
		
		foreach (string line in lines)
        {
            Console.WriteLine("\t" + line);
        }
	}
	
	public static void Main()
	{
		do
		{
			clientServerApplication client = new clientServerApplication();
			
			Console.WriteLine("Enter command (Write/Read/Quit): ");
			string commandInput = Console.ReadLine();
			
			if(commandInput == "Write" || commandInput == "write" || commandInput == "W" || commandInput == "w")
			{
				client.userInput();
			}
			else if(commandInput == "Read" || commandInput == "read" || commandInput == "R" || commandInput == "r")
			{
				// Instructs the server to retrieve and send all information stored in the file or database (based on configuration) back to the client
				client.read();
			}
			else if(commandInput == "Quit" || commandInput == "quit" || commandInput == "Q" || commandInput == "q")
			{
				return;
			}
			
		}while(true);
	}
}