# Plus Consulting Code Test: Name Search

## Submission
_**Fork this Repo, complete your code and submit a Pull Request to complete your submission. If needed, please supply a database backup and/or BACPAC.**_

For help learning Git, check out the Git tutorial here: https://try.github.io/levels/1/challenges/1

For instructions on how to submit a Pull Request from a Fork: https://help.github.com/articles/creating-a-pull-request-from-a-fork/

## Overview
For the purposes of this test, you have the option to leverage any database technology you feel comfortable using. You can use any .NET/Client-Side architecture(s) of your choice to complete the requirements outlined below.

## Configuration
If you do not have a copy of Visual Studio 2013+, you can download Visual Studio 2013 Community Edition here:
https://www.visualstudio.com/en-us/news/releasenotes/vs2013-community-vs
If you do not have a copy of SQL Server 2012+, you can download SQL Server 2012 Express here:
https://www.microsoft.com/en-us/download/details.aspx?id=29062
(Optionally) To hasten your progress, if you’re familiar with SQL server, the AdventureWorks2012 database can be obtained here: http://msftdbprodsamples.codeplex.com/releases/view/93587

## Requirements
An enterprise organization is looking to create an application used to find a preset list of names within the content of any given text value. The purpose of this application is to find employee names mentioned in news articles for a new employee engagement program. A team will be updating the list of names on a weekly basis. 

The application must find names of the following formats:
* [First Name] [Last Name]
* [First Name] [Middle Initial] [Last Name]
* [First Name] [Middle Initial]. [Last Name]
* [First Name] [Middle Name] [Last Name]

The output of the application needs to include the following:
* Name
* Number of Occurances


For the purposes of this test, use the following information when constructing your application:

**List of Names**
* Connor Gary Smith
* James Robert Brodrick
* Seth David Greenly
* David Warren Black

**Text Content**

