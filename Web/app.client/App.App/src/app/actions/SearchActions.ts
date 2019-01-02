import { createAction } from "redux-actions";
import { SearchModel, SearchResultViewModel, SearchAggregationModel } from "models";

export namespace SearchActions {
  export enum Type {
    ADD_OVERWRITE_SEARCH = "ADD_OVERWRITE_SEARCH",
    ADD_OVERWRITE_SEARCH_RESULTS = "ADD_OVERWRITE_SEARCH_RESULTS",
    ADD_OVERWRITE_SEARCH_AGGREGATION = "ADD_OVERWRITE_SEARCH_AGGREGATION",
  }

  export const AddOverwriteSearch = createAction<SearchModel[]>(Type.ADD_OVERWRITE_SEARCH);
  export const AddOverwriteSearchResults = createAction<SearchResultViewModel[]>(Type.ADD_OVERWRITE_SEARCH_RESULTS);
  export const AddOverwriteSearchView = createAction<SearchAggregationModel[]>(Type.ADD_OVERWRITE_SEARCH_AGGREGATION);
}

export type SearchActions = Omit<typeof SearchActions, "Type">;
