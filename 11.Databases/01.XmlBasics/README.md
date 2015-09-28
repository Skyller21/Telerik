### XML Basics ###

1. What does the XML language represents? What does it used for?
	* XML means EXtensible Markup Language and is pretty much like HTML.  The data itself is self-described and self-defined. It is well formed and thus XML parser could easily read and understand it. Elements are the building blocks of the XML. They are enclosed by open and close tag.
	* It is designed to focuses on documents but it's widely used to store and transport data over the internet.


1. Create XML document students.xml, which contains structured description of students.
	* I have created the xml with c# code. You can safely delete the xml file and create it again after running the code.
	* There is no validation of the data in the classes, I know :)
	* There is no validation in the creation of the elements in the xml either. :)

1. What does the namespaces represents in the XML documents? What are they used for?
 * XML Namespaces enable the same document to contain XML elements and attributes taken from different vocabularies, without any naming collisions occurring. 
 * Although XML Namespaces are not part of the XML specification itself, virtually all XML software also supports XML Namespaces.

1. Explore [http://en.wikipedia.org/wiki/Uniform_Resource_Identifier](http://en.wikipedia.org/wiki/Uniform_Resource_Identifier) to learn more about URI, URN and URL definitions. 

	* scheme

                		hierarchical part
        		┌───────────────────┴─────────────────────┐
                    authority               path
        		┌───────────────┴───────────────┐┌───┴────┐
  				abc://username:password@example.com:123/path/data?key=value#fragid1
  				└┬┘   └───────┬───────┘ └────┬────┘ └┬┘           └───┬───┘ └──┬──┘
				scheme  user information     host     port            query   fragment

  				urn:example:mammal:monotreme:echidna
  				└┬┘ └──────────────┬───────────────┘
				scheme              path

1. Add default namespace for the students "urn:students".
	* done
1. Create XSD Schema for the students.xml document.
	* done
1. Add new elements in the schema: information for enrollment (date and exam score) and teacher's endorsements.
 	* done
1. Write a XSL stylesheet to visualize the students as HTML.
	* Use Mozilla (or IE :D ) for opening the xml file. 
	* Chrome has security restrictions for local files. 