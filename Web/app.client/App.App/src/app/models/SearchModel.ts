export interface SearchModel {
  identifier: string;
  firstName: string;
  lastName: string;
  middleName: string;
  results: ResultModel[];
}

type ResultModel = {
  identifier: string,
  articleIdentifier: string,
  searchIdentifier: string,
  searchText: string,
  occurrences: number,
}
