# Text Name Search

By [Joshua Zinkovsky](mailto:joshua.zky@gmail.com)

## If Build Errors

If there are errors building the solution, please download this tested and working zip file: https://bit.ly/2Vye3xU

## Instructions

1. Navigate to [repo](https://github.com/Josh961/Text-Name-Search)
2. Clone locally using
   `git clone https://github.com/Josh961/Text-Name-Search.git`
3. Open `Text-Name-Search.sln`
4. Double click `Default.aspx` under directory `Text-Name-Search`
5. Click play in Visual Studio
6. Application should open in default browser
7. Enjoy!

## Discussion

I used the following technologies: HTML, Sass, JavaScript, and ASP.NET.
Vanilla Javascript was used to create the front end, employing the use 
of AJAX requests to communicate with the backend asynchronously. Server
side results displayed within update panel to inhibit a full page refresh.

## Requirements

#### Front End

Users must enter a first, middle, and last name in order to add a new employee. Users
are saved in a list where they can be deleted if need be. Once user initiates a search, a table
will be displayed with the results based on the current list of employees. Results are grouped by
stored names, displaying the different variations found and total number of occurences.

#### Back End

Back end finds names that match the given list of employees. Application ignores any casing.
Required variations are found, with the ability to add more in the future. 

#### Tests

Run tests within visual studio using shortcut `ctrl+r a`

# Plus Consulting Code Test: Name Search

## Submission
_**Fork this Repo, complete your code and submit a Pull Request to complete your submission.**_

## Overview
For the purposes of this test, you can use any .NET or Client-Side architecture(s) of your choice to complete the requirements outlined below.

## Requirements
An enterprise organization is looking to create an application used to find a preset list of names within the content of any given text value. The purpose of this application is to find employee names mentioned in news articles for a new employee engagement program. A team of will be updating the list of names on a weekly basis. The application should be designed to scale, the organization is targetting this application to crawl millions of documents a year.  The team is planning to update the variations of names they wish to find in the future, and eventually using it to search for more than only names. Your solution should be designed to accomodate the future use cases.

There must be a front end and it must:
* Allow the user to enter for a name, including first, middle, and last name
* A user must be required to input first, middle, and last name
* A user must be able to save the list of names they wish to have found
* A user must be able to have the ability to initiate a search
* After choosing to initiate a search, the user must be presented with:
  * Name variations found
  * Total number of occurrences for the searched name
  * The results must be grouped by stored names

Your application backend must accomodate the following:
* When a user searches for a First Name, Middle Name, and Last Name the application must find names that match
* The application must ignore casing
* When matching names, it must find names of the following variations: 
  * [First Name] [Last Name]
  * [First Name] [Middle Initial] [Last Name]
  * [First Name] [Middle Initial]. [Last Name]
  * [First Name] [Middle Name] [Last Name]


For the purposes of this test, use the following information when constructing your application:

**List of Names**
* Connor Gary Smith (3)
* Seth David Greenly (3)
* David Warren Black (4)

**Text Content**

Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas Connor Smith dignissim erat consequat, placerat erat in, lobortis nulla. Vestibulum scelerisque magna ut urna hendrerit, finibus rutrum dolor faucibus. Seth David Greenly Aliquam feugiat urna vel tellus congue, non dictum orci varius. Vivamus tristique, lorem ut hendrerit aliquet, nulla nisl eleifend quam, sed laoreet erat lorem non diam. Nulla facilisi. Etiam bibendum  Seth D. Greenly nec diam sed vestibulum. Nunc ipsum enim, imperdiet eu feugiat vel, vestibulum a justo. Donec efficitur velit porta odio consequat viverra. Quisque in tristique enim, sed euismod purus. Nullam eu leo pellentesque, porta leo in, Sarah Greenly maximus risus. Morbi in risus id risus feugiat egestas. David black Nunc egestas, metus at volutpat tempus, massa justo venenatis arcu, a ornare mauris arcu at justo. Sed accumsan, David W. black erat vitae euismod facilisis, risus odio bibendum neque, sit amet tincidunt diam ante et dolor. Morbi leo felis, posuere id ex ut, varius ornare libero.

Suspendisse lacus ipsum, molestie vel nulla id, commodo hendrerit est. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Maecenas finibus magna libero, vehicula David Black luctus lorem varius non. Integer ut tempor massa, eget sollicitudin purus. Mauris efficitur in ipsum eu consectetur. Aliquam vitae nulla vitae sapien laoreet vehicula et et ex. Donec molestie auctor lorem eget Seth rhoncus. Donec ornare sapien in turpis auctor, ut commodo David Warren Black augue cursus. Pellentesque fermentum nunc turpis, eu vulputate Connor Smith leo aliquet eu. Nam quis pretium felis. Sed id turpis sed lacus malesuada pulvinar et eget leo. Vestibulum eget dapibus mi. Duis tempor nec tellus vitae aliquet. Nam sapien massa, ornare non posuere sit amet, cursus a velit. Curabitur nec consectetur metus. Donec porttitor at libero a blandit.

Proin luctus augue sit amet sem varius ultricies. Vestibulum nibh ligula, sollicitudin ac lectus eu, congue imperdiet quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla ac nisl sed risus tincidunt finibus. Curabitur viverra eget justo non dignissim. Seth D Greenly Proin varius malesuada enim non vulputate. Integer fermentum interdum felis, luctus commodo nisi pulvinar quis.

Donec pharetra faucibus urna a semper. Morbi tempor maximus Connor G Smith lectus sit amet interdum. Integer pretium ut est non vulputate. Aliquam pulvinar turpis laoreet dictum ultrices. Aenean diam metus, David semper at quam et, iaculis viverra ante. Sed efficitur lorem quis consectetur mollis. Vivamus ut purus mauris. Quisque at gravida dolor. Fusce congue magna enim, ut placerat est porttitor a. Phasellus rutrum, neque lacinia Gary Grossman cursus mattis, est lacus placerat nunc, a ornare enim nunc at justo. Sed urna leo, tincidunt elementum consequat vel, condimentum sed lacus.
