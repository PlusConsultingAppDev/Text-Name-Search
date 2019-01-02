import { handleActions } from "redux-actions";
import { RootState } from "app/reducers/state";
import { SearchActions } from "app/actions/SearchActions";
import { SearchAggregationModel } from "models";

const initialSearchAggregationState: RootState.SearchAggregationState = [];

export const searchAggregationReducer = handleActions<RootState.SearchAggregationState, SearchAggregationModel[]>(
  {
    [SearchActions.Type.ADD_OVERWRITE_SEARCH_AGGREGATION]: (state, action) => {
      if (action.payload) {
        return action.payload;
      }
      return state;
    },
  },
  initialSearchAggregationState,
);
