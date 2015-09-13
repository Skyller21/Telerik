using System;
using System.Text;
using System.Collections.Generic;

public class Person
{
	public Person (string firstname, string lastname,  int age, string town)
	{
		this.FirstName = firstname;

		this.LastName = lastname;

		this.Age = age;

		this.Town = town;

	}
	
	public string FirstName {get; set;}
	
	public string LastName {get; set;}
	
	public int Age {get; set;}
	
	public string Town {get; set;}
	
}

