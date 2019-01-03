import {
  ResultModel,
  AuthenticationModel,
  ArticleModel,
  SourceTypeModel,
  SearchModel,
  SearchResultViewModel,
} from "models";

export interface RootState {
  resultData: RootState.ResultState;
  articleData: RootState.ArticleState;
  sourceTypeData: RootState.SourceTypeState;
  searchData: RootState.SearchState;
  searchViewData: RootState.SearchResultViewState;
  authenticationData: RootState.AuthenticationState;
  // tslint:disable-next-line:no-any
  router?: any;
}

export namespace RootState {
  export type ArticleState = ArticleModel[];
  export type ResultState = ResultModel[];
  export type SourceTypeState = SourceTypeModel[];
  export type SearchState = SearchModel;
  export type SearchResultViewState = SearchResultViewModel[];
  export type AuthenticationState = AuthenticationModel;
}
