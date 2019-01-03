import { handleActions } from "redux-actions";
import { RootState } from "app/reducers/state";
import { SearchActions } from "app/actions/SearchActions";
import { SearchModel } from "models";

const initialSearchState: RootState.SearchState = { identifier: "", firstName: "", lastName: "", middleName: "", results: [] };

export const searchReducer = handleActions<RootState.SearchState, SearchModel>(
  {
    [SearchActions.Type.ADD_OVERWRITE_SEARCH]: (state, action) => {
      if (action.payload) {
        return action.payload;
      }
      return state;
    },
  },
  initialSearchState,
);
