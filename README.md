# Jecripe_Paralympic
This is a free code game project from UFABC's students and professor to introduce and disseminate the paralympic games in wide fashion. 

The documented comments always will be like:
  	
		/// <summary>
		/// Connects to the database and attempts to apply all adds, 
		/// updates and deletes
		/// </summary>
		/// <seealso cref="Adjuster.BusinessServices.Accident"/> 
		/// <param name="data">a dataset, passed by reference, 
		/// that contains all the 
		/// data for updating</param>
		/// <example> This sample shows how to call the SaveData 
		/// method from a wireless device.
		/// <code>
		/// 
		///AccidentCRUD accCRUD = new Adjuster.BusinessServices.AccidentCRUD();
		///accCRUD.SaveData(ref ds);
		///
		///</code>
		///</example>
		///<permission cref="System.Security.PermissionSet">Everyone 
		///can access this method.</Permission>
		public void SaveData(ref DataSet data)
		{
		}

		Tags:
		c - The c tag gives you a way to indicate that text within a description should be marked as code. Use code to indicate multiple lines as code.
		code* - The code tag gives you a way to indicate multiple lines as code. Use <c> to indicate that text within a description should be marked as code.
		example* - The example tag lets you specify an example of how to use a method or other library member. Commonly, this would involve use of the code tag.
		exception* - The exception tag lets you specify which exceptions a class can throw.
		include - The include tag lets you refer to comments in another file that describe the types and members in your source code. This is an alternative to placing documentation comments directly in your source code file.
		para - The para tag is for use inside a tag, such as <remarks> or <returns>, and lets you add structure to the text.
		param* - The param tag should be used in the comment for a method declaration to describe one of the parameters for the method.
		paramref - The paramref tag gives you a way to indicate that a word is a parameter. The XML file can be processed to format this parameter in some distinct way.
		permission* - The permission tag lets you document the access of a member. The System.Security.PermissionSet lets you specify access to a member.
		remarks* - The remarks tag is where you can specify overview information about a class or other type. <summary> is where you can describe the members of the type.
		returns - The returns tag should be used in the comment for a method declaration to describe the return value.
		see - The see tag lets you specify a link from within text. Use <seealso> to indicate text that you might want to appear in a See Also section.
		seealso* - The seealso tag lets you specify the text that you might want to appear in a See Also section. Use <see> to specify a link from within text.
		summary* - The summary tag should be used to describe a member for a type. Use <remarks> to supply information about the type itself.
		value* - The value tag lets you describe a property. Note that when you add a property via code wizard in the Visual Studio .NET development environment, it will add a <summary> tag for the new property. You should then manually add a <value> tag to describe the value that the property represents.
