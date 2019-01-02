export interface SearchAggregationModel {
  searchDate: string;
  searchIdentifier: string;
  firstName: number;
  lastName: string;
  middleName: string;
  totalOccurrences: number;
  results: SearchResultModel[];
}

export interface SearchResultModel {
  articleIdentifier: string;
  articleName: string;
  data: SearchDataModel[];
}

export interface SearchDataModel {
  searchText: string;
  occurrences: number;
}
