using System;

namespace Bussen
{
	class Bus
	{
			const int max_number = 5;
			public Person [] passengers = new Person[max_number];
			public int number_passengers;

		
		public void Run()
		{
			
			int i;
			
			do
			{
				
				Console.WriteLine("");
				Console.WriteLine("*****************************************");
				Console.WriteLine("Welcome to the awesome SL-bus simulator!");
				Console.WriteLine("");
				Console.WriteLine("Menu:");
				Console.WriteLine("1.  Add passenger");
				Console.WriteLine("2.  Print bus");
				Console.WriteLine("3.  Print total age");
				Console.WriteLine("4.  Print average age");
				Console.WriteLine("5.  Print max age");
				Console.WriteLine("6.  Find age");
				Console.WriteLine("7.  Get off");
				Console.WriteLine("8.  Poke");
				Console.WriteLine("9.  Print sex");
				Console.WriteLine("10. Sort bus");
				Console.WriteLine("11. Exit simulator");
				Console.WriteLine("");
				Console.WriteLine("*****************************************");
				Console.WriteLine("");
				
				i = getMenuChoice();
				
				switch (i)
				{
					
					case 1:
						{
							add_passenger();
							break;
						}
					case 2:
						{
							print_bus();
							wait_for_key_and_clear();
							break;
						}
					case 3:
						{
							print_total_age();
							wait_for_key_and_clear();
							break;
						}
					case 4:
						{
							print_average_age();
							wait_for_key_and_clear();
							break;
						}
					case 5:
						{
							print_max_age();
							wait_for_key_and_clear();
							break;
						}
					case 6:
						{
							find_age();
							wait_for_key_and_clear();
							break;
						}
					case 7:
						{
							getting_off();
							wait_for_key_and_clear();
							break;
						}
					case 8:
						{
							poke();
							wait_for_key_and_clear();
							break;
						}
					case 9:
						{
							print_sex();
							wait_for_key_and_clear();
							break;
						}
					case 10:
						{
							sort_bus();
							wait_for_key_and_clear();
							break;
						}
					case 11:
						{
							Console.WriteLine("");
							Console.WriteLine("Exiting program.");
							Console.WriteLine("");
							break;
						}
				}
			} while( i >= 1 && i <= 10 ); //exit on 11
			
		}

		public int getMenuChoice()
		{
			int i = 0;
			
			do {
			
				Console.Write("Enter menu choice between 1 - 11: ");
				try
				{
					i = int.Parse(Console.ReadLine());
				}
				catch (System.FormatException ex)
				{
					Console.WriteLine("Incorrect choice.");
					Console.WriteLine("Error: " + ex.Message);
				}
					
			} while ( i < 1 || i > 11);
			
			return i; 
			
		}
		
		
		public void add_passenger()
		{
			
			//Check if bus is full
			if (number_passengers == max_number) {
				Console.WriteLine("");
				Console.WriteLine("Da bus is full!");
				Console.WriteLine("");
				
			} else {
				
				Console.WriteLine("");
				
				Person passenger = get_passenger();
				
				passengers[number_passengers] = passenger;
				
				number_passengers++;
				
			}

		}
		
		public void print_bus()
		{
			if (number_passengers == 0) {
				Console.WriteLine("");
				Console.WriteLine("Da bus is empty!");
				Console.WriteLine("");
				
			} else {
				
				Console.WriteLine("");
				
				int i = 0 ;
				do {
					Console.WriteLine("Passenger " + (i + 1) + ": " + passengers[i]);
					i++;
				} while (i < number_passengers);
				Console.WriteLine("");
			
			}
				
		}
		
		public void print_total_age()
		{
			int age;
			age = calc_total_age();
			
			Console.WriteLine("");
			Console.WriteLine("The total age is: " + age);
			Console.WriteLine("");
		}
		
		public void print_average_age()
		{
			double age;
			age = calc_average_age();
			
			Console.WriteLine("");
			Console.WriteLine("The average age is: " + age);
			Console.WriteLine("");
		}
		
		public int calc_total_age()
		{
			int totalAge = 0;
			int i = 0;
			
			do {
				totalAge = totalAge + passengers[i].age;
				i++;
			} while (i < number_passengers);
			
			return totalAge;
		}
		
		public double calc_average_age()
		{

			double averageAge = 0;
			int totalAge = 0;
			
			if (number_passengers > 0) {
				totalAge = calc_total_age();
				averageAge = (totalAge / number_passengers);
			}
			
			return averageAge;
		}
		
		public void print_max_age()
		{

			int maxAge = 0;
			int i = 0;
			
			do {	
				if (passengers[i].age >  maxAge) {
					maxAge = passengers[i].age;
				}
				
				i++;
			} while (i < number_passengers);
			
			
			Console.WriteLine("");
			Console.WriteLine("The max age is: " + maxAge);
			Console.WriteLine("");
		}
		
		public void find_age()
		{

			int age = 0;
			age = get_age();
			
			for (int i = 0; i < number_passengers; i++){
				if (age == passengers[i].age) {
					Console.WriteLine("Passenger " + (i + 1) + ": " + passengers[i]);
				}
			}
			
		}
		
		public string get_name()
		{
			string name = "";
			
			do {
			
				Console.Write("Enter name: ");
				name = Console.ReadLine();
					
			} while ( name == "" );
			
			return name; 
			
		}
		
