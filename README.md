404 Error Checker (Visual Basic)
========================


A Visual Basic tool for checking a list of URL to find out which ones throw a 404 errror. 

*Warning: This project is not complete, and it is currently a work in progress. You can use the Stage 2 of this project in a reliable way for now while
I finish stage 3*

This program is related to:
https://github.com/LagrangianPoint/404-Error-Checker-Python



## Why use this tool?
This tools is ideal for checking the **404** error list that **Google Webmaster Tools** throws whenever these kind of errors arise for a website.

For **SEO** purposes, it is very bad to have lots of 404 erros exist in your site, and it also could irritate users. 

These errors may arrise as a result of a desing change of a website, website migration, or a small change in an htaccess file.

## Requirements
- Visual Studio 2012 Express
*I'm not sure if this will compile in older Visual Studio compilers.*

## Usage

**Compiling Project**

1. Double click *404 Checker stage 1.sln* so Visual Studio Express [or better] can open the project.
2. Compile the project to create a binary file.
3. Double click the generated binary file.

**Using the binary file**

1. Download the binary file
2. Double click to run it.

## Stages
### Stage 1 [completed]
The first step was to build a simple class for URL checking,  and a basic GUI was built for testing purposes.
This version only checks the status of a single url.

### Stage 2 [completed]
The next step is to improve the class create in the previous step, and allow it to work in a multithread/multiprocessor fashion. 

This version allows you to check hundreds (or thousands) of urls at the same time since you can use multiple threads.

You can also configure the maximum number of threads to use, so the URL checking can be faster depending on the targe server.

### Stage 3
Create a GUI that makes use of the class built in the second step, and make this application more usable to the end user.








