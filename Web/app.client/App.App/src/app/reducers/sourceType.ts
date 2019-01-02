import { handleActions } from "redux-actions";
import { RootState } from "app/reducers/state";
import { SourceTypeActions } from "app/actions/SourceTypeActions";
import { SourceTypeModel } from "models";

const initialState: RootState.SourceTypeState = [];
export const sourceTypeReducer = handleActions<RootState.SourceTypeState, SourceTypeModel[]>(
  {
    [SourceTypeActions.Type.ADD_OVERWRITE_SOURCETYPE]: (state, action) => {
      if (action.payload) {
        return action.payload;
      }
      return state;
    },
  },
  initialState,
);
