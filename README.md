# Plus Consulting Code Test: Name Search

## Submission
_**Fork this Repo, complete your code and submit a Pull Request to complete your submission. If needed, please supply a database backup and/or BACPAC.**_

For help learning Git, check out the Git tutorial here: https://try.github.io/levels/1/challenges/1

For instructions on how to submit a Pull Request from a Fork: https://help.github.com/articles/creating-a-pull-request-from-a-fork/

## Overview
For the purposes of this test, you can use any .NET/Client-Side architecture(s) of your choice to complete the requirements outlined below.

## Configuration
If you do not have a copy of Visual Studio 2013+, you can download Visual Studio 2013 Community Edition here:
https://www.visualstudio.com/en-us/news/releasenotes/vs2013-community-vs

## Requirements
An enterprise organization is looking to create an application used to find a preset list of names within the content of any given text value. The purpose of this application is to find employee names mentioned in news articles for a new employee engagement program. A team will be updating the list of names on a weekly basis. 

The application must find names of the following formats, regardless of casing:
* [First Name] [Last Name]
* [First Name] [Middle Initial] [Last Name]
* [First Name] [Middle Initial]. [Last Name]
* [First Name] [Middle Name] [Last Name]

The output of the application needs to include the following:
* Name
* Number of Occurrences


For the purposes of this test, use the following information when constructing your application:

**List of Names**
* Connor Gary Smith (2)
* Seth David Greenly (2)
* David Warren Black (4)

**Text Content**
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas Connor Smith dignissim erat consequat, placerat erat in, lobortis nulla. Vestibulum scelerisque magna ut urna hendrerit, finibus rutrum dolor faucibus. Seth David Greenly Aliquam feugiat urna vel tellus congue, non dictum orci varius. Vivamus tristique, lorem ut hendrerit aliquet, nulla nisl eleifend quam, sed laoreet erat lorem non diam. Nulla facilisi. Etiam bibendum  Seth D. Greenly nec diam sed vestibulum. Nunc ipsum enim, imperdiet eu feugiat vel, vestibulum a justo. Donec efficitur velit porta odio consequat viverra. Quisque in tristique enim, sed euismod purus. Nullam eu leo pellentesque, porta leo in, maximus risus. Morbi in risus id risus feugiat egestas. David Black Nunc egestas, metus at volutpat tempus, massa justo venenatis arcu, a ornare mauris arcu at justo. Sed accumsan, David W. Black erat vitae euismod facilisis, risus odio bibendum neque, sit amet tincidunt diam ante et dolor. Morbi leo felis, posuere id ex ut, varius ornare libero.

Suspendisse lacus ipsum, molestie vel nulla id, commodo hendrerit est. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Maecenas finibus magna libero, vehicula David Black luctus lorem varius non. Integer ut tempor massa, eget sollicitudin purus. Mauris efficitur in ipsum eu consectetur. Aliquam vitae nulla vitae sapien laoreet vehicula et et ex. Donec molestie auctor lorem eget rhoncus. Donec ornare sapien in turpis auctor, ut commodo David Warren Black augue cursus. Pellentesque fermentum nunc turpis, eu vulputate Connor Smith leo aliquet eu. Nam quis pretium felis. Sed id turpis sed lacus malesuada pulvinar et eget leo. Vestibulum eget dapibus mi. Duis tempor nec tellus vitae aliquet. Nam sapien massa, ornare non posuere sit amet, cursus a velit. Curabitur nec consectetur metus. Donec porttitor at libero a blandit.

Proin luctus augue sit amet sem varius ultricies. Vestibulum nibh ligula, sollicitudin ac lectus eu, congue imperdiet quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla ac nisl sed risus tincidunt finibus. Curabitur viverra eget justo non dignissim. Proin varius malesuada enim non vulputate. Integer fermentum interdum felis, luctus commodo nisi pulvinar quis.

Donec pharetra faucibus urna a semper. Morbi tempor maximus Connor G Smith lectus sit amet interdum. Integer pretium ut est non vulputate. Aliquam pulvinar turpis laoreet dictum ultrices. Aenean diam metus, semper at quam et, iaculis viverra ante. Sed efficitur lorem quis consectetur mollis. Vivamus ut purus mauris. Quisque at gravida dolor. Fusce congue magna enim, ut placerat est porttitor a. Phasellus rutrum, neque lacinia cursus mattis, est lacus placerat nunc, a ornare enim nunc at justo. Sed urna leo, tincidunt elementum consequat vel, condimentum sed lacus.
