import { combineReducers, Reducer } from "redux";
import { RootState } from "app/reducers/state";
import { articleReducer } from "app/reducers/article";
import { resultReducer } from "app/reducers/result";
import { sourceTypeReducer } from "app/reducers/sourceType";
import { searchReducer } from "app/reducers/search";
import { searchResultsReducer } from "app/reducers/searchResults";
import { searchAggregationReducer } from "app/reducers/searchAggregation";
import { authenticationReducer } from "app/reducers/authentication";
import {
  AuthenticationModel,
  ArticleModel,
  ResultModel,
  SourceTypeModel,
  SearchModel,
  SearchResultViewModel,
  SearchAggregationModel,
} from "models";
export { RootState };

export const rootReducer = combineReducers<RootState>({
  /* tslint:disable */
  articleData: articleReducer as Reducer<ArticleModel[], any>,
  resultData: resultReducer as Reducer<ResultModel[], any>,
  sourceTypeData: sourceTypeReducer as Reducer<SourceTypeModel[], any>,
  searchData: searchReducer as Reducer<SearchModel[], any>,
  searchViewData: searchResultsReducer as Reducer<SearchResultViewModel[], any>,
  searchAggregateData: searchAggregationReducer as Reducer<SearchAggregationModel[], any>,
  authenticationData: authenticationReducer as Reducer<AuthenticationModel, any>
  /* tslint:enable */
});
