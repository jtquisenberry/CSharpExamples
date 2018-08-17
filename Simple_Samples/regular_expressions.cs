using System;
using System.Data;
using System.Data.Sql;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Collections;

public class Program
{
	public static void Main()
	{
		//Console.WriteLine("Hello World");
		string match = RegExMatchGroups("(\\d)?(.*)","4bcd",0);
		//Console.WriteLine(match);
	}

	
	
	public static string RegExMatchGroups(string pattern, string input, int Options)
	{
		
		if ((input == null  || pattern == null))
		{
			return String.Empty;
		}
		
		System.Text.RegularExpressions.RegexOptions RegexOption = new System.Text.RegularExpressions.RegexOptions();
		RegexOption = (RegexOptions)Enum.Parse(typeof (RegexOptions), Options.ToString());
		
		
		int i = 0;
		foreach (Group group in Regex.Match(input, pattern, RegexOption).Groups)
		{
			
			
			
			if (!(i==0))
			{
				Console.WriteLine(group.Value)	;
				
			}
			
			i++;
			
		}
		
		
		
		
		
		
		
		//Console.WriteLine(Regex.Match(input, pattern, RegexOption).Groups);
		
		
		
		return Regex.Match(input, pattern, RegexOption).Value;
	}
	
	
	/*
	public static SqlString RegExMatchGroups(SqlString pattern, SqlString input, SqlInt32 Options)
	{
		if ((input.IsNull || pattern.IsNull))
		{
			return String.Empty;
		}

		System.Text.RegularExpressions.RegexOptions RegexOption = new System.Text.RegularExpressions.RegexOptions();
		//RegexOption = (int)Options;
		RegexOption = (RegexOptions)Enum.Parse(typeof (RegexOptions), Options.ToString());
		return Regex.Match(input.Value, pattern.Value, RegexOption).Value;
	}
	*/
}