Project PRG2782
Baobab Ridge Wildlife Rehabilitation Records System
----------------------------------------------------------------------------------------------------------------------------
PRG282_S_PM_Group 7

**Members:**                        
Marissa Steyl (603839)            
Rudolph Petrus Gerber (604003)             
Corban John Williams (603900)                
Jaco Basson (603296)                   

----------------------------------------------------------------------------------------------------------------------------
**How are we going to build this record system?**
---------------------
The Wildlife Rehabilitations Record System is a Windows Forms application being developed in C# to aid animal admissions and storing organized records to the Boabab Ridge Center.

~Object-Oriented Programming (OOP).
This record system consist of various classes and objects that hold different features the program can perform and to store animal information. This is to maintain the records from the data source and operational actions.

~Layered Architecture.
To maintain a structured architecture the Wildlife Rehabilitation Record System application holds three files that store different logic. The first file is the Presentation layer, where all the form data and design is stored for easy access to the user interface operations and displays. The Business Layer or Logic Layer holds all the calculations and actions the program processes. This also includes validation. The Data Layer's function is mainly to interact with the data source and pull the data from the text files to be used in the application. All these layers work together to make the application work.

~File-Based Data Storage.
The text files are the data source that stores and provides the information to the main application through reading and writing streams. This allows a separation between the data and the user interface, for a disconnected connection. This is where the file can be opened and read from and be closed after usage.

~Windows Forms User Interface.
The User interface is a Windows forms C# application that allows the user to see the data and manipulate the data while not having access or seeing the data that is stored in a textfile.

~Data Validation and Error Handling.
Try catches, if statements and exception handling is just some of the validation methods we used in the Wildlife Rehabilitation Records System. This insures the system does not crash and handles errors or incorrect values by notifying the user through a exception message. This ensure the program is faultless in the way it proceeds when data is incorrect.

**Features:**
---------------------
~ *Add Animal Records*:                    
Register new animals by entering certain details and storing the inputted values in a formatted structure in the animal.txt. This is initiated after the input textboxes are filled and the save record button is clicked.

~ *View All Animal Records*:               
Display all the animal information from the animal.txt after reading the individual records, and viewing the details in a DataGridView of the user interface on the main form. This happens when the application is run.

~*Update Animal Records*:                
Animal informatiom can be modified from the user clicking a value in the display grid and then comparing old values to new values to ensure the changes is saved to the text file.

~*Delete Animal Records*:                 
Removes the selected row from the displayed data by clicking on a cell then matching the data to the selected row. The button delete will handle the rewrite of the data, without the selected animal to the same text file.

~*Generate Summary Report*:                
Calculate the average recovery time and animal ages, while also counting the amount of animals in the system to be displayed in a pop-up form with the values and layout of the data being saved to a summary text file.

~*File Handling and Error Management*:        
Appropriate messages inform the user of files not being found, empty fields or files and incorrect formation of data, to prevent the program from crashing. Try catches, among other validation methods is used to elegantly manage human error.


**Two File Formats:**
---------------------
~*animal.txt*                              
Organized animal information is stored in a text file for easy access to individual records. The file contain fields like
animalID, Name Species, Age, Recovery, Score, Status and Housing Unit associating the animal details. The application reads the data from the text file using StreamReader and performs operations of adding, updating and deleting animals through code.

~*summary.txt*                              
Summary data is extracted and calculated from the animal.txt and stored in a meaningful structure. This report includes the number of animals stored in the animal text file, the average age of the animals stored and average recovery score. Moreover the amount of stable, serious, critical, recovery and release animal patients are counted and displayed in this summary. The date and time is also displayed in the summary.txt. This text file is set up to override the previous information that was stored in the file when new information is added and the user wants to view a new summary report.

**Limitations:**
---------------------
~Dependance on file availability if the file is not yet created or locked.               
~Fixed Report Structure with little flexabillity to add data to this report             
~No built-in encryption for data protection on the file       
~Limited scalability with the increase in data rewritten to the file            
