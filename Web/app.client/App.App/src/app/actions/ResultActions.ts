import { createAction } from "redux-actions";
import { ResultModel } from "models";

export namespace ResultActions {
  export enum Type {
    ADD_OVERWRITE_RESULT = "ADD_OVERWRITE_RESULT",
  }

  export const AddOverwriteResults = createAction<ResultModel[]>(Type.ADD_OVERWRITE_RESULT);

}

export type ResultActions = Omit<typeof ResultActions, "Type">;
