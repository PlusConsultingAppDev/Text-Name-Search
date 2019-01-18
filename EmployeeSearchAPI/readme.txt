README:

The solution is a 2 webapi and one angular app:

1. Uses SQL Server for storing the Employee Search configuration values.
There is a Migrations folder that needs to be run to setup the database and the table. 

2. The solution uses ElasticSearch to implement indexing and document search. There is an index that needs created, called "documentindex" that is being used to search for employees
- There is a separate tool that creates and populates the index with the test data. It is a NuGet package.

3. The solution uses Nest client for ElasticSearch to connect and issue queries to ElasticSearch.

3. The client solution is an angular client application that uses material design. It uses (they can be added with npm):
- Angular material
- Toastr notification component

4. The css and the components are minimal on purpose. 


Some possible enhancements

1. ElasticSearch: It is a goto solution for indexing a large number of documents and quickly quering them. It supports hundreds of millions of documents. 
Some alternatives to ElasticSearch that maybe viable:
 - Azure Search Service. The benefit is that you don't need to maintain the ElasticSearch environment, you pay for what you use and the speed should be comparable
 - SQL Server full text indexing. Again, you have to maintain and scale it.
 - Bing search. For searching web pages and if there is no need to store the documents (more for "spying" on your employees :)).
 
There is ISearchSearvice interface, that if implemented would allow connecting to other search engines. 

 
2. SQL Server for employee configurstion values. MongoDB can be used for that purpose as well. I did SQL Server, mainly out of habbit.

3. Caching of the data. ElasticSearch supports caching, so there was no need to implement it within the solution. But, it is something that should be thought of in use-cases like this one. 

4. CSS and overal look and feel. Can be improved.

5. Unit testing/integration testing. I did create unit tests for the API and the angular mainly for demo purposes. They need to be completed.

6. Autocomplete. Sometimes it adds value, but it was not required, so I left it un-implemented.

7. Docker: The solution can be run in docker environment as well. 