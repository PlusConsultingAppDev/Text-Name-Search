CREATE VIEW [search].[SearchResultsView]
AS 
SELECT 
    r.[Identifier] as ResultIdentifier,
	s.[FirstName],
	s.[LastName],
	s.[MiddleName],
	s.[Created] as SearchDate,
    r.[SearchIdentifier],
	r.[ArticleIdentifier],
	a.[Name] as ArticleName,
	r.[SearchText],
	r.[Occurrences], 
	r.[Created],
    r.[CreatedBy],
	r.[Modified],
    r.[ModifiedBy]
  FROM 
	[search].[results] r
  LEFT JOIN
	[search].[search] s
  ON
	s.Identifier = r.SearchIdentifier
  LEFT JOIN
    [search].[Articles] a
  ON
	a.Identifier = r.ArticleIdentifier;