# Meme Vault

Meme Vault is a demo opensource project DataTier.Net

DataTier.Net
https://github.com/DataJuggler/DataTier.Net
Create Stored Procedure Powered Data Tiers

Meme Vault is used to help categorize images with alternates. I frequently know I have an image but I can't
remember what I named it. Each image can be assigned alternates to help it show up in search.

# Requirements:

SQL Server or SQL Server Express
Visual Studio 2022 with Desktop development features (WinForms - WPF)

DataTier.NET has a release version, however if you prefer to to run the source code version
you must use Visul Studio 2019 as DataTier.NET references Visual Studio and it doesn't work in VS 2022.

# Quick Start:

# Clone Project

Clone the project using Visual Studio or Download a Zip file if you prefer

Meme Vault
https://github.com/DataJuggler/MemeVault

Or

Create a Folder and use the CLI

Example: Change to your folder

CD C:\Projects\GitHub\MemeVault
git clone https://github.com/DataJuggler/MemeVault.git

# Create Database

Create a database in SQL Server Management Studio named MemeVault

Execute the SQL Script located in the SQL Folder of this project.

Meme Vault Database.sql

Create a connectionstring to your database.

Example: Data Source=MyServer\SQLExpress;Initial Catalog=MemeVault;Integrated Security=True;Encrypt=False;

# Tip
DataTier.NET comes with a free tool located in the Tools folder called Connection Builder.
Connection Builder is installed with DataTier.NET and I think you will agree its worth the price
and leave a star please if you do.

Create a System level environment variable (Not a User level at the top) named 'MemeVaultConnString'
Set the value of your environment variable to the connectionstring to your database.

# Update NuGet Packages
It's always a good idea to update the project libraries just in case there are any fixes.

# Running the project
Start the app and select your root folder where you store memes or images.

Example: C:\Twitter

Click Save.

This will scan your Meme Folder and save all the .jpg's and .png's found in SQL Server in the Image table.
The Name and Path will be stored and a field 'Indexed' will be default to false.

# VCR Type Buttons
In Index Mode there are 4 buttons:

Move First - Move to the first image
Move Previous - Move to the index below the current image
Move Next - Move to the next index after the current image
Move Last - move to the last image

These should be enabled correctly based upon the current index
The method UIEnable handles setting the buttons if there are ever problems.

# Auto Index On Save
I keep this checkbox checked as it will set Indexed to true when you click Save.

Search Mode vs Index Mode

There are two modes for Meme Vault. Search Mode is where you search for images that have been indexed.
A custom stored procedure was written that scores the best match based on your search text.

You must index images before they show up in search. I may change this if I get the time.

Index Mode

The first time you click on Index mode each session, this will scan the directory of your Meme folder
and save any new images if found. 