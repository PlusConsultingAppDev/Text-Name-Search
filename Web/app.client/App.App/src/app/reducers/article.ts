import { handleActions } from "redux-actions";
import { RootState } from "app/reducers/state";
import { ArticleActions } from "app/actions/ArticleActions";
import { ArticleModel } from "models";

const initialState: RootState.ArticleState = [];
export const articleReducer = handleActions<RootState.ArticleState, ArticleModel[]>(
  {
    [ArticleActions.Type.ADD_OVERWRITE_ARTICLE]: (state, action) => {
      if (action.payload) {
        return action.payload;
      }
      return state;
    },
  },
  initialState,
);
