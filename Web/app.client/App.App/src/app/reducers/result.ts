import { handleActions } from "redux-actions";
import { RootState } from "app/reducers/state";
import { ResultActions } from "app/actions/ResultActions";
import { ResultModel } from "models";

const initialState: RootState.ResultState = [];
export const resultReducer = handleActions<RootState.ResultState, ResultModel[]>(
  {
    [ResultActions.Type.ADD_OVERWRITE_RESULT]: (state, action) => {
      if (action.payload) {
        return action.payload;
      }
      return state;
    },
  },
  initialState,
);