		public int get_age()
		{
			int age = 0;
			
			do {
			
				Console.Write("Enter age between 1 - 120: ");
				try
				{
					age = int.Parse(Console.ReadLine());
				}
				catch (System.FormatException ex)
				{
					Console.WriteLine("Incorrect age.");
					Console.WriteLine("Error: " + ex.Message);
				}
					
			} while ( age < 1 || age > 120); //Only 1 - 120 year olds are allowed on the bus due to safety reasons.
			
			return age; 
			
		}
		
		public string get_sex()
		{
			string sex = "";
			
			do {
			
				Console.Write("Enter sex (M - Male, F - Female): ");
				sex = Console.ReadLine();
					
			} while ( sex != "M" && sex != "F" );
			
			return sex; 
			
		}
		
		public Person get_passenger()
		{
			Person p = new Person();
			
			p.name = get_name();
			p.age = get_age();
			p.sex = get_sex();
			
			return p; 
			
		}
		
		public void sort_bus()
		{

		    int needsSorting = 1;
		    
		    Console.WriteLine("Bus before sort:");
		    
		    print_bus();
		
		    //Create a loop that for each number should sort, cancel if the numbers are sorted
		    for (int i = 0; i < number_passengers - 1 && needsSorting == 1; i++)
		    {
		        //Signal that we are starting with a new sort
			    needsSorting = 0;
			
		        //Go through all the numbers and even the numbers that are sorted (variable i)
		        for (int j = 0; j < number_passengers - 1 - i; j++)
		        {
		            //Move the bigger numbers forward (to the front) of the array
		            if (passengers [j].age > passengers [j + 1].age)            
		            {
		                //Signal that we have to keep sorting
		                needsSorting = 1;
		                //Change seat
		                Person tmp = passengers [j + 1];
		                passengers [j + 1] = passengers [j];
		                passengers [j] = tmp;
		            }
		        }   //If we have not needed to sort any numbers, needsSorting == 0 and the loop will cancel
			}
		    Console.WriteLine("Bus after sort:");
		    print_bus();
		}
    

		public void print_sex()
		{

			Console.WriteLine("");
			Console.WriteLine("Printing males: ");
			
			for (int i = 0; i < number_passengers; i++){
				if (passengers[i].sex == "M"){
					Console.WriteLine(passengers[i]);
				}
			}
			Console.WriteLine("");
			
			Console.WriteLine("Printing females: ");
			
			for (int i = 0; i < number_passengers; i++){
				if (passengers[i].sex == "F"){
					Console.WriteLine(passengers[i]);
				}
			}	
			Console.WriteLine("");
			
		}	
		public void poke()
		{
		
			int number = 0;
			string pokeResponse = "";
			
			if (number_passengers == 0){
				Console.WriteLine("");
				Console.WriteLine("There are no passengers on the bus.");
				Console.WriteLine("");
			}
			else {
				Console.WriteLine("");
				print_bus();
				Console.WriteLine("");
				
				number = get_passenger_number();
				Console.WriteLine("Poking passenger: " + number);	
				pokeResponse = passengers[number - 1].poke();
				Console.WriteLine(pokeResponse);
				Console.WriteLine("");
			
			}
			
		}
		
		public void getting_off()
		{

			int number = 0;
			int index = 0;
			
			if (number_passengers == 0){
				Console.WriteLine("");
				Console.WriteLine("There are no passengers in the bus.");
				Console.WriteLine("");
			} else{
				
				print_bus();
				
				number = get_passenger_number();
				index = number - 1;
				if (number == number_passengers){
					passengers[index] = null;
					number_passengers--;
				} else{
					number_passengers--;
					for (int i = index; i < (max_number - 1); i++){
						if (i < number_passengers){
							passengers[i] = passengers[i + 1];
						}else {
							passengers[i] = null;
						}
						
					}
				}
				
				print_bus();
				
			}
			
		}	
		
		public int get_passenger_number()
		{
			int number = 0;
			
			do {
			
				Console.Write("Enter number between 1 - " + number_passengers + ": ");
				try
				{
					number = int.Parse(Console.ReadLine());
				}
				catch (System.FormatException ex)
				{
					Console.WriteLine("Incorrect number.");
					Console.WriteLine("Error: " + ex.Message);
				}
					
			} while ( number < 1 || number > number_passengers);
			
			return number; 
			
		}
		
		public void wait_for_key_and_clear()
		{
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			Console.Clear();
		}
		
		
	}
	class Person
	{
		public string name {get; set;}
		public int age {get; set;}
		public string sex {get; set;}
		
		public override string ToString()
		{
			string s = "";
			
			if (sex == "M") { 
				s = "Male";
			} else { 
				s = "Female";
			}
			
			return name + ", " + age + " years, " + s;
		} 
		
		public string poke(){
			string s;
			
			if (age < 5) {
				s = "Gagagagaga!";
			}else if (age < 18 && age >= 5){
				s = "I want to play soccer";			
			}else if (age < 24 && age >= 18){
				s = "I will be working with IT when I graduate college";
			}else if (age < 60 && age >= 24 && sex == "F"){
				s = "I'm now working at an IT- company, and I can afford the best beauty products!";
			}else if (age < 60 && age >= 24 && sex == "M"){
				s = "I'm now working on an oil rig, and I love to watch boxing.";
			}else if (age < 80 && age >= 60){
				s = "I want to retire soon..";
			}else if (age >= 80 && sex == "F"){
				s = "I have finally retired after working at an IT-company, but where are my löständers!?";
			}else if (age >= 80 && sex == "M"){
				s = "I have finally retired after working at an oil rig, but where are my löständers!?";
			}else { s = "should not be possible"; };
			
			return s;
		}
		
		
	}
	
	class Program
	{
		public static void Main(string[] args)
		{

			var myBus = new Bus();
			myBus.Run();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}