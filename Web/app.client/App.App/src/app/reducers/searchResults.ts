import { handleActions } from "redux-actions";
import { RootState } from "app/reducers/state";
import { SearchActions } from "app/actions/SearchActions";
import { SearchResultViewModel } from "models";

const initialSearchResultState: RootState.SearchResultViewState = [];

export const searchResultsReducer = handleActions<RootState.SearchResultViewState, SearchResultViewModel[]>(
  {
    [SearchActions.Type.ADD_OVERWRITE_SEARCH_RESULTS]: (state, action) => {
      if (action.payload) {
        return action.payload;
      }
      return state;
    },
  },
  initialSearchResultState,
);
